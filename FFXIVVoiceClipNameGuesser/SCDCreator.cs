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

namespace FFXIVVoiceClipNameGuesser {
    public partial class SCDCreator : Form {
        public SCDCreator() {
            InitializeComponent();
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }
        protected virtual bool IsFileLocked(string file) {
            try {
                using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None)) {
                    stream.Close();
                }
            } catch (IOException) {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        private void generateButton_Click(object sender, EventArgs e) {
            SCDGenerator generator = new SCDGenerator();
            string outputPath = Path.Combine(Path.GetDirectoryName(wavSelection.FilePath.Text), Guid.NewGuid() + ".wav");
            Process.Start(Path.Combine(Application.StartupPath, "ffmpeg.exe"), $"-i {@"""" + wavSelection.FilePath.Text + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + outputPath + @""""}");
            while (IsFileLocked(outputPath)) { };
            using (FileStream header = new FileStream(Path.Combine(Application.StartupPath, "header.bin"), FileMode.Open, FileAccess.Read)) {
                using (FileStream input = new FileStream(outputPath, FileMode.Open, FileAccess.Read)) {
                    generator.GenerateSCD(header, input, outputSelection.FilePath.Text);
                }
            }
            File.Delete(outputPath);
        }
    }
}
