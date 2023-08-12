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
            AutoScaleDimensions = new SizeF(96, 96);
        }
        int selectedVoiceEmote = 0;
        string selectedVoiceBattle = "";

        public int SelectedVoiceEmote { get => selectedVoiceEmote; set => selectedVoiceEmote = value; }
        public string SelectedVoiceBattle { get => selectedVoiceBattle; set => selectedVoiceBattle = value; }

        private void addToVoiceListButton_Click(object sender, EventArgs e) {
            switch (sexListComboBox.SelectedIndex) {
                case 0:
                    int value = int.Parse(RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex]);
                    selectedVoiceEmote = value;
                    selectedVoiceBattle = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                    DialogResult = DialogResult.OK;
                    Close();
                    break;
                case 1:
                    string stringValue = RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(stringValue)) {
                        int value2 = int.Parse(stringValue);
                        selectedVoiceEmote = value2;
                        selectedVoiceBattle = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
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
            foreach (RaceVoice voices in RaceVoice.RacialListEmotes) {
                raceListComboBox.Items.Add(voices.RaceName);
            }
            sexListComboBox.SelectedIndex = 0;
            raceListComboBox.SelectedIndex = 0;
            voiceListComboBox.SelectedIndex = 0;
        }
    }
}
