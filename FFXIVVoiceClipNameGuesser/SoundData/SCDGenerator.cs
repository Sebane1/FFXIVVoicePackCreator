using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public class SCDGenerator {
        public void ConvertAndGenerateMSADCPM(string inputPath, string outputPath) {
            if (File.Exists(inputPath)) {
                SCDGenerator generator = new SCDGenerator();
                string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");
                Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -f wav -acodec adpcm_ms -block_size 256 -ar: 44100 -ac 1 {@"""" + tempPath + @""""}");
                while (IsFileLocked(tempPath)) { };
                using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, @"res\MSADPCM.bin"), FileMode.Open, FileAccess.Read)) {
                    using (FileStream inputStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read)) {
                        generator.GenerateMSADPCM(header, inputStream, outputPath);
                    }
                }
                File.Delete(tempPath);
            }
        }
        public void ConvertAndGenerateOGG(string inputPath, string outputPath, int positionStart, int positionEnd, int numSamples) {
            if (File.Exists(inputPath)) {
                SCDGenerator generator = new SCDGenerator();
                string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".ogg");
                Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -c:a libvorbis -ar: 44100 {@"""" + tempPath + @""""}");
                while (IsFileLocked(tempPath)) { };
                using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, @"res\OGG.bin"), FileMode.Open, FileAccess.Read)) {
                    using (FileStream inputStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read)) {
                        generator.GenerateOGG(header, inputStream, positionStart, positionStart, positionStart, outputPath);
                    }
                }
                File.Delete(tempPath);
            }
        }

        public void ConvertAndGenerateOrchestrion(string inputPath, string outputPath, int positionStart, int positionEnd, int numSamples) {
            if (File.Exists(inputPath)) {
                SCDGenerator generator = new SCDGenerator();
                string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".ogg");
                Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -c:a libvorbis -ar: 44100 -ac 1 {@"""" + tempPath + @""""}");
                while (IsFileLocked(tempPath)) { };
                using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, @"res\ORCHESTRION.bin"), FileMode.Open, FileAccess.Read)) {
                    using (FileStream inputStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read)) {
                        generator.GenerateOrchestrion(header, inputStream, positionStart, positionStart, positionStart, outputPath);
                    }
                }
                File.Delete(tempPath);
            }
        }

        public static bool IsFileLocked(string file) {
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


        public Stream SCDHeader(FileStream header, int audiolength, short soundCount, short audioCount, short entries, int trackOffset, int audioOffset,int layoutOffset,int routingOffset, int attributreOffset, int eofPaddingSize) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                using (BinaryWriter writer = new BinaryWriter(memoryStream)) {
                    MemoryStream padding = new MemoryStream(new byte[28]);
                    header.CopyTo(memoryStream);

                    //SCD Header
                    writer.Seek(0, SeekOrigin.Begin);
                    writer.Write("SEDBSSCF");
                    writer.Write((int)3);
                    writer.Write((short)0x0400);
                    writer.Write((short)0x30);
                    writer.Write(audiolength);
                    padding.CopyTo(memoryStream);

                    // Offset Header
                    writer.Write((short)soundCount); // Size?
                    writer.Write((short)entries); // Entry Count?
                    writer.Write((short)audioCount); // Table 2 Offset?
                    writer.Write((short)0x0001); // Unknown?
                    writer.Write((int)trackOffset); // Offset Table 0 Offset?
                    writer.Write((int)audioOffset); // Sound Entry Offset Table Offset?
                    writer.Write((int)layoutOffset); //  Offset to Offset Table 2?
                    writer.Write((int)routingOffset); //   Unknown/Null?
                    writer.Write((int)attributreOffset); //  Offset To ???
                    writer.Write((int)eofPaddingSize); //  Offset To ???
                    return memoryStream;
                }
            }
        }

        public void GenerateMSADPCM(FileStream header, FileStream wavFile, string output) {
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
                                headerWriter.Seek(16, SeekOrigin.Begin);

                                // Write the audio length
                                headerWriter.Write((int)wavFile.Length);

                                // Skip 448 positions into the header
                                headerWriter.Seek(448, SeekOrigin.Begin);

                                // Write the audio file length
                                headerWriter.Write((int)wavFile.Length);

                                // Copy modified header to file
                                headerStream.Seek(0, SeekOrigin.Begin);
                                headerStream.CopyTo(outputFileStream);

                                // Forcibly rewrite the bits per sample to 256.. 
                                // This is a hack to get the audio to play in FFXIV at all, and not a fix for audio distortion.
                                waveWriter.Seek(32, SeekOrigin.Begin);
                                waveWriter.Write((short)256);

                                // Skip 20 positions into wave file and copy to file
                                wavStream.Seek(20, SeekOrigin.Begin);
                                CopyStream(wavStream, outputFileStream, 50);
                                waveSpacing.CopyTo(outputFileStream);
                                wavStream.Seek(70, SeekOrigin.Begin);
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

        //-------------------------------------------------------------------------------------------------------------------------------------------
        // Code following this line is altered, or heavily inspired from FFXIV Explorer
        private byte[] CreateSCDHeader(FileStream header, int oggLength, float volume, int numChannels, int sampleRate, int loopStart, int loopEnd) {
            using (MemoryStream oggHeader = new MemoryStream()) {
                using (BinaryWriter writer = new BinaryWriter(oggHeader)) {
                    header.CopyTo(oggHeader);
                    //Edit the parts needed
                    writer.BaseStream.Position = 0x10;
                    writer.Write((int)(oggHeader.Length + oggLength));
                    writer.BaseStream.Position = 0x1B0;
                    writer.Write((int)(oggLength - 0x10));

                    writer.BaseStream.Position = 0xA8;
                    writer.Write((float)volume);
                    writer.BaseStream.Position = 0x1B4;
                    writer.Write((int)numChannels);
                    writer.BaseStream.Position = 0x1B8;
                    writer.Write((int)sampleRate);
                    writer.BaseStream.Position = 0x1C0;
                    writer.Write((int)loopStart);
                    writer.BaseStream.Position = 0x1C4;
                    writer.Write((int)loopEnd);
                    return oggHeader.ToArray();
                }
            }
        }

        private void GenerateOGG(FileStream header, FileStream oggFile, int positionStart, int positionEnd, int numSamples, string output) {
            float volume = 1.0f;
            int numChannels = 2;
            int sampleRate = 44100;
            int loopStart = 0;
            int loopEnd = (int)oggFile.Length;

            loopStart = GetBytePosition(positionStart, numSamples, (int)oggFile.Length - 0x10);
            loopEnd = GetBytePosition(positionEnd, numSamples, (int)oggFile.Length - 0x10);
            //Create Header
            using (MemoryStream genereatedHeader = new MemoryStream(CreateSCDHeader(header, (int)oggFile.Length, volume, numChannels, sampleRate, loopStart, loopEnd))) {
                using (FileStream outputFileStream = new FileStream(output, FileMode.Create)) {
                    //Write out scd
                    genereatedHeader.CopyTo(outputFileStream);
                    oggFile.CopyTo(outputFileStream);
                }
            }
        }


        private int GetBytePosition(float samplePosition, float numSamples, float filesize) {
            return (int)((filesize / numSamples) * samplePosition);
        }

        // End of FFXIV Explorer algorithms --------------------------------------------------------------------------------------------------------
        private void GenerateOrchestrion(FileStream header, FileStream oggFile, int positionStart, int positionEnd, int numSamples, string output) {
            float volume = 1.0f;
            int numChannels = 2;
            int sampleRate = 44100;
            int loopStart = 0;
            int loopEnd = (int)oggFile.Length;

            loopStart = GetBytePosition(positionStart, numSamples, (int)oggFile.Length - 0x10);
            loopEnd = GetBytePosition(positionEnd, numSamples, (int)oggFile.Length - 0x10);
            //Create Header
            using (MemoryStream generatedHeader = new MemoryStream(CreateSCDHeader(header, (int)oggFile.Length, volume, numChannels, sampleRate, loopStart, loopEnd))) {
                using (FileStream outputFileStream = new FileStream(output, FileMode.Create)) {
                    //Write out scd
                    generatedHeader.CopyTo(outputFileStream);
                    oggFile.Seek(0, SeekOrigin.Begin);
                    oggFile.Seek(0x28, SeekOrigin.Current);
                    oggFile.CopyTo(outputFileStream);
                }
            }
        }
    }
}
