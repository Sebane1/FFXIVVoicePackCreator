
using System;
using System.Collections.Generic;
using System.Linq;
using VfxEditor.Utils;
using VfxEditor.TmbFormat.Entries;
using VfxEditor.TmbFormat.Utils;
using VfxEditor.FileManager;
using VfxEditor.Parsing;

namespace VfxEditor.TmbFormat {
    public class Tmtr : TmbItemWithTime {
        public override string Magic => "TMTR";
        public override int Size => 0x18;
        public override int ExtraSize => !UseUnknownExtra ? 0 : 8 + ( 12 * UnknownData.Count );

        public readonly List<TmbEntry> Entries = new();
        private readonly List<int> TempIds;

        private bool UseUnknownExtra => UnknownExtraAssigned.Value == true;
        private readonly ParsedBool UnknownExtraAssigned = new( "Use Unknown Extra Data", defaultValue: false );
        private readonly List<TmtrUnknownData> UnknownData = new();

        public Tmtr( bool papEmbedded ) : base( papEmbedded ) { }

        public Tmtr( TmbReader reader, bool papEmbedded ) : base( reader, papEmbedded ) {
            ReadHeader( reader );
            TempIds = reader.ReadOffsetTimeline();
            reader.ReadAtOffset( ( binaryReader ) => {
                UnknownExtraAssigned.Value = true;

                binaryReader.ReadInt32(); // 8
                var count = binaryReader.ReadInt32();
                for( var i = 0; i < count; i++ ) UnknownData.Add( new TmtrUnknownData( binaryReader, papEmbedded ) );
            } );
        }

        public void PickEntries( TmbReader reader ) => Entries.AddRange( reader.Pick<TmbEntry>( TempIds ) );

        public override void Write( TmbWriter writer ) {
            WriteHeader( writer );
            writer.WriteOffsetTimeline( Entries );
            if ( !UseUnknownExtra ) writer.Write( 0 );
            else {
                writer.WriteExtra( ( binaryWriter ) => {
                    binaryWriter.Write( 8 );
                    binaryWriter.Write( UnknownData.Count );
                    UnknownData.ForEach( x => x.Write( binaryWriter ) );
                } );
            }
        }
    }
}
