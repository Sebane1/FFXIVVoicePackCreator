
namespace FFXIVVoicePackCreator {
    partial class BulkSCDCreator {
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
            generateButton = new System.Windows.Forms.Button();
            scdTypeComboBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            mediaListBox = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            outputFolderText = new System.Windows.Forms.TextBox();
            addButton = new System.Windows.Forms.Button();
            outputFolderLabel = new System.Windows.Forms.Label();
            addMediaButton = new System.Windows.Forms.Button();
            removeSelectedMedia = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            generateButton.Location = new System.Drawing.Point(21, 315);
            generateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            generateButton.Name = "generateButton";
            generateButton.Size = new System.Drawing.Size(406, 25);
            generateButton.TabIndex = 2;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // scdTypeComboBox
            // 
            scdTypeComboBox.FormattingEnabled = true;
            scdTypeComboBox.Items.AddRange(new object[] { "Sound Effect", "Background Music", "Orchestrion" });
            scdTypeComboBox.Location = new System.Drawing.Point(163, 16);
            scdTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            scdTypeComboBox.Name = "scdTypeComboBox";
            scdTypeComboBox.Size = new System.Drawing.Size(264, 23);
            scdTypeComboBox.TabIndex = 4;
            scdTypeComboBox.SelectedIndexChanged += scdTypeComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 15);
            label1.TabIndex = 5;
            label1.Text = "File Type";
            // 
            // mediaListBox
            // 
            mediaListBox.AllowDrop = true;
            mediaListBox.FormattingEnabled = true;
            mediaListBox.ItemHeight = 15;
            mediaListBox.Location = new System.Drawing.Point(22, 113);
            mediaListBox.Name = "mediaListBox";
            mediaListBox.Size = new System.Drawing.Size(406, 154);
            mediaListBox.TabIndex = 6;
            mediaListBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            mediaListBox.DragDrop += mediaListBox_DragDrop;
            mediaListBox.DragEnter += mediaListBox_DragEnter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(183, 15);
            label2.TabIndex = 7;
            label2.Text = "Drag And Drop Media Files Below";
            label2.Click += label2_Click;
            // 
            // outputFolderText
            // 
            outputFolderText.Location = new System.Drawing.Point(163, 50);
            outputFolderText.Name = "outputFolderText";
            outputFolderText.Size = new System.Drawing.Size(156, 23);
            outputFolderText.TabIndex = 8;
            // 
            // addButton
            // 
            addButton.Location = new System.Drawing.Point(325, 50);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(102, 23);
            addButton.TabIndex = 9;
            addButton.Text = "Pick Output";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // outputFolderLabel
            // 
            outputFolderLabel.AutoSize = true;
            outputFolderLabel.Location = new System.Drawing.Point(27, 53);
            outputFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            outputFolderLabel.Name = "outputFolderLabel";
            outputFolderLabel.Size = new System.Drawing.Size(52, 15);
            outputFolderLabel.TabIndex = 10;
            outputFolderLabel.Text = "File Type";
            outputFolderLabel.Click += outputFolderLabel_Click;
            // 
            // addMediaButton
            // 
            addMediaButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            addMediaButton.Location = new System.Drawing.Point(22, 273);
            addMediaButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addMediaButton.Name = "addMediaButton";
            addMediaButton.Size = new System.Drawing.Size(203, 25);
            addMediaButton.TabIndex = 11;
            addMediaButton.Text = "Add Media";
            addMediaButton.UseVisualStyleBackColor = true;
            addMediaButton.Click += addMediaButton_Click;
            // 
            // removeSelectedMedia
            // 
            removeSelectedMedia.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            removeSelectedMedia.Location = new System.Drawing.Point(233, 273);
            removeSelectedMedia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            removeSelectedMedia.Name = "removeSelectedMedia";
            removeSelectedMedia.Size = new System.Drawing.Size(195, 25);
            removeSelectedMedia.TabIndex = 12;
            removeSelectedMedia.Text = "Remove Selected Media";
            removeSelectedMedia.UseVisualStyleBackColor = true;
            removeSelectedMedia.Click += removeSelectedMedia_Click;
            // 
            // BulkSCDCreator
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(440, 352);
            Controls.Add(removeSelectedMedia);
            Controls.Add(addMediaButton);
            Controls.Add(outputFolderLabel);
            Controls.Add(addButton);
            Controls.Add(outputFolderText);
            Controls.Add(label2);
            Controls.Add(mediaListBox);
            Controls.Add(label1);
            Controls.Add(scdTypeComboBox);
            Controls.Add(generateButton);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "BulkSCDCreator";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Standalone SCD Converter";
            Load += SCDCreator_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ComboBox scdTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox mediaListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputFolderText;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.Button addMediaButton;
        private System.Windows.Forms.Button removeSelectedMedia;
    }
}