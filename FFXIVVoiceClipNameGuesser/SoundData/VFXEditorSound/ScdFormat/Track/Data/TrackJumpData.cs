using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VfxEditor.Parsing;

namespace VfxEditor.ScdFormat {
    public enum TrackCmdJump {
        LZE = 0x1,
        LNZ,
    }

    public class TrackJumpData : ScdTrackData {
        public readonly ParsedEnum<TrackCmdJump> Condition = new( "Condition" );
        public readonly ParsedInt Offset = new( "Offset" );

        public override void Read( BinaryReader reader ) {
            Condition.Read( reader );
            Offset.Read( reader );
        }

        public override void Write( BinaryWriter writer ) {
            Condition.Write( writer );
            Offset.Write( writer );
        }
    }
}
