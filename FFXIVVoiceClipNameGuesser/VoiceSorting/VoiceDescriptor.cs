using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator.VoiceSorting {
    public class VoiceDescriptor {
        string raceName;
        string voiceGender;
        string voiceValue;
        int index;

        public string RaceName { get => raceName; set => raceName = value; }
        public string VoiceGender { get => voiceGender; set => voiceGender = value; }
        public string VoiceValue { get => voiceValue; set => voiceValue = value; }
        public int Index { get => index; set => index = value; }

        public VoiceDescriptor(string raceName, string voiceGender, string voiceValue, int index) {
            this.raceName = raceName;
            this.voiceGender = voiceGender;
            this.voiceValue = voiceValue;
            this.index = index;
        }

        public string VerboseDescription {
            get {
                return raceName + ", " + voiceGender + " Voice " + index;
            }
        }
    }
}
