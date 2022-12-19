
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace VfxEditor.ScdFormat {
    public class ScdSimpleSplitView<T> where T : class, IScdSimpleUiBase {
        private readonly List<T> Items;
        private T Selected = null;
        private readonly string ItemName;

        public ScdSimpleSplitView(string itemName, List<T> items) {
            Items = items;
            ItemName = itemName;
        }
    }
}
