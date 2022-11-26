using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public partial class VoiceSelection : Form {
        public VoiceSelection() {
            InitializeComponent();
            RefreshRacialChoices();
        }
        int selectedVoice = 0;

        public int SelectedVoice { get => selectedVoice; set => selectedVoice = value; }

        private void addToVoiceListButton_Click(object sender, EventArgs e) {
            switch (sexListComboBox.SelectedIndex) {
                case 0:
                    int value = int.Parse(RaceVoices.RacialList[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex]);
                    selectedVoice = value;
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
                case 1:
                    string stringValue = RaceVoices.RacialList[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(stringValue)) {
                        int value2 = int.Parse(stringValue);
                        selectedVoice = value2;
                        DialogResult = DialogResult.OK;
                        Close();
                    } else {
                        MessageBox.Show("Voice does not exist", Text);
                    }
                    break;
            }
        }
        void RefreshRacialChoices() {
            raceListComboBox.Items.Clear();
            foreach (RaceVoices voices in RaceVoices.RacialList) {
                raceListComboBox.Items.Add(voices.RaceName);
            }
            sexListComboBox.SelectedIndex = 0;
            raceListComboBox.SelectedIndex = 0;
            voiceListComboBox.SelectedIndex = 0;
        }
    }
}
