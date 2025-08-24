using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VfxEditor.ScdFormat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace FFXIVVoicePackCreator {
    public partial class BulkSCDCreator : Form {
        private Form form;

        public Form Form { get => form; set => form = value; }

        public BulkSCDCreator() {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e) {
            //form.TopMost = true;
            TopMost = true;
            if (!string.IsNullOrEmpty(outputFolderText.Text)) {
                foreach (var item in mediaListBox.Items) {
                    var mediaItem = item as string;
                    var output = Path.Combine(outputFolderText.Text, Path.GetFileNameWithoutExtension(mediaItem) + ".scd");
                    Directory.CreateDirectory(outputFolderText.Text);
                    if (!string.IsNullOrEmpty(mediaItem) && !string.IsNullOrEmpty(output)) {
                        SCDGenerator generator = new SCDGenerator();
                        switch (scdTypeComboBox.SelectedIndex) {
                            case 0:
                                generator.ConvertAndGenerateMSADCPM(mediaItem, output);
                                break;
                            case 1:
                                generator.ConvertAndGenerateOGG(mediaItem, output, 0, 0, 1);
                                break;
                            case 2:
                                if (File.Exists(mediaItem)) {
                                    bool isAlreadyAnOgg = mediaItem.ToLower().EndsWith(".ogg");

                                    string tempPath = isAlreadyAnOgg ? mediaItem : Path.Combine(Path.GetDirectoryName(mediaItem), Guid.NewGuid() + ".ogg");
                                    Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + mediaItem + @""""} -c:a libvorbis -ar: 44100 -ac 1 {@"""" + tempPath + @""""}");
                                    while (SCDGenerator.IsFileLocked(tempPath)) { }
                                    ;
                                    InjectSCDFilesOgg(Path.Combine(Application.StartupPath, @"res\scd\orchestrion.scd"), output,
                                    new List<string>() { tempPath }, 0, 0);
                                    if (!isAlreadyAnOgg) {
                                        File.Delete(tempPath);
                                    }
                                }
                                break;
                        }

                        this.Focus();
                    }
                    TopMost = false;
                }
                //form.TopMost = false;
                MessageBox.Show($"SCD files created successfully!", Text);
            } else {
                MessageBox.Show($"No output folder was set!", Text);
            }
        }

        private void SCDCreator_Load(object sender, EventArgs e) {
            scdTypeComboBox.SelectedIndex = 0;
            AutoScaleDimensions = new SizeF(96, 96);
        }
        private void InjectSCDFilesOgg(string input, string output, List<string> list, int loopStart, int loopEnd) {
            using (FileStream fileStream = new FileStream(input, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fileStream)) {
                    ScdFile file = new ScdFile(reader);

                    for (int i = 0; i < file.Audio.Count; i++) {
                        ScdAudioEntry entry = file.Audio[i];
                        if (entry.Format == SscfWaveFormat.Vorbis) {
                            string path = list[i++];
                            if (!string.IsNullOrEmpty(path)) {
                                file.Import(path, entry, loopStart, loopEnd);
                            }
                        }
                    }
                    using (FileStream exportStream = new FileStream(output, FileMode.Create, FileAccess.Write)) {
                        using (BinaryWriter writer = new BinaryWriter(exportStream)) {
                            file.Write(writer);
                        }
                    }
                }
            }
        }

        private void scdTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void textValidation_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void mediaListBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) { e.Effect = DragDropEffects.Copy; }
        }

        private void mediaListBox_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) {
                mediaListBox.Items.Add(file);
            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void outputFolderLabel_Click(object sender, EventArgs e) {

        }

        private void addButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                outputFolderText.Text = dialog.SelectedPath;
            }
        }

        private void addMediaButton_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                mediaListBox.Items.Add(dialog.FileName);
            }
        }

        private void removeSelectedMedia_Click(object sender, EventArgs e) {
            if (mediaListBox.SelectedIndex > -1) {
                mediaListBox.Items.RemoveAt(mediaListBox.SelectedIndex);
            }
        }
    }
}
