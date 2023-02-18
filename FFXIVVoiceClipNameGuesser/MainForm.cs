using Anamnesis.Penumbra;
using AutoUpdaterDotNET;
using FFBardMusicPlayer.FFXIV;
using FFXIVVoicePackCreator.Json;
using FFXIVVoicePackCreator.VoiceSorting;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Shell;
using System.Xml.Linq;
using VfxEditor.ScdFormat;

namespace FFXIVVoicePackCreator {
    public partial class MainWindow : Form {
        private FFXIVHook hook = new FFXIVHook();

        private string newModPath;
        private string exportFilePathEmote;
        private string exportFilePathBattle;
        private string jsonFilepath;
        private string dumpFilePath;
        private string savePath;
        private string metaFilePath;
        private string penumbraModPath;
        private string battleVoiceToSwapWith;

        private Point startPos;
        private SCDGenerator scdGenerator;
        private List<int> emoteVoicesToReplace = new List<int>();
        private List<string> dumpFiles;
        private List<string> secondaryKnownFileList;
        private List<string> lostFileListPaths;
        private List<string> battleVoicesToReplace = new List<string>();
        private List<FilePicker> emoteFilePickers = new List<FilePicker>();
        private List<FilePicker> battleFilePickers = new List<FilePicker>();
        private List<TimeCodeData> timeCodeDataList;
        private List<TextBox> authorInformation;

        private bool alreadyShown;
        private bool hasSaved = true;
        private bool canDoDragDrop;

        public readonly string _defaultModName = "";
        public string _defaultAuthor = "FFXIV Voice Pack Creator";
        public readonly string _defaultDescription = "Exported by FFXIV Voice Pack Creator";
        public readonly string _descriptionBattleVoiceDisclaimer = "\\n\\nDISCLAIMER:\\nIt is no longer a requirement to separate battle voices to the Base Collection as of Penumbra v0.6.1.0";
        public string _defaultWebsite = "https://github.com/Sebane1/FFXIVVoicePackCreator";
        private readonly string _battleSoundTutorial = "Due to how Square Enix authored their voice files, battle sounds for each race range between 10 (Au Ra), 12 (Most Races), or 16 (Hrothgar and Viera) actual sound clips. Because of this you may not hear all the sounds you assign.\r\n\r\nThis tool tries its best to fit what it can depending on the space available. Assign your lines best to worst in each category, or whatever makes sense for your situation.";

        private bool suppressVoiceSwapBattleVoiceChecked;
        private bool battleVoicesInUse;
        private bool showedNewFeaturesPrompt;
        private int offset;
        private List<decimal> currentAudioTimings;
        private VoiceDescriptor selectedVoiceDescriptor;
        private bool foundInstance;

        public bool HasSaved {
            get => hasSaved; set {
                hasSaved = value;
                if (!hasSaved) {
                    Text = Application.ProductName + " " + Application.ProductVersion + (!string.IsNullOrWhiteSpace(savePath) ? $" ({savePath})*" : "*");
                } else {
                    Text = Application.ProductName + " " + Application.ProductVersion + (!string.IsNullOrWhiteSpace(savePath) ? $" ({savePath})" : "");
                }
            }
        }

        public string VersionText { get; private set; }
        public FFXIVHook Hook { get => hook; set => hook = value; }
        public VoiceDescriptor SelectedVoiceDescriptor { get => selectedVoiceDescriptor; set => selectedVoiceDescriptor = value; }
        public bool FoundInstance { get => foundInstance; set => foundInstance = value; }
        public bool IsRunningTest { get; internal set; }

        public MainWindow() {
            GetAuthorWebsite();
            GetAuthorName();
            InitializeComponent();
            RefreshFFXIVInstance();
            if (hook.Process != null) {
                VolumeMixer.SetApplicationMute(Hook.Process.Id, false);
            }
            modWebsiteTextBox.Text = _defaultWebsite;
            modAuthorTextBox.Text = _defaultAuthor;
        }

        private void RefreshFFXIVInstance() {
            var processes = new List<Process>(Process.GetProcessesByName("ffxiv_dx11"));
            foundInstance = false;
            if (processes.Count > 0) {
                foundInstance = true;
                Hook.Hook(processes[0], false);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            CleanDirectory();
            AutoScaleDimensions = new SizeF(96, 96);
            TopMost = true;
            GetPenumbraPath();
            exportProgressBar.Visible = false;
            VersionText = Application.ProductName + " " + Application.ProductVersion;
            Text = Application.ProductName + " " + Application.ProductVersion;
            InitializeVoiceData();
            CheckForCommandArguments();
        }

        private void InitializeVoiceData() {
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
                unused1,
                unused2};
            battleFilePickers = new List<FilePicker>() {
                attack1,
                attack2,
                attack3,
                attack4,
                attack5,
                attack6,
                hurt1,
                hurt2,
                hurt3,
                hurt4,
                hurt5,
                hurt6,
                death1,
                death2,
                extra1,
                extra2
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

        private void CheckForCommandArguments() {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                if (!string.IsNullOrWhiteSpace(args[1])) {
                    if (File.Exists(args[1]) && args[1].Contains(".ffxivsp")) {
                        savePath = args[1];
                        OpenProject(savePath);
                    }
                }
            }
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
            foreach (RaceVoice voices in RaceVoice.RacialListEmotes) {
                raceListComboBox.Items.Add(voices.RaceName);
            }
            sexListComboBox.SelectedIndex = 0;
            raceListComboBox.SelectedIndex = 0;
            voiceListComboBox.SelectedIndex = 0;
        }

        private void PickVoiceDump(bool forceNewPath = false) {
            bool dontLoad = false;
            if (!forceNewPath) {
                GetDumpPath();
            } else {
                dumpFilePath = null;
            }
            if (string.IsNullOrWhiteSpace(dumpFilePath)) {
                MessageBox.Show(@"Please select the folder with your dumped voice files. Should be under ""vo_emote"".", VersionText);
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    dumpFilePath = openFileDialog.SelectedPath;
                    WriteDumpPath(dumpFilePath);
                } else {
                    MessageBox.Show("No dumped voice folder selected", VersionText);
                    dontLoad = true;
                }
            }
            if (!dontLoad) {
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
            }
        }

