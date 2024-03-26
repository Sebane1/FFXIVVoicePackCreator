
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            sCDWavMergerToolStripMenuItem = new ToolStripMenuItem();
            sCDEditorToolStripMenuItem = new ToolStripMenuItem();
            bulkSCDAudioExtractorToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            configurePenumbraFolderToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            battleSoundGuidelinesToolStripMenuItem = new ToolStripMenuItem();
            troubleshootingFAQToolStripMenuItem = new ToolStripMenuItem();
            refreshFFXIVInstanceToolStripMenuItem = new ToolStripMenuItem();
            label7 = new Label();
            modNameTextBox = new TextBox();
            modAuthorTextBox = new TextBox();
            label8 = new Label();
            modDescriptionTextBox = new TextBox();
            label9 = new Label();
            modWebsiteTextBox = new TextBox();
            label10 = new Label();
            modVersionTextBox = new TextBox();
            label11 = new Label();
            tabManager = new TabControl();
            voiceExportTab = new TabPage();
            autoSyncCheckbox = new CheckBox();
            oldExportMode = new CheckBox();
            addRaceButton = new Button();
            label13 = new Label();
            clearListButton = new Button();
            removeFromList = new Button();
            voiceReplacementList = new ListBox();
            addToVoiceListButton = new Button();
            label12 = new Label();
            voiceListComboBox = new ComboBox();
            raceListComboBox = new ComboBox();
            sexListComboBox = new ComboBox();
            exportProgressBar = new ProgressBar();
            easyGenerateButton = new Button();
            quickImportButton = new Button();
            quickSwapButton = new Button();
            voiceTabs = new TabControl();
            emoteVoicesPage = new TabPage();
            testingLabel = new Label();
            surprised = new FilePicker();
            angry = new FilePicker();
            furious = new FilePicker();
            cheer = new FilePicker();
            doze = new FilePicker();
            fume = new FilePicker();
            huh = new FilePicker();
            chuckle = new FilePicker();
            laugh = new FilePicker();
            no = new FilePicker();
            stretch = new FilePicker();
            upset = new FilePicker();
            yes = new FilePicker();
            happy = new FilePicker();
            battleVoicesPage = new TabPage();
            extra2 = new FilePicker();
            extra1 = new FilePicker();
            death2 = new FilePicker();
            death1 = new FilePicker();
            hurt6 = new FilePicker();
            hurt5 = new FilePicker();
            hurt4 = new FilePicker();
            hurt3 = new FilePicker();
            hurt2 = new FilePicker();
            hurt1 = new FilePicker();
            attack6 = new FilePicker();
            attack5 = new FilePicker();
            attack4 = new FilePicker();
            attack3 = new FilePicker();
            attack2 = new FilePicker();
            attack1 = new FilePicker();
            multiSCDFile = new Button();
            unused2 = new FilePicker();
            unused1 = new FilePicker();
            voiceSwapBattleVoices = new CheckBox();
            ffxivRefreshTimer = new Timer(components);
            testEmotesButton = new Button();
            testBattleSoundButton = new Button();
            donateButton = new Button();
            discordButton = new Button();
            menuStrip1.SuspendLayout();
            tabManager.SuspendLayout();
            voiceExportTab.SuspendLayout();
            voiceTabs.SuspendLayout();
            emoteVoicesPage.SuspendLayout();
            battleVoicesPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, configToolStripMenuItem, helpToolStripMenuItem, refreshFFXIVInstanceToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(980, 24);
            menuStrip1.TabIndex = 32;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sCDWavMergerToolStripMenuItem, sCDEditorToolStripMenuItem, bulkSCDAudioExtractorToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // sCDWavMergerToolStripMenuItem
            // 
            sCDWavMergerToolStripMenuItem.Name = "sCDWavMergerToolStripMenuItem";
            sCDWavMergerToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            sCDWavMergerToolStripMenuItem.Text = "Create Standalone SCD";
            sCDWavMergerToolStripMenuItem.Click += sCDCreatorToolStripMenuItem_Click;
            // 
            // sCDEditorToolStripMenuItem
            // 
            sCDEditorToolStripMenuItem.Name = "sCDEditorToolStripMenuItem";
            sCDEditorToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            sCDEditorToolStripMenuItem.Text = "SCD Editor";
            sCDEditorToolStripMenuItem.Click += sCDEditorToolStripMenuItem_Click;
            // 
            // bulkSCDAudioExtractorToolStripMenuItem
            // 
            bulkSCDAudioExtractorToolStripMenuItem.Name = "bulkSCDAudioExtractorToolStripMenuItem";
            bulkSCDAudioExtractorToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            bulkSCDAudioExtractorToolStripMenuItem.Text = "Bulk SCD Audio Extractor";
            bulkSCDAudioExtractorToolStripMenuItem.Click += bulkSCDAudioExtractorToolStripMenuItem_Click;
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configurePenumbraFolderToolStripMenuItem });
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            configToolStripMenuItem.Text = "Config";
            // 
            // configurePenumbraFolderToolStripMenuItem
            // 
            configurePenumbraFolderToolStripMenuItem.Name = "configurePenumbraFolderToolStripMenuItem";
            configurePenumbraFolderToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            configurePenumbraFolderToolStripMenuItem.Text = "Configure Penumbra Folder";
            configurePenumbraFolderToolStripMenuItem.Click += pickExportFolderToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { battleSoundGuidelinesToolStripMenuItem, troubleshootingFAQToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // battleSoundGuidelinesToolStripMenuItem
            // 
            battleSoundGuidelinesToolStripMenuItem.Name = "battleSoundGuidelinesToolStripMenuItem";
            battleSoundGuidelinesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            battleSoundGuidelinesToolStripMenuItem.Text = "Battle Sound Guidelines";
            battleSoundGuidelinesToolStripMenuItem.Click += battleSoundGuidelinesToolStripMenuItem_Click;
            // 
            // troubleshootingFAQToolStripMenuItem
            // 
            troubleshootingFAQToolStripMenuItem.Name = "troubleshootingFAQToolStripMenuItem";
            troubleshootingFAQToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            troubleshootingFAQToolStripMenuItem.Text = "Troubleshooting FAQ";
            troubleshootingFAQToolStripMenuItem.Click += troublshootingFAQToolStripMenuItem_Click;
            // 
            // refreshFFXIVInstanceToolStripMenuItem
            // 
            refreshFFXIVInstanceToolStripMenuItem.Name = "refreshFFXIVInstanceToolStripMenuItem";
            refreshFFXIVInstanceToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            refreshFFXIVInstanceToolStripMenuItem.Text = "Refresh FFXIV Instance";
            refreshFFXIVInstanceToolStripMenuItem.Click += refreshFFXIVInstanceToolStripMenuItem_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(492, 56);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(39, 15);
            label7.TabIndex = 35;
            label7.Text = "Name";
            // 
            // modNameTextBox
            // 
            modNameTextBox.Location = new System.Drawing.Point(570, 52);
            modNameTextBox.Margin = new Padding(4, 3, 4, 3);
            modNameTextBox.Name = "modNameTextBox";
            modNameTextBox.Size = new System.Drawing.Size(140, 23);
            modNameTextBox.TabIndex = 38;
            modNameTextBox.TextChanged += modNameTextbox_TextChanged;
            modNameTextBox.KeyDown += MainWindow_KeyDown;
            // 
            // modAuthorTextBox
            // 
            modAuthorTextBox.Location = new System.Drawing.Point(570, 82);
            modAuthorTextBox.Margin = new Padding(4, 3, 4, 3);
            modAuthorTextBox.Name = "modAuthorTextBox";
            modAuthorTextBox.Size = new System.Drawing.Size(140, 23);
            modAuthorTextBox.TabIndex = 40;
            modAuthorTextBox.Text = "FFXIV Voice Pack Creator";
            modAuthorTextBox.TextChanged += modNameTextbox_TextChanged;
            modAuthorTextBox.Enter += modAuthorTextBox_Leave;
            modAuthorTextBox.KeyDown += MainWindow_KeyDown;
            modAuthorTextBox.Leave += modAuthorTextBox_Leave;
            modAuthorTextBox.MouseLeave += modAuthorTextBox_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(492, 86);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(44, 15);
            label8.TabIndex = 39;
            label8.Text = "Author";
            // 
            // modDescriptionTextBox
            // 
            modDescriptionTextBox.Location = new System.Drawing.Point(570, 112);
            modDescriptionTextBox.Margin = new Padding(4, 3, 4, 3);
            modDescriptionTextBox.Name = "modDescriptionTextBox";
            modDescriptionTextBox.Size = new System.Drawing.Size(397, 23);
            modDescriptionTextBox.TabIndex = 42;
            modDescriptionTextBox.Text = "Exported by FFXIV Voice Pack Creator";
            modDescriptionTextBox.TextChanged += modNameTextbox_TextChanged;
            modDescriptionTextBox.KeyDown += MainWindow_KeyDown;
            modDescriptionTextBox.Leave += modDescriptionTextBox_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(492, 115);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(67, 15);
            label9.TabIndex = 41;
            label9.Text = "Description";
            // 
            // modWebsiteTextBox
            // 
            modWebsiteTextBox.Location = new System.Drawing.Point(789, 53);
            modWebsiteTextBox.Margin = new Padding(4, 3, 4, 3);
            modWebsiteTextBox.Name = "modWebsiteTextBox";
            modWebsiteTextBox.Size = new System.Drawing.Size(178, 23);
            modWebsiteTextBox.TabIndex = 44;
            modWebsiteTextBox.Text = "https://github.com/Sebane1/FFXIVVoicePackCreator";
            modWebsiteTextBox.TextChanged += modNameTextbox_TextChanged;
            modWebsiteTextBox.Enter += modWebsiteTextBox_Leave;
            modWebsiteTextBox.KeyDown += MainWindow_KeyDown;
            modWebsiteTextBox.Leave += modWebsiteTextBox_Leave;
            modWebsiteTextBox.MouseLeave += modWebsiteTextBox_Leave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(713, 56);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(49, 15);
            label10.TabIndex = 43;
            label10.Text = "Website";
            // 
            // modVersionTextBox
            // 
            modVersionTextBox.Location = new System.Drawing.Point(789, 83);
            modVersionTextBox.Margin = new Padding(4, 3, 4, 3);
            modVersionTextBox.Name = "modVersionTextBox";
            modVersionTextBox.Size = new System.Drawing.Size(178, 23);
            modVersionTextBox.TabIndex = 46;
            modVersionTextBox.Text = "1.0.0";
            modVersionTextBox.TextChanged += modNameTextbox_TextChanged;
            modVersionTextBox.KeyDown += MainWindow_KeyDown;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(713, 86);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(45, 15);
            label11.TabIndex = 45;
            label11.Text = "Version";
            // 
            // tabManager
            // 
            tabManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tabManager.Controls.Add(voiceExportTab);
            tabManager.Location = new System.Drawing.Point(488, 141);
            tabManager.Margin = new Padding(4, 3, 4, 3);
            tabManager.MinimumSize = new System.Drawing.Size(492, 435);
            tabManager.Name = "tabManager";
            tabManager.SelectedIndex = 0;
            tabManager.Size = new System.Drawing.Size(492, 435);
            tabManager.TabIndex = 47;
            tabManager.Selecting += tabManager_Selecting;
            // 
            // voiceExportTab
            // 
            voiceExportTab.Controls.Add(autoSyncCheckbox);
            voiceExportTab.Controls.Add(oldExportMode);
            voiceExportTab.Controls.Add(addRaceButton);
            voiceExportTab.Controls.Add(label13);
            voiceExportTab.Controls.Add(clearListButton);
            voiceExportTab.Controls.Add(removeFromList);
            voiceExportTab.Controls.Add(voiceReplacementList);
            voiceExportTab.Controls.Add(addToVoiceListButton);
            voiceExportTab.Controls.Add(label12);
            voiceExportTab.Controls.Add(voiceListComboBox);
            voiceExportTab.Controls.Add(raceListComboBox);
            voiceExportTab.Controls.Add(sexListComboBox);
            voiceExportTab.Location = new System.Drawing.Point(4, 24);
            voiceExportTab.Margin = new Padding(4, 3, 4, 3);
            voiceExportTab.Name = "voiceExportTab";
            voiceExportTab.Padding = new Padding(4, 3, 4, 3);
            voiceExportTab.Size = new System.Drawing.Size(484, 407);
            voiceExportTab.TabIndex = 0;
            voiceExportTab.Text = "Voice Replacer";
            voiceExportTab.UseVisualStyleBackColor = true;
            // 
            // autoSyncCheckbox
            // 
            autoSyncCheckbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            autoSyncCheckbox.AutoSize = true;
            autoSyncCheckbox.BackColor = System.Drawing.Color.Transparent;
            autoSyncCheckbox.Checked = true;
            autoSyncCheckbox.CheckState = CheckState.Checked;
            autoSyncCheckbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            autoSyncCheckbox.Location = new System.Drawing.Point(117, 383);
            autoSyncCheckbox.Name = "autoSyncCheckbox";
            autoSyncCheckbox.Size = new System.Drawing.Size(169, 19);
            autoSyncCheckbox.TabIndex = 55;
            autoSyncCheckbox.Text = "Synchronize To Animations";
            autoSyncCheckbox.UseVisualStyleBackColor = false;
            autoSyncCheckbox.CheckedChanged += autoSyncCheckbox_CheckedChanged;
            // 
            // oldExportMode
            // 
            oldExportMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            oldExportMode.AutoSize = true;
            oldExportMode.BackColor = System.Drawing.Color.IndianRed;
            oldExportMode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            oldExportMode.Location = new System.Drawing.Point(3, 383);
            oldExportMode.Name = "oldExportMode";
            oldExportMode.Size = new System.Drawing.Size(116, 19);
            oldExportMode.TabIndex = 54;
            oldExportMode.Text = "Old Export Mode";
            oldExportMode.UseVisualStyleBackColor = false;
            oldExportMode.Visible = false;
            // 
            // addRaceButton
            // 
            addRaceButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addRaceButton.Location = new System.Drawing.Point(378, 12);
            addRaceButton.Margin = new Padding(4, 3, 4, 3);
            addRaceButton.Name = "addRaceButton";
            addRaceButton.Size = new System.Drawing.Size(91, 25);
            addRaceButton.TabIndex = 41;
            addRaceButton.Text = "Add All Voices";
            addRaceButton.UseVisualStyleBackColor = true;
            addRaceButton.Click += addRaceButton_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(7, 42);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(128, 15);
            label13.TabIndex = 40;
            label13.Text = "Voice Replacement List";
            // 
            // clearListButton
            // 
            clearListButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clearListButton.Location = new System.Drawing.Point(400, 380);
            clearListButton.Margin = new Padding(4, 3, 4, 3);
            clearListButton.Name = "clearListButton";
            clearListButton.Size = new System.Drawing.Size(81, 24);
            clearListButton.TabIndex = 39;
            clearListButton.Text = "Clear List";
            clearListButton.UseVisualStyleBackColor = true;
            clearListButton.Click += clearListButton_Click;
            // 
            // removeFromList
            // 
            removeFromList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            removeFromList.Location = new System.Drawing.Point(288, 380);
            removeFromList.Margin = new Padding(4, 3, 4, 3);
            removeFromList.Name = "removeFromList";
            removeFromList.Size = new System.Drawing.Size(108, 24);
            removeFromList.TabIndex = 38;
            removeFromList.Text = "Remove Selected";
            removeFromList.UseVisualStyleBackColor = true;
            removeFromList.Click += removeFromList_Click;
            // 
            // voiceReplacementList
            // 
            voiceReplacementList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            voiceReplacementList.BorderStyle = BorderStyle.FixedSingle;
            voiceReplacementList.FormattingEnabled = true;
            voiceReplacementList.ItemHeight = 15;
            voiceReplacementList.Location = new System.Drawing.Point(4, 60);
            voiceReplacementList.Margin = new Padding(4, 3, 4, 3);
            voiceReplacementList.Name = "voiceReplacementList";
            voiceReplacementList.Size = new System.Drawing.Size(476, 317);
            voiceReplacementList.TabIndex = 37;
            voiceReplacementList.UseTabStops = false;
            voiceReplacementList.SelectedIndexChanged += voiceReplacementList_SelectedIndexChanged;
            // 
            // addToVoiceListButton
            // 
            addToVoiceListButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addToVoiceListButton.Location = new System.Drawing.Point(302, 12);
            addToVoiceListButton.Margin = new Padding(4, 3, 4, 3);
            addToVoiceListButton.Name = "addToVoiceListButton";
            addToVoiceListButton.Size = new System.Drawing.Size(68, 25);
            addToVoiceListButton.TabIndex = 36;
            addToVoiceListButton.Text = "Add Voice";
            addToVoiceListButton.UseVisualStyleBackColor = true;
            addToVoiceListButton.Click += addToVoiceListButton_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(7, 17);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(35, 15);
            label12.TabIndex = 35;
            label12.Text = "Voice";
            // 
            // voiceListComboBox
            // 
            voiceListComboBox.AutoCompleteCustomSource.AddRange(new string[] { "Voice 1", "Voice 2", "Voice 3", "Voice 4", "Voice 5", "Voice 6", "Voice 7", "Voice 8", "Voice 9", "Voice 10", "Voice 11", "Voice 12" });
            voiceListComboBox.FormattingEnabled = true;
            voiceListComboBox.Items.AddRange(new object[] { "Voice 1", "Voice 2", "Voice 3", "Voice 4", "Voice 5", "Voice 6", "Voice 7", "Voice 8", "Voice 9", "Voice 10", "Voice 11", "Voice 12" });
            voiceListComboBox.Location = new System.Drawing.Point(227, 14);
            voiceListComboBox.Margin = new Padding(4, 3, 4, 3);
            voiceListComboBox.Name = "voiceListComboBox";
            voiceListComboBox.Size = new System.Drawing.Size(67, 23);
            voiceListComboBox.TabIndex = 33;
            voiceListComboBox.Text = "Voice 1";
            // 
            // raceListComboBox
            // 
            raceListComboBox.FormattingEnabled = true;
            raceListComboBox.Location = new System.Drawing.Point(139, 14);
            raceListComboBox.Margin = new Padding(4, 3, 4, 3);
            raceListComboBox.Name = "raceListComboBox";
            raceListComboBox.Size = new System.Drawing.Size(80, 23);
            raceListComboBox.TabIndex = 32;
            raceListComboBox.Text = "Midlander";
            // 
            // sexListComboBox
            // 
            sexListComboBox.FormattingEnabled = true;
            sexListComboBox.Items.AddRange(new object[] { "Masculine", "Feminine" });
            sexListComboBox.Location = new System.Drawing.Point(50, 14);
            sexListComboBox.Margin = new Padding(4, 3, 4, 3);
            sexListComboBox.Name = "sexListComboBox";
            sexListComboBox.Size = new System.Drawing.Size(81, 23);
            sexListComboBox.TabIndex = 31;
            sexListComboBox.Text = "Masculine";
            // 
            // exportProgressBar
            // 
            exportProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            exportProgressBar.Location = new System.Drawing.Point(4, 576);
            exportProgressBar.Margin = new Padding(4, 3, 4, 3);
            exportProgressBar.Name = "exportProgressBar";
            exportProgressBar.Size = new System.Drawing.Size(972, 30);
            exportProgressBar.TabIndex = 50;
            // 
            // easyGenerateButton
            // 
            easyGenerateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            easyGenerateButton.Location = new System.Drawing.Point(780, 576);
            easyGenerateButton.Margin = new Padding(4, 3, 4, 3);
            easyGenerateButton.Name = "easyGenerateButton";
            easyGenerateButton.Size = new System.Drawing.Size(196, 30);
            easyGenerateButton.TabIndex = 34;
            easyGenerateButton.Text = "Generate";
            easyGenerateButton.UseVisualStyleBackColor = true;
            easyGenerateButton.Click += easyGenerateButton_Click;
            easyGenerateButton.KeyDown += MainWindow_KeyDown;
            // 
            // quickImportButton
            // 
            quickImportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            quickImportButton.Location = new System.Drawing.Point(4, 576);
            quickImportButton.Margin = new Padding(4, 3, 4, 3);
            quickImportButton.Name = "quickImportButton";
            quickImportButton.Size = new System.Drawing.Size(236, 30);
            quickImportButton.TabIndex = 49;
            quickImportButton.Text = "Quick Import";
            quickImportButton.UseVisualStyleBackColor = true;
            quickImportButton.Click += quickImportButton_Click;
            quickImportButton.KeyDown += MainWindow_KeyDown;
            // 
            // quickSwapButton
            // 
            quickSwapButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            quickSwapButton.Location = new System.Drawing.Point(240, 576);
            quickSwapButton.Margin = new Padding(4, 3, 4, 3);
            quickSwapButton.Name = "quickSwapButton";
            quickSwapButton.Size = new System.Drawing.Size(248, 30);
            quickSwapButton.TabIndex = 51;
            quickSwapButton.Text = "Quick Swap";
            quickSwapButton.UseVisualStyleBackColor = true;
            quickSwapButton.Click += quickSwapButton_Click;
            // 
            // voiceTabs
            // 
            voiceTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            voiceTabs.Controls.Add(emoteVoicesPage);
            voiceTabs.Controls.Add(battleVoicesPage);
            voiceTabs.Location = new System.Drawing.Point(4, 29);
            voiceTabs.Margin = new Padding(4, 3, 4, 3);
            voiceTabs.Name = "voiceTabs";
            voiceTabs.SelectedIndex = 0;
            voiceTabs.Size = new System.Drawing.Size(488, 547);
            voiceTabs.TabIndex = 52;
            voiceTabs.SelectedIndexChanged += voiceTabs_SelectedIndexChanged;
            // 
            // emoteVoicesPage
            // 
            emoteVoicesPage.Controls.Add(testingLabel);
            emoteVoicesPage.Controls.Add(surprised);
            emoteVoicesPage.Controls.Add(angry);
            emoteVoicesPage.Controls.Add(furious);
            emoteVoicesPage.Controls.Add(cheer);
            emoteVoicesPage.Controls.Add(doze);
            emoteVoicesPage.Controls.Add(fume);
            emoteVoicesPage.Controls.Add(huh);
            emoteVoicesPage.Controls.Add(chuckle);
            emoteVoicesPage.Controls.Add(laugh);
            emoteVoicesPage.Controls.Add(no);
            emoteVoicesPage.Controls.Add(stretch);
            emoteVoicesPage.Controls.Add(upset);
            emoteVoicesPage.Controls.Add(yes);
            emoteVoicesPage.Controls.Add(happy);
            emoteVoicesPage.Location = new System.Drawing.Point(4, 24);
            emoteVoicesPage.Margin = new Padding(4, 3, 4, 3);
            emoteVoicesPage.Name = "emoteVoicesPage";
            emoteVoicesPage.Padding = new Padding(4, 3, 4, 3);
            emoteVoicesPage.Size = new System.Drawing.Size(480, 519);
            emoteVoicesPage.TabIndex = 0;
            emoteVoicesPage.Text = "Emote Voices";
            emoteVoicesPage.UseVisualStyleBackColor = true;
            // 
            // testingLabel
            // 
            testingLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testingLabel.BackColor = System.Drawing.Color.Silver;
            testingLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            testingLabel.Location = new System.Drawing.Point(0, 452);
            testingLabel.Name = "testingLabel";
            testingLabel.Size = new System.Drawing.Size(480, 64);
            testingLabel.TabIndex = 59;
            testingLabel.Text = "No Selection";
            testingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surprised
            // 
            surprised.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            surprised.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            surprised.Filter = resources.GetString("surprised.Filter");
            surprised.Index = 0;
            surprised.IsPlayable = true;
            surprised.IsSaveMode = false;
            surprised.IsSwappable = true;
            surprised.Location = new System.Drawing.Point(4, 4);
            surprised.Margin = new Padding(5, 3, 5, 3);
            surprised.MaximumSize = new System.Drawing.Size(468, 30);
            surprised.MinimumSize = new System.Drawing.Size(468, 30);
            surprised.Name = "surprised";
            surprised.Size = new System.Drawing.Size(468, 30);
            surprised.TabIndex = 0;
            surprised.KeyDown += MainWindow_KeyDown;
            // 
            // angry
            // 
            angry.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            angry.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            angry.Filter = resources.GetString("angry.Filter");
            angry.Index = 1;
            angry.IsPlayable = true;
            angry.IsSaveMode = false;
            angry.IsSwappable = true;
            angry.Location = new System.Drawing.Point(4, 36);
            angry.Margin = new Padding(5, 3, 5, 3);
            angry.MaximumSize = new System.Drawing.Size(468, 30);
            angry.MinimumSize = new System.Drawing.Size(468, 30);
            angry.Name = "angry";
            angry.Size = new System.Drawing.Size(468, 30);
            angry.TabIndex = 1;
            angry.KeyDown += MainWindow_KeyDown;
            // 
            // furious
            // 
            furious.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            furious.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            furious.Filter = resources.GetString("furious.Filter");
            furious.Index = 2;
            furious.IsPlayable = true;
            furious.IsSaveMode = false;
            furious.IsSwappable = true;
            furious.Location = new System.Drawing.Point(4, 68);
            furious.Margin = new Padding(5, 3, 5, 3);
            furious.MaximumSize = new System.Drawing.Size(468, 30);
            furious.MinimumSize = new System.Drawing.Size(468, 30);
            furious.Name = "furious";
            furious.Size = new System.Drawing.Size(468, 30);
            furious.TabIndex = 2;
            furious.KeyDown += MainWindow_KeyDown;
            // 
            // cheer
            // 
            cheer.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cheer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cheer.Filter = resources.GetString("cheer.Filter");
            cheer.Index = 3;
            cheer.IsPlayable = true;
            cheer.IsSaveMode = false;
            cheer.IsSwappable = true;
            cheer.Location = new System.Drawing.Point(4, 100);
            cheer.Margin = new Padding(5, 3, 5, 3);
            cheer.MaximumSize = new System.Drawing.Size(468, 30);
            cheer.MinimumSize = new System.Drawing.Size(468, 30);
            cheer.Name = "cheer";
            cheer.Size = new System.Drawing.Size(468, 30);
            cheer.TabIndex = 3;
            cheer.KeyDown += MainWindow_KeyDown;
            // 
            // doze
            // 
            doze.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            doze.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            doze.Filter = resources.GetString("doze.Filter");
            doze.Index = 4;
            doze.IsPlayable = true;
            doze.IsSaveMode = false;
            doze.IsSwappable = true;
            doze.Location = new System.Drawing.Point(4, 132);
            doze.Margin = new Padding(5, 3, 5, 3);
            doze.MaximumSize = new System.Drawing.Size(468, 30);
            doze.MinimumSize = new System.Drawing.Size(468, 30);
            doze.Name = "doze";
            doze.Size = new System.Drawing.Size(468, 30);
            doze.TabIndex = 4;
            doze.KeyDown += MainWindow_KeyDown;
            // 
            // fume
            // 
            fume.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fume.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fume.Filter = resources.GetString("fume.Filter");
            fume.Index = 5;
            fume.IsPlayable = true;
            fume.IsSaveMode = false;
            fume.IsSwappable = true;
            fume.Location = new System.Drawing.Point(4, 164);
            fume.Margin = new Padding(5, 3, 5, 3);
            fume.MaximumSize = new System.Drawing.Size(468, 30);
            fume.MinimumSize = new System.Drawing.Size(468, 30);
            fume.Name = "fume";
            fume.Size = new System.Drawing.Size(468, 30);
            fume.TabIndex = 5;
            fume.KeyDown += MainWindow_KeyDown;
            // 
            // huh
            // 
            huh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            huh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            huh.Filter = resources.GetString("huh.Filter");
            huh.Index = 6;
            huh.IsPlayable = true;
            huh.IsSaveMode = false;
            huh.IsSwappable = true;
            huh.Location = new System.Drawing.Point(4, 196);
            huh.Margin = new Padding(5, 3, 5, 3);
            huh.MaximumSize = new System.Drawing.Size(468, 30);
            huh.MinimumSize = new System.Drawing.Size(468, 30);
            huh.Name = "huh";
            huh.Size = new System.Drawing.Size(468, 30);
            huh.TabIndex = 6;
            huh.KeyDown += MainWindow_KeyDown;
            // 
            // chuckle
            // 
            chuckle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chuckle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chuckle.Filter = resources.GetString("chuckle.Filter");
            chuckle.Index = 7;
            chuckle.IsPlayable = true;
            chuckle.IsSaveMode = false;
            chuckle.IsSwappable = true;
            chuckle.Location = new System.Drawing.Point(4, 228);
            chuckle.Margin = new Padding(5, 3, 5, 3);
            chuckle.MaximumSize = new System.Drawing.Size(468, 30);
            chuckle.MinimumSize = new System.Drawing.Size(468, 30);
            chuckle.Name = "chuckle";
            chuckle.Size = new System.Drawing.Size(468, 30);
            chuckle.TabIndex = 7;
            chuckle.KeyDown += MainWindow_KeyDown;
            // 
            // laugh
            // 
            laugh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            laugh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            laugh.Filter = resources.GetString("laugh.Filter");
            laugh.Index = 8;
            laugh.IsPlayable = true;
            laugh.IsSaveMode = false;
            laugh.IsSwappable = true;
            laugh.Location = new System.Drawing.Point(4, 260);
            laugh.Margin = new Padding(5, 3, 5, 3);
            laugh.MaximumSize = new System.Drawing.Size(468, 30);
            laugh.MinimumSize = new System.Drawing.Size(468, 30);
            laugh.Name = "laugh";
            laugh.Size = new System.Drawing.Size(468, 30);
            laugh.TabIndex = 8;
            laugh.KeyDown += MainWindow_KeyDown;
            // 
            // no
            // 
            no.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            no.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            no.Filter = resources.GetString("no.Filter");
            no.Index = 9;
            no.IsPlayable = true;
            no.IsSaveMode = false;
            no.IsSwappable = true;
            no.Location = new System.Drawing.Point(4, 292);
            no.Margin = new Padding(5, 3, 5, 3);
            no.MaximumSize = new System.Drawing.Size(468, 30);
            no.MinimumSize = new System.Drawing.Size(468, 30);
            no.Name = "no";
            no.Size = new System.Drawing.Size(468, 30);
            no.TabIndex = 9;
            no.KeyDown += MainWindow_KeyDown;
            // 
            // stretch
            // 
            stretch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            stretch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stretch.Filter = resources.GetString("stretch.Filter");
            stretch.Index = 10;
            stretch.IsPlayable = true;
            stretch.IsSaveMode = false;
            stretch.IsSwappable = true;
            stretch.Location = new System.Drawing.Point(4, 324);
            stretch.Margin = new Padding(5, 3, 5, 3);
            stretch.MaximumSize = new System.Drawing.Size(468, 30);
            stretch.MinimumSize = new System.Drawing.Size(468, 30);
            stretch.Name = "stretch";
            stretch.Size = new System.Drawing.Size(468, 30);
            stretch.TabIndex = 10;
            stretch.KeyDown += MainWindow_KeyDown;
            // 
            // upset
            // 
            upset.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            upset.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            upset.Filter = resources.GetString("upset.Filter");
            upset.Index = 11;
            upset.IsPlayable = true;
            upset.IsSaveMode = false;
            upset.IsSwappable = true;
            upset.Location = new System.Drawing.Point(4, 356);
            upset.Margin = new Padding(5, 3, 5, 3);
            upset.MaximumSize = new System.Drawing.Size(468, 30);
            upset.MinimumSize = new System.Drawing.Size(468, 30);
            upset.Name = "upset";
            upset.Size = new System.Drawing.Size(468, 30);
            upset.TabIndex = 11;
            upset.KeyDown += MainWindow_KeyDown;
            // 
            // yes
            // 
            yes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            yes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            yes.Filter = resources.GetString("yes.Filter");
            yes.Index = 12;
            yes.IsPlayable = true;
            yes.IsSaveMode = false;
            yes.IsSwappable = true;
            yes.Location = new System.Drawing.Point(4, 388);
            yes.Margin = new Padding(5, 3, 5, 3);
            yes.MaximumSize = new System.Drawing.Size(468, 30);
            yes.MinimumSize = new System.Drawing.Size(468, 30);
            yes.Name = "yes";
            yes.Size = new System.Drawing.Size(468, 30);
            yes.TabIndex = 12;
            yes.KeyDown += MainWindow_KeyDown;
            // 
            // happy
            // 
            happy.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            happy.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            happy.Filter = resources.GetString("happy.Filter");
            happy.Index = 13;
            happy.IsPlayable = true;
            happy.IsSaveMode = false;
            happy.IsSwappable = true;
            happy.Location = new System.Drawing.Point(4, 420);
            happy.Margin = new Padding(5, 3, 5, 3);
            happy.MaximumSize = new System.Drawing.Size(468, 30);
            happy.MinimumSize = new System.Drawing.Size(468, 30);
            happy.Name = "happy";
            happy.Size = new System.Drawing.Size(468, 30);
            happy.TabIndex = 13;
            happy.KeyDown += MainWindow_KeyDown;
            // 
            // battleVoicesPage
            // 
            battleVoicesPage.Controls.Add(extra2);
            battleVoicesPage.Controls.Add(extra1);
            battleVoicesPage.Controls.Add(death2);
            battleVoicesPage.Controls.Add(death1);
            battleVoicesPage.Controls.Add(hurt6);
            battleVoicesPage.Controls.Add(hurt5);
            battleVoicesPage.Controls.Add(hurt4);
            battleVoicesPage.Controls.Add(hurt3);
            battleVoicesPage.Controls.Add(hurt2);
            battleVoicesPage.Controls.Add(hurt1);
            battleVoicesPage.Controls.Add(attack6);
            battleVoicesPage.Controls.Add(attack5);
            battleVoicesPage.Controls.Add(attack4);
            battleVoicesPage.Controls.Add(attack3);
            battleVoicesPage.Controls.Add(attack2);
            battleVoicesPage.Controls.Add(attack1);
            battleVoicesPage.Controls.Add(multiSCDFile);
            battleVoicesPage.Location = new System.Drawing.Point(4, 24);
            battleVoicesPage.Margin = new Padding(4, 3, 4, 3);
            battleVoicesPage.Name = "battleVoicesPage";
            battleVoicesPage.Padding = new Padding(4, 3, 4, 3);
            battleVoicesPage.Size = new System.Drawing.Size(192, 72);
            battleVoicesPage.TabIndex = 1;
            battleVoicesPage.Text = "Battle Voices";
            battleVoicesPage.UseVisualStyleBackColor = true;
            // 
            // extra2
            // 
            extra2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            extra2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            extra2.Filter = null;
            extra2.Index = 31;
            extra2.IsPlayable = true;
            extra2.IsSaveMode = false;
            extra2.IsSwappable = false;
            extra2.Location = new System.Drawing.Point(4, 261);
            extra2.Margin = new Padding(4, 3, 4, 3);
            extra2.MaximumSize = new System.Drawing.Size(588, 30);
            extra2.MinimumSize = new System.Drawing.Size(588, 30);
            extra2.Name = "extra2";
            extra2.Size = new System.Drawing.Size(588, 30);
            extra2.TabIndex = 17;
            // 
            // extra1
            // 
            extra1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            extra1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            extra1.Filter = null;
            extra1.Index = 30;
            extra1.IsPlayable = true;
            extra1.IsSaveMode = false;
            extra1.IsSwappable = false;
            extra1.Location = new System.Drawing.Point(4, 229);
            extra1.Margin = new Padding(4, 3, 4, 3);
            extra1.MaximumSize = new System.Drawing.Size(588, 30);
            extra1.MinimumSize = new System.Drawing.Size(588, 30);
            extra1.Name = "extra1";
            extra1.Size = new System.Drawing.Size(588, 30);
            extra1.TabIndex = 16;
            // 
            // death2
            // 
            death2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            death2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            death2.Filter = null;
            death2.Index = 29;
            death2.IsPlayable = true;
            death2.IsSaveMode = false;
            death2.IsSwappable = false;
            death2.Location = new System.Drawing.Point(4, 197);
            death2.Margin = new Padding(4, 3, 4, 3);
            death2.MaximumSize = new System.Drawing.Size(588, 30);
            death2.MinimumSize = new System.Drawing.Size(588, 30);
            death2.Name = "death2";
            death2.Size = new System.Drawing.Size(588, 30);
            death2.TabIndex = 15;
            // 
            // death1
            // 
            death1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            death1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            death1.Filter = null;
            death1.Index = 28;
            death1.IsPlayable = true;
            death1.IsSaveMode = false;
            death1.IsSwappable = false;
            death1.Location = new System.Drawing.Point(4, 165);
            death1.Margin = new Padding(4, 3, 4, 3);
            death1.MaximumSize = new System.Drawing.Size(588, 30);
            death1.MinimumSize = new System.Drawing.Size(588, 30);
            death1.Name = "death1";
            death1.Size = new System.Drawing.Size(588, 30);
            death1.TabIndex = 14;
            // 
            // hurt6
            // 
            hurt6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt6.Filter = null;
            hurt6.Index = 27;
            hurt6.IsPlayable = true;
            hurt6.IsSaveMode = false;
            hurt6.IsSwappable = false;
            hurt6.Location = new System.Drawing.Point(4, 133);
            hurt6.Margin = new Padding(4, 3, 4, 3);
            hurt6.MaximumSize = new System.Drawing.Size(588, 30);
            hurt6.MinimumSize = new System.Drawing.Size(588, 30);
            hurt6.Name = "hurt6";
            hurt6.Size = new System.Drawing.Size(588, 30);
            hurt6.TabIndex = 13;
            // 
            // hurt5
            // 
            hurt5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt5.Filter = null;
            hurt5.Index = 26;
            hurt5.IsPlayable = true;
            hurt5.IsSaveMode = false;
            hurt5.IsSwappable = false;
            hurt5.Location = new System.Drawing.Point(4, 101);
            hurt5.Margin = new Padding(4, 3, 4, 3);
            hurt5.MaximumSize = new System.Drawing.Size(588, 30);
            hurt5.MinimumSize = new System.Drawing.Size(588, 30);
            hurt5.Name = "hurt5";
            hurt5.Size = new System.Drawing.Size(588, 30);
            hurt5.TabIndex = 12;
            // 
            // hurt4
            // 
            hurt4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt4.Filter = null;
            hurt4.Index = 25;
            hurt4.IsPlayable = true;
            hurt4.IsSaveMode = false;
            hurt4.IsSwappable = false;
            hurt4.Location = new System.Drawing.Point(4, 69);
            hurt4.Margin = new Padding(4, 3, 4, 3);
            hurt4.MaximumSize = new System.Drawing.Size(588, 30);
            hurt4.MinimumSize = new System.Drawing.Size(588, 30);
            hurt4.Name = "hurt4";
            hurt4.Size = new System.Drawing.Size(588, 30);
            hurt4.TabIndex = 11;
            // 
            // hurt3
            // 
            hurt3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt3.Filter = null;
            hurt3.Index = 24;
            hurt3.IsPlayable = true;
            hurt3.IsSaveMode = false;
            hurt3.IsSwappable = false;
            hurt3.Location = new System.Drawing.Point(4, 37);
            hurt3.Margin = new Padding(4, 3, 4, 3);
            hurt3.MaximumSize = new System.Drawing.Size(588, 30);
            hurt3.MinimumSize = new System.Drawing.Size(588, 30);
            hurt3.Name = "hurt3";
            hurt3.Size = new System.Drawing.Size(588, 30);
            hurt3.TabIndex = 10;
            // 
            // hurt2
            // 
            hurt2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt2.Filter = null;
            hurt2.Index = 23;
            hurt2.IsPlayable = true;
            hurt2.IsSaveMode = false;
            hurt2.IsSwappable = false;
            hurt2.Location = new System.Drawing.Point(4, 5);
            hurt2.Margin = new Padding(4, 3, 4, 3);
            hurt2.MaximumSize = new System.Drawing.Size(588, 30);
            hurt2.MinimumSize = new System.Drawing.Size(588, 30);
            hurt2.Name = "hurt2";
            hurt2.Size = new System.Drawing.Size(588, 30);
            hurt2.TabIndex = 9;
            // 
            // hurt1
            // 
            hurt1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hurt1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            hurt1.Filter = null;
            hurt1.Index = 22;
            hurt1.IsPlayable = true;
            hurt1.IsSaveMode = false;
            hurt1.IsSwappable = false;
            hurt1.Location = new System.Drawing.Point(4, -27);
            hurt1.Margin = new Padding(4, 3, 4, 3);
            hurt1.MaximumSize = new System.Drawing.Size(588, 30);
            hurt1.MinimumSize = new System.Drawing.Size(588, 30);
            hurt1.Name = "hurt1";
            hurt1.Size = new System.Drawing.Size(588, 30);
            hurt1.TabIndex = 8;
            // 
            // attack6
            // 
            attack6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack6.Filter = null;
            attack6.Index = 21;
            attack6.IsPlayable = true;
            attack6.IsSaveMode = false;
            attack6.IsSwappable = false;
            attack6.Location = new System.Drawing.Point(4, -59);
            attack6.Margin = new Padding(4, 3, 4, 3);
            attack6.MaximumSize = new System.Drawing.Size(588, 30);
            attack6.MinimumSize = new System.Drawing.Size(588, 30);
            attack6.Name = "attack6";
            attack6.Size = new System.Drawing.Size(588, 30);
            attack6.TabIndex = 7;
            attack6.Load += attack6_Load;
            // 
            // attack5
            // 
            attack5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack5.Filter = null;
            attack5.Index = 20;
            attack5.IsPlayable = true;
            attack5.IsSaveMode = false;
            attack5.IsSwappable = false;
            attack5.Location = new System.Drawing.Point(4, -91);
            attack5.Margin = new Padding(4, 3, 4, 3);
            attack5.MaximumSize = new System.Drawing.Size(588, 30);
            attack5.MinimumSize = new System.Drawing.Size(588, 30);
            attack5.Name = "attack5";
            attack5.Size = new System.Drawing.Size(588, 30);
            attack5.TabIndex = 6;
            // 
            // attack4
            // 
            attack4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack4.Filter = null;
            attack4.Index = 19;
            attack4.IsPlayable = true;
            attack4.IsSaveMode = false;
            attack4.IsSwappable = false;
            attack4.Location = new System.Drawing.Point(4, -123);
            attack4.Margin = new Padding(4, 3, 4, 3);
            attack4.MaximumSize = new System.Drawing.Size(588, 30);
            attack4.MinimumSize = new System.Drawing.Size(588, 30);
            attack4.Name = "attack4";
            attack4.Size = new System.Drawing.Size(588, 30);
            attack4.TabIndex = 5;
            // 
            // attack3
            // 
            attack3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack3.Filter = null;
            attack3.Index = 18;
            attack3.IsPlayable = true;
            attack3.IsSaveMode = false;
            attack3.IsSwappable = false;
            attack3.Location = new System.Drawing.Point(4, -155);
            attack3.Margin = new Padding(4, 3, 4, 3);
            attack3.MaximumSize = new System.Drawing.Size(588, 30);
            attack3.MinimumSize = new System.Drawing.Size(588, 30);
            attack3.Name = "attack3";
            attack3.Size = new System.Drawing.Size(588, 30);
            attack3.TabIndex = 4;
            // 
            // attack2
            // 
            attack2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack2.Filter = null;
            attack2.Index = 17;
            attack2.IsPlayable = true;
            attack2.IsSaveMode = false;
            attack2.IsSwappable = false;
            attack2.Location = new System.Drawing.Point(4, -187);
            attack2.Margin = new Padding(4, 3, 4, 3);
            attack2.MaximumSize = new System.Drawing.Size(588, 30);
            attack2.MinimumSize = new System.Drawing.Size(588, 30);
            attack2.Name = "attack2";
            attack2.Size = new System.Drawing.Size(588, 30);
            attack2.TabIndex = 3;
            // 
            // attack1
            // 
            attack1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            attack1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            attack1.Filter = null;
            attack1.Index = 16;
            attack1.IsPlayable = true;
            attack1.IsSaveMode = false;
            attack1.IsSwappable = false;
            attack1.Location = new System.Drawing.Point(4, -219);
            attack1.Margin = new Padding(4, 3, 4, 3);
            attack1.MaximumSize = new System.Drawing.Size(588, 30);
            attack1.MinimumSize = new System.Drawing.Size(588, 30);
            attack1.Name = "attack1";
            attack1.Size = new System.Drawing.Size(588, 30);
            attack1.TabIndex = 2;
            // 
            // multiSCDFile
            // 
            multiSCDFile.Location = new System.Drawing.Point(398, 690);
            multiSCDFile.Margin = new Padding(4, 3, 4, 3);
            multiSCDFile.Name = "multiSCDFile";
            multiSCDFile.Size = new System.Drawing.Size(175, 27);
            multiSCDFile.TabIndex = 1;
            multiSCDFile.Text = "Open";
            multiSCDFile.UseVisualStyleBackColor = true;
            multiSCDFile.Click += multiSCDFile_Click;
            // 
            // unused2
            // 
            unused2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            unused2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            unused2.BackColor = System.Drawing.Color.Gainsboro;
            unused2.Filter = resources.GetString("unused2.Filter");
            unused2.Index = 15;
            unused2.IsPlayable = true;
            unused2.IsSaveMode = false;
            unused2.IsSwappable = true;
            unused2.Location = new System.Drawing.Point(504, 24);
            unused2.Margin = new Padding(5, 3, 5, 3);
            unused2.MaximumSize = new System.Drawing.Size(468, 30);
            unused2.MinimumSize = new System.Drawing.Size(468, 30);
            unused2.Name = "unused2";
            unused2.Size = new System.Drawing.Size(468, 30);
            unused2.TabIndex = 15;
            unused2.Visible = false;
            unused2.KeyDown += MainWindow_KeyDown;
            // 
            // unused1
            // 
            unused1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            unused1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            unused1.BackColor = System.Drawing.Color.Gainsboro;
            unused1.Filter = resources.GetString("unused1.Filter");
            unused1.Index = 14;
            unused1.IsPlayable = true;
            unused1.IsSaveMode = false;
            unused1.IsSwappable = true;
            unused1.Location = new System.Drawing.Point(504, 24);
            unused1.Margin = new Padding(5, 3, 5, 3);
            unused1.MaximumSize = new System.Drawing.Size(468, 30);
            unused1.MinimumSize = new System.Drawing.Size(468, 30);
            unused1.Name = "unused1";
            unused1.Size = new System.Drawing.Size(468, 30);
            unused1.TabIndex = 14;
            unused1.Visible = false;
            unused1.KeyDown += MainWindow_KeyDown;
            // 
            // voiceSwapBattleVoices
            // 
            voiceSwapBattleVoices.AutoSize = true;
            voiceSwapBattleVoices.Location = new System.Drawing.Point(175, 32);
            voiceSwapBattleVoices.Name = "voiceSwapBattleVoices";
            voiceSwapBattleVoices.Size = new System.Drawing.Size(198, 19);
            voiceSwapBattleVoices.TabIndex = 53;
            voiceSwapBattleVoices.Text = "Swap Battle Voice (Experimental)";
            voiceSwapBattleVoices.UseVisualStyleBackColor = true;
            voiceSwapBattleVoices.CheckedChanged += voiceSwapBattleVoices_CheckedChanged;
            // 
            // ffxivRefreshTimer
            // 
            ffxivRefreshTimer.Enabled = true;
            ffxivRefreshTimer.Interval = 5000;
            ffxivRefreshTimer.Tick += ffxivRefreshTimer_Tick;
            // 
            // testEmotesButton
            // 
            testEmotesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testEmotesButton.Location = new System.Drawing.Point(492, 576);
            testEmotesButton.Margin = new Padding(4, 3, 4, 3);
            testEmotesButton.Name = "testEmotesButton";
            testEmotesButton.Size = new System.Drawing.Size(140, 30);
            testEmotesButton.TabIndex = 54;
            testEmotesButton.Text = "Test Emotes";
            testEmotesButton.UseVisualStyleBackColor = true;
            testEmotesButton.Click += testEmotesButton_Click;
            // 
            // testBattleSoundButton
            // 
            testBattleSoundButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testBattleSoundButton.Location = new System.Drawing.Point(632, 576);
            testBattleSoundButton.Margin = new Padding(4, 3, 4, 3);
            testBattleSoundButton.Name = "testBattleSoundButton";
            testBattleSoundButton.Size = new System.Drawing.Size(148, 30);
            testBattleSoundButton.TabIndex = 55;
            testBattleSoundButton.Text = "Test Battle";
            testBattleSoundButton.UseVisualStyleBackColor = true;
            testBattleSoundButton.Click += testBattleSoundButton_Click;
            // 
            // donateButton
            // 
            donateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            donateButton.BackColor = System.Drawing.Color.IndianRed;
            donateButton.ForeColor = System.Drawing.Color.White;
            donateButton.Location = new System.Drawing.Point(904, 0);
            donateButton.Name = "donateButton";
            donateButton.Size = new System.Drawing.Size(75, 23);
            donateButton.TabIndex = 56;
            donateButton.Text = "Donate";
            donateButton.UseVisualStyleBackColor = false;
            donateButton.Click += donateButton_Click;
            // 
            // discordButton
            // 
            discordButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            discordButton.BackColor = System.Drawing.Color.RoyalBlue;
            discordButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            discordButton.Location = new System.Drawing.Point(828, 0);
            discordButton.Name = "discordButton";
            discordButton.Size = new System.Drawing.Size(75, 23);
            discordButton.TabIndex = 57;
            discordButton.Text = "Discord";
            discordButton.UseVisualStyleBackColor = false;
            discordButton.Click += discordButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(980, 609);
            Controls.Add(discordButton);
            Controls.Add(donateButton);
            Controls.Add(exportProgressBar);
            Controls.Add(testBattleSoundButton);
            Controls.Add(voiceSwapBattleVoices);
            Controls.Add(quickSwapButton);
            Controls.Add(modVersionTextBox);
            Controls.Add(label11);
            Controls.Add(modWebsiteTextBox);
            Controls.Add(quickImportButton);
            Controls.Add(label10);
            Controls.Add(modDescriptionTextBox);
            Controls.Add(easyGenerateButton);
            Controls.Add(label9);
            Controls.Add(modAuthorTextBox);
            Controls.Add(label8);
            Controls.Add(unused2);
            Controls.Add(modNameTextBox);
            Controls.Add(unused1);
            Controls.Add(label7);
            Controls.Add(menuStrip1);
            Controls.Add(tabManager);
            Controls.Add(voiceTabs);
            Controls.Add(testEmotesButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FFXIV Voice Pack Creator";
            FormClosing += MainWindow_FormClosing;
            Load += Form1_Load;
            KeyDown += MainWindow_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabManager.ResumeLayout(false);
            voiceExportTab.ResumeLayout(false);
            voiceExportTab.PerformLayout();
            voiceTabs.ResumeLayout(false);
            emoteVoicesPage.ResumeLayout(false);
            battleVoicesPage.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCDWavMergerToolStripMenuItem;
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

