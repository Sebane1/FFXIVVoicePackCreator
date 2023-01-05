using FFXIVVoicePackCreator.VoiceSorting;
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

        private static List<RaceVoice> racialListEmotes;
        private static List<RaceVoice> racialListBattle;
        private static Dictionary<string, RaceVoice> racialLookup = new Dictionary<string, RaceVoice>();
        private static Dictionary<string, List<VoiceDescriptor>> racesToVoiceDescription = new Dictionary<string, List<VoiceDescriptor>>();
        private static Dictionary<string, TimeCodeData> timeCodeData = new Dictionary<string, TimeCodeData>();

        public string RaceName { get => raceName; set => raceName = value; }
        public List<string> Masculine { get => _masculine; set => _masculine = value; }
        public List<string> Feminine { get => _feminine; set => _feminine = value; }
        public static List<RaceVoice> RacialListEmotes { get => racialListEmotes; set => racialListEmotes = value; }
        public static List<RaceVoice> RacialListBattle { get => racialListBattle; set => racialListBattle = value; }
        public static Dictionary<string, List<VoiceDescriptor>> RacesToVoiceDescription { get => racesToVoiceDescription; set => racesToVoiceDescription = value; }
        public static Dictionary<string, TimeCodeData> TimeCodeData { get => timeCodeData; set => timeCodeData = value; }

        public static void LoadRacialVoiceInfo() {
            LoadRacialEmotes();
            LoadRacialCombat();
            LoadTimeCodes();
        }

        private static void LoadTimeCodes() {
            timeCodeData.Clear();
            string racialListPath = Path.Combine(Application.StartupPath, @"res\racialEmoteTime.txt");
            using (StreamReader streamReader = new StreamReader(racialListPath)) {
                int races = int.Parse(streamReader.ReadLine());
                for (int raceIndex = 0; raceIndex < races; raceIndex++) {
                    string raceName = streamReader.ReadLine();
                    string gender = streamReader.ReadLine();
                    TimeCodeData timeCodeDataMasculine = new TimeCodeData();
                    timeCodeDataMasculine.Descriptor = raceName + "_" + gender;
                    for (int i = 0; i < 16; i++) {
                        string value = streamReader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(value)) {
                            try {
                                timeCodeDataMasculine.TimeCodes.Add(decimal.Parse(value));
                            } catch {
                                timeCodeDataMasculine.TimeCodes.Add(decimal.Parse(value.Replace(".", ",")));
                            }
                        }
                    }

                    gender = streamReader.ReadLine();
                    TimeCodeData timeCodeDataFeminine = new TimeCodeData();
                    timeCodeDataFeminine.Descriptor = raceName + "_" + gender;
                    for (int i = 0; i < 16; i++) {
                        string value = streamReader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(value)) {
                            try {
                                timeCodeDataFeminine.TimeCodes.Add(decimal.Parse(value));
                            } catch {
                                timeCodeDataFeminine.TimeCodes.Add(decimal.Parse(value.Replace(".", ",")));
                            }
                        }
                    }
                    timeCodeData.Add(timeCodeDataMasculine.Descriptor, timeCodeDataMasculine);
                    timeCodeData.Add(timeCodeDataFeminine.Descriptor, timeCodeDataFeminine);
                }
            }
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

                        if (!racesToVoiceDescription.ContainsKey(value)) {
                            racesToVoiceDescription.Add(value, new List<VoiceDescriptor>() { new VoiceDescriptor(raceVoice.RaceName, "Masculine", value, (i + 1)) });
                        } else {
                            racesToVoiceDescription[value].Add(new VoiceDescriptor(raceVoice.RaceName, "Masculine", value, (i + 1)));
                        }
                    }
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoice.Feminine.Add(value);

                        if (!racesToVoiceDescription.ContainsKey(value)) {
                            racesToVoiceDescription.Add(value, new List<VoiceDescriptor>() { new VoiceDescriptor(raceVoice.RaceName, "Feminine", value, (i + 1)) });
                        } else {
                            racesToVoiceDescription[value].Add(new VoiceDescriptor(raceVoice.RaceName, "Feminine", value, (i + 1)));
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
                    RaceVoice raceVoice = new RaceVoice();
                    raceVoice.RaceName = streamReader.ReadLine();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoice.Masculine.Add(value);
                        if (!racesToVoiceDescription.ContainsKey(value)) {
                            racesToVoiceDescription.Add(value, new List<VoiceDescriptor>() { new VoiceDescriptor(raceVoice.RaceName, "Masculine", value, (12 - i)) });
                        }
                    }
                    raceVoice.Masculine.Reverse();
                    streamReader.ReadLine();
                    for (int i = 0; i < 12; i++) {
                        string value = streamReader.ReadLine();
                        raceVoice.Feminine.Add(value);
                        if (!racesToVoiceDescription.ContainsKey(value)) {
                            racesToVoiceDescription.Add(value, new List<VoiceDescriptor>() { new VoiceDescriptor(raceVoice.RaceName, "Feminine", value, (12 - i)) });
                        }
                    }
                    raceVoice.Feminine.Reverse();
                    racialListEmotes.Add(raceVoice);
                    racialLookup.Add(raceVoice.RaceName, raceVoice);
                }
            }
        }
    }
}
