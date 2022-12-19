using System;
using System.IO;
using VfxEditor.AvfxFormat;

namespace VfxEditor.Parsing {
    public class ParsedBool : ParsedBase {
        public readonly string Name;
        private int Size;
        public bool? Value = false;

        public ParsedBool( string name, bool defaultValue, int size = 4) : this( name, size ) {
            Value = defaultValue;
        }

        public ParsedBool( string name, int size = 4 ) {
            Name = name;
            Size = size;
        }

        public override void Read( BinaryReader reader ) => Read( reader, Size );

        public override void Read( BinaryReader reader, int size ) {
            var b = reader.ReadByte();
            Value = b switch {
                0x00 => false,
                0x01 => true,
                0xff => null,
                _ => null
            };
            Size = size;
        }

        public override void Write( BinaryWriter writer ) {
            byte v = Value switch {
                true => 0x01,
                false => 0x00,
                null => 0xff
            };
            writer.Write( v );
            AvfxBase.WritePad( writer, Size - 1 );
        }
    }
}
