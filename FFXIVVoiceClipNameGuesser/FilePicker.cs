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
        bool isSwappable = true;

        [Category("Select Type"), Description("Changes what type of selection is made")]
        public bool IsSaveMode { get => isSaveMode; set => isSaveMode = value; }

        [Category("Filter"), Description("Changes what type of selection is made")]
        public string Filter { get => filter; set => filter = value; }

        [Category("Can Use Voice Swap"), Description("Changes whether this entry support voice swap")]
        public bool IsSwappable { get => isSwappable; set => isSwappable = value; }

        string filter;
        private Point startPos;
        private bool canDoDragDrop;
        private bool ignoreClear;

        private void filePicker_Load(object sender, EventArgs e) {
            labelName.Text = (index == -1 ? Name : ($"({index})  " + Name));
            if (!isSwappable) {
                useGameFileCheckBox.Visible = false;
            }
            filePath.AllowDrop = true;
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
                    filePath.Text = "sound/voice/vo_emote/" + (voiceSelection.SelectedVoiceEmote + index) + ".scd";
                }
            }
        }

        public void SetToGameFile(int voiceSelection) {
            ignoreClear = true;
            useGameFileCheckBox.Checked = true;
            filePath.Text = "sound/voice/vo_emote/" + (voiceSelection + index) + ".scd";
            filePath.ReadOnly = true;
            ignoreClear = false;
            filePath.AllowDrop = false;
        }
        public void SetFilePath(string path) {
            ignoreClear = true;
            useGameFileCheckBox.Checked = false;
            filePath.Text = path;
            filePath.ReadOnly = false;
            ignoreClear = false;
            filePath.AllowDrop = true;
        }
        private void useGameFileCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (!ignoreClear) {
                FilePath.Text = "";
                switch (useGameFileCheckBox.Checked) {
                    case true:
                        MessageBox.Show("This path will now point to internal game files", Text);
                        filePath.ReadOnly = true;
                        break;
                    case false:
                        MessageBox.Show("This path will now point to external sound files", Text);
                        filePath.ReadOnly = false;
                        break;
                }
            }
        }

        private void filePath_TextChanged(object sender, EventArgs e) {
            if (filePath.Text.Contains(".scd")) {
                ignoreClear = true;
                useGameFileCheckBox.Checked = true;
                filePath.ReadOnly = true;
                ignoreClear = false;
            } else {
                filePath.ReadOnly = false;
            }
        }

        private void filePath_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void filePath_DragDrop(object sender, DragEventArgs e) {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (CheckExtentions(file)) {
                filePath.Text = file;
            } else {
                MessageBox.Show("This is not a media file this tool recognizes.", ParentForm.Text);
            }
        }
        private bool CheckExtentions(string file) {
            string[] extentions = new string[] { ".wav", ".aac", ".wma", ".wmv", ".avi", ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".mp4", ".mov", ".3g2", ".3gp2", ".3gp", ".3gpp", ".m4a", ".cda", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".mkv", ".WAV", ".AAC", ".WMA", ".WMV", ".AVI", ".MPG", ".MPEG", ".M1V", ".MP2", ".MP3", ".MPA", ".MPE", ".M3U", ".MP4", ".MOV", ".3G2", ".3GP2", ".3GP", ".3GPP", ".M4A", ".CDA", ".AIF", ".AIFC", ".AIFF", ".RMI", ".MKV", ".flac", ".ogg" };
            foreach (string extention in extentions) {
                if (file.Contains(extention)) {
                    return true;
                }
            }
            return false;
        }
    }
}
