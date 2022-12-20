using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Shell;
using VfxEditor.ScdFormat;

namespace FFXIVVoicePackCreator {
    public partial class MainWindow : Form {
        private string exportFilePathEmote;
        private string exportFilePathBattle;
        private string jsonFilepath;
        private string dumpFilePath;
        private List<string> dumpFiles;
        private List<string> secondaryKnownFileList;
        private List<string> lostFileListPaths;
        private Point startPos;
        private bool canDoDragDrop;
        private SCDGenerator scdGenerator;
        private string metaFilePath;
        private bool firstDone;
        private string fileReplacementPaths;
        private string fileSwapPaths;
        private List<int> emoteVoicesToReplace = new List<int>();
        private List<string> battleVoicesToReplace = new List<string>();
        private bool alreadyShown;
        private List<FilePicker> emoteFilePickers = new List<FilePicker>();
        private List<FilePicker> battleFilePickers = new List<FilePicker>();
        private List<TextBox> authorInformation;
        private string savePath;
        private bool hasSaved = true;
        private bool firstDone2;

        public static string _defaultModName = "";
        public static string _defaultAuthor = "FFXIV Voice Pack Creator";
        public static string _defaultDescription = "Exported by FFXIV Voice Pack Creator";
        public static string _descriptionBattleVoiceDisclaimer = "\r\n DISCLAIMER: Penumbra does not support battle voices in collections assigned to specific characters. To hear battle voices make sure the collection is assigned to Base Collection";
        public static string _defaultWebsite = "https://github.com/Sebane1/FFXIVVoicePackCreator";
        private string penumbraModPath;
        private string battleVoiceToSwapWith;
        private bool suppressNextVoiceTabWarning;
        private bool suppressVoiceSwapBattleVoiceChecked;
        private bool battleVoicesInUse;

        public MainWindow() {
            InitializeComponent();
            // foundNamesList.SelectionMode = SelectionMode.MultiExtended;
        }

        private void Form1_Load(object sender, EventArgs e) {
            CleanDirectory();
            TopMost = true;
            GetPenumbraPath();
            exportProgressBar.Visible = false;
            Text = Application.ProductName + " " + Application.ProductVersion;
            RaceVoice.LoadRacialVoiceInfo();
            RefreshRacialChoices();
            scdGenerator = new SCDGenerator();
            emoteFilePickers = new List<FilePicker>() {
                surprised,
                angry,
                furious,
                cheer,
                doze,
                fume,
                huh,
                chuckle,
                laugh,
                no,
                stretch,
                upset,
                yes,
                happy,
                unknown1,
                unknown2};

            battleFilePickers = new List<FilePicker>() {
                battle1,
                battle2,
                battle3,
                battle4,
                battle5,
                battle6,
                battle7,
                battle8,
                battle9,
                battle10,
                battle11,
                battle12,
                battle13,
                battle14,
                battle15,
                battle16
            };

            authorInformation = new List<TextBox>() {
                modNameTextBox,
                modAuthorTextBox,
                modDescriptionTextBox,
                modWebsiteTextBox,
                modVersionTextBox,
            };
            TopMost = false;
        }

        private void CleanDirectory() {
            foreach (string file in Directory.GetFiles(Application.StartupPath)) {
                if (file.Contains("WebView2") || file.Contains(".zip") || file.Contains(".pdb") || file.Contains(".config") || file.Contains(".xml") || file.Contains(".log") || file.Contains(".tmp") || file.Contains("ZipExtractor")) {
                    try {
                        File.Delete(file);
                    } catch {

                    }
                }
            }
        }

        void RefreshRacialChoices() {
            raceListComboBox.Items.Clear();
            foreach (RaceVoice voices in RaceVoice.RacialList) {
                raceListComboBox.Items.Add(voices.RaceName);
            }
            sexListComboBox.SelectedIndex = 0;
            raceListComboBox.SelectedIndex = 0;
            voiceListComboBox.SelectedIndex = 0;
        }

