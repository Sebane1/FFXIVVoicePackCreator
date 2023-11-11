using FFXIVVoicePackCreator.Json;
using Lumina;
using Lumina.Excel.GeneratedSheets;
using NAudio.Vorbis;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    public partial class RoleplayingVoicePackCreator : Form {
        public RoleplayingVoicePackCreator() {
            InitializeComponent();
        }

        Dictionary<string, List<string>> _categories = new Dictionary<string, List<string>>();
        private string cacheFolder;
        private object[] originalTemplateList;
        private bool hasSaved = true;
        private string currentSavePath;
        private MainWindow legacyWindow;
        private WaveOutEvent output;

        public bool HasSaved {
            get => hasSaved; set {
                hasSaved = value;
                if (!hasSaved) {
                    Text = Application.ProductName + " " + Application.ProductVersion + (!string.IsNullOrWhiteSpace(currentSavePath) ? $" ({currentSavePath})*" : "*");
                } else {
                    Text = Application.ProductName + " " + Application.ProductVersion + (!string.IsNullOrWhiteSpace(currentSavePath) ? $" ({currentSavePath})" : "");
                }
            }
        }

        private void filePicker1_Load(object sender, EventArgs e) {

        }

        private void RoleplayingVoicePackCreator_Load(object sender, EventArgs e) {
            foreach (Process process in Process.GetProcessesByName("ffmpeg")) {
                process.Kill();
            }
            AutoScaleDimensions = new SizeF(96, 96);
            Text = Application.ProductName + " " + Application.ProductVersion + (!string.IsNullOrWhiteSpace(currentSavePath) ? $" ({currentSavePath})" : "");
            InstallationCheck();
            originalTemplateList = new object[categoryComboBox.Items.Count];
            categoryComboBox.Items.CopyTo(originalTemplateList, 0);
            CheckForCommandArguments();
            try {
                var lumina = new GameData(Path.GetDirectoryName(Process.GetProcessesByName("ffxiv_dx11")[0].MainModule.FileName) + @"\sqpack");
                var emotes = lumina.GetExcelSheet<Emote>();
                var actions = lumina.GetExcelSheet<Lumina.Excel.GeneratedSheets.Action>();
                foreach (Emote emote in emotes.AsEnumerable<Emote>()) {
                    if (!string.IsNullOrEmpty(emote.Name.RawString) && !categoryComboBox.Items.Contains(emote.Name.RawString)) {
                        categoryComboBox.Items.Add(emote.Name.RawString);
                    }
                }
                foreach (Lumina.Excel.GeneratedSheets.Action action in actions.AsEnumerable<Lumina.Excel.GeneratedSheets.Action>()) {
                    if (!string.IsNullOrEmpty(action.Name.RawString) &&
                        !action.Name.RawString.StartsWith("_rsv") &&
                        !categoryComboBox.Items.Contains(action.Name.RawString)) {
                        categoryComboBox.Items.Add(action.Name.RawString);
                    }
                }
            } catch {
                MessageBox.Show("FFXIV instance not detected, category selection list wont display all options.", "FFXIV Voice Pack Creator");
            }
        }

        private void InstallationCheck() {
            string artemisRoleplayingKit = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
         + @"\XIVLauncher\pluginConfigs\ArtemisRoleplayingKit.json";
            if (File.Exists(artemisRoleplayingKit)) {
                ArtemisRoleplayingKit file = JsonConvert.DeserializeObject<ArtemisRoleplayingKit>(
                    File.OpenText(artemisRoleplayingKit).ReadToEnd());
                cacheFolder = file.CacheFolder;
            } else {
                artemisRoleplayingKit = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
              + @"\XIVLauncher\pluginConfigs\RoleplayingVoiceDalamud.json";
                if (File.Exists(artemisRoleplayingKit)) {
                    ArtemisRoleplayingKit file = JsonConvert.DeserializeObject<ArtemisRoleplayingKit>(
                        File.OpenText(artemisRoleplayingKit).ReadToEnd());
                    cacheFolder = file.CacheFolder;
                } else {
                    MessageBox.Show("Unable to find the Artemis Roleplaying Kit config. The plugin is mandatory for expanded sound options due to Penumbra limitations. Ensure you've enabled Voice Pack support in the plugin.\r\n\r\nAlternatively, you can open the legacy voice pack creator window.", "FFXIV Voice Pack Creator");
                }
            }
        }

        private void soundList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void addCategoryButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(categoryComboBox.Text) && !categoryList.Items.Contains(categoryComboBox.Text)) {
                categoryList.Items.Add(categoryComboBox.Text);
                _categories.Add(categoryComboBox.Text, new List<string>());
                categoryList.SelectedIndex = categoryList.Items.Count - 1;
                RefreshLists();
                RefreshCategories();
                HasSaved = false;
            }
        }
        void RefreshCategories() {
            categoryList.Items.Clear();
            categoryList.Items.AddRange(_categories.Keys.ToArray<string>());
        }
        private void AddSoundButton_Click(object sender, EventArgs e) {
            if (categoryList.Items.Count > 0) {
                if (categoryList.SelectedIndex > -1) {
                    OpenFileDialog openFileDialog = new OpenFileDialog {
                        Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.RMI;*.MKV;*.flac;*.ogg;"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK) {
                        _categories[(string)categoryList.SelectedItem].Add(openFileDialog.FileName);
                    }
                    RefreshLists();
                    HasSaved = false;
                } else {
                    MessageBox.Show("Select a sound category before trying to add sound!", "FFXIV Voice Pack Creator");
                }
            } else {
                MessageBox.Show("Add a sound category before trying to add sound!", "FFXIV Voice Pack Creator");
            }
        }
        private void RefreshLists() {
            soundList.Items.Clear();
            if (categoryList.SelectedItem != null) {
                foreach (var sound in _categories[(string)categoryList.SelectedItem]) {
                    soundList.Items.Add(Path.GetFileName(sound));
                }
            }
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshLists();
        }

        private void removeSoundButton_Click(object sender, EventArgs e) {
            if (soundList.Items.Count > 0) {
                _categories[(string)categoryList.SelectedItem].RemoveAt(soundList.SelectedIndex);
                RefreshLists();
            }
            HasSaved = false;
        }

        private void clearListButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("This will clear all sounds in the category, are you sure?",
                "FFXIV Voice Pack Creator", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                if (soundList.Items.Count > 0) {
                    _categories[(string)categoryList.SelectedItem].Clear();
                    RefreshLists();
                }
                HasSaved = false;
            }
        }

        private void soundList_DragDrop(object sender, DragEventArgs e) {
            string[] files = ((string[])e.Data.GetData(DataFormats.FileDrop, false));
            foreach (string file in files) {
                if (CheckExtentions(file)) {
                    _categories[(string)categoryList.SelectedItem].Add(file);
                }
            }
            RefreshLists();
            HasSaved = false;
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keys) {
            switch (keys) {
                case Keys.S | Keys.Control:
                    // ... Process Shift+Ctrl+Alt+B ...
                    saveToolStripMenuItem_Click(this, EventArgs.Empty);
                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.S) {
                saveToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private bool CheckExtentions(string file) {
            string[] extentions = new string[] { ".wav", ".aac", ".wma", ".wmv", ".avi", ".mpg", ".mpeg", ".m1v",
                ".mp2", ".mp3", ".mpa", ".mpe", ".m3u", ".mp4", ".mov", ".3g2", ".3gp2", ".3gp", ".3gpp", ".m4a",
                ".cda", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".mkv", ".WAV", ".AAC", ".WMA", ".WMV",
                ".AVI", ".MPG", ".MPEG", ".M1V", ".MP2", ".MP3", ".MPA", ".MPE", ".M3U", ".MP4", ".MOV", ".3G2", ".3GP2",
                ".3GP", ".3GPP", ".M4A", ".CDA", ".AIF", ".AIFC", ".AIFF", ".RMI", ".MKV", ".flac", ".ogg" };
            foreach (string extention in extentions) {
                if (file.Contains(extention)) {
                    return true;
                }
            }
            return false;
        }

        private void soundList_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
        private void CheckForCommandArguments() {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) {
                if (!string.IsNullOrWhiteSpace(args[1])) {
                    if (File.Exists(args[1]) && args[1].Contains(".rpvpp")) {
                        currentSavePath = args[1];
                        Open(currentSavePath);
                    } else if (File.Exists(args[1]) && args[1].Contains(".ffxivsp")) {
                        currentSavePath = args[1];
                        OpenOldProject(currentSavePath);
                    }
                }
            }
        }
        private void addAllCategoriesButton_Click(object sender, EventArgs e) {
            foreach (string category in originalTemplateList) {
                if (!categoryList.Items.Contains(category)) {
                    categoryList.Items.Add(category);
                    _categories.Add(category, new List<string>());
                }
            }
            RefreshLists();
            RefreshCategories();
            categoryList.SelectedIndex = categoryList.Items.Count - 1;
            HasSaved = false;
        }

        private void exportButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(nameTextBox.Text)) {
                if (string.IsNullOrEmpty(cacheFolder)) {
                    InstallationCheck();
                }
                if (!string.IsNullOrEmpty(cacheFolder)) {
                    string voicePackFolder = cacheFolder + @"\VoicePack\";
                    string exportPath = voicePackFolder + nameTextBox.Text;
                    exportButton.Enabled = false;
                    foreach (Process process in Process.GetProcessesByName("ffmpeg")) {
                        process.Kill();
                    }
                    foreach (string key in _categories.Keys) {
                        int number = 0;
                        foreach (string value in _categories[key]) {
                            if (File.Exists(value)) {
                                if (!Directory.Exists(exportPath)) {
                                    Directory.CreateDirectory(exportPath);
                                }
                                string inputPath = value;
                                string tempPath = Path.Combine(exportPath, StripNonCharacters(key) + number++ + ".mp3");
                                Process process = new Process();
                                process.StartInfo.FileName = Path.Combine(Application.StartupPath, @"res\ffmpeg.exe");
                                process.StartInfo.Arguments = $"-i {@"""" + inputPath
                                + @""""} -acodec mp3 -ac 1 {@"""" + tempPath + @""""}";
                                process.Start();
                            }
                            Application.DoEvents();
                        }
                    }
                    exportButton.Enabled = true;
                    MessageBox.Show("Export is complete, check the Artemis Roleplaying Kit plugin.", "FFXIV Voice Pack Creator");
                } else {
                    MessageBox.Show("No files were exported. No Artemis Roleplaying Kit cache was found.", "FFXIV Voice Pack Creator");
                }
            } else {
                MessageBox.Show("Please enter a name!", "FFXIV Voice Pack Creator");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(currentSavePath)) {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Roleplaying Voice Pack Project|*.rpvpp;";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    currentSavePath = saveFileDialog.FileName;
                    Save(currentSavePath);
                }
            } else {
                Save(currentSavePath);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!HasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (currentSavePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "FFXIV Sound Project|*.rpvpp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                currentSavePath = saveFileDialog.FileName;
                            }
                        }
                        if (currentSavePath != null) {
                            Save(currentSavePath);
                            _categories.Clear();
                            soundList.Items.Clear();
                            categoryList.Items.Clear();
                        }
                        break;
                    case DialogResult.No:
                        HasSaved = true;
                        _categories.Clear();
                        soundList.Items.Clear();
                        categoryList.Items.Clear();
                        break;
                    case DialogResult.Cancel:

                        break;
                }
            } else {
                HasSaved = true;
                _categories.Clear();
                soundList.Items.Clear();
                categoryList.Items.Clear();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Roleplaying Voice Pack Project|*.rpvpp;";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                currentSavePath = saveFileDialog.FileName;
                Save(currentSavePath);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Roleplaying Voice Pack Project|*.rpvpp;*.ffxivsp;";
            if (!HasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (currentSavePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Roleplaying Voice Pack Project|*.rpvpp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                currentSavePath = saveFileDialog.FileName;
                            }
                        }
                        if (currentSavePath != null) {
                            Save(currentSavePath);
                            _categories.Clear();
                            soundList.Items.Clear();
                            categoryList.Items.Clear();
                            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                                currentSavePath = openFileDialog.FileName;
                                if (currentSavePath.EndsWith(".rpvpp")) {
                                    Open(currentSavePath);
                                } else {
                                    OpenOldProject(currentSavePath);
                                    currentSavePath = currentSavePath.Replace(".ffxivsp", ".rpvpp");
                                }
                            }
                        }
                        break;
                    case DialogResult.No:
                        _categories.Clear();
                        soundList.Items.Clear();
                        categoryList.Items.Clear();
                        if (openFileDialog.ShowDialog() == DialogResult.OK) {
                            currentSavePath = openFileDialog.FileName;
                            if (currentSavePath.EndsWith(".rpvpp")) {
                                Open(currentSavePath);
                            } else {
                                OpenOldProject(currentSavePath);
                                currentSavePath = currentSavePath.Replace(".ffxivsp", ".rpvpp");
                            }
                        }
                        break;
                    case DialogResult.Cancel:

                        break;
                }
            } else {
                HasSaved = true;
                _categories.Clear();
                soundList.Items.Clear();
                categoryList.Items.Clear();
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    currentSavePath = openFileDialog.FileName;
                    if (currentSavePath.EndsWith(".rpvpp")) {
                        Open(currentSavePath);
                    } else {
                        OpenOldProject(currentSavePath);
                        currentSavePath = currentSavePath.Replace(".ffxivsp", ".rpvpp");
                    }
                }
            }
        }
        public void Save(string path) {
            string json = JsonConvert.SerializeObject(new RoleplayingVoicePackProject(nameTextBox.Text, _categories));
            StreamWriter writer = File.CreateText(path);
            writer.Write(json);
            writer.Flush();
            writer.Close();
            HasSaved = true;
        }
        public void Open(string path) {
            _categories.Clear();
            soundList.Items.Clear();
            categoryList.Items.Clear();
            using (StreamReader reader = File.OpenText(path)) {
                RoleplayingVoicePackProject project =
                        JsonConvert.DeserializeObject<RoleplayingVoicePackProject>(reader.ReadToEnd());
                _categories = project.Categories;
                nameTextBox.Text = project.Name;
                RefreshCategories();
                RefreshLists();
            }
        }

        private void RoleplayingVoicePackCreator_FormClosing(object sender, FormClosingEventArgs e) {
            if (!HasSaved) {
                DialogResult dialogResult = MessageBox.Show("Save changes?", Text, MessageBoxButtons.YesNoCancel);
                switch (dialogResult) {
                    case DialogResult.Yes:
                        if (currentSavePath == null) {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "FFXIV Sound Project|*.ffxivsp;";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                currentSavePath = saveFileDialog.FileName;
                            }
                        }
                        if (currentSavePath != null) {
                            Save(currentSavePath);
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            foreach (Process process in Process.GetProcessesByName("ffmpeg")) {
                process.Kill();
            }
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
        private void legacyWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            if (legacyWindow == null || !legacyWindow.Visible) {
                legacyWindow = new MainWindow();
                legacyWindow.Show();
            }
        }

        private void getRoleplayingVoiceToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Process.Start(new System.Diagnostics.ProcessStartInfo() {
                    FileName = "https://github.com/Sebane1/RoleplayingVoiceDalamud",
                    UseShellExecute = true,
                    Verb = "OPEN"
                });
            } catch {

            }
        }

        private void removeCategoryButton_Click(object sender, EventArgs e) {
            if (categoryList.SelectedItem != null) {
                _categories.Remove(categoryList.SelectedItem.ToString());
                categoryList.Items.RemoveAt(categoryList.SelectedIndex);
            }
        }

        public void OpenOldProject(string path) {
            List<string> emoteList = new List<string>();
            List<string> battleList = new List<string>();
            try {
                using (StreamReader reader = new StreamReader(path)) {
                    int version = int.Parse(reader.ReadLine());
                    switch (version) {
                        case 2:
                        case 3:
                        case 4:
                            OpenProjectLegacy2(reader, emoteList, battleList);
                            break;
                        default:
                            throw new Exception();
                    }
                }
            } catch {
                OpenProjectLegacy(path, emoteList);
            }
            for (int i = 0; i < emoteList.Count; i++) {
                if (i < 14) {
                    _categories[categoryComboBox.Items[i] as string] = new List<string> { emoteList[i] };
                } else {
                    break;
                }
            }
            for (int i = 0; i < battleList.Count; i++) {
                if (i < 6) {
                    if (!_categories.ContainsKey("Attack")) {
                        _categories["Attack"] = new List<string> { battleList[i] };
                    } else {
                        _categories["Attack"].Add(battleList[i]);
                    }
                } else
                if (i < 12) {
                    if (!_categories.ContainsKey("Hurt")) {
                        _categories["Hurt"] = new List<string> { battleList[i] };
                    } else {
                        _categories["Hurt"].Add(battleList[i]);
                    }
                } else
                if (i < 14) {
                    if (!_categories.ContainsKey("Death")) {
                        _categories["Death"] = new List<string> { battleList[i] };
                    } else {
                        _categories["Death"].Add(battleList[i]);
                    }
                } else
                if (i < 16) {
                    if (!_categories.ContainsKey("Attack")) {
                        _categories["Attack"] = new List<string> { battleList[i] };
                    } else {
                        _categories["Attack"].Add(battleList[i]);
                    }
                }
            }
            RefreshCategories();
            RefreshLists();
            HasSaved = true;
        }
        private void OpenProjectLegacy2(StreamReader reader, List<string> emoteList, List<string> battleList) {
            int itemCount = int.Parse(reader.ReadLine());
            nameTextBox.Text = reader.ReadLine();
            for (int i = 0; i < itemCount - 1; i++) {
                reader.ReadLine();
            }
            itemCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < itemCount; i++) {
                emoteList.Add(reader.ReadLine());
            }
            itemCount = int.Parse(reader.ReadLine());
            for (int i = 0; i < itemCount; i++) {
                if (i < 16) {
                    battleList.Add(reader.ReadLine());
                } else {
                    reader.ReadLine();
                }
            }
        }
        public void OpenProjectLegacy(string path, List<string> emoteList) {
            using (StreamReader reader = new StreamReader(path)) {
                int itemCount = int.Parse(reader.ReadLine());
                nameTextBox.Text = reader.ReadLine();
                for (int i = 0; i < itemCount - 1; i++) {
                    reader.ReadLine();
                }
                itemCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < itemCount; i++) {
                    emoteList.Add(reader.ReadLine());
                }
            }
            HasSaved = true;
        }

        private void soundList_DoubleClick(object sender, EventArgs e) {
            if (soundList.SelectedIndex > -1) {
                string fileName = _categories[categoryList.SelectedItem as string][soundList.SelectedIndex];
                Task.Run(async () => {
                    int maxTime = 20000;
                    if (File.Exists(fileName)) {
                        if (output != null) {
                            output.Stop();
                        }
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        output = new WaveOutEvent();
                        if (fileName.EndsWith(".ogg")) {
                            using (var player = new VorbisWaveReader(fileName)) {
                                output.Init(player);
                                output.Play();
                                while (output.PlaybackState == PlaybackState.Playing) {
                                    Thread.Sleep(200); ;
                                    if (stopwatch.ElapsedMilliseconds > maxTime) {
                                        output.Stop();
                                        break;
                                    }
                                }
                            }
                        } else {
                            using (var player = new AudioFileReader(fileName)) {
                                output.Init(player);
                                output.Play();
                                while (output.PlaybackState == PlaybackState.Playing) {
                                    Thread.Sleep(200);
                                    //Application.DoEvents();
                                    if (stopwatch.ElapsedMilliseconds > maxTime) {
                                        output.Stop();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            );
            }
        }

        private void quickImport_Click(object sender, EventArgs e) {
            MessageBox.Show("To use quick import successfully, make sure file names contain the action sound you want to replace or add sound to.", "FFXIV Voice Pack Creator");
            FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
            _categories.Clear();
            if (folderSelectDialog.ShowDialog() == DialogResult.OK) {
                foreach (string filename in Directory.GetFiles(folderSelectDialog.SelectedPath)) {
                    if (CheckExtentions(filename)) {
                        string strippedPath = FirstCharToUpper(StripNonCharacters(Path.GetFileNameWithoutExtension(filename).ToLower()));
                        if (!_categories.ContainsKey(strippedPath)) {
                            _categories[strippedPath] = new List<string> { filename };
                        } else {
                            _categories[strippedPath].Add(filename);
                        }
                    }
                    RefreshCategories();
                    RefreshLists();
                    HasSaved = false;
                }
            }
        }
        public string FirstCharToUpper(string input) {
            switch (input) {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input[0].ToString().ToUpper() + input.Substring(1);
            }
        }
        public string StripNonCharacters(string str) {
            Regex rgx = new Regex("[^a-zA-Z]");
            str = rgx.Replace(str, "");
            return str;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e) {

        }
    }
}
