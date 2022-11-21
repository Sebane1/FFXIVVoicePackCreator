
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.incrementButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.missingFIleList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.foundNamesList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.attempts = new System.Windows.Forms.TextBox();
            this.startNumber = new System.Windows.Forms.ComboBox();
            this.startNumberGuess = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCDWavMergerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeVoiceDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickExportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.lostFileList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modNameTextbox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.modWebsiteTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.modVersionTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.jsonText = new System.Windows.Forms.TextBox();
            this.tabManager = new System.Windows.Forms.TabControl();
            this.voiceExportTab = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.clearListButton = new System.Windows.Forms.Button();
            this.removeFromList = new System.Windows.Forms.Button();
            this.voiceReplacementList = new System.Windows.Forms.ListBox();
            this.addToVoiceListButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.easyGenerateButton = new System.Windows.Forms.Button();
            this.voiceListComboBox = new System.Windows.Forms.ComboBox();
            this.raceListComboBox = new System.Windows.Forms.ComboBox();
            this.sexListComboBox = new System.Windows.Forms.ComboBox();
            this.voiceGuessingTab = new System.Windows.Forms.TabPage();
            this.unknown2 = new FFXIVVoicePackCreator.FilePicker();
            this.unknown1 = new FFXIVVoicePackCreator.FilePicker();
            this.happy = new FFXIVVoicePackCreator.FilePicker();
            this.yes = new FFXIVVoicePackCreator.FilePicker();
            this.upset = new FFXIVVoicePackCreator.FilePicker();
            this.stretch = new FFXIVVoicePackCreator.FilePicker();
            this.no = new FFXIVVoicePackCreator.FilePicker();
            this.laugh = new FFXIVVoicePackCreator.FilePicker();
            this.chuckle = new FFXIVVoicePackCreator.FilePicker();
            this.huh = new FFXIVVoicePackCreator.FilePicker();
            this.fume = new FFXIVVoicePackCreator.FilePicker();
            this.doze = new FFXIVVoicePackCreator.FilePicker();
            this.cheer = new FFXIVVoicePackCreator.FilePicker();
            this.furious = new FFXIVVoicePackCreator.FilePicker();
            this.angry = new FFXIVVoicePackCreator.FilePicker();
            this.surprised = new FFXIVVoicePackCreator.FilePicker();
            this.menuStrip1.SuspendLayout();
            this.tabManager.SuspendLayout();
            this.voiceExportTab.SuspendLayout();
            this.voiceGuessingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // incrementButton
            // 
            this.incrementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.incrementButton.Location = new System.Drawing.Point(330, 310);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(154, 23);
            this.incrementButton.TabIndex = 16;
            this.incrementButton.Text = "Guess And Generate";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(330, 278);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(154, 23);
            this.generateButton.TabIndex = 21;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Brute Force Attempts";
            // 
            // missingFIleList
            // 
            this.missingFIleList.FormattingEnabled = true;
            this.missingFIleList.Location = new System.Drawing.Point(160, 23);
            this.missingFIleList.Name = "missingFIleList";
            this.missingFIleList.Size = new System.Drawing.Size(165, 238);
            this.missingFIleList.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Missing Names";
            // 
            // foundNamesList
            // 
            this.foundNamesList.FormattingEnabled = true;
            this.foundNamesList.Location = new System.Drawing.Point(6, 23);
            this.foundNamesList.Name = "foundNamesList";
            this.foundNamesList.Size = new System.Drawing.Size(148, 238);
            this.foundNamesList.TabIndex = 28;
            this.foundNamesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDoubleClick);
            this.foundNamesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDown);
            this.foundNamesList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Found Names";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Starting Value";
            // 
            // attempts
            // 
            this.attempts.Location = new System.Drawing.Point(127, 312);
            this.attempts.Name = "attempts";
            this.attempts.Size = new System.Drawing.Size(82, 20);
            this.attempts.TabIndex = 20;
            this.attempts.Text = "0";
            // 
            // startNumber
            // 
            this.startNumber.FormattingEnabled = true;
            this.startNumber.Location = new System.Drawing.Point(215, 280);
            this.startNumber.Name = "startNumber";
            this.startNumber.Size = new System.Drawing.Size(109, 21);
            this.startNumber.TabIndex = 30;
            // 
            // startNumberGuess
            // 
            this.startNumberGuess.FormattingEnabled = true;
            this.startNumberGuess.Location = new System.Drawing.Point(215, 312);
            this.startNumberGuess.Name = "startNumberGuess";
            this.startNumberGuess.Size = new System.Drawing.Size(109, 21);
            this.startNumberGuess.TabIndex = 31;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sCDWavMergerToolStripMenuItem,
            this.changeVoiceDumpToolStripMenuItem,
            this.pickExportFolderToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sCDWavMergerToolStripMenuItem
            // 
            this.sCDWavMergerToolStripMenuItem.Name = "sCDWavMergerToolStripMenuItem";
            this.sCDWavMergerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sCDWavMergerToolStripMenuItem.Text = "SCD Audio Merger";
            this.sCDWavMergerToolStripMenuItem.Click += new System.EventHandler(this.sCDWavMergerToolStripMenuItem_Click);
            // 
            // changeVoiceDumpToolStripMenuItem
            // 
            this.changeVoiceDumpToolStripMenuItem.Name = "changeVoiceDumpToolStripMenuItem";
            this.changeVoiceDumpToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.changeVoiceDumpToolStripMenuItem.Text = "Change Voice Dump";
            this.changeVoiceDumpToolStripMenuItem.Click += new System.EventHandler(this.changeVoiceDumpToolStripMenuItem_Click);
            // 
            // pickExportFolderToolStripMenuItem
            // 
            this.pickExportFolderToolStripMenuItem.Name = "pickExportFolderToolStripMenuItem";
            this.pickExportFolderToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pickExportFolderToolStripMenuItem.Text = "Pick Export Folder";
            this.pickExportFolderToolStripMenuItem.Click += new System.EventHandler(this.pickExportFolderToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Lost Files";
            // 
            // lostFileList
            // 
            this.lostFileList.FormattingEnabled = true;
            this.lostFileList.Location = new System.Drawing.Point(331, 23);
            this.lostFileList.Name = "lostFileList";
            this.lostFileList.Size = new System.Drawing.Size(153, 238);
            this.lostFileList.TabIndex = 33;
            this.lostFileList.SelectedIndexChanged += new System.EventHandler(this.lostFileList_SelectedIndexChanged);
            this.lostFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lostFileList_MouseDoubleClick);
            this.lostFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lostNamesList_MouseDown);
            this.lostFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lostNamesList_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Name";
            // 
            // modNameTextbox
            // 
            this.modNameTextbox.Location = new System.Drawing.Point(572, 36);
            this.modNameTextbox.Name = "modNameTextbox";
            this.modNameTextbox.Size = new System.Drawing.Size(148, 20);
            this.modNameTextbox.TabIndex = 38;
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(572, 62);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(148, 20);
            this.authorTextBox.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Author";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(572, 88);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(435, 20);
            this.descriptionTextBox.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(507, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Description";
            // 
            // modWebsiteTextBox
            // 
            this.modWebsiteTextBox.Location = new System.Drawing.Point(823, 36);
            this.modWebsiteTextBox.Name = "modWebsiteTextBox";
            this.modWebsiteTextBox.Size = new System.Drawing.Size(184, 20);
            this.modWebsiteTextBox.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(758, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Website";
            // 
            // modVersionTextBox
            // 
            this.modVersionTextBox.Location = new System.Drawing.Point(823, 62);
            this.modVersionTextBox.Name = "modVersionTextBox";
            this.modVersionTextBox.Size = new System.Drawing.Size(184, 20);
            this.modVersionTextBox.TabIndex = 46;
            this.modVersionTextBox.Text = "1.0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(758, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Penumbra Json Config";
            // 
            // jsonText
            // 
            this.jsonText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonText.Location = new System.Drawing.Point(507, 136);
            this.jsonText.Multiline = true;
            this.jsonText.Name = "jsonText";
            this.jsonText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.jsonText.Size = new System.Drawing.Size(500, 105);
            this.jsonText.TabIndex = 19;
            // 
            // tabManager
            // 
            this.tabManager.Controls.Add(this.voiceExportTab);
            this.tabManager.Controls.Add(this.voiceGuessingTab);
            this.tabManager.Location = new System.Drawing.Point(507, 247);
            this.tabManager.Name = "tabManager";
            this.tabManager.SelectedIndex = 0;
            this.tabManager.Size = new System.Drawing.Size(500, 374);
            this.tabManager.TabIndex = 47;
            this.tabManager.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabManager_Selecting);
            // 
            // voiceExportTab
            // 
            this.voiceExportTab.Controls.Add(this.label13);
            this.voiceExportTab.Controls.Add(this.clearListButton);
            this.voiceExportTab.Controls.Add(this.removeFromList);
            this.voiceExportTab.Controls.Add(this.voiceReplacementList);
            this.voiceExportTab.Controls.Add(this.addToVoiceListButton);
            this.voiceExportTab.Controls.Add(this.label12);
            this.voiceExportTab.Controls.Add(this.easyGenerateButton);
            this.voiceExportTab.Controls.Add(this.voiceListComboBox);
            this.voiceExportTab.Controls.Add(this.raceListComboBox);
            this.voiceExportTab.Controls.Add(this.sexListComboBox);
            this.voiceExportTab.Location = new System.Drawing.Point(4, 22);
            this.voiceExportTab.Name = "voiceExportTab";
            this.voiceExportTab.Padding = new System.Windows.Forms.Padding(3);
            this.voiceExportTab.Size = new System.Drawing.Size(492, 348);
            this.voiceExportTab.TabIndex = 0;
            this.voiceExportTab.Text = "Voice Replacer";
            this.voiceExportTab.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Voice Replacement List";
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(9, 321);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(138, 21);
            this.clearListButton.TabIndex = 39;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // removeFromList
            // 
            this.removeFromList.Location = new System.Drawing.Point(177, 321);
            this.removeFromList.Name = "removeFromList";
            this.removeFromList.Size = new System.Drawing.Size(138, 21);
            this.removeFromList.TabIndex = 38;
            this.removeFromList.Text = "Remove Selected";
            this.removeFromList.UseVisualStyleBackColor = true;
            this.removeFromList.Click += new System.EventHandler(this.removeFromList_Click);
            // 
            // voiceReplacementList
            // 
            this.voiceReplacementList.FormattingEnabled = true;
            this.voiceReplacementList.Location = new System.Drawing.Point(9, 65);
            this.voiceReplacementList.Name = "voiceReplacementList";
            this.voiceReplacementList.Size = new System.Drawing.Size(477, 251);
            this.voiceReplacementList.TabIndex = 37;
            // 
            // addToVoiceListButton
            // 
            this.addToVoiceListButton.Location = new System.Drawing.Point(407, 11);
            this.addToVoiceListButton.Name = "addToVoiceListButton";
            this.addToVoiceListButton.Size = new System.Drawing.Size(79, 21);
            this.addToVoiceListButton.TabIndex = 36;
            this.addToVoiceListButton.Text = "Add";
            this.addToVoiceListButton.UseVisualStyleBackColor = true;
            this.addToVoiceListButton.Click += new System.EventHandler(this.addToVoiceListButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Voice";
            // 
            // easyGenerateButton
            // 
            this.easyGenerateButton.Location = new System.Drawing.Point(348, 321);
            this.easyGenerateButton.Name = "easyGenerateButton";
            this.easyGenerateButton.Size = new System.Drawing.Size(138, 21);
            this.easyGenerateButton.TabIndex = 34;
            this.easyGenerateButton.Text = "Generate";
            this.easyGenerateButton.UseVisualStyleBackColor = true;
            this.easyGenerateButton.Click += new System.EventHandler(this.easyGenerateButton_Click);
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
            this.voiceListComboBox.Location = new System.Drawing.Point(292, 12);
            this.voiceListComboBox.Name = "voiceListComboBox";
            this.voiceListComboBox.Size = new System.Drawing.Size(109, 21);
            this.voiceListComboBox.TabIndex = 33;
            // 
            // raceListComboBox
            // 
            this.raceListComboBox.FormattingEnabled = true;
            this.raceListComboBox.Location = new System.Drawing.Point(177, 12);
            this.raceListComboBox.Name = "raceListComboBox";
            this.raceListComboBox.Size = new System.Drawing.Size(109, 21);
            this.raceListComboBox.TabIndex = 32;
            // 
            // sexListComboBox
            // 
            this.sexListComboBox.FormattingEnabled = true;
            this.sexListComboBox.Items.AddRange(new object[] {
            "Masculine",
            "Feminine"});
            this.sexListComboBox.Location = new System.Drawing.Point(62, 12);
            this.sexListComboBox.Name = "sexListComboBox";
            this.sexListComboBox.Size = new System.Drawing.Size(109, 21);
            this.sexListComboBox.TabIndex = 31;
            // 
            // voiceGuessingTab
            // 
            this.voiceGuessingTab.Controls.Add(this.foundNamesList);
            this.voiceGuessingTab.Controls.Add(this.label5);
            this.voiceGuessingTab.Controls.Add(this.missingFIleList);
            this.voiceGuessingTab.Controls.Add(this.label3);
            this.voiceGuessingTab.Controls.Add(this.lostFileList);
            this.voiceGuessingTab.Controls.Add(this.label6);
            this.voiceGuessingTab.Controls.Add(this.incrementButton);
            this.voiceGuessingTab.Controls.Add(this.attempts);
            this.voiceGuessingTab.Controls.Add(this.generateButton);
            this.voiceGuessingTab.Controls.Add(this.label1);
            this.voiceGuessingTab.Controls.Add(this.startNumberGuess);
            this.voiceGuessingTab.Controls.Add(this.label2);
            this.voiceGuessingTab.Controls.Add(this.startNumber);
            this.voiceGuessingTab.Location = new System.Drawing.Point(4, 22);
            this.voiceGuessingTab.Name = "voiceGuessingTab";
            this.voiceGuessingTab.Padding = new System.Windows.Forms.Padding(3);
            this.voiceGuessingTab.Size = new System.Drawing.Size(492, 348);
            this.voiceGuessingTab.TabIndex = 1;
            this.voiceGuessingTab.Text = "Voice Guesser";
            this.voiceGuessingTab.UseVisualStyleBackColor = true;
            // 
            // unknown2
            // 
            this.unknown2.Filter = resources.GetString("unknown2.Filter");
            this.unknown2.Index = 15;
            this.unknown2.IsSaveMode = false;
            this.unknown2.Location = new System.Drawing.Point(12, 576);
            this.unknown2.Name = "unknown2";
            this.unknown2.Size = new System.Drawing.Size(489, 31);
            this.unknown2.TabIndex = 15;
            // 
            // unknown1
            // 
            this.unknown1.Filter = resources.GetString("unknown1.Filter");
            this.unknown1.Index = 14;
            this.unknown1.IsSaveMode = false;
            this.unknown1.Location = new System.Drawing.Point(12, 539);
            this.unknown1.Name = "unknown1";
            this.unknown1.Size = new System.Drawing.Size(489, 31);
            this.unknown1.TabIndex = 14;
            // 
            // happy
            // 
            this.happy.Filter = resources.GetString("happy.Filter");
            this.happy.Index = 13;
            this.happy.IsSaveMode = false;
            this.happy.Location = new System.Drawing.Point(12, 502);
            this.happy.Name = "happy";
            this.happy.Size = new System.Drawing.Size(489, 31);
            this.happy.TabIndex = 13;
            // 
            // yes
            // 
            this.yes.Filter = resources.GetString("yes.Filter");
            this.yes.Index = 12;
            this.yes.IsSaveMode = false;
            this.yes.Location = new System.Drawing.Point(12, 469);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(489, 31);
            this.yes.TabIndex = 12;
            // 
            // upset
            // 
            this.upset.Filter = resources.GetString("upset.Filter");
            this.upset.Index = 11;
            this.upset.IsSaveMode = false;
            this.upset.Location = new System.Drawing.Point(12, 432);
            this.upset.Name = "upset";
            this.upset.Size = new System.Drawing.Size(489, 31);
            this.upset.TabIndex = 11;
            // 
            // stretch
            // 
            this.stretch.Filter = resources.GetString("stretch.Filter");
            this.stretch.Index = 10;
            this.stretch.IsSaveMode = false;
            this.stretch.Location = new System.Drawing.Point(12, 395);
            this.stretch.Name = "stretch";
            this.stretch.Size = new System.Drawing.Size(489, 31);
            this.stretch.TabIndex = 10;
            // 
            // no
            // 
            this.no.Filter = resources.GetString("no.Filter");
            this.no.Index = 9;
            this.no.IsSaveMode = false;
            this.no.Location = new System.Drawing.Point(12, 358);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(489, 31);
            this.no.TabIndex = 9;
            // 
            // laugh
            // 
            this.laugh.Filter = resources.GetString("laugh.Filter");
            this.laugh.Index = 8;
            this.laugh.IsSaveMode = false;
            this.laugh.Location = new System.Drawing.Point(12, 321);
            this.laugh.Name = "laugh";
            this.laugh.Size = new System.Drawing.Size(489, 31);
            this.laugh.TabIndex = 8;
            // 
            // chuckle
            // 
            this.chuckle.Filter = resources.GetString("chuckle.Filter");
            this.chuckle.Index = 7;
            this.chuckle.IsSaveMode = false;
            this.chuckle.Location = new System.Drawing.Point(12, 284);
            this.chuckle.Name = "chuckle";
            this.chuckle.Size = new System.Drawing.Size(489, 31);
            this.chuckle.TabIndex = 7;
            // 
            // huh
            // 
            this.huh.Filter = resources.GetString("huh.Filter");
            this.huh.Index = 6;
            this.huh.IsSaveMode = false;
            this.huh.Location = new System.Drawing.Point(12, 247);
            this.huh.Name = "huh";
            this.huh.Size = new System.Drawing.Size(489, 31);
            this.huh.TabIndex = 6;
            // 
            // fume
            // 
            this.fume.Filter = resources.GetString("fume.Filter");
            this.fume.Index = 5;
            this.fume.IsSaveMode = false;
            this.fume.Location = new System.Drawing.Point(12, 210);
            this.fume.Name = "fume";
            this.fume.Size = new System.Drawing.Size(489, 31);
            this.fume.TabIndex = 5;
            // 
            // doze
            // 
            this.doze.Filter = resources.GetString("doze.Filter");
            this.doze.Index = 4;
            this.doze.IsSaveMode = false;
            this.doze.Location = new System.Drawing.Point(12, 173);
            this.doze.Name = "doze";
            this.doze.Size = new System.Drawing.Size(489, 31);
            this.doze.TabIndex = 4;
            // 
            // cheer
            // 
            this.cheer.Filter = resources.GetString("cheer.Filter");
            this.cheer.Index = 3;
            this.cheer.IsSaveMode = false;
            this.cheer.Location = new System.Drawing.Point(12, 136);
            this.cheer.Name = "cheer";
            this.cheer.Size = new System.Drawing.Size(489, 31);
            this.cheer.TabIndex = 3;
            // 
            // furious
            // 
            this.furious.Filter = resources.GetString("furious.Filter");
            this.furious.Index = 2;
            this.furious.IsSaveMode = false;
            this.furious.Location = new System.Drawing.Point(12, 99);
            this.furious.Name = "furious";
            this.furious.Size = new System.Drawing.Size(489, 31);
            this.furious.TabIndex = 2;
            // 
            // angry
            // 
            this.angry.Filter = resources.GetString("angry.Filter");
            this.angry.Index = 1;
            this.angry.IsSaveMode = false;
            this.angry.Location = new System.Drawing.Point(12, 62);
            this.angry.Name = "angry";
            this.angry.Size = new System.Drawing.Size(489, 31);
            this.angry.TabIndex = 1;
            // 
            // surprised
            // 
            this.surprised.Filter = resources.GetString("surprised.Filter");
            this.surprised.Index = 0;
            this.surprised.IsSaveMode = false;
            this.surprised.Location = new System.Drawing.Point(12, 25);
            this.surprised.Name = "surprised";
            this.surprised.Size = new System.Drawing.Size(489, 31);
            this.surprised.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 624);
            this.Controls.Add(this.modVersionTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.modWebsiteTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.modNameTextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.jsonText);
            this.Controls.Add(this.unknown2);
            this.Controls.Add(this.unknown1);
            this.Controls.Add(this.happy);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.upset);
            this.Controls.Add(this.stretch);
            this.Controls.Add(this.no);
            this.Controls.Add(this.laugh);
            this.Controls.Add(this.chuckle);
            this.Controls.Add(this.huh);
            this.Controls.Add(this.fume);
            this.Controls.Add(this.doze);
            this.Controls.Add(this.cheer);
            this.Controls.Add(this.furious);
            this.Controls.Add(this.angry);
            this.Controls.Add(this.surprised);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Voice Mod Filename Guesser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabManager.ResumeLayout(false);
            this.voiceExportTab.ResumeLayout(false);
            this.voiceExportTab.PerformLayout();
            this.voiceGuessingTab.ResumeLayout(false);
            this.voiceGuessingTab.PerformLayout();
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
        private FilePicker unknown1;
        private FilePicker unknown2;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox missingFIleList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox foundNamesList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox attempts;
        private System.Windows.Forms.ComboBox startNumber;
        private System.Windows.Forms.ComboBox startNumberGuess;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCDWavMergerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeVoiceDumpToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lostFileList;
        private System.Windows.Forms.ToolStripMenuItem pickExportFolderToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox modNameTextbox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox modWebsiteTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox modVersionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox jsonText;
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
    }
}