        private void PickVoiceDump() {
            bool dontLoad = false;
            MessageBox.Show(@"Please select the folder with your dumped voice files. Should be under ""vo_emote"".", Text);
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                dumpFilePath = openFileDialog.SelectedPath;
            } else {
                MessageBox.Show("No dumped voice folder selected", Text);
                dontLoad = true;
            }
            if (!dontLoad) {
                hasSaved = false;
                missingFIleList.Items.Clear();
                if (dumpFiles != null) {
                    dumpFiles.Clear();
                }
                dumpFiles = new List<string>();
                dumpFiles.AddRange(Directory.GetFiles(dumpFilePath));
                if (secondaryKnownFileList != null) {
                    secondaryKnownFileList.Clear();
                }
                secondaryKnownFileList = new List<string>();
                int startValue = 7301000;
                int index = 0;
                int attempts = (dumpFiles.Count / 16);
                bool firstUnfound = false;
                int foundVoices = 0;
                int unfoundVoices = 0;
                for (int counter = 0; counter <= attempts; counter++) {
                    bool itemsNotFound = false;
                    for (int emoteCount = 0; emoteCount <= 15; emoteCount++) {
                        string fileName = (startValue + emoteCount) + "";
                        string name = ListContainsName(dumpFiles, fileName);
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
                        //startNumberGuess.Items.Add(startValue);
                        unfoundVoices++;
                    } else {
                        foundNamesList.Items.Add("----------------");
                        //startNumber.Items.Add(startValue);
                        foundVoices++;
                        secondaryKnownFileList.Add("");
                    }
                    startValue += 1000;
                }
                lostFileListPaths = new List<string>();
                while (index < dumpFiles.Count) {
                    lostFileList.Items.Add(Path.GetFileName(dumpFiles[index++]));
                    lostFileListPaths.Add(dumpFiles[index++]);
                }
                MessageBox.Show("Found " + foundVoices + " voices. Was not able to find " + unfoundVoices + " voices.", Text);
                if (missingFIleList.Items.Count > 0) {
                    MessageBox.Show(missingFIleList.Items.Count + @" items do not have a known filename. Check ""Missing Names"" list to help with you guesswork", Text);
                }
            }
        }

        private void ExportEmoteFiles(int startValue) {
            int i = 0;
            foreach (FilePicker file in emoteFilePickers) {
                if (!string.IsNullOrEmpty(file.FilePath.Text)) {
                    if (!file.UseGameFileCheckBox.Checked) {
                        string fileName = (startValue + i) + "";
                        if (firstDone) {
                            fileReplacementPaths += ",\r\n" + @"       ""sound/voice/vo_emote/" + fileName + @".scd"": ""sound\\voice\\vo_emote\\" + file.Name + @".scd""";
                        } else {
                            fileReplacementPaths += @"""sound/voice/vo_emote/" + fileName + @".scd"": ""sound\\voice\\vo_emote\\" + file.Name + @".scd""";
                            firstDone = true;
                        }
                    } else {
                        string fileName = (startValue + i) + "";
                        if (firstDone2) {
                            fileSwapPaths += ",\r\n" + @"       ""sound/voice/vo_emote/" + fileName + @".scd"": """ + file.FilePath.Text + @"""";
                        } else {
                            fileSwapPaths += @"""sound/voice/vo_emote/" + fileName + @".scd"": """ + file.FilePath.Text + @"""";
                            firstDone2 = true;
                        }
                    }
                }
                i++;
            }
        }