        private void ExportEmoteFiles(int startValue, Option options) {
            int i = 0;
            if (!autoSyncCheckbox.Checked) {
                foreach (FilePicker file in emoteFilePickers) {
                    if (!string.IsNullOrEmpty(file.FilePath.Text)) {
                        string fileName = (startValue + i) + "";
                        if (!file.UseGameFileCheckBox.Checked) {
                            options.Files.Add(@"sound/voice/vo_emote/" + fileName + @".scd", "sound\\voice\\vo_emote\\" + file.Name + @".scd");
                        } else {
                            options.FileSwaps.Add("sound/voice/vo_emote/" + fileName + @".scd", file.FilePath.Text);
                        }
                    }
                    i++;
                }
            } else {
                foreach (FilePicker file in emoteFilePickers) {
                    if (!string.IsNullOrEmpty(file.FilePath.Text)) {
                        string fileName = (startValue + i) + "";
                        if (!file.UseGameFileCheckBox.Checked) {
                            VoiceDescriptor voiceDescriptor = RaceVoice.RacesToVoiceDescription[startValue + ""][0];
                            options.Files.Add(@"sound/voice/vo_emote/" + fileName + @".scd", "sound\\voice\\vo_emote\\" + file.Name +
                                "_" + voiceDescriptor.RaceName + "_" + voiceDescriptor.VoiceGender + @".scd");
                        } else {
                            options.FileSwaps.Add("sound/voice/vo_emote/" + fileName + @".scd", file.FilePath.Text);
                        }
                    }
                    i++;
                }
            }
        }

