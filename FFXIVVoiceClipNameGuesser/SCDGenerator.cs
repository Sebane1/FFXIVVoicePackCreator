using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public class SCDGenerator {
        public void ConvertAndGenerateSCD(string inputPath, string outputPath) {
            if (File.Exists(inputPath)) {
                SCDGenerator generator = new SCDGenerator();
                string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");
                Process.Start(Path.Combine(Application.StartupPath, "ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + tempPath + @""""}");
                while (IsFileLocked(tempPath)) { };
                using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, "header.bin"), FileMode.Open, FileAccess.Read)) {
                    using (FileStream inputStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read)) {
                        generator.GenerateSCD(header, inputStream, outputPath);
                    }
                }
                File.Delete(tempPath);
            }
        }
        protected virtual bool IsFileLocked(string file) {
            try {
                using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None)) {
                    stream.Close();
                }
            } catch (IOException) {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
        public void GenerateSCD(FileStream header, FileStream wavFile, string output) {
            using (FileStream outputFileStream = new FileStream(output, FileMode.Create)) {
                using (MemoryStream headerStream = new MemoryStream()) {
                    using (MemoryStream wavStream = new MemoryStream()) {
                        using (BinaryWriter headerWriter = new BinaryWriter(headerStream)) {
                            using (BinaryWriter waveWriter = new BinaryWriter(wavStream)) {
                                MemoryStream waveSpacing = new MemoryStream(new byte[44]);
                                // Load header into memory
                                header.Seek(0, SeekOrigin.Begin);
                                header.CopyTo(headerStream);

                                // Load wave file into memory
                                wavFile.Seek(0, SeekOrigin.Begin);
                                wavFile.CopyTo(wavStream);

                                // Skip 16 positions into the header
                                headerWriter.Seek(0, SeekOrigin.Begin);
                                headerWriter.Seek(16, SeekOrigin.Current);

                                // Write the audio length
                                headerWriter.Write((int)wavFile.Length);

                                // Skip 448 positions into the header
                                headerWriter.Seek(0, SeekOrigin.Begin);
                                headerWriter.Seek(448, SeekOrigin.Current);

                                // Write the audio file length
                                headerWriter.Write((int)wavFile.Length);

                                // Copy modified header to file
                                headerStream.Seek(0, SeekOrigin.Begin);
                                headerStream.CopyTo(outputFileStream);

                                // Forcibly rewrite the bits per sample to 256.. 
                                // This is a hack to get the audio to play in FFXIV at all, and not a fix for audio distortion.
                                waveWriter.Seek(0, SeekOrigin.Begin);
                                waveWriter.Seek(32, SeekOrigin.Current);
                                waveWriter.Write((short)256);

                                // Skip 20 positions into wave file and copy to file
                                wavStream.Seek(0, SeekOrigin.Begin);
                                wavStream.Seek(20, SeekOrigin.Current);
                                CopyStream(wavStream, outputFileStream, 50);
                                waveSpacing.CopyTo(outputFileStream);
                                wavStream.Seek(0, SeekOrigin.Begin);
                                wavStream.Seek(70, SeekOrigin.Current);
                                char fourth = '.';
                                char third = '.';
                                char second = '.';
                                char first = '.';
                                while (true) {
                                    fourth = third;
                                    third = second;
                                    second = first;
                                    first = (char)wavStream.ReadByte();
                                    string value = fourth + "" + third + "" + second + "" + first;
                                    if (value == "data") {
                                        break;
                                    }
                                }
                                wavStream.Seek(6, SeekOrigin.Current);
                                wavStream.CopyTo(outputFileStream);
                            }
                        }
                    }
                }
            }
        }
        public static void CopyStream(Stream input, Stream output, int bytes) {
            byte[] buffer = new byte[32768];
            int read;
            while (bytes > 0 &&
                   (read = input.Read(buffer, 0, Math.Min(buffer.Length, bytes))) > 0) {
                output.Write(buffer, 0, read);
                bytes -= read;
            }
        }
    }
}
