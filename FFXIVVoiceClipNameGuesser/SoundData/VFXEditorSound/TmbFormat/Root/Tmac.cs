

using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using VfxEditor.Utils;
using VfxEditor.TmbFormat.Entries;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.Parsing;
using VfxEditor.FileManager;

namespace VfxEditor.TmbFormat {
    public class Tmac : TmbItemWithTime {
        public override string Magic => "TMAC";
        public override int Size => 0x1C;
        public override int ExtraSize => 0;

        private readonly ParsedInt Unk1 = new( "Unknown 1" );
        private readonly ParsedInt Unk2 = new( "Unknown 2" );

        public readonly List<Tmtr> Tracks = new();
        private Tmtr SelectedTrack = null;

        private readonly List<int> TempIds;

        public Tmac( bool papEmbedded ) : base( papEmbedded ) { }

        public Tmac( TmbReader reader, bool papEmbedded ) : base( reader, papEmbedded ) {
            ReadHeader( reader );
            Unk1.Read( reader );
            Unk2.Read( reader );
            TempIds = reader.ReadOffsetTimeline();
        }

        public void PickTracks( TmbReader reader ) {
            Tracks.AddRange( reader.Pick<Tmtr>( TempIds ) );
        }

        public override void Write( TmbWriter writer ) {
            WriteHeader( writer );
            Unk1.Write( writer );
            Unk2.Write( writer );
            writer.WriteOffsetTimeline( Tracks );
        }
    }
}
