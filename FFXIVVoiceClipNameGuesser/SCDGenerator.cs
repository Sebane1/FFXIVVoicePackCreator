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
                                wavStream.CopyTo(outputFileStream);
                            }
                        }
                    }
                }
            }
        }
    }
}
