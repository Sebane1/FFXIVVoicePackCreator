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

namespace FFXIVVoicePackCreator {
    public partial class MainWindow : Form {
        private string filepath;
        private string jsonFilepath;
        private string dumpFilepath;
        private List<string> files;
        private List<string> secondaryKnownFileList;
        private List<string> lostFileListPaths;
        private Point startPos;
        private bool canDoDragDrop;
        private SCDGenerator scdGenerator;
        private string metaFilePath;
        private bool firstDone;
        private string paths;
        private List<RaceVoices> racialList;
        private List<int> voicesToReplace = new List<int>();
        private Dictionary<string, List<string>> racesToVoice = new Dictionary<string, List<string>>();
        public MainWindow() {
            InitializeComponent();
            // foundNamesList.SelectionMode = SelectionMode.MultiExtended;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            Text = Application.ProductName + " " + Application.ProductVersion;
            LoadRacialVoiceInfo();
            missingFIleList.Items.Clear();
            if (MessageBox.Show(@"Do you have voices dumped via FFXIVExplorer or an equivalent tool as .wav files?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                PickVoiceDump();
            } else {
                MessageBox.Show("Voice guessing will be hindered without a dump folder selected.", Text);
            }
            scdGenerator = new SCDGenerator();
        }

        private void LoadRacialVoiceInfo() {
            string racialListPath = Path.Combine(Application.StartupPath, "racialVoiceList.txt");
            racialList = new List<RaceVoices>();
            using (StreamReader streamReader = new StreamReader(racialListPath)) {
                for (int raceIndex = 0; raceIndex < 8; raceIndex++) {
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
            RefreshRacialChoices();
        }

        void RefreshRacialChoices() {
            raceListComboBox.Items.Clear();
            foreach (RaceVoices voices in racialList) {
                raceListComboBox.Items.Add(voices.RaceName);
            }
            sexListComboBox.SelectedIndex = 0;
            raceListComboBox.SelectedIndex = 0;
            voiceListComboBox.SelectedIndex = 0;
        }

        private void PickVoiceDump() {
            bool dontLoad = false;
            MessageBox.Show(@"Please select the folder with your dumped voice files. Should be under ""vo_emote"".", Text);
            FolderSelectDialog openFileDialog = new FolderSelectDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                dumpFilepath = openFileDialog.SelectedPath;
            } else {
                MessageBox.Show("No dumped voice folder selected", Text);
                dontLoad = true;
            }
            if (!dontLoad) {
                missingFIleList.Items.Clear();
                if (files != null) {
                    files.Clear();
                }
                files = new List<string>();
                files.AddRange(Directory.GetFiles(dumpFilepath));
                if (secondaryKnownFileList != null) {
                    secondaryKnownFileList.Clear();
                }
                secondaryKnownFileList = new List<string>();
                int startValue = 7301000;
                int index = 0;
                int attempts = (files.Count / 16);
                bool firstUnfound = false;
                int foundVoices = 0;
                int unfoundVoices = 0;
                for (int counter = 0; counter <= attempts; counter++) {
                    bool itemsNotFound = false;
                    for (int emoteCount = 0; emoteCount <= 15; emoteCount++) {
                        string fileName = (startValue + emoteCount) + "";
                        string name = ListContainsName(files, fileName);
                        if (string.IsNullOrEmpty(name)) {
                            missingFIleList.Items.Add((firstUnfound ? "" : "  ") + fileName + $" ({(Emotion)emoteCount})");
                            itemsNotFound = true;
                            firstUnfound = false;
                        } else {
                            firstUnfound = true;
                            index++;
                            foundNamesList.Items.Add(Path.GetFileName(name) + $" ({(Emotion)emoteCount})");
                            secondaryKnownFileList.Add(name);
                        }
                    }
                    if (itemsNotFound) {
                        missingFIleList.Items.Add("----------------");
                        startNumberGuess.Items.Add(startValue);
                        unfoundVoices++;
                    } else {
                        foundNamesList.Items.Add("----------------");
                        startNumber.Items.Add(startValue);
                        foundVoices++;
                        secondaryKnownFileList.Add("");
                    }
                    startValue += 1000;
                }
                lostFileListPaths = new List<string>();
                while (index < files.Count) {
                    lostFileList.Items.Add(Path.GetFileName(files[index++]));
                    lostFileListPaths.Add(files[index++]);
                }
                MessageBox.Show("Found " + foundVoices + " voices. Was not able to find " + unfoundVoices + " voices.", Text);
                if (missingFIleList.Items.Count > 0) {
                    MessageBox.Show(missingFIleList.Items.Count + @" items do not have a known filename. Check ""Missing Names"" list to help with you guesswork", Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void incrementButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(startNumberGuess.Text)) {
                startNumberGuess.SelectedIndex = -1;
            }
            paths = "";
            files = new List<string>() {
                surprised.FilePath.Text,
                angry.FilePath.Text,
                furious.FilePath.Text,
                cheer.FilePath.Text,
                doze.FilePath.Text,
                fume.FilePath.Text,
                huh.FilePath.Text,
                chuckle.FilePath.Text,
                laugh.FilePath.Text,
                no.FilePath.Text,
                stretch.FilePath.Text,
                upset.FilePath.Text,
                yes.FilePath.Text,
                happy.FilePath.Text,
                unknown1.FilePath.Text,
                unknown2.FilePath.Text};
            if (filepath == null) {
                GetFilePaths();
            }
            if (filepath != null) {
                firstDone = false;
                for (int counter = 0; counter <= int.Parse(attempts.Text); counter++) {
                    int startValue = int.Parse(startNumberGuess.Text.Replace(",", "").Replace(".", "").Replace("scd", ""));
                    ExportFiles(startValue);
                    if (startNumberGuess.SelectedIndex < startNumberGuess.Items.Count - 1) {
                        startNumberGuess.SelectedIndex++;
                    } else {
                        MessageBox.Show("Reached the end of the guess list, going to the beginning of the list", Text);
                        startNumberGuess.SelectedIndex = 0;
                        break;
                    }
                }
                ExportJson(paths);
                ExportMeta();
            }
        }

        private void ExportFiles(int startValue) {
            int i = 0;
            foreach (string file in files) {
                if (!string.IsNullOrEmpty(file)) {
                    string fileName = (startValue + i) + "";
                    scdGenerator.ConvertAndGenerateSCD(file, Path.Combine(filepath, fileName + ".scd"));
                    if (firstDone) {
                        paths += ",\r\n" + @"       ""sound/voice/vo_emote/" + fileName + @".scd"": ""sound\\voice\\vo_emote\\" + fileName + @".scd""";
                    } else {
                        paths += @"""sound/voice/vo_emote/" + fileName + @".scd"": ""sound\\voice\\vo_emote\\" + fileName + @".scd""";
                        firstDone = true;
                    }
                }
                i++;
            }
        }

        private void generateButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(startNumber.Text)) {
                startNumber.SelectedIndex = -1;
                startNumber.Text = 7301000 + "";
            }
            paths = "";
            files = new List<string>() {
                surprised.FilePath.Text,
                angry.FilePath.Text,
                furious.FilePath.Text,
                cheer.FilePath.Text,
                doze.FilePath.Text,
                fume.FilePath.Text,
                huh.FilePath.Text,
                chuckle.FilePath.Text,
                laugh.FilePath.Text,
                no.FilePath.Text,
                stretch.FilePath.Text,
                upset.FilePath.Text,
                yes.FilePath.Text,
                happy.FilePath.Text,
                unknown1.FilePath.Text,
                unknown2.FilePath.Text};
            if (filepath == null) {
                GetFilePaths();
            }
            if (filepath != null) {
                firstDone = false;
                for (int counter = 0; counter <= int.Parse(attempts.Text); counter++) {
                    int startValue = int.Parse(startNumber.Text.Replace(",", "").Replace(".", "").Replace("scd", ""));
                    ExportFiles(startValue);
                }
                ExportJson(paths);
                ExportMeta();
            }
        }

        private void ExportJson(string paths) {
            jsonText.Text = @"{
  ""Name"": """",
  ""Priority"": 0,
  ""Files"": {
       " + paths + @"
  },
  ""FileSwaps"": { },
  ""Manipulations"": []
}";
            if (jsonFilepath != null) {
                using (StreamWriter writer = new StreamWriter(jsonFilepath)) {
                    writer.WriteLine(jsonText.Text);
                }
            }
        }

        private void ExportMeta() {
            string metaText = @"{
  ""FileVersion"": 3,
  ""Name"": """ + modNameTextbox.Text + @""",
  ""Author"": """ + authorTextBox.Text + @""",
  ""Description"": """ + descriptionTextBox.Text + @""",
  ""Version"": """ + modVersionTextBox.Text + @""",
  ""Website"": """ + modWebsiteTextBox.Text + @""",
  ""ModTags"": []
}";
            if (metaFilePath != null) {
                using (StreamWriter writer = new StreamWriter(metaFilePath)) {
                    writer.WriteLine(metaText);
                }
            }
        }

        private void GetFilePaths() {
            MessageBox.Show(@"Please select the root folder for your custom penumbra sound mod. Ideally you've created one inside your penumbra mods folder for easy testing. (You can use Penumbra to export this mod to a .pmp package later)", Text);
            FolderSelectDialog folderSelect = new FolderSelectDialog();
            if (folderSelect.ShowDialog() == DialogResult.OK) {
                filepath = Path.Combine(folderSelect.SelectedPath, @"sound\voice\vo_emote");
                Directory.CreateDirectory(filepath);
                jsonFilepath = Path.Combine(folderSelect.SelectedPath, "default_mod.json");
                metaFilePath = Path.Combine(folderSelect.SelectedPath, "meta.json");
                if (File.Exists(jsonFilepath)) {
                    MessageBox.Show(@"Existing mod configuration detected.", Text);
                }
            }
        }

        private string ListContainsName(List<string> files, string fileName) {
            foreach (string file in files) {
                if (file.Contains(fileName)) {
                    return file;
                }
            }
            return "";
        }
        enum Emotion {
            Surprised,
            Angry,
            Furious,
            Cheer,
            Doze,
            Fume,
            Huh,
            Chuckle,
            Laugh,
            No,
            Stretch,
            Upset,
            Yes,
            Happy,
            Unknown1,
            Unknown2
        }

        private void foundNamesList_MouseDown(object sender, MouseEventArgs e) {
            startPos = e.Location;
            canDoDragDrop = true;
        }

        private void foundNamesList_MouseMove(object sender, MouseEventArgs e) {
            if ((e.X != startPos.X || startPos.Y != e.Y) && canDoDragDrop) {
                List<string> fileList = new List<string>();
                foreach (int item in foundNamesList.SelectedIndices) {
                    if (!string.IsNullOrEmpty(secondaryKnownFileList[item])) {
                        fileList.Add(secondaryKnownFileList[item]);
                    }
                }
                if (fileList.Count > 0) {
                    DataObject fileDragData = new DataObject(DataFormats.FileDrop, fileList.ToArray());
                    DoDragDrop(fileDragData, DragDropEffects.Copy);
                }
                canDoDragDrop = false;
            }
        }
        private void lostNamesList_MouseDown(object sender, MouseEventArgs e) {
            startPos = e.Location;
            canDoDragDrop = true;
        }

        private void lostNamesList_MouseMove(object sender, MouseEventArgs e) {
            if ((e.X != startPos.X || startPos.Y != e.Y) && canDoDragDrop) {
                List<string> fileList = new List<string>();
                foreach (int item in lostFileList.SelectedIndices) {
                    if (!string.IsNullOrEmpty(lostFileListPaths[item])) {
                        fileList.Add(lostFileListPaths[item]);
                    }
                }
                if (fileList.Count > 0) {
                    DataObject fileDragData = new DataObject(DataFormats.FileDrop, fileList.ToArray());
                    DoDragDrop(fileDragData, DragDropEffects.Copy);
                }
                canDoDragDrop = false;
            }
        }
        private void foundNamesList_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (!string.IsNullOrEmpty(secondaryKnownFileList[foundNamesList.SelectedIndex])) {
                Process.Start(secondaryKnownFileList[foundNamesList.SelectedIndex]);
            }
        }

        private void sCDWavMergerToolStripMenuItem_Click(object sender, EventArgs e) {
            SCDCreator sCDCreator = new SCDCreator();
            sCDCreator.ShowDialog();
        }

        private void changeVoiceDumpToolStripMenuItem_Click(object sender, EventArgs e) {
            PickVoiceDump();
        }

        private void pickExportFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            GetFilePaths();
        }

        private void lostFileList_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (!string.IsNullOrEmpty(lostFileListPaths[lostFileList.SelectedIndex])) {
                Process.Start(lostFileListPaths[lostFileList.SelectedIndex]);
            }
        }

        private void lostFileList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {
        }

        private void addToVoiceListButton_Click(object sender, EventArgs e) {
            switch (sexListComboBox.SelectedIndex) {
                case 0:
                    int value = int.Parse(racialList[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex]);
                    if (!voicesToReplace.Contains(value)) {
                        voicesToReplace.Add(value);
                        string text = "Character Voice: " + racialList[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                        foreach (string raceValue in racesToVoice[value + ""]) {
                            text += " | " + raceValue;
                        }
                        voiceReplacementList.Items.Add(text);
                    } else {
                        MessageBox.Show("This voice has already been added for replacement.", Text);
                    }
                    break;
                case 1:
                    string stringValue = racialList[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(stringValue)) {
                        int value2 = int.Parse(stringValue);
                        if (!voicesToReplace.Contains(value2)) {
                            voicesToReplace.Add(value2);
                            string text = "Character Voice: " + racialList[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                            foreach (string raceValue in racesToVoice[value2 + ""]) {
                                text += " | " + raceValue;
                            }
                            voiceReplacementList.Items.Add(text);
                        } else {
                            MessageBox.Show("This voice has already been added for replacement.", Text);
                        }
                    } else {
                        MessageBox.Show("Theres is no voice to replace.", Text);
                    }
                    break;
            }
        }

        private void easyGenerateButton_Click(object sender, EventArgs e) {
            paths = "";
            files = new List<string>() {
                surprised.FilePath.Text,
                angry.FilePath.Text,
                furious.FilePath.Text,
                cheer.FilePath.Text,
                doze.FilePath.Text,
                fume.FilePath.Text,
                huh.FilePath.Text,
                chuckle.FilePath.Text,
                laugh.FilePath.Text,
                no.FilePath.Text,
                stretch.FilePath.Text,
                upset.FilePath.Text,
                yes.FilePath.Text,
                happy.FilePath.Text,
                unknown1.FilePath.Text,
                unknown2.FilePath.Text};
            if (filepath == null) {
                GetFilePaths();
            }
            if (filepath != null) {
                firstDone = false;
                foreach (int value in voicesToReplace) {
                    ExportFiles(value);
                }
                ExportJson(paths);
                ExportMeta();
            }
        }

        private void clearListButton_Click(object sender, EventArgs e) {
            voicesToReplace.Clear();
            voiceReplacementList.Items.Clear();
        }

        private void removeFromList_Click(object sender, EventArgs e) {
            if (voiceReplacementList.Items.Count > 0) {
                if (voiceReplacementList.SelectedIndex > -1) {
                    voicesToReplace.RemoveAt(voiceReplacementList.SelectedIndex);
                    voiceReplacementList.Items.RemoveAt(voiceReplacementList.SelectedIndex);
                    voiceReplacementList.SelectedIndex = -1;
                }
            }
        }
    }
}
