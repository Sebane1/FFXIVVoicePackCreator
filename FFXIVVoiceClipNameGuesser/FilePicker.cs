using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Gui;
using NAudio.Wave;

namespace FFXIVVoicePackCreator {
    public partial class FilePicker : UserControl {
        public FilePicker() {
            InitializeComponent();
        }

        int index = 0;
        bool isSaveMode = false;
        bool isSwappable = true;
        bool isPlayable = true;
        public event EventHandler OnFileSelected;
        [Category("Select Type"), Description("Changes what type of selection is made")]
        public bool IsSaveMode { get => isSaveMode; set => isSaveMode = value; }

        [Category("Filter"), Description("Changes what type of selection is made")]
        public string Filter { get => filter; set => filter = value; }

        [Category("Can Use Voice Swap"), Description("Changes whether this entry support voice swap")]
        public bool IsSwappable { get => isSwappable; set => isSwappable = value; }
        [Category("Can Play Audio"), Description("Can this play sound?")]
        public bool IsPlayable { get => isPlayable; set => isPlayable = value; }


        string filter;
        private Point startPos;
        private bool canDoDragDrop;
        private bool ignoreClear;
        private bool muteState;
        private MainWindow window;
        private WaveOutEvent output;
        private int maxTime = 4000;

        private void filePicker_Load(object sender, EventArgs e) {
            AutoScaleDimensions = new SizeF(96, 96);
            labelName.Text = (index == -1 ? Name : ($"({index})  " + Name));
            if (!isSwappable) {
                useGameFileCheckBox.Visible = false;
            }
            filePath.AllowDrop = true;
            if (isPlayable) {
                playButton.Visible = true;
            } else {
                playButton.Visible = false;
            }
            window = (ParentForm as MainWindow);
            if (window != null && window.FoundInstance) {
                muteState = VolumeMixer.GetApplicationMute(window.Hook.Process.Id);
            }
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
                if (OnFileSelected != null) {
                    OnFileSelected.Invoke(this, EventArgs.Empty);
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
            playButton.Visible = false;

        }
        public void SetFilePath(string path) {
            ignoreClear = true;
            useGameFileCheckBox.Checked = false;
            filePath.Text = path;
            filePath.ReadOnly = false;
            ignoreClear = false;
            filePath.AllowDrop = true;
            if (isPlayable) {
                playButton.Visible = true;
            } else {
                playButton.Visible = false;
            }
        }
        private void useGameFileCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (!ignoreClear) {
                FilePath.Text = "";
                switch (useGameFileCheckBox.Checked) {
                    case true:
                        MessageBox.Show("This path will now point to internal game files", Text);
                        filePath.ReadOnly = true;
                        playButton.Visible = false;
                        break;
                    case false:
                        MessageBox.Show("This path will now point to external sound files", Text);
                        filePath.ReadOnly = false;
                        if (isPlayable) {
                            playButton.Visible = true;
                        } else {
                            playButton.Visible = false;
                        }
                        break;
                }
            }
        }

        private void filePath_TextChanged(object sender, EventArgs e) {
            if (filePath.Text.Contains(".scd") && isSwappable) {
                ignoreClear = true;
                useGameFileCheckBox.Checked = true;
                filePath.ReadOnly = true;
                ignoreClear = false;
                playButton.Visible = false;
            } else {
                filePath.ReadOnly = false;
                if (isPlayable) {
                    playButton.Visible = true;
                } else {
                    playButton.Visible = false;
                }
            }
            if (window != null) {
                window.HasSaved = false;
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

        private void playButton_Click(object sender, EventArgs e) {
            if (index == 4) {
                maxTime = 10000;
            } else if (index < 16) {
                maxTime = 3000;
            }
            if (window != null && index < 16 && window.FoundInstance) {
                {
                    window.Hook.SendSyncKey(Keys.Enter);
                    Thread.Sleep(800);
                    window.Hook.SendString(@"/" + Name);
                    Thread.Sleep(200);
                    window.Hook.SendSyncKey(Keys.Enter);
                    VolumeMixer.SetApplicationMute(window.Hook.Process.Id, true);
                    Thread.Sleep(200);
                }
            }
            if (window.AutoSyncCheckbox.Checked) {
                if (window.SelectedVoiceDescriptor != null) {
                    decimal delay = (decimal)1000.0 * RaceVoice.TimeCodeData[window.SelectedVoiceDescriptor.RaceName + "_" + window.SelectedVoiceDescriptor.VoiceGender].TimeCodes[index];
                    Thread.Sleep((int)delay);
                    if (index == 4) {
                        maxTime = 10000 - (int)delay;
                    } else {
                        maxTime = 3000 - (int)delay;
                    }
                }
            }
            PlaySound(filePath.Text);
            if (window != null && index < 16 && window.FoundInstance) {
                VolumeMixer.SetApplicationMute(window.Hook.Process.Id, muteState);
                window.TopMost = true;
                window.Focus();
                window.TopMost = false;
            }
        }
        public void PlaySound(string fileName) {
            if (File.Exists(fileName)) {
                if (output != null) {
                    output.Stop();
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                output = new WaveOutEvent();
                using (var player = new AudioFileReader(fileName)) {
                    output.Init(player);
                    output.Play();
                    while (output.PlaybackState == PlaybackState.Playing) {
                        Thread.Sleep(200);
                        Application.DoEvents();
                        if (stopwatch.ElapsedMilliseconds > maxTime) {
                            output.Stop();
                            break;
                        }
                        if (window != null && window.FoundInstance) {
                            Thread.Sleep(maxTime - (int)stopwatch.ElapsedMilliseconds);
                        }
                    }
                }
            }
        }
    }
}
