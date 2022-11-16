using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoiceClipNameGuesser {
    public partial class FilePicker : UserControl {
        public FilePicker() {
            InitializeComponent();
        }

        int index = 0;
        bool isSaveMode = false;

        [Category("Select Type"), Description("Changes what type of selection is made")]
        public bool IsSaveMode { get => isSaveMode; set => isSaveMode = value; }

        [Category("Filter"), Description("Changes what type of selection is made")]
        public string Filter { get => filter; set => filter = value; }

        string filter;
        private void filePicker_Load(object sender, EventArgs e) {
            labelName.Text = (index == -1 ? Name : ($"({index})  " + Name));
        }

        private void openButton_Click(object sender, EventArgs e) {
            if (!isSaveMode) {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath.Text = openFileDialog.FileName;
                }
            } else {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = filter;
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath.Text = saveFileDialog.FileName;
                }
            }
        }
    }
}
