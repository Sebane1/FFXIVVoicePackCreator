using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoiceClipNameGuesser {
    public class SCDGenerator {
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
                                int positionsMoved;
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
