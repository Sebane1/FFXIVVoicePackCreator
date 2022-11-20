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
        public SCDCreator() {
            InitializeComponent();
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }

        private void generateButton_Click(object sender, EventArgs e) {
            SCDGenerator generator = new SCDGenerator();
            generator.ConvertAndGenerateSCD(mediaSelection.FilePath.Text, outputSelection.FilePath.Text);
            this.Focus();
        }
    }
}
