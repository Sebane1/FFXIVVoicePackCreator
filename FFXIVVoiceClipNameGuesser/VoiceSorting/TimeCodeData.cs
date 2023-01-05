using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator.VoiceSorting {
    public class TimeCodeData {
        string descriptor;
        List<decimal> timeCodes = new List<decimal>();
        public string Descriptor { get => descriptor; set => descriptor = value; }
        public List<decimal> TimeCodes { get => timeCodes; set => timeCodes = value; }
    }
}
