using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VfxEditor.ScdFormat;

namespace FFXIVVoicePackCreator.SoundData {
    internal class AudioReplacementItem {
        int index;
        ScdAudioEntry scdAudioEntry;
        string replacementFile;

        public AudioReplacementItem(int index, ScdAudioEntry scdAudioEntry, string replacementFile) {
            this.index = index;
            this.scdAudioEntry = scdAudioEntry;
            this.replacementFile = replacementFile;
        }

        public int Index { get => index; set => index = value; }
        public ScdAudioEntry ScdAudioEntry { get => scdAudioEntry; set => scdAudioEntry = value; }
        public string ReplacementFile { get => replacementFile; set => replacementFile = value; }

        public override string ToString() {
            if (!string.IsNullOrEmpty(replacementFile)) {
                return replacementFile;
            } else {
                return  scdAudioEntry.Format + " Audio At Index " + index;
            }
        }
    }
}
