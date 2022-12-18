using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public class RaceVoice {
        string raceName;
        List<string> _masculine = new List<string>();
        List<string> _feminine = new List<string>();

        public string RaceName { get => raceName; set => raceName = value; }
        public List<string> Masculine { get => _masculine; set => _masculine = value; }
        public List<string> Feminine { get => _feminine; set => _feminine = value; }
        public static Dictionary<string, List<string>> RacesToVoice { get => racesToVoiceEmote; set => racesToVoiceEmote = value; }
        public static List<RaceVoice> RacialList { get => racialListEmotes; set => racialListEmotes = value; }

        private static List<RaceVoice> racialListEmotes;
        private static Dictionary<string, List<string>> racesToVoiceEmote = new Dictionary<string, List<string>>();
        private static List<RaceVoice> racialListBattle;

        public static void LoadRacialVoiceInfo() {
            LoadRacialEmotes();
            LoadRacialCombat();
        }

        private static void LoadRacialCombat() {
            racialListBattle = new List<RaceVoice>();
            string racialListPath = Path.Combine(Application.StartupPath, @"res\racialBattleList.txt");
            using (StreamReader streamReader = new StreamReader(racialListPath)) {
                int races = int.Parse(streamReader.ReadLine());
                for (int raceIndex = 0; raceIndex < races; raceIndex++) {
                    RaceVoice raceVoice = new RaceVoice();
                    raceVoice.RaceName = streamReader.ReadLine();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoice.Masculine.Add(value);

                        if (!racesToVoiceEmote.ContainsKey(value)) {
                            racesToVoiceEmote.Add(value, new List<string>() { raceVoice.RaceName + ", Masculine Battle Voice " + i });
                        } else {
                            racesToVoiceEmote[value].Add(raceVoice.RaceName + ", Masculine Battle Voice " + i);
                        }
                    }
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoice.Feminine.Add(value);

                        if (!racesToVoiceEmote.ContainsKey(value)) {
                            racesToVoiceEmote.Add(value, new List<string>() { raceVoice.RaceName + ", Feminine Battle Voice " + i });
                        } else {
                            racesToVoiceEmote[value].Add(raceVoice.RaceName + ", Feminine Battle Voice " + i);
                        }
                    }
                    racialListBattle.Add(raceVoice);
                }
            }
        }

        private static void LoadRacialEmotes() {
            racialListEmotes = new List<RaceVoice>();
            string racialListPath = Path.Combine(Application.StartupPath, @"res\racialVoiceList.txt");
            using (StreamReader streamReader = new StreamReader(racialListPath)) {
                int races = int.Parse(streamReader.ReadLine());
                for (int raceIndex = 0; raceIndex < races; raceIndex++) {
                    RaceVoice raceVoices = new RaceVoice();
                    raceVoices.RaceName = streamReader.ReadLine();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoices.Masculine.Add(value);

                        if (!racesToVoiceEmote.ContainsKey(value)) {
                            racesToVoiceEmote.Add(value, new List<string>() { raceVoices.RaceName + ", Masculine Voice " + (12 - i) });
                        } else {
                            racesToVoiceEmote[value].Add(raceVoices.RaceName + ", Masculine Voice " + (12 - i));
                        }
                    }
                    raceVoices.Masculine.Reverse();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoices.Feminine.Add(value);

                        if (!racesToVoiceEmote.ContainsKey(value)) {
                            racesToVoiceEmote.Add(value, new List<string>() { raceVoices.RaceName + ", Feminine, Voice " + (12 - i) });
                        } else {
                            racesToVoiceEmote[value].Add(raceVoices.RaceName + ", Feminine Voice " + (12 - i));
                        }
                    }
                    raceVoices.Feminine.Reverse();
                    racialListEmotes.Add(raceVoices);
                }
            }
        }
    }
}
