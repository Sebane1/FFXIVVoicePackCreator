using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public class SCDFile {
        private List<int> soundOffsets = new List<int>();
        private List<int> trackOffsets = new List<int>();
        private List<int> audioOffsets = new List<int>();
        private List<int> layoutOffsets = new List<int>();
        private List<int> attributeOffsets = new List<int>();
        private List<Sound> audio = new List<Sound>();
        private List<SoundLayout> layouts = new List<SoundLayout>();

        public int Magic { get; private set; }
        public int SectionType { get; private set; }
        public int SedbVersion { get; private set; }
        public byte Endian { get; private set; }
        public byte AlignmentBits { get; private set; }
        public short HeaderSize { get; private set; } // always 0x30
        public int FileSize { get; private set; } // the ENTIRE file, including the header
        public byte[] UnkPadding { get; private set; }

        public short SoundCount { get; private set; }
        public short TrackCount { get; private set; }
        public short AudioCount { get; private set; }
        public short UnkOffset { get; private set; }
        public int TrackOffset { get; private set; }
        public int AudioOffset { get; private set; }
        public int LayoutOffset { get; private set; }
        public int RoutingOffset { get; private set; }
        public int AttributeOffset { get; private set; }
        public int EofPaddingSize { get; private set; }
        public long SoundOffset { get; private set; }

        public List<int> SoundOffsets => soundOffsets;

        public List<int> TrackOffsets => trackOffsets;

        public List<int> AudioOffsets => audioOffsets;

        public List<int> LayoutOffsets => layoutOffsets;

        public List<int> AttributeOffsets => attributeOffsets;

        public List<Sound> Audio { get => audio; set => audio = value; }
        public List<SoundLayout> Layouts { get => layouts; set => layouts = value; }

        public void WriteFile(BinaryWriter writer) {
            writer.Seek(0, SeekOrigin.Begin);
            writer.Write("SEDBSSCF");
            writer.Write((int)3);
            writer.Write((short)0x0400);
            writer.Write((short)0x30);
            writer.Write(FileSize); // placeholder
            writer.Write(UnkPadding);

            writer.Write(SoundCount);
            writer.Write(TrackCount);
            writer.Write(AudioCount);
            writer.Write(UnkOffset);
            writer.Write(TrackOffset);
            writer.Write(AudioOffset);
            writer.Write(LayoutOffset);
            writer.Write(RoutingOffset);
            writer.Write(AttributeOffset);
            writer.Write(EofPaddingSize);

            WriteOffsets(SoundOffsets, writer);
            WriteOffsets(TrackOffsets, writer);
            WriteOffsets(AudioOffsets, writer);
            WriteOffsets(LayoutOffsets, writer);
            WriteOffsets(AttributeOffsets, writer);
        }

        public void ReadFile(BinaryReader reader) {
            Magic = reader.ReadInt32();
            SectionType = reader.ReadInt32();
            SedbVersion = reader.ReadInt32();
            Endian = reader.ReadByte();
            AlignmentBits = reader.ReadByte();
            HeaderSize = reader.ReadInt16();
            FileSize = reader.ReadInt32();
            UnkPadding = reader.ReadBytes(28);

            SoundCount = reader.ReadInt16();
            TrackCount = reader.ReadInt16();
            AudioCount = reader.ReadInt16();
            UnkOffset = reader.ReadInt16();
            TrackOffset = reader.ReadInt32();
            AudioOffset = reader.ReadInt32();
            LayoutOffset = reader.ReadInt32();
            RoutingOffset = reader.ReadInt32();
            AttributeOffset = reader.ReadInt32();
            EofPaddingSize = reader.ReadInt32();

            SoundOffset = reader.BaseStream.Position;
            ReadOffsets(SoundOffsets, reader, SoundCount);
            ReadOffsets(TrackOffsets, reader, TrackCount);
            ReadOffsets(AudioOffsets, reader, AudioCount);

            if (LayoutOffset != 0) {
                ReadOffsets(LayoutOffsets, reader, SoundCount);
            }
            if (AttributeOffset != 0) {
                var attributeCount = (LayoutOffsets[0] - AttributeOffset) / 4;
                ReadOffsets(AttributeOffsets, reader, attributeCount);
            }

            foreach (var offset in AudioOffsets.Where(x => x != 0)) {
                var newAudio = new Sound();
                newAudio.Read(reader, offset);
                Audio.Add(newAudio);
            }
            foreach (var offset in LayoutOffsets.Where(x => x != 0)) {
                var newLayout = new SoundLayout();
                newLayout.Read(reader, offset);
                Layouts.Add(newLayout);
            }

            foreach (var offset in TrackOffsets.Where(x => x != 0)) {
                var newTrack = new ScdTrackEntry();
                newTrack.Read(reader, offset);
                Tracks.Add(newTrack);
            }

            foreach (var offset in AttributeOffsets.Where(x => x != 0)) {
                var newAttribute = new ScdAttributeEntry();
                newAttribute.Read(reader, offset);
                Attributes.Add(newAttribute);
            }

            foreach (var offset in SoundOffsets.Where(x => x != 0)) {
                var newSound = new ScdSoundEntry();
                newSound.Read(reader, offset);
                Sounds.Add(newSound);
            }

        }

        public static void ReadOffsets(List<int> offsets, BinaryReader reader, int count) {
            for (var i = 0; i < count; i++) {
                offsets.Add(reader.ReadInt32());
            }
            reader.BaseStream.Seek(16, SeekOrigin.Current);
        }

        public static void WriteOffsets(List<int> offsets, BinaryWriter writer) {
            foreach (var offset in offsets) {
                writer.Write(offset);
            }
            new MemoryStream(new byte[16]).CopyTo(writer.BaseStream);
        }
        private static void UpdateOffsets<T>(BinaryWriter writer, List<T> items, int offsetLocation, Action<BinaryWriter, T> action) where T : SoundEntry {
            List<int> positions = new List<int>();
            foreach (var item in items) {
                positions.Add((int)writer.BaseStream.Position);
                action.Invoke(writer, item);
            }
            var savePos = writer.BaseStream.Position;

            writer.BaseStream.Seek(offsetLocation, SeekOrigin.Begin);
            foreach (var position in positions) {
                writer.Write(position);
            }
            writer.BaseStream.Seek(savePos, SeekOrigin.Begin);
        }
    }
}
