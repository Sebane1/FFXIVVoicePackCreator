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
                }
                this.Focus();
                MessageBox.Show($"SCD file created successfully!", Text);
            } else {
                MessageBox.Show($"Input and output cannot be blank!", Text);
            }
            form.TopMost = true;
            TopMost = true;
        }

        private void SCDCreator_Load(object sender, EventArgs e) {
            scdTypeComboBox.SelectedIndex = 0;
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
    }
}
