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

        public SCDCreator() {
            InitializeComponent();
        }

        private void filePicker1_Load(object sender, EventArgs e) {
            form = ((Form)Parent);
        }

        private void generateButton_Click(object sender, EventArgs e) {

            form.TopMost = true;
            SCDGenerator generator = new SCDGenerator();
            generator.ConvertAndGenerateSCD(mediaSelection.FilePath.Text, outputSelection.FilePath.Text);
            this.Focus();
            MessageBox.Show($"SCD file created successfully!", Text);
            form.TopMost = false;
        }
    }
}
