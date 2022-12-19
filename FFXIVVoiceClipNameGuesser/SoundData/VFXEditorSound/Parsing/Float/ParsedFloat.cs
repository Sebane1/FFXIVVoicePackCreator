
using System.IO;

namespace VfxEditor.Parsing {
    public class ParsedFloat : ParsedBase {
        public readonly string Name;
        public float Value = 0f;

        public ParsedFloat( string name, float defaultValue ) : this( name ) {
            Value = defaultValue;
        }

        public ParsedFloat( string name ) {
            Name = name;
        }

        public override void Read( BinaryReader reader ) => Read( reader, 0 );

        public override void Read( BinaryReader reader, int _ ) {
            Value = reader.ReadSingle();
        }

        public override void Write( BinaryWriter writer ) => writer.Write( Value );
    }
}
