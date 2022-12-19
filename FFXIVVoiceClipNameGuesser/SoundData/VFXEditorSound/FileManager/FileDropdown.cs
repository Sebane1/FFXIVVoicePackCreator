

using System.Collections.Generic;
using VfxEditor.Utils;

namespace VfxEditor.FileManager {
    public abstract class FileDropdown<T> : FileManagerFile where T : class {
        protected T Selected = null;

        private readonly bool AllowNew;

        public FileDropdown( bool allowNew ) {
            AllowNew = allowNew;
        }

        public abstract List<T> GetItems();

        protected abstract string GetName( T item, int idx );

        public void ClearSelected() { Selected = null; }
    }
}
