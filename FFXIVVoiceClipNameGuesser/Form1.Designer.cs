
namespace FFXIVVoiceClipNameGuesser {
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
            this.jsonText = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.missingFIleList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.foundNamesList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.attempts = new System.Windows.Forms.TextBox();
            this.startNumber = new System.Windows.Forms.ComboBox();
            this.startNumberGuess = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCDWavMergerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unknown2 = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.unknown1 = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.happy = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.yes = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.upset = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.stretch = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.no = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.laugh = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.chuckle = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.huh = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.fume = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.doze = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.cheer = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.furious = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.angry = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.surprised = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.changeVoiceDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // incrementButton
            // 
            this.incrementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.incrementButton.Location = new System.Drawing.Point(853, 576);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(154, 23);
            this.incrementButton.TabIndex = 16;
            this.incrementButton.Text = "Guess And Generate";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // jsonText
            // 
            this.jsonText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonText.Location = new System.Drawing.Point(507, 41);
            this.jsonText.Multiline = true;
            this.jsonText.Name = "jsonText";
            this.jsonText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.jsonText.Size = new System.Drawing.Size(500, 200);
            this.jsonText.TabIndex = 19;
            this.jsonText.TextChanged += new System.EventHandler(this.jsonText_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(853, 544);
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
            this.label2.Location = new System.Drawing.Point(526, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Brute Force Attempts";
            // 
            // missingFIleList
            // 
            this.missingFIleList.FormattingEnabled = true;
            this.missingFIleList.Location = new System.Drawing.Point(866, 264);
            this.missingFIleList.Name = "missingFIleList";
            this.missingFIleList.Size = new System.Drawing.Size(141, 251);
            this.missingFIleList.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(863, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Missing Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Penumbra Json Config";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // foundNamesList
            // 
            this.foundNamesList.FormattingEnabled = true;
            this.foundNamesList.Location = new System.Drawing.Point(507, 264);
            this.foundNamesList.Name = "foundNamesList";
            this.foundNamesList.Size = new System.Drawing.Size(350, 251);
            this.foundNamesList.TabIndex = 28;
            this.foundNamesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDoubleClick);
            this.foundNamesList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseDown);
            this.foundNamesList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.foundNamesList_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Found Names";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Starting Value";
            // 
            // attempts
            // 
            this.attempts.Location = new System.Drawing.Point(638, 578);
            this.attempts.Name = "attempts";
            this.attempts.Size = new System.Drawing.Size(82, 20);
            this.attempts.TabIndex = 20;
            this.attempts.Text = "0";
            // 
            // startNumber
            // 
            this.startNumber.FormattingEnabled = true;
            this.startNumber.Location = new System.Drawing.Point(726, 546);
            this.startNumber.Name = "startNumber";
            this.startNumber.Size = new System.Drawing.Size(121, 21);
            this.startNumber.TabIndex = 30;
            this.startNumber.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // startNumberGuess
            // 
            this.startNumberGuess.FormattingEnabled = true;
            this.startNumberGuess.Location = new System.Drawing.Point(726, 578);
            this.startNumberGuess.Name = "startNumberGuess";
            this.startNumberGuess.Size = new System.Drawing.Size(121, 21);
            this.startNumberGuess.TabIndex = 31;
            this.startNumberGuess.SelectedIndexChanged += new System.EventHandler(this.startValueGuess_SelectedIndexChanged);
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
            this.changeVoiceDumpToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sCDWavMergerToolStripMenuItem
            // 
            this.sCDWavMergerToolStripMenuItem.Name = "sCDWavMergerToolStripMenuItem";
            this.sCDWavMergerToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.sCDWavMergerToolStripMenuItem.Text = "SCD Wav Merger (Experimental)";
            this.sCDWavMergerToolStripMenuItem.Click += new System.EventHandler(this.sCDWavMergerToolStripMenuItem_Click);
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
            // changeVoiceDumpToolStripMenuItem
            // 
            this.changeVoiceDumpToolStripMenuItem.Name = "changeVoiceDumpToolStripMenuItem";
            this.changeVoiceDumpToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.changeVoiceDumpToolStripMenuItem.Text = "Change Voice Dump";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 624);
            this.Controls.Add(this.startNumberGuess);
            this.Controls.Add(this.startNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.foundNamesList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.missingFIleList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.attempts);
            this.Controls.Add(this.jsonText);
            this.Controls.Add(this.incrementButton);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Voice Mod Filename Guesser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox jsonText;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox missingFIleList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
    }
}

