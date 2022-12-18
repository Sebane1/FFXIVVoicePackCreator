using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public class Sound : SoundEntry{
        public int DataLength;
        public int NumChannels;
        public int SampleRate;
        public SscfWaveFormat Format;
        public int LoopStart;
        public int LoopEnd;
        public int FirstFrame;
        public short AuxCount;
        public short BitsPerSample;

        public byte[] AuxChunkData;
        public AudioData Data { get; set; }

        public override void Read(BinaryReader reader) {
            // Datalength = 0, 0x20
            DataLength = reader.ReadInt32();
            NumChannels = reader.ReadInt32();
            SampleRate = reader.ReadInt32();
            Format = (SscfWaveFormat)reader.ReadInt32();
            LoopStart = reader.ReadInt32();
            LoopEnd = reader.ReadInt32();
            FirstFrame = reader.ReadInt32();
            AuxCount = reader.ReadInt16();
            BitsPerSample = reader.ReadInt16(); // padding

            if (DataLength == 0) {
                AuxChunkData = Array.Empty<byte>();
                return;
            }

            var chunkStartPos = reader.BaseStream.Position;
            var chunkEndPos = chunkStartPos;
            for (var i = 0; i < AuxCount; i++) {
                reader.ReadInt32(); // id
                chunkEndPos += reader.ReadInt32(); // data, skip for now
                reader.BaseStream.Seek(chunkEndPos, SeekOrigin.Begin);
            }
            AuxChunkData = GetDataRange(chunkStartPos, chunkEndPos, reader);

            switch (Format) {
                case SscfWaveFormat.MsAdPcm:
                    Data = new MSAdpcm(reader, this);
                    break;
                case SscfWaveFormat.Vorbis:
                    Data = new Vorbis(reader, this);
                    break;
            }
        }

        public override void Write(BinaryWriter writer) {
            writer.Write(DataLength);
            writer.Write(NumChannels);
            writer.Write(SampleRate);
            writer.Write((int)Format);
            writer.Write(LoopStart);
            writer.Write(LoopEnd);
            writer.Write(FirstFrame);
            writer.Write(AuxCount);
            writer.Write(BitsPerSample);

            writer.Write(AuxChunkData);
            Data?.Write(writer);

            new MemoryStream(new byte[16]).CopyTo(writer.BaseStream);
            //padding = 16;
        }

        public static byte[] GetDataRange(long start, long end, BinaryReader reader) {
            var savePos = reader.BaseStream.Position;
            reader.BaseStream.Seek(start, SeekOrigin.Begin);
            var valueToReturn = reader.ReadBytes((int)(end - start));
            reader.BaseStream.Seek(savePos, SeekOrigin.Begin);
            return valueToReturn;
        }
    }
}
public enum SscfWaveFormat : int {
    Empty = -1,
    Pcm = 0x01,
    Atrac3 = 0x05,
    Vorbis = 0x06,
    Xma = 0x0B,
    MsAdPcm = 0x0C,
    Atrac3Too = 0x0D
}