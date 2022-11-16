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

namespace FFXIVVoiceClipNameGuesser {
    public partial class SCDCreator : Form {
        public SCDCreator() {
            InitializeComponent();
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }

        private void generateButton_Click(object sender, EventArgs e) {
            SCDGenerator generator = new SCDGenerator();
            using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, "header.bin"), FileMode.Open, FileAccess.Read)) {
                using (FileStream input = new FileStream(wavSelection.FilePath.Text, FileMode.Open, FileAccess.Read)) {
                    generator.GenerateSCD(header, input, outputSelection.FilePath.Text);
                }
            }
        }
    }
}
