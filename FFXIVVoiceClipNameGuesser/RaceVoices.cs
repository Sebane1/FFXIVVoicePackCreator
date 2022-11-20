using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public class RaceVoices {
        string raceName;
        List<string> _masculine = new List<string>();
        List<string> _feminine = new List<string>();

        public string RaceName { get => raceName; set => raceName = value; }
        public List<string> Masculine { get => _masculine; set => _masculine = value; }
        public List<string> Feminine { get => _feminine; set => _feminine = value; }
    }
}
