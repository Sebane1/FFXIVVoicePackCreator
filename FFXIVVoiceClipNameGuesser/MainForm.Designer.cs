
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.missingFIleList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.foundNamesList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCDWavMergerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCDEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkSCDAudioExtractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurePenumbraFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeVoiceDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.battleSoundGuidelinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troubleshootingFAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshFFXIVInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.lostFileList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modNameTextBox = new System.Windows.Forms.TextBox();
            this.modAuthorTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.modDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.modWebsiteTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.modVersionTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabManager = new System.Windows.Forms.TabControl();
            this.voiceExportTab = new System.Windows.Forms.TabPage();
            this.autoSyncCheckbox = new System.Windows.Forms.CheckBox();
            this.oldExportMode = new System.Windows.Forms.CheckBox();
            this.addRaceButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.clearListButton = new System.Windows.Forms.Button();
            this.removeFromList = new System.Windows.Forms.Button();
            this.voiceReplacementList = new System.Windows.Forms.ListBox();
            this.addToVoiceListButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.voiceListComboBox = new System.Windows.Forms.ComboBox();
            this.raceListComboBox = new System.Windows.Forms.ComboBox();
            this.sexListComboBox = new System.Windows.Forms.ComboBox();
            this.voiceGuessingTab = new System.Windows.Forms.TabPage();
            this.exportProgressBar = new System.Windows.Forms.ProgressBar();
            this.easyGenerateButton = new System.Windows.Forms.Button();
            this.quickImportButton = new System.Windows.Forms.Button();
            this.quickSwapButton = new System.Windows.Forms.Button();
            this.voiceTabs = new System.Windows.Forms.TabControl();
            this.emoteVoicesPage = new System.Windows.Forms.TabPage();
            this.testingLabel = new System.Windows.Forms.Label();
            this.surprised = new FFXIVVoicePackCreator.FilePicker();
            this.angry = new FFXIVVoicePackCreator.FilePicker();
            this.furious = new FFXIVVoicePackCreator.FilePicker();
            this.cheer = new FFXIVVoicePackCreator.FilePicker();
            this.doze = new FFXIVVoicePackCreator.FilePicker();
            this.fume = new FFXIVVoicePackCreator.FilePicker();
            this.huh = new FFXIVVoicePackCreator.FilePicker();
            this.chuckle = new FFXIVVoicePackCreator.FilePicker();
            this.laugh = new FFXIVVoicePackCreator.FilePicker();
            this.no = new FFXIVVoicePackCreator.FilePicker();
            this.stretch = new FFXIVVoicePackCreator.FilePicker();
            this.upset = new FFXIVVoicePackCreator.FilePicker();
            this.yes = new FFXIVVoicePackCreator.FilePicker();
            this.happy = new FFXIVVoicePackCreator.FilePicker();
            this.battleVoicesPage = new System.Windows.Forms.TabPage();
            this.extra2 = new FFXIVVoicePackCreator.FilePicker();
            this.extra1 = new FFXIVVoicePackCreator.FilePicker();
            this.death2 = new FFXIVVoicePackCreator.FilePicker();
            this.death1 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt6 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt5 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt4 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt3 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt2 = new FFXIVVoicePackCreator.FilePicker();
            this.hurt1 = new FFXIVVoicePackCreator.FilePicker();
            this.attack6 = new FFXIVVoicePackCreator.FilePicker();
            this.attack5 = new FFXIVVoicePackCreator.FilePicker();
            this.attack4 = new FFXIVVoicePackCreator.FilePicker();
            this.attack3 = new FFXIVVoicePackCreator.FilePicker();
            this.attack2 = new FFXIVVoicePackCreator.FilePicker();
            this.attack1 = new FFXIVVoicePackCreator.FilePicker();
            this.multiSCDFile = new System.Windows.Forms.Button();
            this.unused2 = new FFXIVVoicePackCreator.FilePicker();
            this.unused1 = new FFXIVVoicePackCreator.FilePicker();
            this.voiceSwapBattleVoices = new System.Windows.Forms.CheckBox();
            this.ffxivRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.testEmotesButton = new System.Windows.Forms.Button();
            this.testBattleSoundButton = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.discordButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabManager.SuspendLayout();
            this.voiceExportTab.SuspendLayout();
            this.voiceGuessingTab.SuspendLayout();
            this.voiceTabs.SuspendLayout();
            this.emoteVoicesPage.SuspendLayout();
            this.battleVoicesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // missingFIleList
            // 
            this.missingFIleList.FormattingEnabled = true;
            this.missingFIleList.ItemHeight = 15;
            this.missingFIleList.Location = new System.Drawing.Point(173, 27);
            this.missingFIleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.missingFIleList.Name = "missingFIleList";
            this.missingFIleList.Size = new System.Drawing.Size(157, 364);
            this.missingFIleList.TabIndex = 24;
            this.missingFIleList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Missing Names";
            // 
            // foundNamesList
            // 
            this.foundNamesList.FormattingEnabled = true;
            this.foundNamesList.ItemHeight = 15;
            this.foundNamesList.Location = new System.Drawing.Point(7, 27);
            this.foundNamesList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.foundNamesList.Name = "foundNamesList";
            this.foundNamesList.Size = new System.Drawing.Size(158, 364);
            this.foundNamesList.TabIndex = 28;
            this.foundNamesList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.foundNamesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDoubleClick);
            this.foundNamesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDown);
            this.foundNamesList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Found Names";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.configToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.refreshFFXIVInstanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sCDWavMergerToolStripMenuItem,
            this.sCDEditorToolStripMenuItem,
            this.bulkSCDAudioExtractorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sCDWavMergerToolStripMenuItem
            // 
            this.sCDWavMergerToolStripMenuItem.Name = "sCDWavMergerToolStripMenuItem";
            this.sCDWavMergerToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.sCDWavMergerToolStripMenuItem.Text = "Create Standalone SCD";
            this.sCDWavMergerToolStripMenuItem.Click += new System.EventHandler(this.sCDCreatorToolStripMenuItem_Click);
            // 
            // sCDEditorToolStripMenuItem
            // 
            this.sCDEditorToolStripMenuItem.Name = "sCDEditorToolStripMenuItem";
            this.sCDEditorToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.sCDEditorToolStripMenuItem.Text = "SCD Editor";
            this.sCDEditorToolStripMenuItem.Click += new System.EventHandler(this.sCDEditorToolStripMenuItem_Click);
            // 
            // bulkSCDAudioExtractorToolStripMenuItem
            // 
            this.bulkSCDAudioExtractorToolStripMenuItem.Name = "bulkSCDAudioExtractorToolStripMenuItem";
            this.bulkSCDAudioExtractorToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.bulkSCDAudioExtractorToolStripMenuItem.Text = "Bulk SCD Audio Extractor";
            this.bulkSCDAudioExtractorToolStripMenuItem.Click += new System.EventHandler(this.bulkSCDAudioExtractorToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurePenumbraFolderToolStripMenuItem,
            this.changeVoiceDumpToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // configurePenumbraFolderToolStripMenuItem
            // 
            this.configurePenumbraFolderToolStripMenuItem.Name = "configurePenumbraFolderToolStripMenuItem";
            this.configurePenumbraFolderToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.configurePenumbraFolderToolStripMenuItem.Text = "Configure Penumbra Folder";
            this.configurePenumbraFolderToolStripMenuItem.Click += new System.EventHandler(this.pickExportFolderToolStripMenuItem_Click);
            // 
            // changeVoiceDumpToolStripMenuItem
            // 
            this.changeVoiceDumpToolStripMenuItem.Name = "changeVoiceDumpToolStripMenuItem";
            this.changeVoiceDumpToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeVoiceDumpToolStripMenuItem.Text = "Change Voice Dump";
            this.changeVoiceDumpToolStripMenuItem.Click += new System.EventHandler(this.changeVoiceDumpToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.battleSoundGuidelinesToolStripMenuItem,
            this.troubleshootingFAQToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // battleSoundGuidelinesToolStripMenuItem
            // 
            this.battleSoundGuidelinesToolStripMenuItem.Name = "battleSoundGuidelinesToolStripMenuItem";
            this.battleSoundGuidelinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.battleSoundGuidelinesToolStripMenuItem.Text = "Battle Sound Guidelines";
            this.battleSoundGuidelinesToolStripMenuItem.Click += new System.EventHandler(this.battleSoundGuidelinesToolStripMenuItem_Click);
            // 
            // troubleshootingFAQToolStripMenuItem
            // 
            this.troubleshootingFAQToolStripMenuItem.Name = "troubleshootingFAQToolStripMenuItem";
            this.troubleshootingFAQToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.troubleshootingFAQToolStripMenuItem.Text = "Troubleshooting FAQ";
            this.troubleshootingFAQToolStripMenuItem.Click += new System.EventHandler(this.troublshootingFAQToolStripMenuItem_Click);
            // 
            // refreshFFXIVInstanceToolStripMenuItem
            // 
            this.refreshFFXIVInstanceToolStripMenuItem.Name = "refreshFFXIVInstanceToolStripMenuItem";
            this.refreshFFXIVInstanceToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.refreshFFXIVInstanceToolStripMenuItem.Text = "Refresh FFXIV Instance";
            this.refreshFFXIVInstanceToolStripMenuItem.Click += new System.EventHandler(this.refreshFFXIVInstanceToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Lost Files";
            // 
            // lostFileList
            // 
            this.lostFileList.FormattingEnabled = true;
            this.lostFileList.ItemHeight = 15;
            this.lostFileList.Location = new System.Drawing.Point(338, 27);
            this.lostFileList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lostFileList.Name = "lostFileList";
            this.lostFileList.Size = new System.Drawing.Size(138, 364);
            this.lostFileList.TabIndex = 33;
            this.lostFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.lostFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lostFileList_MouseDoubleClick);
            this.lostFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lostNamesList_MouseDown);
            this.lostFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lostNamesList_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "Name";
            // 
            // modNameTextBox
            // 
            this.modNameTextBox.Location = new System.Drawing.Point(570, 52);
            this.modNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modNameTextBox.Name = "modNameTextBox";
            this.modNameTextBox.Size = new System.Drawing.Size(140, 23);
            this.modNameTextBox.TabIndex = 38;
            this.modNameTextBox.TextChanged += new System.EventHandler(this.modNameTextbox_TextChanged);
            this.modNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // modAuthorTextBox
            // 
            this.modAuthorTextBox.Location = new System.Drawing.Point(570, 82);
            this.modAuthorTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modAuthorTextBox.Name = "modAuthorTextBox";
            this.modAuthorTextBox.Size = new System.Drawing.Size(140, 23);
            this.modAuthorTextBox.TabIndex = 40;
            this.modAuthorTextBox.Text = "FFXIV Voice Pack Creator";
            this.modAuthorTextBox.TextChanged += new System.EventHandler(this.modNameTextbox_TextChanged);
            this.modAuthorTextBox.Enter += new System.EventHandler(this.modAuthorTextBox_Leave);
            this.modAuthorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.modAuthorTextBox.Leave += new System.EventHandler(this.modAuthorTextBox_Leave);
            this.modAuthorTextBox.MouseLeave += new System.EventHandler(this.modAuthorTextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 39;
            this.label8.Text = "Author";
            // 
            // modDescriptionTextBox
            // 
            this.modDescriptionTextBox.Location = new System.Drawing.Point(570, 112);
            this.modDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modDescriptionTextBox.Name = "modDescriptionTextBox";
            this.modDescriptionTextBox.Size = new System.Drawing.Size(397, 23);
            this.modDescriptionTextBox.TabIndex = 42;
            this.modDescriptionTextBox.Text = "Exported by FFXIV Voice Pack Creator";
            this.modDescriptionTextBox.TextChanged += new System.EventHandler(this.modNameTextbox_TextChanged);
            this.modDescriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.modDescriptionTextBox.Leave += new System.EventHandler(this.modDescriptionTextBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 115);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 41;
            this.label9.Text = "Description";
            // 
            // modWebsiteTextBox
            // 
            this.modWebsiteTextBox.Location = new System.Drawing.Point(789, 53);
            this.modWebsiteTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modWebsiteTextBox.Name = "modWebsiteTextBox";
            this.modWebsiteTextBox.Size = new System.Drawing.Size(178, 23);
            this.modWebsiteTextBox.TabIndex = 44;
            this.modWebsiteTextBox.Text = "https://github.com/Sebane1/FFXIVVoicePackCreator";
            this.modWebsiteTextBox.TextChanged += new System.EventHandler(this.modNameTextbox_TextChanged);
            this.modWebsiteTextBox.Enter += new System.EventHandler(this.modWebsiteTextBox_Leave);
            this.modWebsiteTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.modWebsiteTextBox.Leave += new System.EventHandler(this.modWebsiteTextBox_Leave);
            this.modWebsiteTextBox.MouseLeave += new System.EventHandler(this.modWebsiteTextBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(713, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Website";
            // 
            // modVersionTextBox
            // 
            this.modVersionTextBox.Location = new System.Drawing.Point(789, 83);
            this.modVersionTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modVersionTextBox.Name = "modVersionTextBox";
            this.modVersionTextBox.Size = new System.Drawing.Size(178, 23);
            this.modVersionTextBox.TabIndex = 46;
            this.modVersionTextBox.Text = "1.0.0";
            this.modVersionTextBox.TextChanged += new System.EventHandler(this.modNameTextbox_TextChanged);
            this.modVersionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(713, 86);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "Version";
            // 
            // tabManager
            // 
            this.tabManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabManager.Controls.Add(this.voiceExportTab);
            this.tabManager.Controls.Add(this.voiceGuessingTab);
            this.tabManager.Location = new System.Drawing.Point(488, 141);
            this.tabManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabManager.MinimumSize = new System.Drawing.Size(492, 435);
            this.tabManager.Name = "tabManager";
            this.tabManager.SelectedIndex = 0;
            this.tabManager.Size = new System.Drawing.Size(492, 435);
            this.tabManager.TabIndex = 47;
            this.tabManager.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabManager_Selecting);
            // 
            // voiceExportTab
            // 
            this.voiceExportTab.Controls.Add(this.autoSyncCheckbox);
            this.voiceExportTab.Controls.Add(this.oldExportMode);
            this.voiceExportTab.Controls.Add(this.addRaceButton);
            this.voiceExportTab.Controls.Add(this.label13);
            this.voiceExportTab.Controls.Add(this.clearListButton);
            this.voiceExportTab.Controls.Add(this.removeFromList);
            this.voiceExportTab.Controls.Add(this.voiceReplacementList);
            this.voiceExportTab.Controls.Add(this.addToVoiceListButton);
            this.voiceExportTab.Controls.Add(this.label12);
            this.voiceExportTab.Controls.Add(this.voiceListComboBox);
            this.voiceExportTab.Controls.Add(this.raceListComboBox);
            this.voiceExportTab.Controls.Add(this.sexListComboBox);
            this.voiceExportTab.Location = new System.Drawing.Point(4, 24);
            this.voiceExportTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceExportTab.Name = "voiceExportTab";
            this.voiceExportTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceExportTab.Size = new System.Drawing.Size(484, 407);
            this.voiceExportTab.TabIndex = 0;
            this.voiceExportTab.Text = "Voice Replacer";
            this.voiceExportTab.UseVisualStyleBackColor = true;
            // 
            // autoSyncCheckbox
            // 
            this.autoSyncCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoSyncCheckbox.AutoSize = true;
            this.autoSyncCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.autoSyncCheckbox.Checked = true;
            this.autoSyncCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSyncCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.autoSyncCheckbox.Location = new System.Drawing.Point(117, 383);
            this.autoSyncCheckbox.Name = "autoSyncCheckbox";
            this.autoSyncCheckbox.Size = new System.Drawing.Size(169, 19);
            this.autoSyncCheckbox.TabIndex = 55;
            this.autoSyncCheckbox.Text = "Synchronize To Animations";
            this.autoSyncCheckbox.UseVisualStyleBackColor = false;
            this.autoSyncCheckbox.CheckedChanged += new System.EventHandler(this.autoSyncCheckbox_CheckedChanged);
            // 
            // oldExportMode
            // 
            this.oldExportMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldExportMode.AutoSize = true;
            this.oldExportMode.BackColor = System.Drawing.Color.IndianRed;
            this.oldExportMode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.oldExportMode.Location = new System.Drawing.Point(3, 383);
            this.oldExportMode.Name = "oldExportMode";
            this.oldExportMode.Size = new System.Drawing.Size(116, 19);
            this.oldExportMode.TabIndex = 54;
            this.oldExportMode.Text = "Old Export Mode";
            this.oldExportMode.UseVisualStyleBackColor = false;
            this.oldExportMode.Visible = false;
            // 
            // addRaceButton
            // 
            this.addRaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRaceButton.Location = new System.Drawing.Point(378, 12);
            this.addRaceButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addRaceButton.Name = "addRaceButton";
            this.addRaceButton.Size = new System.Drawing.Size(91, 25);
            this.addRaceButton.TabIndex = 41;
            this.addRaceButton.Text = "Add All Voices";
            this.addRaceButton.UseVisualStyleBackColor = true;
            this.addRaceButton.Click += new System.EventHandler(this.addRaceButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 42);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 15);
            this.label13.TabIndex = 40;
            this.label13.Text = "Voice Replacement List";
            // 
            // clearListButton
            // 
            this.clearListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearListButton.Location = new System.Drawing.Point(400, 380);
            this.clearListButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(81, 24);
            this.clearListButton.TabIndex = 39;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // removeFromList
            // 
            this.removeFromList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFromList.Location = new System.Drawing.Point(288, 380);
            this.removeFromList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.removeFromList.Name = "removeFromList";
            this.removeFromList.Size = new System.Drawing.Size(108, 24);
            this.removeFromList.TabIndex = 38;
            this.removeFromList.Text = "Remove Selected";
            this.removeFromList.UseVisualStyleBackColor = true;
            this.removeFromList.Click += new System.EventHandler(this.removeFromList_Click);
            // 
            // voiceReplacementList
            // 
            this.voiceReplacementList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceReplacementList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.voiceReplacementList.FormattingEnabled = true;
            this.voiceReplacementList.ItemHeight = 15;
            this.voiceReplacementList.Location = new System.Drawing.Point(4, 60);
            this.voiceReplacementList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceReplacementList.Name = "voiceReplacementList";
            this.voiceReplacementList.Size = new System.Drawing.Size(476, 317);
            this.voiceReplacementList.TabIndex = 37;
            this.voiceReplacementList.UseTabStops = false;
            this.voiceReplacementList.SelectedIndexChanged += new System.EventHandler(this.voiceReplacementList_SelectedIndexChanged);
            // 
            // addToVoiceListButton
            // 
            this.addToVoiceListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToVoiceListButton.Location = new System.Drawing.Point(302, 12);
            this.addToVoiceListButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addToVoiceListButton.Name = "addToVoiceListButton";
            this.addToVoiceListButton.Size = new System.Drawing.Size(68, 25);
            this.addToVoiceListButton.TabIndex = 36;
            this.addToVoiceListButton.Text = "Add Voice";
            this.addToVoiceListButton.UseVisualStyleBackColor = true;
            this.addToVoiceListButton.Click += new System.EventHandler(this.addToVoiceListButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "Voice";
            // 
            // voiceListComboBox
            // 
            this.voiceListComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Voice 1",
            "Voice 2",
            "Voice 3",
            "Voice 4",
            "Voice 5",
            "Voice 6",
            "Voice 7",
            "Voice 8",
            "Voice 9",
            "Voice 10",
            "Voice 11",
            "Voice 12"});
            this.voiceListComboBox.FormattingEnabled = true;
            this.voiceListComboBox.Items.AddRange(new object[] {
            "Voice 1",
            "Voice 2",
            "Voice 3",
            "Voice 4",
            "Voice 5",
            "Voice 6",
            "Voice 7",
            "Voice 8",
            "Voice 9",
            "Voice 10",
            "Voice 11",
            "Voice 12"});
            this.voiceListComboBox.Location = new System.Drawing.Point(227, 14);
            this.voiceListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceListComboBox.Name = "voiceListComboBox";
            this.voiceListComboBox.Size = new System.Drawing.Size(67, 23);
            this.voiceListComboBox.TabIndex = 33;
            this.voiceListComboBox.Text = "Voice 1";
            // 
            // raceListComboBox
            // 
            this.raceListComboBox.FormattingEnabled = true;
            this.raceListComboBox.Location = new System.Drawing.Point(139, 14);
            this.raceListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.raceListComboBox.Name = "raceListComboBox";
            this.raceListComboBox.Size = new System.Drawing.Size(80, 23);
            this.raceListComboBox.TabIndex = 32;
            this.raceListComboBox.Text = "Midlander";
            // 
            // sexListComboBox
            // 
            this.sexListComboBox.FormattingEnabled = true;
            this.sexListComboBox.Items.AddRange(new object[] {
            "Masculine",
            "Feminine"});
            this.sexListComboBox.Location = new System.Drawing.Point(50, 14);
            this.sexListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sexListComboBox.Name = "sexListComboBox";
            this.sexListComboBox.Size = new System.Drawing.Size(81, 23);
            this.sexListComboBox.TabIndex = 31;
            this.sexListComboBox.Text = "Masculine";
            // 
            // voiceGuessingTab
            // 
            this.voiceGuessingTab.Controls.Add(this.foundNamesList);
            this.voiceGuessingTab.Controls.Add(this.label5);
            this.voiceGuessingTab.Controls.Add(this.missingFIleList);
            this.voiceGuessingTab.Controls.Add(this.label3);
            this.voiceGuessingTab.Controls.Add(this.lostFileList);
            this.voiceGuessingTab.Controls.Add(this.label6);
            this.voiceGuessingTab.Location = new System.Drawing.Point(4, 24);
            this.voiceGuessingTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceGuessingTab.Name = "voiceGuessingTab";
            this.voiceGuessingTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceGuessingTab.Size = new System.Drawing.Size(484, 407);
            this.voiceGuessingTab.TabIndex = 1;
            this.voiceGuessingTab.Text = "Voice Guesser";
            this.voiceGuessingTab.UseVisualStyleBackColor = true;
            // 
            // exportProgressBar
            // 
            this.exportProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportProgressBar.Location = new System.Drawing.Point(4, 576);
            this.exportProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exportProgressBar.Name = "exportProgressBar";
            this.exportProgressBar.Size = new System.Drawing.Size(972, 30);
            this.exportProgressBar.TabIndex = 50;
            // 
            // easyGenerateButton
            // 
            this.easyGenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.easyGenerateButton.Location = new System.Drawing.Point(780, 576);
            this.easyGenerateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.easyGenerateButton.Name = "easyGenerateButton";
            this.easyGenerateButton.Size = new System.Drawing.Size(196, 30);
            this.easyGenerateButton.TabIndex = 34;
            this.easyGenerateButton.Text = "Generate";
            this.easyGenerateButton.UseVisualStyleBackColor = true;
            this.easyGenerateButton.Click += new System.EventHandler(this.easyGenerateButton_Click);
            this.easyGenerateButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // quickImportButton
            // 
            this.quickImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quickImportButton.Location = new System.Drawing.Point(4, 576);
            this.quickImportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.quickImportButton.Name = "quickImportButton";
            this.quickImportButton.Size = new System.Drawing.Size(236, 30);
            this.quickImportButton.TabIndex = 49;
            this.quickImportButton.Text = "Quick Import";
            this.quickImportButton.UseVisualStyleBackColor = true;
            this.quickImportButton.Click += new System.EventHandler(this.quickImportButton_Click);
            this.quickImportButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // quickSwapButton
            // 
            this.quickSwapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quickSwapButton.Location = new System.Drawing.Point(240, 576);
            this.quickSwapButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.quickSwapButton.Name = "quickSwapButton";
            this.quickSwapButton.Size = new System.Drawing.Size(248, 30);
            this.quickSwapButton.TabIndex = 51;
            this.quickSwapButton.Text = "Quick Swap";
            this.quickSwapButton.UseVisualStyleBackColor = true;
            this.quickSwapButton.Click += new System.EventHandler(this.quickSwapButton_Click);
            // 
            // voiceTabs
            // 
            this.voiceTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.voiceTabs.Controls.Add(this.emoteVoicesPage);
            this.voiceTabs.Controls.Add(this.battleVoicesPage);
            this.voiceTabs.Location = new System.Drawing.Point(4, 29);
            this.voiceTabs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceTabs.Name = "voiceTabs";
            this.voiceTabs.SelectedIndex = 0;
            this.voiceTabs.Size = new System.Drawing.Size(488, 547);
            this.voiceTabs.TabIndex = 52;
            this.voiceTabs.SelectedIndexChanged += new System.EventHandler(this.voiceTabs_SelectedIndexChanged);
            // 
            // emoteVoicesPage
            // 
            this.emoteVoicesPage.Controls.Add(this.testingLabel);
            this.emoteVoicesPage.Controls.Add(this.surprised);
            this.emoteVoicesPage.Controls.Add(this.angry);
            this.emoteVoicesPage.Controls.Add(this.furious);
            this.emoteVoicesPage.Controls.Add(this.cheer);
            this.emoteVoicesPage.Controls.Add(this.doze);
            this.emoteVoicesPage.Controls.Add(this.fume);
            this.emoteVoicesPage.Controls.Add(this.huh);
            this.emoteVoicesPage.Controls.Add(this.chuckle);
            this.emoteVoicesPage.Controls.Add(this.laugh);
            this.emoteVoicesPage.Controls.Add(this.no);
            this.emoteVoicesPage.Controls.Add(this.stretch);
            this.emoteVoicesPage.Controls.Add(this.upset);
            this.emoteVoicesPage.Controls.Add(this.yes);
            this.emoteVoicesPage.Controls.Add(this.happy);
            this.emoteVoicesPage.Location = new System.Drawing.Point(4, 24);
            this.emoteVoicesPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.emoteVoicesPage.Name = "emoteVoicesPage";
            this.emoteVoicesPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.emoteVoicesPage.Size = new System.Drawing.Size(480, 519);
            this.emoteVoicesPage.TabIndex = 0;
            this.emoteVoicesPage.Text = "Emote Voices";
            this.emoteVoicesPage.UseVisualStyleBackColor = true;
            // 
            // testingLabel
            // 
            this.testingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testingLabel.BackColor = System.Drawing.Color.Silver;
            this.testingLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.testingLabel.Location = new System.Drawing.Point(0, 452);
            this.testingLabel.Name = "testingLabel";
            this.testingLabel.Size = new System.Drawing.Size(480, 64);
            this.testingLabel.TabIndex = 59;
            this.testingLabel.Text = "No Selection";
            this.testingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surprised
            // 
            this.surprised.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.surprised.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.surprised.Filter = resources.GetString("surprised.Filter");
            this.surprised.Index = 0;
            this.surprised.IsPlayable = true;
            this.surprised.IsSaveMode = false;
            this.surprised.IsSwappable = true;
            this.surprised.Location = new System.Drawing.Point(4, 4);
            this.surprised.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.surprised.MaximumSize = new System.Drawing.Size(468, 30);
            this.surprised.MinimumSize = new System.Drawing.Size(468, 30);
            this.surprised.Name = "surprised";
            this.surprised.Size = new System.Drawing.Size(468, 30);
            this.surprised.TabIndex = 0;
            this.surprised.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // angry
            // 
            this.angry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.angry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.angry.Filter = resources.GetString("angry.Filter");
            this.angry.Index = 1;
            this.angry.IsPlayable = true;
            this.angry.IsSaveMode = false;
            this.angry.IsSwappable = true;
            this.angry.Location = new System.Drawing.Point(4, 36);
            this.angry.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.angry.MaximumSize = new System.Drawing.Size(468, 30);
            this.angry.MinimumSize = new System.Drawing.Size(468, 30);
            this.angry.Name = "angry";
            this.angry.Size = new System.Drawing.Size(468, 30);
            this.angry.TabIndex = 1;
            this.angry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // furious
            // 
            this.furious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.furious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.furious.Filter = resources.GetString("furious.Filter");
            this.furious.Index = 2;
            this.furious.IsPlayable = true;
            this.furious.IsSaveMode = false;
            this.furious.IsSwappable = true;
            this.furious.Location = new System.Drawing.Point(4, 68);
            this.furious.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.furious.MaximumSize = new System.Drawing.Size(468, 30);
            this.furious.MinimumSize = new System.Drawing.Size(468, 30);
            this.furious.Name = "furious";
            this.furious.Size = new System.Drawing.Size(468, 30);
            this.furious.TabIndex = 2;
            this.furious.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // cheer
            // 
            this.cheer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cheer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cheer.Filter = resources.GetString("cheer.Filter");
            this.cheer.Index = 3;
            this.cheer.IsPlayable = true;
            this.cheer.IsSaveMode = false;
            this.cheer.IsSwappable = true;
            this.cheer.Location = new System.Drawing.Point(4, 100);
            this.cheer.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cheer.MaximumSize = new System.Drawing.Size(468, 30);
            this.cheer.MinimumSize = new System.Drawing.Size(468, 30);
            this.cheer.Name = "cheer";
            this.cheer.Size = new System.Drawing.Size(468, 30);
            this.cheer.TabIndex = 3;
            this.cheer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // doze
            // 
            this.doze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.doze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.doze.Filter = resources.GetString("doze.Filter");
            this.doze.Index = 4;
            this.doze.IsPlayable = true;
            this.doze.IsSaveMode = false;
            this.doze.IsSwappable = true;
            this.doze.Location = new System.Drawing.Point(4, 132);
            this.doze.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.doze.MaximumSize = new System.Drawing.Size(468, 30);
            this.doze.MinimumSize = new System.Drawing.Size(468, 30);
            this.doze.Name = "doze";
            this.doze.Size = new System.Drawing.Size(468, 30);
            this.doze.TabIndex = 4;
            this.doze.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // fume
            // 
            this.fume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fume.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fume.Filter = resources.GetString("fume.Filter");
            this.fume.Index = 5;
            this.fume.IsPlayable = true;
            this.fume.IsSaveMode = false;
            this.fume.IsSwappable = true;
            this.fume.Location = new System.Drawing.Point(4, 164);
            this.fume.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.fume.MaximumSize = new System.Drawing.Size(468, 30);
            this.fume.MinimumSize = new System.Drawing.Size(468, 30);
            this.fume.Name = "fume";
            this.fume.Size = new System.Drawing.Size(468, 30);
            this.fume.TabIndex = 5;
            this.fume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // huh
            // 
            this.huh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.huh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.huh.Filter = resources.GetString("huh.Filter");
            this.huh.Index = 6;
            this.huh.IsPlayable = true;
            this.huh.IsSaveMode = false;
            this.huh.IsSwappable = true;
            this.huh.Location = new System.Drawing.Point(4, 196);
            this.huh.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.huh.MaximumSize = new System.Drawing.Size(468, 30);
            this.huh.MinimumSize = new System.Drawing.Size(468, 30);
            this.huh.Name = "huh";
            this.huh.Size = new System.Drawing.Size(468, 30);
            this.huh.TabIndex = 6;
            this.huh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // chuckle
            // 
            this.chuckle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chuckle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chuckle.Filter = resources.GetString("chuckle.Filter");
            this.chuckle.Index = 7;
            this.chuckle.IsPlayable = true;
            this.chuckle.IsSaveMode = false;
            this.chuckle.IsSwappable = true;
            this.chuckle.Location = new System.Drawing.Point(4, 228);
            this.chuckle.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chuckle.MaximumSize = new System.Drawing.Size(468, 30);
            this.chuckle.MinimumSize = new System.Drawing.Size(468, 30);
            this.chuckle.Name = "chuckle";
            this.chuckle.Size = new System.Drawing.Size(468, 30);
            this.chuckle.TabIndex = 7;
            this.chuckle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // laugh
            // 
            this.laugh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.laugh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.laugh.Filter = resources.GetString("laugh.Filter");
            this.laugh.Index = 8;
            this.laugh.IsPlayable = true;
            this.laugh.IsSaveMode = false;
            this.laugh.IsSwappable = true;
            this.laugh.Location = new System.Drawing.Point(4, 260);
            this.laugh.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.laugh.MaximumSize = new System.Drawing.Size(468, 30);
            this.laugh.MinimumSize = new System.Drawing.Size(468, 30);
            this.laugh.Name = "laugh";
            this.laugh.Size = new System.Drawing.Size(468, 30);
            this.laugh.TabIndex = 8;
            this.laugh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // no
            // 
            this.no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.no.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.no.Filter = resources.GetString("no.Filter");
            this.no.Index = 9;
            this.no.IsPlayable = true;
            this.no.IsSaveMode = false;
            this.no.IsSwappable = true;
            this.no.Location = new System.Drawing.Point(4, 292);
            this.no.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.no.MaximumSize = new System.Drawing.Size(468, 30);
            this.no.MinimumSize = new System.Drawing.Size(468, 30);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(468, 30);
            this.no.TabIndex = 9;
            this.no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // stretch
            // 
            this.stretch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.stretch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stretch.Filter = resources.GetString("stretch.Filter");
            this.stretch.Index = 10;
            this.stretch.IsPlayable = true;
            this.stretch.IsSaveMode = false;
            this.stretch.IsSwappable = true;
            this.stretch.Location = new System.Drawing.Point(4, 324);
            this.stretch.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.stretch.MaximumSize = new System.Drawing.Size(468, 30);
            this.stretch.MinimumSize = new System.Drawing.Size(468, 30);
            this.stretch.Name = "stretch";
            this.stretch.Size = new System.Drawing.Size(468, 30);
            this.stretch.TabIndex = 10;
            this.stretch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // upset
            // 
            this.upset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.upset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upset.Filter = resources.GetString("upset.Filter");
            this.upset.Index = 11;
            this.upset.IsPlayable = true;
            this.upset.IsSaveMode = false;
            this.upset.IsSwappable = true;
            this.upset.Location = new System.Drawing.Point(4, 356);
            this.upset.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.upset.MaximumSize = new System.Drawing.Size(468, 30);
            this.upset.MinimumSize = new System.Drawing.Size(468, 30);
            this.upset.Name = "upset";
            this.upset.Size = new System.Drawing.Size(468, 30);
            this.upset.TabIndex = 11;
            this.upset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // yes
            // 
            this.yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.yes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.yes.Filter = resources.GetString("yes.Filter");
            this.yes.Index = 12;
            this.yes.IsPlayable = true;
            this.yes.IsSaveMode = false;
            this.yes.IsSwappable = true;
            this.yes.Location = new System.Drawing.Point(4, 388);
            this.yes.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.yes.MaximumSize = new System.Drawing.Size(468, 30);
            this.yes.MinimumSize = new System.Drawing.Size(468, 30);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(468, 30);
            this.yes.TabIndex = 12;
            this.yes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // happy
            // 
            this.happy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.happy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.happy.Filter = resources.GetString("happy.Filter");
            this.happy.Index = 13;
            this.happy.IsPlayable = true;
            this.happy.IsSaveMode = false;
            this.happy.IsSwappable = true;
            this.happy.Location = new System.Drawing.Point(4, 420);
            this.happy.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.happy.MaximumSize = new System.Drawing.Size(468, 30);
            this.happy.MinimumSize = new System.Drawing.Size(468, 30);
            this.happy.Name = "happy";
            this.happy.Size = new System.Drawing.Size(468, 30);
            this.happy.TabIndex = 13;
            this.happy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // battleVoicesPage
            // 
            this.battleVoicesPage.Controls.Add(this.extra2);
            this.battleVoicesPage.Controls.Add(this.extra1);
            this.battleVoicesPage.Controls.Add(this.death2);
            this.battleVoicesPage.Controls.Add(this.death1);
            this.battleVoicesPage.Controls.Add(this.hurt6);
            this.battleVoicesPage.Controls.Add(this.hurt5);
            this.battleVoicesPage.Controls.Add(this.hurt4);
            this.battleVoicesPage.Controls.Add(this.hurt3);
            this.battleVoicesPage.Controls.Add(this.hurt2);
            this.battleVoicesPage.Controls.Add(this.hurt1);
            this.battleVoicesPage.Controls.Add(this.attack6);
            this.battleVoicesPage.Controls.Add(this.attack5);
            this.battleVoicesPage.Controls.Add(this.attack4);
            this.battleVoicesPage.Controls.Add(this.attack3);
            this.battleVoicesPage.Controls.Add(this.attack2);
            this.battleVoicesPage.Controls.Add(this.attack1);
            this.battleVoicesPage.Controls.Add(this.multiSCDFile);
            this.battleVoicesPage.Location = new System.Drawing.Point(4, 24);
            this.battleVoicesPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.battleVoicesPage.Name = "battleVoicesPage";
            this.battleVoicesPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.battleVoicesPage.Size = new System.Drawing.Size(192, 72);
            this.battleVoicesPage.TabIndex = 1;
            this.battleVoicesPage.Text = "Battle Voices";
            this.battleVoicesPage.UseVisualStyleBackColor = true;
            // 
            // extra2
            // 
            this.extra2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.extra2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extra2.Filter = null;
            this.extra2.Index = 31;
            this.extra2.IsPlayable = true;
            this.extra2.IsSaveMode = false;
            this.extra2.IsSwappable = false;
            this.extra2.Location = new System.Drawing.Point(4, 261);
            this.extra2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extra2.MaximumSize = new System.Drawing.Size(588, 30);
            this.extra2.MinimumSize = new System.Drawing.Size(588, 30);
            this.extra2.Name = "extra2";
            this.extra2.Size = new System.Drawing.Size(588, 30);
            this.extra2.TabIndex = 17;
            // 
            // extra1
            // 
            this.extra1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.extra1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extra1.Filter = null;
            this.extra1.Index = 30;
            this.extra1.IsPlayable = true;
            this.extra1.IsSaveMode = false;
            this.extra1.IsSwappable = false;
            this.extra1.Location = new System.Drawing.Point(4, 229);
            this.extra1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extra1.MaximumSize = new System.Drawing.Size(588, 30);
            this.extra1.MinimumSize = new System.Drawing.Size(588, 30);
            this.extra1.Name = "extra1";
            this.extra1.Size = new System.Drawing.Size(588, 30);
            this.extra1.TabIndex = 16;
            // 
            // death2
            // 
            this.death2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.death2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.death2.Filter = null;
            this.death2.Index = 29;
            this.death2.IsPlayable = true;
            this.death2.IsSaveMode = false;
            this.death2.IsSwappable = false;
            this.death2.Location = new System.Drawing.Point(4, 197);
            this.death2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.death2.MaximumSize = new System.Drawing.Size(588, 30);
            this.death2.MinimumSize = new System.Drawing.Size(588, 30);
            this.death2.Name = "death2";
            this.death2.Size = new System.Drawing.Size(588, 30);
            this.death2.TabIndex = 15;
            // 
            // death1
            // 
            this.death1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.death1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.death1.Filter = null;
            this.death1.Index = 28;
            this.death1.IsPlayable = true;
            this.death1.IsSaveMode = false;
            this.death1.IsSwappable = false;
            this.death1.Location = new System.Drawing.Point(4, 165);
            this.death1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.death1.MaximumSize = new System.Drawing.Size(588, 30);
            this.death1.MinimumSize = new System.Drawing.Size(588, 30);
            this.death1.Name = "death1";
            this.death1.Size = new System.Drawing.Size(588, 30);
            this.death1.TabIndex = 14;
            // 
            // hurt6
            // 
            this.hurt6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt6.Filter = null;
            this.hurt6.Index = 27;
            this.hurt6.IsPlayable = true;
            this.hurt6.IsSaveMode = false;
            this.hurt6.IsSwappable = false;
            this.hurt6.Location = new System.Drawing.Point(4, 133);
            this.hurt6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt6.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt6.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt6.Name = "hurt6";
            this.hurt6.Size = new System.Drawing.Size(588, 30);
            this.hurt6.TabIndex = 13;
            // 
            // hurt5
            // 
            this.hurt5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt5.Filter = null;
            this.hurt5.Index = 26;
            this.hurt5.IsPlayable = true;
            this.hurt5.IsSaveMode = false;
            this.hurt5.IsSwappable = false;
            this.hurt5.Location = new System.Drawing.Point(4, 101);
            this.hurt5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt5.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt5.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt5.Name = "hurt5";
            this.hurt5.Size = new System.Drawing.Size(588, 30);
            this.hurt5.TabIndex = 12;
            // 
            // hurt4
            // 
            this.hurt4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt4.Filter = null;
            this.hurt4.Index = 25;
            this.hurt4.IsPlayable = true;
            this.hurt4.IsSaveMode = false;
            this.hurt4.IsSwappable = false;
            this.hurt4.Location = new System.Drawing.Point(4, 69);
            this.hurt4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt4.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt4.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt4.Name = "hurt4";
            this.hurt4.Size = new System.Drawing.Size(588, 30);
            this.hurt4.TabIndex = 11;
            // 
            // hurt3
            // 
            this.hurt3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt3.Filter = null;
            this.hurt3.Index = 24;
            this.hurt3.IsPlayable = true;
            this.hurt3.IsSaveMode = false;
            this.hurt3.IsSwappable = false;
            this.hurt3.Location = new System.Drawing.Point(4, 37);
            this.hurt3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt3.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt3.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt3.Name = "hurt3";
            this.hurt3.Size = new System.Drawing.Size(588, 30);
            this.hurt3.TabIndex = 10;
            // 
            // hurt2
            // 
            this.hurt2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt2.Filter = null;
            this.hurt2.Index = 23;
            this.hurt2.IsPlayable = true;
            this.hurt2.IsSaveMode = false;
            this.hurt2.IsSwappable = false;
            this.hurt2.Location = new System.Drawing.Point(4, 5);
            this.hurt2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt2.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt2.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt2.Name = "hurt2";
            this.hurt2.Size = new System.Drawing.Size(588, 30);
            this.hurt2.TabIndex = 9;
            // 
            // hurt1
            // 
            this.hurt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hurt1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hurt1.Filter = null;
            this.hurt1.Index = 22;
            this.hurt1.IsPlayable = true;
            this.hurt1.IsSaveMode = false;
            this.hurt1.IsSwappable = false;
            this.hurt1.Location = new System.Drawing.Point(4, -27);
            this.hurt1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hurt1.MaximumSize = new System.Drawing.Size(588, 30);
            this.hurt1.MinimumSize = new System.Drawing.Size(588, 30);
            this.hurt1.Name = "hurt1";
            this.hurt1.Size = new System.Drawing.Size(588, 30);
            this.hurt1.TabIndex = 8;
            // 
            // attack6
            // 
            this.attack6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack6.Filter = null;
            this.attack6.Index = 21;
            this.attack6.IsPlayable = true;
            this.attack6.IsSaveMode = false;
            this.attack6.IsSwappable = false;
            this.attack6.Location = new System.Drawing.Point(4, -59);
            this.attack6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack6.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack6.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack6.Name = "attack6";
            this.attack6.Size = new System.Drawing.Size(588, 30);
            this.attack6.TabIndex = 7;
            this.attack6.Load += new System.EventHandler(this.attack6_Load);
            // 
            // attack5
            // 
            this.attack5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack5.Filter = null;
            this.attack5.Index = 20;
            this.attack5.IsPlayable = true;
            this.attack5.IsSaveMode = false;
            this.attack5.IsSwappable = false;
            this.attack5.Location = new System.Drawing.Point(4, -91);
            this.attack5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack5.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack5.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack5.Name = "attack5";
            this.attack5.Size = new System.Drawing.Size(588, 30);
            this.attack5.TabIndex = 6;
            // 
            // attack4
            // 
            this.attack4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack4.Filter = null;
            this.attack4.Index = 19;
            this.attack4.IsPlayable = true;
            this.attack4.IsSaveMode = false;
            this.attack4.IsSwappable = false;
            this.attack4.Location = new System.Drawing.Point(4, -123);
            this.attack4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack4.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack4.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack4.Name = "attack4";
            this.attack4.Size = new System.Drawing.Size(588, 30);
            this.attack4.TabIndex = 5;
            // 
            // attack3
            // 
            this.attack3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack3.Filter = null;
            this.attack3.Index = 18;
            this.attack3.IsPlayable = true;
            this.attack3.IsSaveMode = false;
            this.attack3.IsSwappable = false;
            this.attack3.Location = new System.Drawing.Point(4, -155);
            this.attack3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack3.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack3.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack3.Name = "attack3";
            this.attack3.Size = new System.Drawing.Size(588, 30);
            this.attack3.TabIndex = 4;
            // 
            // attack2
            // 
            this.attack2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack2.Filter = null;
            this.attack2.Index = 17;
            this.attack2.IsPlayable = true;
            this.attack2.IsSaveMode = false;
            this.attack2.IsSwappable = false;
            this.attack2.Location = new System.Drawing.Point(4, -187);
            this.attack2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack2.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack2.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack2.Name = "attack2";
            this.attack2.Size = new System.Drawing.Size(588, 30);
            this.attack2.TabIndex = 3;
            // 
            // attack1
            // 
            this.attack1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.attack1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attack1.Filter = null;
            this.attack1.Index = 16;
            this.attack1.IsPlayable = true;
            this.attack1.IsSaveMode = false;
            this.attack1.IsSwappable = false;
            this.attack1.Location = new System.Drawing.Point(4, -219);
            this.attack1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.attack1.MaximumSize = new System.Drawing.Size(588, 30);
            this.attack1.MinimumSize = new System.Drawing.Size(588, 30);
            this.attack1.Name = "attack1";
            this.attack1.Size = new System.Drawing.Size(588, 30);
            this.attack1.TabIndex = 2;
            // 
            // multiSCDFile
            // 
            this.multiSCDFile.Location = new System.Drawing.Point(398, 690);
            this.multiSCDFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.multiSCDFile.Name = "multiSCDFile";
            this.multiSCDFile.Size = new System.Drawing.Size(175, 27);
            this.multiSCDFile.TabIndex = 1;
            this.multiSCDFile.Text = "Open";
            this.multiSCDFile.UseVisualStyleBackColor = true;
            this.multiSCDFile.Click += new System.EventHandler(this.multiSCDFile_Click);
            // 
            // unused2
            // 
            this.unused2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.unused2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.unused2.BackColor = System.Drawing.Color.Gainsboro;
            this.unused2.Filter = resources.GetString("unused2.Filter");
            this.unused2.Index = 15;
            this.unused2.IsPlayable = true;
            this.unused2.IsSaveMode = false;
            this.unused2.IsSwappable = true;
            this.unused2.Location = new System.Drawing.Point(504, 24);
            this.unused2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.unused2.MaximumSize = new System.Drawing.Size(468, 30);
            this.unused2.MinimumSize = new System.Drawing.Size(468, 30);
            this.unused2.Name = "unused2";
            this.unused2.Size = new System.Drawing.Size(468, 30);
            this.unused2.TabIndex = 15;
            this.unused2.Visible = false;
            this.unused2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // unused1
            // 
            this.unused1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.unused1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.unused1.BackColor = System.Drawing.Color.Gainsboro;
            this.unused1.Filter = resources.GetString("unused1.Filter");
            this.unused1.Index = 14;
            this.unused1.IsPlayable = true;
            this.unused1.IsSaveMode = false;
            this.unused1.IsSwappable = true;
            this.unused1.Location = new System.Drawing.Point(504, 24);
            this.unused1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.unused1.MaximumSize = new System.Drawing.Size(468, 30);
            this.unused1.MinimumSize = new System.Drawing.Size(468, 30);
            this.unused1.Name = "unused1";
            this.unused1.Size = new System.Drawing.Size(468, 30);
            this.unused1.TabIndex = 14;
            this.unused1.Visible = false;
            this.unused1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // voiceSwapBattleVoices
            // 
            this.voiceSwapBattleVoices.AutoSize = true;
            this.voiceSwapBattleVoices.Location = new System.Drawing.Point(175, 32);
            this.voiceSwapBattleVoices.Name = "voiceSwapBattleVoices";
            this.voiceSwapBattleVoices.Size = new System.Drawing.Size(198, 19);
            this.voiceSwapBattleVoices.TabIndex = 53;
            this.voiceSwapBattleVoices.Text = "Swap Battle Voice (Experimental)";
            this.voiceSwapBattleVoices.UseVisualStyleBackColor = true;
            this.voiceSwapBattleVoices.CheckedChanged += new System.EventHandler(this.voiceSwapBattleVoices_CheckedChanged);
            // 
            // ffxivRefreshTimer
            // 
            this.ffxivRefreshTimer.Enabled = true;
            this.ffxivRefreshTimer.Interval = 5000;
            this.ffxivRefreshTimer.Tick += new System.EventHandler(this.ffxivRefreshTimer_Tick);
            // 
            // testEmotesButton
            // 
            this.testEmotesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testEmotesButton.Location = new System.Drawing.Point(492, 576);
            this.testEmotesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.testEmotesButton.Name = "testEmotesButton";
            this.testEmotesButton.Size = new System.Drawing.Size(144, 30);
            this.testEmotesButton.TabIndex = 54;
            this.testEmotesButton.Text = "Test Emotes";
            this.testEmotesButton.UseVisualStyleBackColor = true;
            this.testEmotesButton.Click += new System.EventHandler(this.testEmotesButton_Click);
            // 
            // testBattleSoundButton
            // 
            this.testBattleSoundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testBattleSoundButton.Location = new System.Drawing.Point(636, 576);
            this.testBattleSoundButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.testBattleSoundButton.Name = "testBattleSoundButton";
            this.testBattleSoundButton.Size = new System.Drawing.Size(144, 30);
            this.testBattleSoundButton.TabIndex = 55;
            this.testBattleSoundButton.Text = "Test Battle";
            this.testBattleSoundButton.UseVisualStyleBackColor = true;
            this.testBattleSoundButton.Click += new System.EventHandler(this.testBattleSoundButton_Click);
            // 
            // donateButton
            // 
            this.donateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.donateButton.BackColor = System.Drawing.Color.IndianRed;
            this.donateButton.ForeColor = System.Drawing.Color.White;
            this.donateButton.Location = new System.Drawing.Point(904, 0);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(75, 23);
            this.donateButton.TabIndex = 56;
            this.donateButton.Text = "Donate";
            this.donateButton.UseVisualStyleBackColor = false;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // discordButton
            // 
            this.discordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.discordButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.discordButton.Location = new System.Drawing.Point(828, 0);
            this.discordButton.Name = "discordButton";
            this.discordButton.Size = new System.Drawing.Size(75, 23);
            this.discordButton.TabIndex = 57;
            this.discordButton.Text = "Discord";
            this.discordButton.UseVisualStyleBackColor = false;
            this.discordButton.Click += new System.EventHandler(this.discordButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(980, 609);
            this.Controls.Add(this.discordButton);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.exportProgressBar);
            this.Controls.Add(this.testBattleSoundButton);
            this.Controls.Add(this.voiceSwapBattleVoices);
            this.Controls.Add(this.quickSwapButton);
            this.Controls.Add(this.modVersionTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.modWebsiteTextBox);
            this.Controls.Add(this.quickImportButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.modDescriptionTextBox);
            this.Controls.Add(this.easyGenerateButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.modAuthorTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.unused2);
            this.Controls.Add(this.modNameTextBox);
            this.Controls.Add(this.unused1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabManager);
            this.Controls.Add(this.voiceTabs);
            this.Controls.Add(this.testEmotesButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFXIV Voice Pack Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabManager.ResumeLayout(false);
            this.voiceExportTab.ResumeLayout(false);
            this.voiceExportTab.PerformLayout();
            this.voiceGuessingTab.ResumeLayout(false);
            this.voiceGuessingTab.PerformLayout();
            this.voiceTabs.ResumeLayout(false);
            this.emoteVoicesPage.ResumeLayout(false);
            this.battleVoicesPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private FilePicker surprised;
        private FilePicker angry;
        private FilePicker furious;
        private FilePicker cheer;
        private FilePicker doze;
        private FilePicker fume;
        private FilePicker huh;
        private FilePicker chuckle;
        private FilePicker laugh;
        private FilePicker no;
        private FilePicker stretch;
        private FilePicker upset;
        private FilePicker yes;
        private FilePicker happy;
        private FilePicker unused1;
        private System.Windows.Forms.ListBox missingFIleList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox foundNamesList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCDWavMergerToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lostFileList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox modNameTextBox;
        private System.Windows.Forms.TextBox modAuthorTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox modDescriptionTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox modWebsiteTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox modVersionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabManager;
        private System.Windows.Forms.TabPage voiceGuessingTab;
        private System.Windows.Forms.TabPage voiceExportTab;
        private System.Windows.Forms.Button easyGenerateButton;
        private System.Windows.Forms.ComboBox voiceListComboBox;
        private System.Windows.Forms.ComboBox raceListComboBox;
        private System.Windows.Forms.ComboBox sexListComboBox;
        private System.Windows.Forms.Button clearListButton;
        private System.Windows.Forms.Button removeFromList;
        private System.Windows.Forms.ListBox voiceReplacementList;
        private System.Windows.Forms.Button addToVoiceListButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button quickImportButton;
        private System.Windows.Forms.Button addRaceButton;
        private System.Windows.Forms.ProgressBar exportProgressBar;
        private System.Windows.Forms.Button quickSwapButton;
        private System.Windows.Forms.TabControl voiceTabs;
        private System.Windows.Forms.TabPage emoteVoicesPage;
        private System.Windows.Forms.TabPage battleVoicesPage;
        private System.Windows.Forms.Button multiSCDFile;
        private FilePicker extra1;
        private FilePicker death2;
        private FilePicker death1;
        private FilePicker hurt6;
        private FilePicker hurt5;
        private FilePicker hurt4;
        private FilePicker hurt3;
        private FilePicker hurt2;
        private FilePicker hurt1;
        private FilePicker attack6;
        private FilePicker attack5;
        private FilePicker attack4;
        private FilePicker attack3;
        private FilePicker attack2;
        private FilePicker attack1;
        private FilePicker unused2;
        private FilePicker extra2;
        private System.Windows.Forms.CheckBox voiceSwapBattleVoices;
        private System.Windows.Forms.ToolStripMenuItem bulkSCDAudioExtractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurePenumbraFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem battleSoundGuidelinesToolStripMenuItem;
        private System.Windows.Forms.CheckBox oldExportMode;
        private System.Windows.Forms.ToolStripMenuItem changeVoiceDumpToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoSyncCheckbox;
        private ToolStripMenuItem sCDEditorToolStripMenuItem;
        private ToolStripMenuItem refreshFFXIVInstanceToolStripMenuItem;
        private Timer ffxivRefreshTimer;
        private Button testEmotesButton;
        private Button testBattleSoundButton;
        private ToolStripMenuItem troubleshootingFAQToolStripMenuItem;
        private Button donateButton;
        private Button discordButton;
        private Label testingLabel;

        public CheckBox AutoSyncCheckbox { get => autoSyncCheckbox; set => autoSyncCheckbox = value; }
    }
}

