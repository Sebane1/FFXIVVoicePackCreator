using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public class MSAdpcm : AudioData {
        public byte[] WaveHeader;
        public byte[] Data;
        public WaveFormat Format;

        public MSAdpcm(BinaryReader reader, Sound entry) {
            WaveHeader = reader.ReadBytes(entry.FirstFrame - entry.AuxChunkData.Length);
            Data = reader.ReadBytes(entry.DataLength);

            using (MemoryStream memoryStream = new MemoryStream(WaveHeader)) {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream)) {
                    Format = WaveFormat.FromFormatChunk(binaryReader, WaveHeader.Length);
                }
            }
        }
        public override WaveStream GetStream() {
            MemoryStream memoryStream = new MemoryStream(Data, 0, Data.Length, false);
            return new RawSourceWaveStream(memoryStream, Format);
        }

        public override void Write(BinaryWriter writer) {
            writer.Write(WaveHeader);
            writer.Write(Data);
        }

        public static void Import(string inputPath, Sound entry) {
            WaveFileReader waveFileCheck = new WaveFileReader(inputPath);
            string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");

            if (waveFileCheck.WaveFormat.Encoding == WaveFormatEncoding.Adpcm) {
                File.Copy(inputPath, tempPath, true);
            }
            waveFileCheck.Close();

            Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + tempPath + @""""}");
            while (SCDGenerator.IsFileLocked(tempPath)) { };

            var data = (MSAdpcm)entry.Data;
            using (WaveFileReader waveFile = new WaveFileReader(tempPath)) {

                byte[] rawData = File.ReadAllBytes(tempPath);
                WaveFormat waveFormat = waveFile.WaveFormat;

                using (MemoryStream ms = new MemoryStream(rawData)) {
                    using (BinaryReader binaryReader = new BinaryReader(ms)) {
                        binaryReader.ReadInt32(); // RIFF
                        binaryReader.ReadInt32();
                        binaryReader.ReadInt32(); // WAVE
                        binaryReader.ReadInt32(); // fmt
                        var headerLength = binaryReader.ReadInt32();
                        data.WaveHeader = binaryReader.ReadBytes(headerLength);
                        binaryReader.ReadInt32(); // data
                        var dataLength = binaryReader.ReadInt32();
                        data.Data = binaryReader.ReadBytes(dataLength);

                        data.Format = waveFormat;
                        entry.DataLength = dataLength;
                        entry.FirstFrame = headerLength + entry.AuxChunkData.Length;
                        entry.SampleRate = waveFormat.SampleRate;
                        entry.NumChannels = waveFormat.Channels;
                        entry.BitsPerSample = (short)waveFormat.BitsPerSample;
                    }
                }
            }
        }
    }
}
