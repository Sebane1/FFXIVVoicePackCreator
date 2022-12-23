using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VfxEditor.ScdFormat;

namespace FFXIVVoicePackCreator {
    public partial class SCDCreator : Form {
        private Form form;

        public Form Form { get => form; set => form = value; }

        public SCDCreator() {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e) {
            form.TopMost = true;
            TopMost = true;
            if (!string.IsNullOrEmpty(mediaSelection.FilePath.Text) && !string.IsNullOrEmpty(outputSelection.FilePath.Text)) {
                SCDGenerator generator = new SCDGenerator();
                switch (scdTypeComboBox.SelectedIndex) {
                    case 0:
                        generator.ConvertAndGenerateMSADCPM(mediaSelection.FilePath.Text, outputSelection.FilePath.Text);
                        break;
                    case 1:
                        generator.ConvertAndGenerateOGG(mediaSelection.FilePath.Text,
                            outputSelection.FilePath.Text,
                            int.Parse(loopStartTextBox.Text),
                            int.Parse(loopEndTextBox.Text),
                            int.Parse(numberOfSamplesTextBox.Text));
                        break;
                    case 2:
                        if (File.Exists(mediaSelection.FilePath.Text)) {
                            string tempPath = Path.Combine(Path.GetDirectoryName(mediaSelection.FilePath.Text), Guid.NewGuid() + ".ogg");
                            Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + mediaSelection.FilePath.Text + @""""} -c:a libvorbis -ar: 44100 {@"""" + tempPath + @""""}");
                            while (SCDGenerator.IsFileLocked(tempPath)) { };
                            InjectSCDFilesOgg(Path.Combine(Application.StartupPath, @"res\scd\orchestrion.scd"), outputSelection.FilePath.Text,
                            new List<string>() { tempPath }, int.Parse(loopStartTextBox.Text), int.Parse(loopEndTextBox.Text));
                            File.Delete(tempPath);
                        }
                        break;
                }
                this.Focus();
                MessageBox.Show($"SCD file created successfully!", Text);
            } else {
                MessageBox.Show($"Input and output cannot be blank!", Text);
            }
            form.TopMost = false;
            TopMost = false;
        }

        private void SCDCreator_Load(object sender, EventArgs e) {
            scdTypeComboBox.SelectedIndex = 0;
        }
        private void InjectSCDFilesOgg(string input, string output, List<string> list, int loopStart, int loopEnd) {
            using (FileStream fileStream = new FileStream(input, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fileStream)) {
                    ScdFile file = new ScdFile(reader);
                    int i = 0;
                    foreach (ScdAudioEntry entry in file.Audio) {
                        if (entry.Format == SscfWaveFormat.Vorbis) {
                            string path = list[i++];
                            if (!string.IsNullOrEmpty(path)) {
                                ScdFile.Import(path, entry, loopStart, loopEnd);
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
            switch (scdTypeComboBox.SelectedIndex) {
                case 0:
                    loopStartTextBox.Enabled = false;
                    loopEndTextBox.Enabled = false;
                    numberOfSamplesTextBox.Enabled = false;
                    loopStartLabel.Enabled = false;
                    loopEndLabel.Enabled = false;
                    NumberOfSamplesLabel.Enabled = false;
                    break;
                case 1:
                case 2:
                    loopStartTextBox.Enabled = true;
                    loopEndTextBox.Enabled = true;
                    numberOfSamplesTextBox.Enabled = true;
                    loopStartLabel.Enabled = true;
                    loopEndLabel.Enabled = true;
                    NumberOfSamplesLabel.Enabled = true;
                    break;
            }
        }

        private void textValidation_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }
    }
}
