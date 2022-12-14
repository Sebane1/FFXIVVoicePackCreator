
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VfxEditor.FileManager;
using VfxEditor.Utils;
using VfxEditor.TmbFormat.Entries;
using VfxEditor.TmbFormat.Utils;

// Rework based on https://github.com/AsgardXIV/XAT
namespace VfxEditor.TmbFormat {
    public class TmbFile : FileDropdown<Tmac> {
//        public readonly CommandManager Command;
        public readonly bool PapEmbedded;

        private readonly Tmdh HeaderTmdh;
        private readonly Tmpp HeaderTmpp;
        private readonly Tmal HeaderTmal;
        private readonly Tmfc FooterTmfc = null;

        private readonly List<Tmac> Actors = new();
        private readonly List<Tmtr> Tracks = new();
        private readonly List<TmbEntry> Entries = new();

        public TmbFile(BinaryReader binaryReader, bool papEmbedded, bool checkOriginal = true) : base(true) {

            var startPos = binaryReader.BaseStream.Position;
            var reader = new TmbReader(binaryReader);
            var original = checkOriginal ? FileUtils.GetOriginal(binaryReader) : null;

            reader.ReadInt32(); // TMLB
            var size = reader.ReadInt32();
            var numEntries = reader.ReadInt32(); // entry count (not including TMLB)

            HeaderTmdh = new Tmdh(reader, papEmbedded);
            HeaderTmpp = new Tmpp(reader, papEmbedded);
            HeaderTmal = new Tmal(reader, papEmbedded);

            for (var i = 0; i < numEntries - (HeaderTmpp.IsAssigned ? 3 : 2); i++) {
                reader.ParseItem(Actors, Tracks, Entries, ref FooterTmfc, papEmbedded, ref Verified);
            }

            HeaderTmal.PickActors(reader);
            Actors.ForEach(x => x.PickTracks(reader));
            Tracks.ForEach(x => x.PickEntries(reader));

            if (checkOriginal) Verified = FileUtils.CompareFiles(original, ToBytes(), out var _);

            binaryReader.BaseStream.Seek(startPos + size, SeekOrigin.Begin);
        }

        public override void Write(BinaryWriter writer) {
            var startPos = writer.BaseStream.Position;
            FileUtils.WriteString(writer, "TMLB");
            writer.Write(0); // placeholder for size

            short id = 2;
            foreach (var actor in Actors) actor.Id = id++;
            foreach (var track in Tracks) track.Id = id++;
            foreach (var entry in Entries) entry.Id = id++;

            var timelineCount = Actors.Count + Actors.Select(x => x.Tracks.Count).Sum() + Tracks.Select(x => x.Entries.Count).Sum();

            List<TmbItem> items = new() { HeaderTmdh };
            if (HeaderTmpp.IsAssigned) items.Add(HeaderTmpp);
            items.Add(HeaderTmal);
            items.AddRange(Actors);
            items.AddRange(Tracks);
            items.AddRange(Entries);

            var itemLength = items.Sum(x => x.Size);
            var extraLength = items.Sum(x => x.ExtraSize);
            var timelineLength = timelineCount * sizeof(short);
            var tmbWriter = new TmbWriter(itemLength, extraLength, timelineLength);

            writer.Write(items.Count);
            foreach (var item in items) {
                tmbWriter.StartPosition = tmbWriter.Writer.BaseStream.Position;
                item.Write(tmbWriter);
            }

            writer.Write(tmbWriter.WriterMs.ToArray());
            writer.Write(tmbWriter.ExtraMs.ToArray());
            writer.Write(tmbWriter.TimelineMs.ToArray());
            writer.Write(tmbWriter.StringMs.ToArray());
            tmbWriter.Dispose();

            // Fill in size placeholder
            var endPos = writer.BaseStream.Position;
            writer.BaseStream.Seek(startPos + 4, SeekOrigin.Begin);
            writer.Write((int)(endPos - startPos));
            writer.BaseStream.Seek(endPos, SeekOrigin.Begin);
        }

        public override List<Tmac> GetItems() => Actors;

        protected override string GetName(Tmac item, int idx) => $"Actor {idx}";

        public static TmbFile FromLocalFile(string path, bool papEmbedded) {
            if (!File.Exists(path)) return null;
            using BinaryReader br = new(File.Open(path, FileMode.Open));
            return new TmbFile(br, papEmbedded);
        }
    }
}