        private void ExportJson() {
            string jsonText = @"{
  ""Name"": """",
  ""Priority"": 0,
  ""Files"": { },
  ""FileSwaps"": { },
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

        private void ExportGroup(string path, Group group) {
            if (path != null) {
                if (group.Options.Count > 0) {
                    using (StreamWriter file = File.CreateText(path)) {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, group);
                    }
                }
            }
        }

        private void ConfigurePenumbraModFolder() {
            MessageBox.Show("Please configure where your penumbra mods folder is, we will remember it for all future exports. This should be where you have penumbra set to use mods.\r\n\r\nNote:\r\nAVOID MANUALLY CREATING ANY NEW FOLDERS IN YOUR PENUMBRA FOLDER, ONLY SELECT THE BASE FOLDER!", VersionText);
            FolderBrowserDialog folderSelect = new FolderBrowserDialog();
            if (folderSelect.ShowDialog() == DialogResult.OK) {
                penumbraModPath = folderSelect.SelectedPath;
                WritePenumbraPath(penumbraModPath);
            }
        }

        private void ConfigureVoiceDumpFolder() {
            WritePenumbraPath(dumpFilePath);
        }

        private bool GetFilePaths() {
            if (string.IsNullOrEmpty(penumbraModPath)) {
                ConfigurePenumbraModFolder();
            }
            if (string.IsNullOrEmpty(modNameTextBox.Text)) {
                MessageBox.Show(@"Please enter a valid mod name", VersionText);
                return false;
            }
            newModPath = Path.Combine(penumbraModPath, modNameTextBox.Text + @"\");
            if (Directory.Exists(newModPath)) {
                try {
                    Directory.Delete(newModPath, true);
                } catch {
                    MessageBox.Show(@"Failed to clean directory", VersionText);
                }
            }
            exportFilePathEmote = Path.Combine(newModPath, @"sound\voice\vo_emote");
            exportFilePathBattle = Path.Combine(newModPath, @"sound\voice\vo_battle");
            jsonFilepath = Path.Combine(newModPath, "default_mod.json");
            metaFilePath = Path.Combine(newModPath, "meta.json");
            Directory.CreateDirectory(exportFilePathEmote);
            Directory.CreateDirectory(exportFilePathBattle);
            if (string.IsNullOrEmpty(exportFilePathEmote) || !exportFilePathEmote.Contains(newModPath)) {
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
            Unused1,
            Unused2
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
            string path = secondaryKnownFileList[foundNamesList.SelectedIndex];
            if (!string.IsNullOrEmpty(path)) {
                ProcessStartInfo info = new ProcessStartInfo(path);
                info.UseShellExecute = true;
                Process.Start(info);
            }
        }

        private void sCDCreatorToolStripMenuItem_Click(object sender, EventArgs e) {
            SCDCreator sCDCreator = new SCDCreator();
            sCDCreator.Form = this;
            sCDCreator.ShowDialog();
        }

        private void changeVoiceDumpToolStripMenuItem_Click(object sender, EventArgs e) {
            PickVoiceDump(true);
        }

        private void pickExportFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            ConfigurePenumbraModFolder();
        }

        private void lostFileList_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (!string.IsNullOrEmpty(lostFileListPaths[lostFileList.SelectedIndex])) {
                ProcessStartInfo info = new ProcessStartInfo(lostFileListPaths[lostFileList.SelectedIndex]);
                info.UseShellExecute = true;
                Process.Start(info);
            }
        }

        private void addToVoiceListButton_Click(object sender, EventArgs e) {
            switch (sexListComboBox.SelectedIndex) {
                case 0:
                    string emoteVoiceValue = RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                    string battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Masculine[voiceListComboBox.SelectedIndex];
                    int emote = int.Parse(emoteVoiceValue);
                    if (!emoteVoicesToReplace.Contains(emote)) {
                        AddReplacementValues(emote, battleVoiceValue);
                    } else {
                        MessageBox.Show("This voice has already been added for replacement.", VersionText);
                    }
                    break;
                case 1:
                    emoteVoiceValue = RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Feminine[voiceListComboBox.SelectedIndex];
                    if (!string.IsNullOrWhiteSpace(emoteVoiceValue)) {
                        emote = int.Parse(emoteVoiceValue);
                        if (!emoteVoicesToReplace.Contains(emote)) {
                            AddReplacementValues(emote, battleVoiceValue);
                        } else {
                            MessageBox.Show("This voice has already been added for replacement.", VersionText);
                        }
                    } else {
                        MessageBox.Show("No such voice exists.", VersionText);
                    }
                    break;
            }
        }

        private void AddReplacementValues(int emote, string battle) {
            HasSaved = false;
            emoteVoicesToReplace.Add(emote);
            if (battle != null) {
                battleVoicesToReplace.Add(battle);
            }
            string text = "Character Voice: " + emote;
            foreach (VoiceDescriptor raceValue in RaceVoice.RacesToVoiceDescription[emote + ""]) {
                text += " | " + raceValue.VerboseDescription;
            }
            voiceReplacementList.Items.Add(text);
        }

        private void easyGenerateButton_Click(object sender, EventArgs e) {
            GetTimeCodeData();
            exportProgressBar.Visible = true;
            exportProgressBar.Value = 0;
            exportProgressBar.Maximum = (emoteFilePickers.Count * (autoSyncCheckbox.Checked ? timeCodeDataList.Count : 1)) + battleFilePickers.Count;
            bool canContinue = true;
            canContinue = GetFilePaths();
            if (canContinue) {
                if (!string.IsNullOrEmpty(savePath)) {
                    SaveProject(savePath);
                }
                if (!string.IsNullOrEmpty(exportFilePathEmote)) {
                    TopMost = true;
                    ExportSoundData();
                    List<Group> emoteGroups = new List<Group>();
                    List<string> emoteGroupPaths = new List<string>();
                    Group group = new Group("Emote Voice To Replace (Group 1)", "The emote voice you are replacing", 0, "Multi", 0);
                    emoteGroups.Add(group);
                    emoteGroupPaths.Add(Path.Combine(newModPath, $"group_001_{group.Name.ToLower()}.json"));
                    int i = 0;
                    foreach (int value in emoteVoicesToReplace) {
                        Option options = new Option(RaceVoice.RacesToVoiceDescription[value + ""][0].VerboseDescription, 0);
                        ExportEmoteFiles(value, options);
                        group.Options.Add(options);
                        if (i < 11) {
                            i++;
                        } else {
                            i = 0;
                            group = new Group($"Emote Voice To Replace (Group {emoteGroups.Count + 1})", "The emote voice you are replacing", 0, "Multi", 0);
                            emoteGroups.Add(group);
                            emoteGroupPaths.Add(Path.Combine(newModPath, $"group_0" + (emoteGroupPaths.Count < 9 ? "0" : "") + $"{emoteGroupPaths.Count + 1}_{group.Name.ToLower()}.json"));
                        }
                    }
                    offset = emoteGroupPaths.Count;
                    List<Group> battleGroups = new List<Group>();
                    List<string> battleGroupPaths = new List<string>();
                    ExportBattleFiles(battleGroups, battleGroupPaths);
                    ExportJson();
                    ExportMeta();
                    for (i = 0; i < emoteGroups.Count; i++) {
                        ExportGroup(emoteGroupPaths[i], emoteGroups[i]);
                    }
                    for (i = 0; i < battleGroupPaths.Count; i++) {
                        ExportGroup(battleGroupPaths[i], battleGroups[i]);
                    }
                    PenumbraHttpApi.Reload(newModPath, modNameTextBox.Text, hook);
                    TopMost = true;
                    BringToFront();
                    TopMost = false;
                    MessageBox.Show(@"Export Complete", VersionText);
                }
            } else {
                MessageBox.Show(@"Export Cancelled", VersionText);
            }
            exportProgressBar.Visible = false;
        }

        private void GetTimeCodeData() {
            timeCodeDataList = new List<TimeCodeData>();
            foreach (int voiceValue in emoteVoicesToReplace) {
                VoiceDescriptor voiceDescriptor = RaceVoice.RacesToVoiceDescription[voiceValue + ""][0];
                TimeCodeData timeCodeData = RaceVoice.TimeCodeData[voiceDescriptor.RaceName + "_" + voiceDescriptor.VoiceGender];
                if (!timeCodeDataList.Contains(timeCodeData)) {
                    timeCodeDataList.Add(timeCodeData);
                }
            }
        }

        private void ExportSoundData() {
            if (!autoSyncCheckbox.Checked) {
                foreach (FilePicker value in emoteFilePickers) {
                    if (File.Exists(value.FilePath.Text)) {
                        if (!Directory.Exists(exportFilePathEmote)) {
                            Directory.CreateDirectory(exportFilePathEmote);
                        }
                        string inputPath = value.FilePath.Text;
                        string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");
                        Process process = new Process();
                        process.StartInfo.FileName = Path.Combine(Application.StartupPath, @"res\ffmpeg.exe");
                        process.StartInfo.Arguments = $"-i {@"""" + inputPath + @""""} -f wav -acodec adpcm_ms -block_size 256 -ar: 44100 -ac 1 {@"""" + tempPath + @""""}";
                        process.Start();
                        while (SCDGenerator.IsFileLocked(tempPath)) { };
                        InjectSCDFiles(Path.Combine(Application.StartupPath, @"res\scd\emote.scd"), exportFilePathEmote, value.Name, new List<string>() { tempPath });
                        File.Delete(tempPath);
                    } else if (!string.IsNullOrWhiteSpace(value.FilePath.Text) && !value.UseGameFileCheckBox.Checked) {
                        MessageBox.Show(@"Please check that file path in """ + value.Name + @""" is valid! Skipping.");
                    }
                    exportProgressBar.Increment(1);
                    exportProgressBar.Refresh();
                    Application.DoEvents();
                }
            } else {
                foreach (TimeCodeData timeCodeData in timeCodeDataList) {
                    int i = 0;
                    foreach (FilePicker value in emoteFilePickers) {
                        if (File.Exists(value.FilePath.Text)) {
                            if (!Directory.Exists(exportFilePathEmote)) {
                                Directory.CreateDirectory(exportFilePathEmote);
                            }
                            string inputPath = value.FilePath.Text;
                            string tempPath = Path.Combine(Path.GetDirectoryName(inputPath), Guid.NewGuid() + ".wav");
                            if (i < timeCodeData.TimeCodes.Count) {
                                decimal timeCode = timeCodeData.TimeCodes[i];
                                Process process = new Process();
                                process.StartInfo.FileName = Path.Combine(Application.StartupPath, @"res\ffmpeg.exe");
                                process.StartInfo.Arguments = $"-f lavfi -i aevalsrc=0:d={timeCode.ToString().Replace(",", ".")} -i "
                                    + @"""" + inputPath + @"""" + @" -filter_complex ""[0:0] [1:0] concat=n=2:v=0:a=1"" -f wav -acodec adpcm_ms -block_size 256 -ar: 44100 -ac 1 " + @"""" + tempPath + @""""; ;
                                process.Start();
                                while (SCDGenerator.IsFileLocked(tempPath)) { };
                                InjectSCDFiles(Path.Combine(Application.StartupPath, @"res\scd\emote.scd"), exportFilePathEmote, value.Name + "_" + timeCodeData.Descriptor, new List<string>() { tempPath });
                                File.Delete(tempPath);
                            }
                        } else if (!string.IsNullOrWhiteSpace(value.FilePath.Text) && !value.UseGameFileCheckBox.Checked) {
                            MessageBox.Show(@"Please check that file path in """ + value.Name + @""" is valid! Skipping.");
                        }
                        i++;
                        exportProgressBar.Increment(1);
                        exportProgressBar.Refresh();
                        Application.DoEvents();
                    }
                }
            }
        }

        private void ExportBattleFiles(List<Group> groups, List<string> groupPaths) {
            battleVoicesInUse = false;
            List<string> list = new List<string>();
            List<string> alreadyProcessed = new List<string>();
            int countedNull = 0;
            Group group = new Group($"Battle Voice To Replace (Group 1)", "The battle voice you are replacing", 0, "Multi", 0);
            groups.Add(group);
            groupPaths.Add(Path.Combine(newModPath, $"group_0" + (offset + groupPaths.Count < 9 ? "0" : "") + $"{offset + groupPaths.Count + 1}_{group.Name.ToLower()}.json"));
            int i = 0;
            if (!voiceSwapBattleVoices.Checked) {
                bool detectedEmptyField = false;
                for (int count = 0; count < 16; count++) {
                    if (!string.IsNullOrEmpty(battleFilePickers[count].FilePath.Text)) {
                        string tempPath = Path.Combine(Path.GetDirectoryName(battleFilePickers[count].FilePath.Text), Guid.NewGuid() + ".wav");
                        Process process = new Process();
                        process.StartInfo.FileName = Path.Combine(Application.StartupPath, @"res\ffmpeg.exe");
                        process.StartInfo.Arguments = $"-i {@"""" + battleFilePickers[count].FilePath.Text
                            + @""""} -f wav -acodec adpcm_ms -block_size 256 -ar: 44100 -ac 1 {@"""" + tempPath + @""""}";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process.StartInfo.RedirectStandardError = true;
                        process.StartInfo.RedirectStandardInput = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.UseShellExecute = false;
                        process.OutputDataReceived += delegate { };
                        process.ErrorDataReceived += delegate { };
                        process.Start();
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
                            // If we're hortgar or Viera
                            if (value.Contains("ros") || value.Contains("vie") || oldExportMode.Checked) {

                                // This file is dumb and is not like the others
                                if (value.Contains("vo_battle_pc_ros_ma_ja") && !oldExportMode.Checked) {
                                    // Special sorting for only one hrothgar file, because this file is dumb.
                                    List<string> battleSounds = new List<string>() {
                                    // Attack
                                    list[0],list[1], list[2], list[3],list[4], list[5],
                                    // Hurt
                                    list[6],list[7],list[8], list[9],list[10], list[11],
                                    // Death
                                    list[12],list[14],
                                    // Extra
                                    list[15], list[13]
                                };
                                    InjectSCDFiles(path, exportFilePathBattle, value, battleSounds);
                                } else {
                                    InjectSCDFiles(path, exportFilePathBattle, value, list);
                                }
                            } else if (value.Contains("aur")) {
                                // Au Ra sorting
                                List<string> battleSounds = new List<string>() {
                                    // Hurt
                                    list[6],list[7],list[8],
                                    // Death
                                    list[12],list[13],
                                    // Attack
                                    list[0],list[1],list[2],list[3],list[4],list[5],
                                    // Extra
                                    list[14], list[15]
                                };
                                InjectSCDFiles(path, exportFilePathBattle, value, battleSounds);
                            } else if (value.Contains("vo_battle_pc_lal_ma_ja")) {
                                // Special sorting for lalafel voice 1, because it wants to stand out from its race as well.
                                List<string> battleSounds = new List<string>() {
                                    // Attack
                                    list[0],list[1], list[2],
                                    // Hurt
                                    list[6],list[7],list[8], list[9],
                                    // Death
                                    list[12],list[13],
                                    // Extra
                                    list[3], list[4], list[5], list[14], list[15], list[10], list[11]
                                };
                                InjectSCDFiles(path, exportFilePathBattle, value, battleSounds);
                            } else {
                                // Sorting for everyone else
                                List<string> battleSounds = new List<string>() {
                                    // Attack
                                    list[0],list[1], list[2], list[3],
                                    // Hurt
                                    list[6],list[7],list[8], list[9],
                                    // Death
                                    list[12],list[13],
                                    // Extra
                                    list[4], list[5], list[14], list[15], list[10], list[11]
                                };
                                InjectSCDFiles(path, exportFilePathBattle, value, battleSounds);
                            }
                            string name = "";
                            bool firstValueAdded = false;
                            foreach (VoiceDescriptor nameValue in RaceVoice.RacesToVoiceDescription[value]) {
                                if (!firstValueAdded) {
                                    name += nameValue.VerboseDescription;
                                    firstValueAdded = true;
                                } else {
                                    name += "| " + nameValue.VerboseDescription;
                                }
                            }
                            Option option = new Option(name, 0);
                            option.Files.Add("sound/voice/vo_battle/" + value + @".scd", "sound\\voice\\vo_battle\\" + value + @".scd");
                            if (i < 31) {
                                i++;
                            } else {
                                i = 0;
                                group = new Group($"Battle Voice To Replace (Group {groups.Count + 1})", "The battle voice you are replacing", 0, "Multi", 0);
                                groups.Add(group);
                                groupPaths.Add(Path.Combine(newModPath, $"group_0" + (offset + groupPaths.Count < 9 ? "0" : "") + $"{offset + groupPaths.Count + 1}_{group.Name.ToLower()}.json"));
                            }
                            group.Options.Add(option);
                            alreadyProcessed.Add(value);
                        }
                    }
                    for (int count = 0; count < 16; count++) {
                        if (File.Exists((list[count]))) {
                            File.Delete(list[count]);
                        }
                    }
                    if (detectedEmptyField) {
                        MessageBox.Show(@"Warning: You have not assigned a battle sound for every field. Due to the way battle sounds work, any missing sounds will play silence.", VersionText);
                    }
                }
            } else {
                foreach (string value in battleVoicesToReplace) {
                    battleVoicesInUse = true;
                    if (!alreadyProcessed.Contains(value)) {
                        string name = "";
                        foreach (VoiceDescriptor nameValue in RaceVoice.RacesToVoiceDescription[value]) {
                            name += nameValue.VerboseDescription + " ";
                        }
                        Option option = new Option(name, 0);
                        option.FileSwaps.Add("sound/voice/vo_battle/" + value + @".scd", "sound/voice/vo_battle/" + battleVoiceToSwapWith + ".scd");
                        if (i < 31) {
                            i++;
                        } else {
                            i = 0;
                            group = new Group($"Battle Voice To Replace (Group {groups.Count + 1})", "The battle voice you are replacing", 0, "Multi", 0);
                            groups.Add(group);
                            groupPaths.Add(Path.Combine(newModPath, $"group_0" + (offset + groupPaths.Count < 9 ? "0" : "") + $"{offset + groupPaths.Count + 1}_{group.Name.ToLower()}.json"));
                        }
                        group.Options.Add(option);
                        alreadyProcessed.Add(value);
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
                                file.Import(path, entry);
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
            HasSaved = false;
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
            HasSaved = false;
        }

        private void tabManager_Selecting(object sender, TabControlCancelEventArgs e) {
            if (!alreadyShown) {
                missingFIleList.Items.Clear();
                PickVoiceDump();
                alreadyShown = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            CleanSlate();
        }
        private bool CleanSlate() {
            if (!HasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", VersionText, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (savePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                savePath = saveFileDialog.FileName;
                                Text = Application.ProductName + " " + Application.ProductVersion + $" ({savePath})";
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
            Text = Application.ProductName + " " + Application.ProductVersion;
            oldExportMode.Checked = false;
            oldExportMode.Visible = false;
            testingLabel.Text = "No Selection";
            selectedVoiceDescriptor = null;
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
            modVersionTextBox.Text = "1.0.0";
            foreach (FilePicker filePicker in emoteFilePickers) {
                filePicker.FilePath.Text = "";
            }
            foreach (FilePicker filePicker in battleFilePickers) {
                filePicker.FilePath.Text = "";
            }
            emoteVoicesToReplace.Clear();
            battleVoicesToReplace.Clear();
            voiceReplacementList.Items.Clear();
            HasSaved = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
            saveFileDialog.AddExtension = true;
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
                HasSaved = true;
            }
        }

        public void SaveProject(string path) {
            using (StreamWriter writer = new StreamWriter(path)) {
                writer.WriteLine(oldExportMode.Checked ? 2 : 4);
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
                writer.WriteLine(autoSyncCheckbox.Checked);
            }
            HasSaved = true;
        }

        public void WritePenumbraPath(string path) {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            using (StreamWriter writer = new StreamWriter(Path.Combine(dataPath, @"PenumbraPath.config"))) {
                writer.WriteLine(path);
            }
        }
        public void WriteDumpPath(string path) {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            using (StreamWriter writer = new StreamWriter(Path.Combine(dataPath, @"DumpPath.config"))) {
                writer.WriteLine(path);
            }
        }
        public void GetDumpPath() {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            string path = Path.Combine(dataPath, @"DumpPath.config");
            if (File.Exists(path)) {
                using (StreamReader reader = new StreamReader(path)) {
                    dumpFilePath = reader.ReadLine();
                }
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
        public void GetAuthorWebsite() {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            string lastDataPath = Path.Combine(dataPath, @"0.0.1.5\");
            if (Directory.Exists(lastDataPath)) {
                dataPath = lastDataPath;
            }
            string path = Path.Combine(dataPath, @"AuthorWebsite.config");
            if (File.Exists(path)) {
                using (StreamReader reader = new StreamReader(path)) {
                    _defaultWebsite = reader.ReadLine();
                }
            }
        }
        public void GetAuthorName() {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            string lastDataPath = Path.Combine(dataPath, @"0.0.1.5\");
            if (Directory.Exists(lastDataPath)) {
                dataPath = lastDataPath;
            }
            string path = Path.Combine(dataPath, @"AuthorName.config");
            if (File.Exists(path)) {
                using (StreamReader reader = new StreamReader(path)) {
                    _defaultAuthor = reader.ReadLine();
                }
            }
        }

        public void WriteAuthorWebsite(string path) {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            using (StreamWriter writer = new StreamWriter(Path.Combine(dataPath, @"AuthorWebsite.config"))) {
                writer.WriteLine(path);
            }
        }
        public void WriteAuthorName(string path) {
            string dataPath = Application.UserAppDataPath.Replace(Application.ProductVersion, null);
            using (StreamWriter writer = new StreamWriter(Path.Combine(dataPath, @"AuthorName.config"))) {
                writer.WriteLine(path);
            }
        }

        public void OpenProject(string path) {
            try {
                List<int> emoteList = new List<int>();
                List<string> battleList = new List<string>();
                using (StreamReader reader = new StreamReader(path)) {
                    int version = int.Parse(reader.ReadLine());
                    string audioSyncPrompt = "This project was made before we added the ability to automatically synchronize emotes to animations. Its now possible to bulk export to multiple races and have the tool synchronize audio timings to each separate race.\r\n\r\nThis feature is on by default, but has been disabled so that it wont interfere with this projects existing configuration.\r\n\r\nSimply enable " + @"""Synchronize To Animations"" when you decide to use the feature. (Does not affect Voice Swap feature)";
                    switch (version) {
                        case 2:
                            OpenVersionLegacy2(reader, emoteList, battleList);
                            if (showedNewFeaturesPrompt) {
                                MessageBox.Show("This project was made before battle voice generation was adjusted to better fit exports to multiple races, and more accurate labelling was added.\r\n\r\nWe've put the application in " + @"""Old Export Mode""" + " so that your exports remain the same, but if you wish to re-assign them to be more accurate with labelling, disable " + @"""Old Export Mode"". This compatibility feature is only available for older projects and to prevent immediate inconvenience.", VersionText);
                                MessageBox.Show(audioSyncPrompt, VersionText);
                                autoSyncCheckbox.Checked = false;
                                oldExportMode.Checked = true;
                                oldExportMode.Visible = true;

                            }
                            break;
                        case 3:
                            OpenVersionLegacy2(reader, emoteList, battleList);
                            if (showedNewFeaturesPrompt) {
                                MessageBox.Show(audioSyncPrompt, VersionText);
                                autoSyncCheckbox.Checked = false;
                            }
                            break;
                        case 4:
                            OpenVersion3(reader, emoteList, battleList);
                            break;
                        default:
                            throw new Exception();
                    }

                    for (int i = 0; i < emoteList.Count; i++) {
                        AddReplacementValues(emoteList[i], i < battleList.Count && battleList.Count > 0 ? battleList[i] : "");
                    }
                }
            } catch {
                OpenProjectLegacy(path);
            }
            HasSaved = true;
        }

        private void OpenVersion3(StreamReader reader, List<int> emoteList, List<string> battleList) {
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
                showedNewFeaturesPrompt = true;
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
            autoSyncCheckbox.Checked = bool.Parse(reader.ReadLine());
            if (!string.IsNullOrEmpty(battleVoiceToSwapWith)) {
                suppressVoiceSwapBattleVoiceChecked = true;
                voiceSwapBattleVoices.Checked = true;
            } else {
                voiceSwapBattleVoices.Checked = false;
            }
        }

        private void OpenVersionLegacy2(StreamReader reader, List<int> emoteList, List<string> battleList) {
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
                showedNewFeaturesPrompt = true;
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
            HasSaved = true;
        }

        private void quickImportButton_Click(object sender, EventArgs e) {
            MessageBox.Show("To use quick import successfully, name your sound files exactly after the sound they intend to replace together in a separated folder. You can use the program labels for reference.", VersionText);
            FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK) {
                foreach (string filename in Directory.GetFiles(folderSelectDialog.SelectedPath)) {
                    foreach (FilePicker filePicker in emoteFilePickers) {
                        if (Path.GetFileNameWithoutExtension(filename).ToLower() == filePicker.Name) {
                            filePicker.SetFilePath(filename);
                        }
                    }
                    foreach (FilePicker filePicker in battleFilePickers) {
                        if (Path.GetFileNameWithoutExtension(filename).ToLower() == filePicker.Name) {
                            filePicker.SetFilePath(filename);
                        }
                    }
                    HasSaved = false;
                }
            }
        }

        private void modNameTextbox_TextChanged(object sender, EventArgs e) {
            HasSaved = false;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (!HasSaved) {
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
            bool voiceIgnored = false;
            int voiceCount = 0;
            for (int i = 0; i < 12; i++) {
                switch (sexListComboBox.SelectedIndex) {
                    case 0:
                        string emoteVoiceValue = RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Masculine[i];
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
                        emoteVoiceValue = RaceVoice.RacialListEmotes[raceListComboBox.SelectedIndex].Feminine[i];
                        battleVoiceValue = RaceVoice.RacialListBattle[raceListComboBox.SelectedIndex].Feminine[i];
                        if (!string.IsNullOrWhiteSpace(emoteVoiceValue)) {
                            int value2 = int.Parse(emoteVoiceValue);
                            if (!emoteVoicesToReplace.Contains(value2)) {
                                AddReplacementValues(value2, battleVoiceValue);
                            } else {
                                voiceAlreadyInList = true;
                            }
                        } else {
                            voiceIgnored = true;
                            voiceCount++;
                        }
                        break;
                }
            }
            if (voiceIgnored) {
                MessageBox.Show("One or more voices did not have relevant data to add", VersionText);
            } else {
                if (voiceAlreadyInList) {
                    MessageBox.Show($"Some voices were already in the list, and were left alone.", VersionText);
                }
            }
        }

        private void quickSwapButton_Click(object sender, EventArgs e) {
            MessageBox.Show(@"Quick swap lets you quickly pick an in game voice that you want to swap with another.", VersionText);
            VoiceSelection voiceSelection = new VoiceSelection();
            if (voiceSelection.ShowDialog() == DialogResult.OK) {
                foreach (FilePicker filePicker in emoteFilePickers) {
                    filePicker.SetToGameFile(voiceSelection.SelectedVoiceEmote);
                }
                battleVoiceToSwapWith = voiceSelection.SelectedVoiceBattle;
                suppressVoiceSwapBattleVoiceChecked = true;
                voiceSwapBattleVoices.Checked = true;
                voiceTabs.SelectedIndex = 0;
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
                        voiceTabs.SelectedIndex = 0;
                    } else {
                        MessageBox.Show(@"No replacement was selected, unchecking", VersionText);
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
            if (voiceTabs.SelectedIndex == 1) {
                if (voiceSwapBattleVoices.Checked) {
                    voiceTabs.SelectedIndex = 0;
                    MessageBox.Show(@"Battle voices cannot be edited while in voice swap mode. If you intend to edit battle voices please disable it.", VersionText);
                } else {
                    if (!showedNewFeaturesPrompt) {
                        showedNewFeaturesPrompt = true;
                        MessageBox.Show(_battleSoundTutorial, VersionText);
                    }
                }
            }
        }

        private void bulkSCDAudioExtractorToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Select your input folder of .scd files", VersionText) == DialogResult.OK) {
                FolderBrowserDialog inputFolderDialog = new FolderBrowserDialog();
                if (inputFolderDialog.ShowDialog() == DialogResult.OK) {
                    if (MessageBox.Show("Select your output folder for extracted sounds", VersionText) == DialogResult.OK) {
                        FolderBrowserDialog outputFolderDialog = new FolderBrowserDialog();
                        if (outputFolderDialog.ShowDialog() == DialogResult.OK) {
                            string[] files = Directory.GetFiles(inputFolderDialog.SelectedPath);
                            string error = null;
                            exportProgressBar.Visible = true;
                            exportProgressBar.Maximum = files.Length;
                            foreach (string path in files) {
                                if (path.Contains(".scd")) {
                                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                                        using (BinaryReader reader = new BinaryReader(fileStream)) {
                                            try {
                                                ScdFile file = new ScdFile(reader, false, true);
                                                int i = 0;
                                                foreach (ScdAudioEntry sound in file.Audio) {
                                                    if (sound.Format == SscfWaveFormat.MsAdPcm) {
                                                        SaveWaveDialog(Path.Combine(outputFolderDialog.SelectedPath, Path.GetFileNameWithoutExtension(path) + (file.Audio.Count > 1 ? i : "") + ".wav"), sound);
                                                        i++;
                                                    }
                                                    if (sound.Format == SscfWaveFormat.Vorbis) {
                                                        SaveOggDialog(Path.Combine(outputFolderDialog.SelectedPath, Path.GetFileNameWithoutExtension(path) + (file.Audio.Count > 1 ? i : "") + ".ogg"), sound);
                                                        i++;
                                                    }
                                                }
                                            } catch {
                                                error += $@"SCD File at ""{path}"" failed to fully read, or another error occured." + "\r\n\r\n";
                                            }
                                            exportProgressBar.Increment(1);
                                            exportProgressBar.Refresh();
                                        }
                                    }
                                } else {
                                    exportProgressBar.Maximum--;
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(error)) {
                                MessageBox.Show(error, VersionText);
                            }
                            MessageBox.Show("Extraction Complete", VersionText);
                            try {
                                Process.Start(new System.Diagnostics.ProcessStartInfo() {
                                    FileName = outputFolderDialog.SelectedPath,
                                    UseShellExecute = true,
                                    Verb = "explore"
                                });
                            } catch {

                            }
                            exportProgressBar.Visible = false;
                        }
                    }
                }
            }
        }
        private void SaveWaveDialog(string output, ScdAudioEntry entry) {
            using var stream = entry.Data.GetStream();
            WaveFileWriter.CreateWaveFile(output, stream);
        }

        private void SaveOggDialog(string output, ScdAudioEntry entry) {
            var data = (ScdVorbis)entry.Data;
            File.WriteAllBytes(output, data.DecodedData);
        }

        private void battleSoundGuidelinesToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(_battleSoundTutorial, VersionText);
        }

        private void attack6_Load(object sender, EventArgs e) {

        }

        private void autoSyncCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (oldExportMode.Checked) {
                MessageBox.Show(@"Due to ""Old Export Mode"" being active, you will not be able to save the state of the selected feature. We are preserving the ability to open this legacy project, and save this as a legacy project at the expense of newer features being persisted.", VersionText);
            }
            if (autoSyncCheckbox.Checked) {
                if (selectedVoiceDescriptor != null) {
                    testingLabel.Text = "Testing " + selectedVoiceDescriptor.RaceName + " " + selectedVoiceDescriptor.VoiceGender;
                } else {
                    testingLabel.Text = "No Selection";
                }
                MessageBox.Show("The tool will now automatically synchronize audio to the start times of each races emote animations. Please trim any empty audio that plays before each sound for best results.\r\n\r\nThe doze emote is timed based on when the character wakes up. Any prior snoring or sleeping is currently sacrificed for the convenience to work. (Does not affect Voice Swap feature)", VersionText);
            } else {
                testingLabel.Text = "Manual Sync";
            }
        }

        private void voiceReplacementList_SelectedIndexChanged(object sender, EventArgs e) {
            if (voiceReplacementList.Items.Count > 0) {
                if (voiceReplacementList.SelectedIndex > -1) {
                    string value = emoteVoicesToReplace[voiceReplacementList.SelectedIndex].ToString();
                    selectedVoiceDescriptor = RaceVoice.RacesToVoiceDescription[value][0];
                    if (autoSyncCheckbox.Checked) {
                        testingLabel.Text = "Testing " + selectedVoiceDescriptor.RaceName + " " + selectedVoiceDescriptor.VoiceGender;
                    } else {
                        testingLabel.Text = "Manual Sync";
                    }
                }
            } else {
                testingLabel.Text = "No Selection";
            }
        }

        private void sCDEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            SCDEditor sCDEditor = new SCDEditor();
            sCDEditor.Form = this;
            sCDEditor.ShowDialog();
        }

        private void refreshFFXIVInstanceToolStripMenuItem_Click(object sender, EventArgs e) {
            RefreshFFXIVInstance();
            if (foundInstance) {
                MessageBox.Show("Client has been refreshed.", VersionText);
            } else {
                MessageBox.Show("No client found.", VersionText);
            }
        }

        private void ffxivRefreshTimer_Tick(object sender, EventArgs e) {
            RefreshFFXIVInstance();
        }

        private void testEmotesButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("This will test every valid emote voice file, based on the voice you select. Will not work for voice swaps as FFXIV contains all those sounds." +
                (foundInstance ? " Please ensure your in game chat box is not selected." : "") + " Continue?", VersionText, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                voiceTabs.SelectedIndex = 0;
                VoiceSelection voiceSelection = new VoiceSelection();
                if (voiceSelection.ShowDialog() == DialogResult.OK) {
                    selectedVoiceDescriptor = RaceVoice.RacesToVoiceDescription[voiceSelection.SelectedVoiceEmote + ""][0];
                    if (autoSyncCheckbox.Checked) {
                        testingLabel.Text = "Testing " + selectedVoiceDescriptor.RaceName + " " + selectedVoiceDescriptor.VoiceGender;
                    } else {
                        testingLabel.Text = "Manual Sync";
                    }
                    IsRunningTest = true;
                    bool voiceSwapDetected = false;
                    foreach (FilePicker filePicker in emoteFilePickers) {
                        if (!string.IsNullOrWhiteSpace(filePicker.FilePath.Text) && !filePicker.UseGameFileCheckBox.Checked) {
                            TopMost = false;
                            filePicker.Play(true);
                        } else if (filePicker.UseGameFileCheckBox.Checked) {
                            voiceSwapDetected = true;
                        }
                    }
                    TopMost = true;
                    Focus();
                    TopMost = false;
                    IsRunningTest = false;
                    VolumeMixer.SetApplicationMute(Hook.Process.Id, false);
                    if (voiceSwapDetected) {
                        MessageBox.Show("One or more audio assignements were skipped as they are either empty or voice swaps.", VersionText);
                    }
                    MessageBox.Show("Test Complete!", VersionText);
                } else {
                    MessageBox.Show("No voice select, test aborted!", VersionText);
                }
            }
        }

        private void testBattleSoundButton_Click(object sender, EventArgs e) {
            if (!voiceSwapBattleVoices.Checked) {
                if (MessageBox.Show("This will test every valid battle voice file. Will not work for voice swaps as FFXIV contains all those sounds. Continue?", VersionText, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    voiceTabs.SelectedIndex = 1;
                    foreach (FilePicker filePicker in battleFilePickers) {
                        if (!string.IsNullOrWhiteSpace(filePicker.FilePath.Text)) {
                            filePicker.Play();
                        }
                    }
                }
                MessageBox.Show("Test Complete!", VersionText);
            } else {
                MessageBox.Show("Cannot preview a voice swap. Battle voice will not be tested.", VersionText);
            }
        }

        private void troublshootingFAQToolStripMenuItem_Click(object sender, EventArgs e) {
            Troubleshooting troubleshooting = new Troubleshooting();
            troubleshooting.ShowDialog();
        }

        private void discordButton_Click(object sender, EventArgs e) {
            try {
                Process.Start(new System.Diagnostics.ProcessStartInfo() {
                    FileName = "https://discord.gg/rtGXwMn7pX",
                    UseShellExecute = true,
                    Verb = "OPEN"
                });
            } catch {

            }
        }

        private void donateButton_Click(object sender, EventArgs e) {
            try {
                Process.Start(new System.Diagnostics.ProcessStartInfo() {
                    FileName = "https://ko-fi.com/sebastina",
                    UseShellExecute = true,
                    Verb = "OPEN"
                });
            } catch {

            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void modAuthorTextBox_Leave(object sender, EventArgs e) {
            WriteAuthorName(modAuthorTextBox.Text);
        }

        private void modWebsiteTextBox_Leave(object sender, EventArgs e) {
            WriteAuthorWebsite(modWebsiteTextBox.Text);
        }
    }
}
