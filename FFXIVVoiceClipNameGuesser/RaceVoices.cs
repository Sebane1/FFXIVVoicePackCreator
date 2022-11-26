using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public class RaceVoices {
        string raceName;
        List<string> _masculine = new List<string>();
        List<string> _feminine = new List<string>();

        public string RaceName { get => raceName; set => raceName = value; }
        public List<string> Masculine { get => _masculine; set => _masculine = value; }
        public List<string> Feminine { get => _feminine; set => _feminine = value; }
        public static Dictionary<string, List<string>> RacesToVoice { get => racesToVoice; set => racesToVoice = value; }
        public static List<RaceVoices> RacialList { get => racialList; set => racialList = value; }

        private static List<RaceVoices> racialList;
        private static Dictionary<string, List<string>> racesToVoice = new Dictionary<string, List<string>>();
        public static void LoadRacialVoiceInfo() {
            racialList = new List<RaceVoices>();
            string racialListPath = Path.Combine(Application.StartupPath, @"res\racialVoiceList.txt");
            racialList = new List<RaceVoices>();
            using (StreamReader streamReader = new StreamReader(racialListPath)) {
                int races = int.Parse(streamReader.ReadLine());
                for (int raceIndex = 0; raceIndex < races; raceIndex++) {
                    RaceVoices raceVoices = new RaceVoices();
                    raceVoices.RaceName = streamReader.ReadLine();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoices.Masculine.Add(value);

                        if (!racesToVoice.ContainsKey(value)) {
                            racesToVoice.Add(value, new List<string>() { raceVoices.RaceName + ", Masculine Voice " + (12 - i) });
                        } else {
                            racesToVoice[value].Add(raceVoices.RaceName + ", Masculine Voice " + (12 - i));
                        }
                    }
                    raceVoices.Masculine.Reverse();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoices.Feminine.Add(value);

                        if (!racesToVoice.ContainsKey(value)) {
                            racesToVoice.Add(value, new List<string>() { raceVoices.RaceName + ", Feminine, Voice " + (12 - i) });
                        } else {
                            racesToVoice[value].Add(raceVoices.RaceName + ", Feminine Voice " + (12 - i));
                        }
                    }
                    raceVoices.Feminine.Reverse();
                    racialList.Add(raceVoices);
                }
            }
        }
    }
}