        private void ExportJson() {
            string jsonText = @"{
  ""Name"": """",
  ""Priority"": 0,
  ""Files"": {
       " + fileReplacementPaths + @"
  },
  ""FileSwaps"": {
       " + fileSwapPaths + @"
  },
  ""Manipulations"": []
}";
            if (jsonFilepath != null) {
                using (StreamWriter writer = new StreamWriter(jsonFilepath)) {
                    writer.WriteLine(jsonText);
                }
            }
        }

        private void ExportMeta() {
            string metaText = @"{
  ""FileVersion"": 3,
  ""Name"": """ + (!string.IsNullOrEmpty(modNameTextBox.Text) ? modNameTextBox.Text : _defaultModName) + @""",
  ""Author"": """ + (!string.IsNullOrEmpty(modAuthorTextBox.Text) ? modAuthorTextBox.Text : _defaultAuthor) + @""",
  ""Description"": """ + (!string.IsNullOrEmpty(modDescriptionTextBox.Text) ? modDescriptionTextBox.Text : _defaultDescription) + (battleVoicesInUse ? _descriptionBattleVoiceDisclaimer : "") + @""",
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

        private void ConfigurePenumbraModFolder() {
            MessageBox.Show(@"Please configure where your penumbra mods folder is, we will remember it for all future exports. This should be where you have penumbra set to use mods.", Text);
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            if (folderSelect.ShowDialog() == DialogResult.OK) {
                penumbraModPath = folderSelect.SelectedPath;
                WritePenumbraPath(penumbraModPath);
            }
        }

        private bool GetFilePaths() {
            if (string.IsNullOrEmpty(penumbraModPath)) {
                ConfigurePenumbraModFolder();
            }
            if (string.IsNullOrEmpty(modNameTextBox.Text)) {
                MessageBox.Show(@"Please enter a valid mod name", Text);
                return false;
            }
            string newModPath = Path.Combine(penumbraModPath, modNameTextBox.Text + @"\");
            if (string.IsNullOrEmpty(exportFilePathEmote) || !exportFilePathEmote.Contains(newModPath)) {
                exportFilePathEmote = Path.Combine(newModPath, @"sound\voice\vo_emote");
                exportFilePathBattle = Path.Combine(newModPath, @"sound\voice\vo_battle");
                Directory.CreateDirectory(exportFilePathEmote);
                Directory.CreateDirectory(exportFilePathBattle);
                jsonFilepath = Path.Combine(newModPath, "default_mod.json");
                metaFilePath = Path.Combine(newModPath, "meta.json");
                if (File.Exists(jsonFilepath)) {
                    switch (MessageBox.Show(@"Existing mod configuration detected. Continue?", Text, MessageBoxButtons.YesNo)) {
                        case DialogResult.Yes:
                            return true;
                        case DialogResult.No:
                            exportFilePathEmote = null;
                            exportFilePathBattle = null;
                            jsonFilepath = null;
                            metaFilePath = null;
                            return false;
                    }
                }
            }
            return true;
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

        private void sCDCreatorToolStripMenuItem_Click(object sender, EventArgs e) {
            SCDCreator sCDCreator = new SCDCreator();
            sCDCreator.Form = this;
            sCDCreator.ShowDialog();
        }

        private void changeVoiceDumpToolStripMenuItem_Click(object sender, EventArgs e) {
            PickVoiceDump();
        }

        private void pickExportFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            ConfigurePenumbraModFolder();
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
                    string emoteVoiceValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                    string battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                    int emote = int.Parse(emoteVoiceValue);
                    if (!emoteVoicesToReplace.Contains(emote)) {
                        AddReplacementValues(emote, battleVoiceValue);
                    } else {
                        MessageBox.Show("This voice has already been added for replacement.", Text);
                    }
                    break;
                case 1:
                    emoteVoiceValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(emoteVoiceValue)) {
                        emote = int.Parse(emoteVoiceValue);
                        if (!emoteVoicesToReplace.Contains(emote)) {
                            AddReplacementValues(emote, battleVoiceValue);
                        } else {
                            MessageBox.Show("This voice has already been added for replacement.", Text);
                        }
                    } else {

                    }
                    break;
            }
        }

        private void AddReplacementValues(int emote, string battle) {
            hasSaved = false;
            emoteVoicesToReplace.Add(emote);
            if (battle != null) {
                battleVoicesToReplace.Add(battle);
            }
            string text = "Character Voice: " + emote;
            foreach (string raceValue in RaceVoice.RacesToVoice[emote + ""]) {
                text += " | " + raceValue;
            }
            voiceReplacementList.Items.Add(text);
        }

        private void easyGenerateButton_Click(object sender, EventArgs e) {
            fileReplacementPaths = "";
            fileSwapPaths = "";
            exportProgressBar.Visible = true;
            exportProgressBar.Value = 0;
            exportProgressBar.Maximum = emoteFilePickers.Count + battleFilePickers.Count;
            bool canContinue = true;
            canContinue = GetFilePaths();
            if (canContinue) {
                if (!string.IsNullOrEmpty(savePath)) {
                    SaveProject(savePath);
                }
                if (!string.IsNullOrEmpty(exportFilePathEmote)) {
                    firstDone = false;
                    firstDone2 = false;
                    TopMost = true;
                    foreach (FilePicker value in emoteFilePickers) {
                        if (File.Exists(value.FilePath.Text)) {
                            if (!Directory.Exists(exportFilePathEmote)) {
                                Directory.CreateDirectory(exportFilePathEmote);
                            }
                            string inputPath = value.FilePath.Text;
                            string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");
                            Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + inputPath + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + tempPath + @""""}");
                            while (SCDGenerator.IsFileLocked(tempPath)) { };
                            InjectSCDFiles(Path.Combine(Application.StartupPath, @"res\scd\emote.scd"), exportFilePathEmote, value.Name, new List<string>() { tempPath });
                            File.Delete(tempPath);
                        } else if (!string.IsNullOrWhiteSpace(value.FilePath.Text) && !value.UseGameFileCheckBox.Checked) {
                            MessageBox.Show(@"Please check that file path in """ + value.Name + @""" is valid! Skipping.");
                        }
                        exportProgressBar.Increment(1);
                        exportProgressBar.Refresh();
                    }
                    foreach (int value in emoteVoicesToReplace) {
                        ExportEmoteFiles(value);
                    }
                    ExportBattleFiles();
                    ExportJson();
                    ExportMeta();
                    BringToFront();
                    MessageBox.Show(@"Export Complete", Text);
                    TopMost = false;
                }
            } else {
                MessageBox.Show(@"Export Cancelled", Text);
            }
            exportProgressBar.Visible = false;
        }

        private void ExportBattleFiles() {
            battleVoicesInUse = false;
            List<string> list = new List<string>();
            List<string> alreadyProcessed = new List<string>();
            int countedNull = 0;
            if (!voiceSwapBattleVoices.Checked) {
                bool detectedEmptyField = false;
                for (int count = 0; count < 16; count++) {
                    if (!string.IsNullOrEmpty(battleFilePickers[count].FilePath.Text)) {
                        string tempPath = Path.Combine(Path.GetDirectoryName(battleFilePickers[count].FilePath.Text), Guid.NewGuid() + ".wav");
                        Process.Start(Path.Combine(Application.StartupPath, @"res\ffmpeg.exe"), $"-i {@"""" + battleFilePickers[count].FilePath.Text + @""""} -f wav -acodec adpcm_ms -block_size 256 -ac 1 {@"""" + tempPath + @""""}");
                        while (SCDGenerator.IsFileLocked(tempPath)) { };
                        list.Add(tempPath);
                    } else {
                        list.Add(null);
                        countedNull++;
                        detectedEmptyField = true;
                    }
                    exportProgressBar.Increment(1);
                    exportProgressBar.Refresh();
                }
                // int battleVoiceCount = 0;

                if (countedNull < battleFilePickers.Count) {
                    battleVoicesInUse = true;
                    foreach (string value in battleVoicesToReplace) {
                        string path = Path.Combine(Application.StartupPath, @"res\scd\" + value + ".scd");
                        if (!alreadyProcessed.Contains(value)) {
                            try {
                                InjectSCDFiles(path, exportFilePathBattle, value, list);
                                if (firstDone) {
                                    fileReplacementPaths += ",\r\n" + @"       ""sound/voice/vo_battle/" + value + @".scd"": ""sound\\voice\\vo_battle\\" + value + @".scd""";
                                } else {
                                    fileReplacementPaths += @"""sound/voice/vo_battle/" + value + @".scd"": ""sound\\voice\\vo_emote\\" + value + @".scd""";
                                    firstDone = true;
                                }
                            } catch {
                                fileReplacementPaths += ",\r\n" + @"       ""sound/voice/vo_battle/" + value + @".scd"": ""sound\\voice\\vo_battle\\" + value + @".scd (Missing Source SCD)""";
                            }
                            alreadyProcessed.Add(value);
                        }
                    }
                    for (int count = 0; count < 16; count++) {
                        if (File.Exists((list[count]))){
                            File.Delete(list[count]);
                        }
                    }
                    if (detectedEmptyField) {
                        MessageBox.Show(@"Warning: You have not assigned a battle sound for every field. Due to the way battle sounds work, any missing sounds will play silence.", Text);
                    }
                }
            } else {
                foreach (string value in battleVoicesToReplace) {
                    battleVoicesInUse = true;
                    if (!alreadyProcessed.Contains(value)) {
                        if (firstDone2) {
                            fileSwapPaths += ",\r\n" + @"       ""sound/voice/vo_battle/" + value + @".scd"": """ + "sound/voice/vo_battle/" + battleVoiceToSwapWith + ".scd" + @"""";
                        } else {
                            fileSwapPaths += @"""sound/voice/vo_battle/" + value + @".scd"": """ + "sound/voice/vo_battle/" + battleVoiceToSwapWith + ".scd" + @"""";
                            firstDone2 = true;
                        }
                    }
                    exportProgressBar.Increment(1);
                    exportProgressBar.Refresh();
                }
                exportProgressBar.Value = exportProgressBar.Maximum;
            }
        }

        private void InjectSCDFiles(string input, string output, string name, List<string> list) {
            using (FileStream fileStream = new FileStream(input, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fileStream)) {
                    ScdFile file = new ScdFile(reader);
                    int i = 0;
                    foreach (ScdAudioEntry entry in file.Audio) {
                        if (entry.Format == SscfWaveFormat.MsAdPcm) {
                            string path = list[i++];
                            if (!string.IsNullOrEmpty(path)) {
                                ScdFile.Import(path, entry);
                            }
                        }
                    }
                    if (!Directory.Exists(exportFilePathBattle)) {
                        Directory.CreateDirectory(exportFilePathBattle);
                    }
                    using (FileStream exportStream = new FileStream(Path.Combine(output, name + ".scd"), FileMode.Create, FileAccess.Write)) {
                        using (BinaryWriter writer = new BinaryWriter(exportStream)) {
                            file.Write(writer);
                        }
                    }
                }
            }
        }

        private void clearListButton_Click(object sender, EventArgs e) {
            emoteVoicesToReplace.Clear();
            battleVoicesToReplace.Clear();
            voiceReplacementList.Items.Clear();
            hasSaved = false;
        }

        private void removeFromList_Click(object sender, EventArgs e) {
            if (voiceReplacementList.Items.Count > 0) {
                if (voiceReplacementList.SelectedIndex > -1) {
                    int index = voiceReplacementList.SelectedIndex;
                    emoteVoicesToReplace.RemoveAt(index);
                    battleVoicesToReplace.RemoveAt(index);
                    voiceReplacementList.Items.RemoveAt(index);
                    voiceReplacementList.SelectedIndex = -1;
                }
            }
            hasSaved = false;
        }

        private void tabManager_Selecting(object sender, TabControlCancelEventArgs e) {
            if (!alreadyShown) {
                missingFIleList.Items.Clear();
                if (MessageBox.Show(@"Do you have voices dumped via FFXIVExplorer or an equivalent tool as .wav files?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    PickVoiceDump();
                } else {
                    MessageBox.Show("Voice guessing will be hindered without a dump folder selected.", Text);
                }
                alreadyShown = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            CleanSlate();
        }
        private bool CleanSlate() {
            if (!hasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (savePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                savePath = saveFileDialog.FileName;
                            }
                        }
                        if (!string.IsNullOrEmpty(savePath)) {
                            SaveProject(savePath);
                            NewProject();
                            return true;
                        }
                        break;
                    case DialogResult.No:
                        NewProject();
                        return true;
                }
            } else {
                NewProject();
                return true;
            }
            return false;
        }
        private void NewProject() {
            hasSaved = true;
            savePath = null;
            exportFilePathEmote = null;
            jsonFilepath = null;
            metaFilePath = null;
            voiceSwapBattleVoices.Checked = false;
            battleVoiceToSwapWith = null;
            foreach (TextBox authorInfo in authorInformation) {
                authorInfo.Text = "";
            }
            modNameTextBox.Text = _defaultModName;
            modAuthorTextBox.Text = _defaultAuthor;
            modDescriptionTextBox.Text = _defaultDescription;
            modWebsiteTextBox.Text = _defaultWebsite;
            modVersionTextBox.Text = "0.0.0";
            foreach (FilePicker filePicker in emoteFilePickers) {
                filePicker.FilePath.Text = "";
            }
            foreach (FilePicker filePicker in battleFilePickers) {
                filePicker.FilePath.Text = "";
            }
            emoteVoicesToReplace.Clear();
            battleVoicesToReplace.Clear();
            voiceReplacementList.Items.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                savePath = saveFileDialog.FileName;
                SaveProject(savePath);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (CleanSlate()) {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    savePath = openFileDialog.FileName;
                    OpenProjectV2(savePath);
                }
                hasSaved = true;
            }
        }

        public void SaveProject(string path) {
            using (StreamWriter writer = new StreamWriter(path)) {
                writer.WriteLine(2);
                // Write author info
                writer.WriteLine(authorInformation.Count);
                foreach (TextBox authorInfo in authorInformation) {
                    writer.WriteLine(authorInfo.Text);
                }
                // Write chosen sound files
                writer.WriteLine(emoteFilePickers.Count);
                foreach (FilePicker filePicker in emoteFilePickers) {
                    writer.WriteLine(filePicker.FilePath.Text);
                }
                writer.WriteLine(battleFilePickers.Count);
                foreach (FilePicker filePicker in battleFilePickers) {
                    writer.WriteLine(filePicker.FilePath.Text);
                }
                // Write emote voices to replace
                writer.WriteLine(emoteVoicesToReplace.Count);
                foreach (int voiceToReplace in emoteVoicesToReplace) {
                    writer.WriteLine(voiceToReplace);
                }
                // Write battle voices to replace
                writer.WriteLine(battleVoicesToReplace.Count);
                foreach (string voiceToReplace in battleVoicesToReplace) {
                    writer.WriteLine(voiceToReplace);
                }
                writer.WriteLine(dumpFilePath);
                writer.WriteLine(exportFilePathEmote);
                writer.WriteLine(exportFilePathBattle);
                writer.WriteLine(jsonFilepath);
                writer.WriteLine(metaFilePath);
                writer.WriteLine(battleVoiceToSwapWith);
            }
            hasSaved = true;
        }

        public void WritePenumbraPath(string path) {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            using (StreamWriter writer = new StreamWriter(Path.Combine(dataPath, @"PenumbraPath.config"))) {
                writer.WriteLine(path);
            }
        }
        public void GetPenumbraPath() {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            string lastDataPath = Path.Combine(dataPath, @"0.0.1.5\");
            if (Directory.Exists(lastDataPath)) {
                dataPath = lastDataPath;
            }
            string path = Path.Combine(dataPath, @"PenumbraPath.config");
            if (File.Exists(path)) {
                using (StreamReader reader = new StreamReader(path)) {
                    penumbraModPath = reader.ReadLine();
                }
            }
        }

        public void OpenProjectV2(string path) {
            try {
                List<int> emoteList = new List<int>();
                List<string> battleList = new List<string>();
                using (StreamReader reader = new StreamReader(path)) {
                    int version = int.Parse(reader.ReadLine());
                    int itemCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++) {
                        authorInformation[i].Text = reader.ReadLine();
                    }
                    itemCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++) {
                        emoteFilePickers[i].FilePath.Text = reader.ReadLine();
                    }
                    itemCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++) {
                        if (i < battleFilePickers.Count) {
                            battleFilePickers[i].FilePath.Text = reader.ReadLine();
                        } else {
                            reader.ReadLine();
                        }
                    }
                    itemCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++) {
                        emoteList.Add(int.Parse(reader.ReadLine()));
                    }
                    itemCount = int.Parse(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++) {
                        battleList.Add(reader.ReadLine());
                    }
                    dumpFilePath = reader.ReadLine();
                    exportFilePathEmote = reader.ReadLine();
                    exportFilePathBattle = reader.ReadLine();
                    jsonFilepath = reader.ReadLine();
                    metaFilePath = reader.ReadLine();
                    battleVoiceToSwapWith = reader.ReadLine();

                    if (!string.IsNullOrEmpty(battleVoiceToSwapWith)) {
                        suppressVoiceSwapBattleVoiceChecked = true;
                        voiceSwapBattleVoices.Checked = true;
                    } else {
                        voiceSwapBattleVoices.Checked = false;
                    }

                    for (int i = 0; i < emoteList.Count; i++) {
                        AddReplacementValues(emoteList[i], i < battleList.Count && battleList.Count > 0 ? battleList[i] : "");
                    }
                }
            } catch {
                OpenProjectLegacy(path);
            }
            hasSaved = true;
        }
        public void OpenProjectLegacy(string path) {
            using (StreamReader reader = new StreamReader(path)) {
                int itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    authorInformation[i].Text = reader.ReadLine();
                }
                itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    emoteFilePickers[i].FilePath.Text = reader.ReadLine();
                }
                itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    AddReplacementValues(int.Parse(reader.ReadLine()), null);
                }
                dumpFilePath = reader.ReadLine();
                exportFilePathEmote = reader.ReadLine();
                jsonFilepath = reader.ReadLine();
                metaFilePath = reader.ReadLine();
            }
            hasSaved = true;
        }

        private void quickImportButton_Click(object sender, EventArgs e) {
            MessageBox.Show("To use quick import successfully, name your sound files exactly after the emote they intend to replace together in a seperated folder.", Text);
            FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK) {
                foreach (string filename in Directory.GetFiles(folderSelectDialog.SelectedPath)) {
                    foreach (FilePicker filePicker in emoteFilePickers) {
                        if (Path.GetFileName(filename).ToLower().Contains(filePicker.Name)) {
                            filePicker.SetFilePath(filename);
                        }
                    }
                    foreach (FilePicker filePicker in battleFilePickers) {
                        if (Path.GetFileName(filename).ToLower().Contains(filePicker.Name)) {
                            filePicker.SetFilePath(filename);
                        }
                    }
                    hasSaved = false;
                }
            }
        }

        private void modNameTextbox_TextChanged(object sender, EventArgs e) {
            hasSaved = false;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (!hasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (savePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                savePath = saveFileDialog.FileName;
                            }
                        }
                        if (savePath != null) {
                            SaveProject(savePath);
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keys) {
            switch (keys) {
                case Keys.S | Keys.Control:
                    // ... Process Shift+Ctrl+Alt+B ...
                    Save();
                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.S) {
                Save();
            }
        }

        private void Save() {
            if (savePath == null) {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    savePath = saveFileDialog.FileName;
                }
            }
            if (savePath != null) {
                SaveProject(savePath);
            }
        }

        private void addRaceButton_Click(object sender, EventArgs e) {
            bool voiceAlreadyInList = false;
            int voiceCount = 0;
            for (int i = 0; i < 12; i++) {
                switch (sexListComboBox.SelectedIndex) {
                    case 0:
                        string emoteVoiceValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Masculine[i];
                        string battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Masculine[i];
                        int value = int.Parse(emoteVoiceValue);
                        if (!emoteVoicesToReplace.Contains(value)) {
                            AddReplacementValues(value, battleVoiceValue);
                        } else {
                            voiceAlreadyInList = true;
                            voiceCount++;
                        }
                        break;
                    case 1:
                        emoteVoiceValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Feminine[i];
                        battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Feminine[i];
                        if (!string.IsNullOrWhiteSpace(emoteVoiceValue)) {
                            int value2 = int.Parse(emoteVoiceValue);
                            if (!emoteVoicesToReplace.Contains(value2)) {
                                AddReplacementValues(value2, battleVoiceValue);
                            } else {
                                voiceAlreadyInList = true;
                            }
                        } else {
                            MessageBox.Show("Theres is no voice to replace.", Text);
                            voiceCount++;
                        }
                        break;
                }
            }
            if (voiceAlreadyInList) {
                MessageBox.Show($"{voiceCount} voices were already added to the list. Anything not already added has been added.", Text);
            }
        }

        private void quickSwapButton_Click(object sender, EventArgs e) {
            MessageBox.Show(@"""Quick Swap"" lets you quickly pick an in game voice that you want to swap with another.", Text);
            VoiceSelection voiceSelection = new VoiceSelection();
            if (voiceSelection.ShowDialog() == DialogResult.OK) {
                foreach (FilePicker filePicker in emoteFilePickers) {
                    filePicker.SetToGameFile(voiceSelection.SelectedVoiceEmote);
                }
                battleVoiceToSwapWith = voiceSelection.SelectedVoiceBattle;
                suppressVoiceSwapBattleVoiceChecked = true;
                voiceSwapBattleVoices.Checked = true;
            }
        }

        private void battleVoiceClips_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void multiSCDFile_Click(object sender, EventArgs e) {
            //battleVoiceClips.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SCD File|*.scd;";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                    using (BinaryReader reader = new BinaryReader(fileStream)) {
                        ScdFile file = new ScdFile(reader, false);
                        foreach (ScdAudioEntry sound in file.Audio) {
                            // battleVoiceClips.Items.Add(sound.Format + " " + sound.DataLength + " " + sound.SampleRate + " " + sound.NumChannels + " ");
                        }
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void voiceSwapBattleVoices_CheckedChanged(object sender, EventArgs e) {
            if (!suppressVoiceSwapBattleVoiceChecked) {
                if (voiceSwapBattleVoices.Checked) {
                    VoiceSelection voiceSelection = new VoiceSelection();
                    if (voiceSelection.ShowDialog() == DialogResult.OK) {
                        battleVoiceToSwapWith = voiceSelection.SelectedVoiceBattle;
                    } else {
                        MessageBox.Show(@"No replacement was selected, unchecking", Text);
                        voiceSwapBattleVoices.Checked = false;
                    }
                } else {
                    battleVoiceToSwapWith = null;
                }
            } else {
                suppressVoiceSwapBattleVoiceChecked = false;
            }
        }

        private void voiceTabs_SelectedIndexChanged(object sender, EventArgs e) {
            if (!suppressNextVoiceTabWarning) {
                if (voiceSwapBattleVoices.Checked) {
                    suppressNextVoiceTabWarning = true;
                    voiceTabs.SelectedIndex = 0;
                    MessageBox.Show(@"Battle voices cannot be edited while in voice swap mode. If you intend to edit battle voices please disable it.", Text);
                }
            } else {
                suppressNextVoiceTabWarning = false;
            }
        }
    }
}
