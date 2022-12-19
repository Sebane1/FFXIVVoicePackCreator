using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VfxEditor.ScdFormat;

namespace FFXIVVoicePackCreator {
    public partial class MainWindow : Form {
        private string exportFilePath;
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
        private List<int> voicesToReplace = new List<int>();
        private bool alreadyShown;
        private List<FilePicker> filePickers = new List<FilePicker>();
        private List<TextBox> authorInformation;
        private string savePath;
        private bool hasSaved = true;
        private bool firstDone2;

        public static string _defaultModName = "";
        public static string _defaultAuthor = "FFXIV Voice Pack Creator";
        public static string _defaultDescription = "Exported by FFXIV Voice Pack Creator";
        public static string _defaultWebsite = "https://github.com/Sebane1/FFXIVVoicePackCreator";
        private string penumbraModPath;

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
            filePickers = new List<FilePicker>() {
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
            FolderSelectDialog openFileDialog = new FolderSelectDialog();
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

        private void ExportFiles(int startValue) {
            int i = 0;
            foreach (FilePicker file in filePickers) {
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
  ""Description"": """ + (!string.IsNullOrEmpty(modDescriptionTextBox.Text) ? modDescriptionTextBox.Text : _defaultDescription) + @""",
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
            FolderSelectDialog folderSelect = new FolderSelectDialog();
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
            exportFilePath = Path.Combine(newModPath, @"sound\voice\vo_emote");
            Directory.CreateDirectory(exportFilePath);
            jsonFilepath = Path.Combine(newModPath, "default_mod.json");
            metaFilePath = Path.Combine(newModPath, "meta.json");
            if (File.Exists(jsonFilepath)) {
                switch (MessageBox.Show(@"Existing mod configuration detected. Continue?", Text, MessageBoxButtons.YesNo)) {
                    case DialogResult.Yes:
                        return true;
                    case DialogResult.No:
                        exportFilePath = null;
                        jsonFilepath = null;
                        metaFilePath = null;
                        return false;
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
                    int value = int.Parse(RaceVoice.RacialList[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex]);
                    if (!voicesToReplace.Contains(value)) {
                        AddReplacementValue(value);
                    } else {
                        MessageBox.Show("This voice has already been added for replacement.", Text);
                    }
                    break;
                case 1:
                    string stringValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(stringValue)) {
                        int value2 = int.Parse(stringValue);
                        if (!voicesToReplace.Contains(value2)) {
                            AddReplacementValue(value2);
                        } else {
                            MessageBox.Show("This voice has already been added for replacement.", Text);
                        }
                    } else {
                        MessageBox.Show("Theres is no voice to replace.", Text);
                    }
                    break;
            }
        }

        private void AddReplacementValue(int value) {
            hasSaved = false;
            voicesToReplace.Add(value);
            string text = "Character Voice: " + value;
            foreach (string raceValue in RaceVoice.RacesToVoice[value + ""]) {
                text += " | " + raceValue;
            }
            voiceReplacementList.Items.Add(text);
        }

        private void easyGenerateButton_Click(object sender, EventArgs e) {
            fileReplacementPaths = "";
            fileSwapPaths = "";
            exportProgressBar.Visible = true;
            exportProgressBar.Value = 0;
            exportProgressBar.Maximum = filePickers.Count;
            bool canContinue = true;

            if (string.IsNullOrEmpty(exportFilePath)) {
                canContinue = GetFilePaths();
            }
            if (canContinue) {
                if (!string.IsNullOrEmpty(savePath)) {
                    SaveProject(savePath);
                }
                if (!string.IsNullOrEmpty(exportFilePath)) {
                    firstDone = false;
                    firstDone2 = false;
                    TopMost = true;
                    foreach (FilePicker value in filePickers) {
                        if (File.Exists(value.FilePath.Text)) {
                            if (!Directory.Exists(exportFilePath)) {
                                Directory.CreateDirectory(exportFilePath);
                            }
                            scdGenerator.ConvertAndGenerateMSADCPM(value.FilePath.Text, Path.Combine(exportFilePath, value.Name + ".scd"));
                        } else if (!string.IsNullOrWhiteSpace(value.FilePath.Text) && !value.UseGameFileCheckBox.Checked) {
                            MessageBox.Show(@"Please check that file path in """ + value.Name + @""" is valid! Skipping.");
                        }
                        exportProgressBar.Increment(1);
                        exportProgressBar.Refresh();
                    }
                    foreach (int value in voicesToReplace) {
                        ExportFiles(value);
                    }
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

        private void clearListButton_Click(object sender, EventArgs e) {
            voicesToReplace.Clear();
            voiceReplacementList.Items.Clear();
            hasSaved = false;
        }

        private void removeFromList_Click(object sender, EventArgs e) {
            if (voiceReplacementList.Items.Count > 0) {
                if (voiceReplacementList.SelectedIndex > -1) {
                    voicesToReplace.RemoveAt(voiceReplacementList.SelectedIndex);
                    voiceReplacementList.Items.RemoveAt(voiceReplacementList.SelectedIndex);
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
            exportFilePath = null;
            jsonFilepath = null;
            metaFilePath = null;
            foreach (TextBox authorInfo in authorInformation) {
                authorInfo.Text = "";
            }
            modNameTextBox.Text = _defaultModName;
            modAuthorTextBox.Text = _defaultAuthor;
            modDescriptionTextBox.Text = _defaultDescription;
            modWebsiteTextBox.Text = _defaultWebsite;
            foreach (FilePicker filePicker in filePickers) {
                filePicker.FilePath.Text = "";
            }
            voicesToReplace.Clear();
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
                    OpenProject(savePath);
                }
                hasSaved = true;
            }
        }

        public void SaveProject(string path) {
            using (StreamWriter writer = new StreamWriter(path)) {
                // Write author info
                writer.WriteLine(authorInformation.Count);
                foreach (TextBox authorInfo in authorInformation) {
                    writer.WriteLine(authorInfo.Text);
                }
                // Write chosen sound files
                writer.WriteLine(filePickers.Count);
                foreach (FilePicker filePicker in filePickers) {
                    writer.WriteLine(filePicker.FilePath.Text);
                }
                // Write voices to replace
                writer.WriteLine(voicesToReplace.Count);
                foreach (int voiceToReplace in voicesToReplace) {
                    writer.WriteLine(voiceToReplace);
                }
                writer.WriteLine(dumpFilePath);
                writer.WriteLine(exportFilePath);
                writer.WriteLine(jsonFilepath);
                writer.WriteLine(metaFilePath);
            }
            hasSaved = true;
        }

        public void WritePenumbraPath(string path) {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Application.UserAppDataPath, @"PenumbraPath.config"))) {
                writer.WriteLine(path);
            }
        }
        public void GetPenumbraPath() {
            string path = Path.Combine(Application.UserAppDataPath, @"PenumbraPath.config");
            if (File.Exists(path)) {
                using (StreamReader reader = new StreamReader(path)) {
                    penumbraModPath = reader.ReadLine();
                }
            }
        }

        public void OpenProject(string path) {
            using (StreamReader reader = new StreamReader(path)) {
                int itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    authorInformation[i].Text = reader.ReadLine();
                }
                itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    filePickers[i].FilePath.Text = reader.ReadLine();
                }
                itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    AddReplacementValue(int.Parse(reader.ReadLine()));
                }
                dumpFilePath = reader.ReadLine();
                exportFilePath = reader.ReadLine();
                jsonFilepath = reader.ReadLine();
                metaFilePath = reader.ReadLine();
            }
            hasSaved = true;
        }

        private void quickImportButton_Click(object sender, EventArgs e) {
            MessageBox.Show("To use quick import successfully, name your sound files exactly after the emote they intend to replace together in a seperated folder.", Text);
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK) {
                foreach (string filename in Directory.GetFiles(folderSelectDialog.SelectedPath)) {
                    foreach (FilePicker filePicker in filePickers) {
                        if (Path.GetFileName(filename).ToLower().Contains(filePicker.Name)) {
                            filePicker.SetFilePath(filename);
                            hasSaved = false;
                        }
                    }
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
                        int value = int.Parse(RaceVoice.RacialList[raceListComboBox.SelectedIndex].Masculine[i]);
                        if (!voicesToReplace.Contains(value)) {
                            AddReplacementValue(value);
                        } else {
                            voiceAlreadyInList = true;
                            voiceCount++;
                        }
                        break;
                    case 1:
                        string stringValue = RaceVoice.RacialList[raceListComboBox.SelectedIndex].Feminine[i];
                        if (!string.IsNullOrWhiteSpace(stringValue)) {
                            int value2 = int.Parse(stringValue);
                            if (!voicesToReplace.Contains(value2)) {
                                AddReplacementValue(value2);
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
                foreach (FilePicker filePicker in filePickers) {
                    filePicker.SetToGameFile(voiceSelection.SelectedVoice);
                }
            }
        }

        private void battleVoiceClips_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void multiSCDFile_Click(object sender, EventArgs e) {
            battleVoiceClips.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SCD File|*.scd;";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read)) {
                    using (BinaryReader reader = new BinaryReader(fileStream)) {
                        ScdFile file = new ScdFile(reader, false);
                        foreach (ScdAudioEntry sound in file.Audio) {
                            battleVoiceClips.Items.Add(sound.Format + " " + sound.DataLength + " " + sound.SampleRate + " " + sound.NumChannels + " ");
                        }
                    }
                }
            }
        }
    }
}
