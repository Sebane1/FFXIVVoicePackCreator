
using System;
using System.IO;
using VfxEditor.Utils;

namespace VfxEditor.Parsing {
    public class ParsedString : ParsedBase {
        public readonly string Name;
        public readonly uint MaxSize;
        public string Value = "";

        private bool Editing = false;
        private DateTime LastEditTime = DateTime.Now;
        private string StateBeforeEdit = "";

        public ParsedString( string name, string defaultValue, uint maxSize = 255 ) : this( name, maxSize ) {
            Value = defaultValue;
        }

        public ParsedString( string name, uint maxSize = 255 ) {
            Name = name;
            MaxSize = maxSize;
        }

        public override void Read( BinaryReader reader ) => Read( reader, 0 );

        public override void Read( BinaryReader reader, int size ) {
            Value = FileUtils.ReadString( reader );
        }

        public override void Write( BinaryWriter writer ) {
            FileUtils.WriteString( writer, Value, writeNull: true );
        }
    }
}
