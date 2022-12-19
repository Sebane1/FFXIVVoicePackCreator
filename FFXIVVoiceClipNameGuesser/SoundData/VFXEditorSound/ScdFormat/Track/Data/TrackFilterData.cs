using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat {
    public class TrackFilterData : ScdTrackData {
        public readonly ParsedEnum<FilterType> Type = new( "Type" );
        public readonly ParsedFloat Frequency = new( "Frequency" );
        public readonly ParsedFloat InvQ = new( "InvQ" );
        public readonly ParsedFloat Gain = new( "Gain" );

        public override void Read( BinaryReader reader ) {
            Type.Read( reader );
            Frequency.Read( reader );
            InvQ.Read( reader );
            Gain.Read( reader );
        }

        public override void Write( BinaryWriter writer ) {
            Type.Write( writer );
            Frequency.Write( writer );
            InvQ.Write( writer );
            Gain.Write( writer );
        }
    }
}
