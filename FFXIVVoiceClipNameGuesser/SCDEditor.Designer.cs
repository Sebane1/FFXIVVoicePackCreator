namespace FFXIVVoicePackCreator {
    partial class SCDEditor {
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
            this.originalSCD = new FFXIVVoicePackCreator.FilePicker();
            this.outputSCD = new FFXIVVoicePackCreator.FilePicker();
            this.audioDataList = new System.Windows.Forms.ListBox();
            this.replaceButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.stopPlaybackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // originalSCD
            // 
            this.originalSCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originalSCD.Filter = "SCD File|*.scd;";
            this.originalSCD.Index = 0;
            this.originalSCD.IsPlayable = false;
            this.originalSCD.IsSaveMode = false;
            this.originalSCD.IsSwappable = false;
            this.originalSCD.Location = new System.Drawing.Point(0, 4);
            this.originalSCD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.originalSCD.MinimumSize = new System.Drawing.Size(300, 28);
            this.originalSCD.Name = "originalSCD";
            this.originalSCD.Size = new System.Drawing.Size(472, 28);
            this.originalSCD.TabIndex = 0;
            this.originalSCD.OnFileSelected += new System.EventHandler(this.originalSCD_OnFileSelected);
            // 
            // outputSCD
            // 
            this.outputSCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputSCD.Filter = "SCD File|*.scd;";
            this.outputSCD.Index = 0;
            this.outputSCD.IsPlayable = false;
            this.outputSCD.IsSaveMode = true;
            this.outputSCD.IsSwappable = false;
            this.outputSCD.Location = new System.Drawing.Point(0, 36);
            this.outputSCD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.outputSCD.MinimumSize = new System.Drawing.Size(300, 28);
            this.outputSCD.Name = "outputSCD";
            this.outputSCD.Size = new System.Drawing.Size(472, 28);
            this.outputSCD.TabIndex = 1;
            // 
            // audioDataList
            // 
            this.audioDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioDataList.FormattingEnabled = true;
            this.audioDataList.ItemHeight = 15;
            this.audioDataList.Location = new System.Drawing.Point(4, 64);
            this.audioDataList.Name = "audioDataList";
            this.audioDataList.Size = new System.Drawing.Size(348, 214);
            this.audioDataList.TabIndex = 2;
            this.audioDataList.DoubleClick += new System.EventHandler(this.audioDataList_DoubleClick);
            // 
            // replaceButton
            // 
            this.replaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceButton.Location = new System.Drawing.Point(4, 280);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(104, 23);
            this.replaceButton.TabIndex = 3;
            this.replaceButton.Text = "Replace Selected";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(124, 280);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(108, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear Selected";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearAllButton.Location = new System.Drawing.Point(248, 280);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(104, 23);
            this.clearAllButton.TabIndex = 5;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(124, 308);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(228, 36);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // stopPlaybackButton
            // 
            this.stopPlaybackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopPlaybackButton.Location = new System.Drawing.Point(4, 308);
            this.stopPlaybackButton.Name = "stopPlaybackButton";
            this.stopPlaybackButton.Size = new System.Drawing.Size(104, 36);
            this.stopPlaybackButton.TabIndex = 7;
            this.stopPlaybackButton.Text = "Stop Playback";
            this.stopPlaybackButton.UseVisualStyleBackColor = true;
            this.stopPlaybackButton.Click += new System.EventHandler(this.stopPlaybackButton_Click);
            // 
            // SCDEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(356, 348);
            this.Controls.Add(this.stopPlaybackButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.audioDataList);
            this.Controls.Add(this.outputSCD);
            this.Controls.Add(this.originalSCD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SCDEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SCDEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SCDEditor_FormClosing);
            this.Load += new System.EventHandler(this.SCDEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FilePicker originalSCD;
        private FilePicker outputSCD;
        private System.Windows.Forms.ListBox audioDataList;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button stopPlaybackButton;
    }
}