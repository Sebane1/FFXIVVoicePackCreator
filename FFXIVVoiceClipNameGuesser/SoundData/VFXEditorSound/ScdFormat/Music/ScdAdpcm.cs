
using NAudio.Wave;
using System.IO;

namespace VfxEditor.ScdFormat {
    public class ScdAdpcm : ScdAudioData {
        public byte[] WaveHeader;
        public byte[] Data;
        public WaveFormat Format;

        public ScdAdpcm(BinaryReader reader, ScdAudioEntry entry) {
            WaveHeader = reader.ReadBytes(entry.FirstFrame - entry.AuxChunkData.Length);
            Data = reader.ReadBytes(entry.DataLength);

            using var ms = new MemoryStream(WaveHeader);
            using var br = new BinaryReader(ms);
            Format = WaveFormat.FromFormatChunk(br, WaveHeader.Length);
        }

        public override WaveStream GetStream() {
            var ms = new MemoryStream(Data, 0, Data.Length, false);
            return new RawSourceWaveStream(ms, Format);
        }

        public override void Write(BinaryWriter writer) {
            writer.Write(WaveHeader);
            writer.Write(Data);
        }

        public static void Import(string path, ScdAudioEntry entry) {
            var data = (ScdAdpcm)entry.Data;
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (var waveFile = new WaveFileReader(path)) {

                    var rawData = File.ReadAllBytes(path);
                    var waveFormat = waveFile.WaveFormat;

                    using var ms = new MemoryStream(rawData);
                    using var br = new BinaryReader(ms);
                    br.ReadInt32(); // RIFF
                    br.ReadInt32();
                    br.ReadInt32(); // WAVE
                    br.ReadInt32(); // fmt
                    var headerLength = br.ReadInt32();
                    data.WaveHeader = br.ReadBytes(headerLength);
                    //br.ReadInt32(); // data
                    char fourth = '.';
                    char third = '.';
                    char second = '.';
                    char first = '.';
                    while (true) {
                        fourth = third;
                        third = second;
                        second = first;
                        first = (char)br.ReadByte();
                        string value = fourth + "" + third + "" + second + "" + first;
                        if (value == "data") {
                            break;
                        }
                    }
                    var dataLength = br.ReadInt32();
                    data.Data = br.ReadBytes((int)ms.Length - (int)ms.Position);

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
