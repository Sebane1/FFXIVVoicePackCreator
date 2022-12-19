using System;
using VfxEditor.Utils;

namespace VfxEditor.Parsing {
    public class ParsedSimpleEnum<T> : ParsedInt where T : Enum {
        private readonly T[] Options;

        public T GetValue() => ToEnum( Value );

        public ParsedSimpleEnum( string name, T[] options, int size = 4 ) : base( name, size ) {
            Options = options;
        }

        public ParsedSimpleEnum( string name, T[] options, int defaultValue, int size = 4 ) : base( name, defaultValue, size ) {
            Options = options;
        }

        private static T ToEnum( int value ) => ( T )(object)value;

        private static int ToInt( T value ) => ( int )(object)value;
    }
}
