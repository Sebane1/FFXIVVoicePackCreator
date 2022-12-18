using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
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
        private Point startPos;
        private bool canDoDragDrop;
        private bool ignoreClear;

        private void filePicker_Load(object sender, EventArgs e) {
            labelName.Text = (index == -1 ? Name : ($"({index})  " + Name));
        }
        private void filePicker_MouseDown(object sender, MouseEventArgs e) {
            if (!useGameFileCheckBox.Checked) {
                startPos = e.Location;
                canDoDragDrop = true;
            }
        }

        private void filePicker_MouseMove(object sender, MouseEventArgs e) {
            if ((e.X != startPos.X || startPos.Y != e.Y) && canDoDragDrop) {
                this.ParentForm.TopMost = true;
                List<string> fileList = new List<string>();
                if (!string.IsNullOrEmpty(filePath.Text)) {
                    fileList.Add(filePath.Text);
                }
                if (fileList.Count > 0) {
                    DataObject fileDragData = new DataObject(DataFormats.FileDrop, fileList.ToArray());
                    DoDragDrop(fileDragData, DragDropEffects.Copy);
                }
                canDoDragDrop = false;
                this.ParentForm.BringToFront();
            }
            this.ParentForm.TopMost = false;
        }
        private void openButton_Click(object sender, EventArgs e) {
            if (!useGameFileCheckBox.Checked) {
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
            } else {
                VoiceSelection voiceSelection = new VoiceSelection();
                if (voiceSelection.ShowDialog() == DialogResult.OK) {
                    filePath.Text = "sound/voice/vo_emote/" + (voiceSelection.SelectedVoice + index) + ".scd";
                }
            }
        }

        public void SetToGameFile(int voiceSelection) {
            ignoreClear = true;
            useGameFileCheckBox.Checked = true;
            filePath.Text = "sound/voice/vo_emote/" + (voiceSelection + index) + ".scd";
            ignoreClear = false;
        }
        public void SetFilePath(string path) {
            ignoreClear = true;
            useGameFileCheckBox.Checked = false;
            filePath.Text = path;
            ignoreClear = false;
        }
        private void useGameFileCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (!ignoreClear) {
                FilePath.Text = "";
                switch (useGameFileCheckBox.Checked) {
                    case true:
                        MessageBox.Show("This path will now point to internal game files", Text);
                        break;
                    case false:
                        MessageBox.Show("This path will now point to external sound files", Text);
                        break;
                }
            }
        }

        private void filePath_TextChanged(object sender, EventArgs e) {
            if (filePath.Text.Contains(".scd")) {
                ignoreClear = true;
                useGameFileCheckBox.Checked = true;
                ignoreClear = false;
            }
        }
    }
}
