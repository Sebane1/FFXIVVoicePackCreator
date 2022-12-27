

using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VfxEditor.FileManager;
using VfxEditor.Utils;

namespace VfxEditor.ScdFormat {
    public class ScdFile : FileManagerFile {

        private readonly ScdHeader Header;
        private readonly ScdOffsetsHeader OffsetsHeader;

        public List<ScdAudioEntry> Audio = new();
        public List<ScdLayoutEntry> Layouts = new();
        public List<ScdSoundEntry> Sounds = new();
        public List<ScdTrackEntry> Tracks = new();
        public List<ScdAttributeEntry> Attributes = new();

        public ScdSimpleSplitView<ScdSoundEntry> SoundView;
        public ScdSimpleSplitView<ScdLayoutEntry> LayoutView;
        public ScdSimpleSplitView<ScdTrackEntry> TrackView;
        public ScdSimpleSplitView<ScdAttributeEntry> AttributeView;

        public ScdFile(BinaryReader reader, bool checkOriginal = true, bool skipAttributeData = false) {
            var original = checkOriginal ? FileUtils.GetOriginal(reader) : null;

            Header = new(reader);
            OffsetsHeader = new(reader);

            // The acutal sound effect/music data
            foreach (var offset in OffsetsHeader.AudioOffsets.Where(x => x != 0)) {
                var newAudio = new ScdAudioEntry();
                newAudio.Read(reader, offset);
                Audio.Add(newAudio);
            }
            if (!skipAttributeData) {
                foreach (var offset in OffsetsHeader.LayoutOffsets.Where(x => x != 0)) {
                    var newLayout = new ScdLayoutEntry();
                    newLayout.Read(reader, offset);
                    Layouts.Add(newLayout);
                }

                foreach (var offset in OffsetsHeader.TrackOffsets.Where(x => x != 0)) {
                    var newTrack = new ScdTrackEntry();
                    newTrack.Read(reader, offset);
                    Tracks.Add(newTrack);
                }

                foreach (var offset in OffsetsHeader.AttributeOffsets.Where(x => x != 0)) {
                    var newAttribute = new ScdAttributeEntry();
                    newAttribute.Read(reader, offset);
                    Attributes.Add(newAttribute);
                }

                foreach (var offset in OffsetsHeader.SoundOffsets.Where(x => x != 0)) {
                    var newSound = new ScdSoundEntry();
                    newSound.Read(reader, offset);
                    Sounds.Add(newSound);
                }

                if (checkOriginal) Verified = FileUtils.CompareFiles(original, ToBytes(), out var _);
            }
            LayoutView = new("Layout", Layouts);
            SoundView = new("Sound", Sounds);
            TrackView = new("Track", Tracks);
            AttributeView = new("Attribute", Attributes);
        }

        public override void Write(BinaryWriter writer) {
            Header.Write(writer);
            OffsetsHeader.Write(writer);

            UpdateOffsets(writer, Layouts, OffsetsHeader.LayoutOffset, (BinaryWriter bw, ScdLayoutEntry item) => {
                item.Write(writer);
            });
            FileUtils.PadTo(writer, 16);

            UpdateOffsets(writer, Sounds, (int)OffsetsHeader.SoundOffset, (BinaryWriter bw, ScdSoundEntry item) => {
                item.Write(writer);
            });
            FileUtils.PadTo(writer, 16);

            UpdateOffsets(writer, Tracks, OffsetsHeader.TrackOffset, (BinaryWriter bw, ScdTrackEntry item) => {
                item.Write(writer);
            });
            FileUtils.PadTo(writer, 16);

            UpdateOffsets(writer, Attributes, OffsetsHeader.AttributeOffset, (BinaryWriter bw, ScdAttributeEntry item) => {
                item.Write(writer);
            });
            FileUtils.PadTo(writer, 16);

            // Sounds
            long paddingSubtract = 0;
            UpdateOffsets(writer, Audio, OffsetsHeader.AudioOffset, (BinaryWriter bw, ScdAudioEntry music) => {
                music.Write(writer, out var padding);
                paddingSubtract += padding;
            });
            if ((paddingSubtract % 16) > 0) paddingSubtract -= paddingSubtract % 16;

            ScdHeader.UpdateFileSize(writer, paddingSubtract); // end with this
        }

        public void Replace(ScdAudioEntry old, ScdAudioEntry newEntry) {
            var index = Audio.IndexOf(old);
            if (index == -1) return;
            Audio.Remove(old);
            Audio.Insert(index, newEntry);
        }

        public void Import(string path, ScdAudioEntry music, int loopStart = 0, int loopEnd = 0) {
            if (music.Format == SscfWaveFormat.Vorbis) {
                ScdVorbis.ImportOgg(path, music, loopStart, loopEnd, this);
            } else {
                ScdAdpcm.Import(path, music);
            }
        }

        private static void UpdateOffsets<T>(BinaryWriter writer, List<T> items, int offsetLocation, Action<BinaryWriter, T> action) where T : ScdEntry {
            List<int> positions = new();
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
