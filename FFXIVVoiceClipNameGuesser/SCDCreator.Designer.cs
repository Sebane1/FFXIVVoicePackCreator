
namespace FFXIVVoicePackCreator {
    partial class SCDCreator {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCDCreator));
            generateButton = new System.Windows.Forms.Button();
            scdTypeComboBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            loopStartTextBox = new System.Windows.Forms.TextBox();
            loopStartLabel = new System.Windows.Forms.Label();
            loopEndLabel = new System.Windows.Forms.Label();
            loopEndTextBox = new System.Windows.Forms.TextBox();
            NumberOfSamplesLabel = new System.Windows.Forms.Label();
            numberOfSamplesTextBox = new System.Windows.Forms.TextBox();
            outputSelection = new FilePicker();
            mediaSelection = new FilePicker();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            generateButton.Location = new System.Drawing.Point(22, 278);
            generateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            generateButton.Name = "generateButton";
            generateButton.Size = new System.Drawing.Size(410, 25);
            generateButton.TabIndex = 2;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // scdTypeComboBox
            // 
            scdTypeComboBox.FormattingEnabled = true;
            scdTypeComboBox.Items.AddRange(new object[] { "Sound Effect", "Background Music", "Orchestrion" });
            scdTypeComboBox.Location = new System.Drawing.Point(160, 107);
            scdTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            scdTypeComboBox.Name = "scdTypeComboBox";
            scdTypeComboBox.Size = new System.Drawing.Size(264, 23);
            scdTypeComboBox.TabIndex = 4;
            scdTypeComboBox.SelectedIndexChanged += scdTypeComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(19, 111);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 15);
            label1.TabIndex = 5;
            label1.Text = "File Type";
            // 
            // loopStartTextBox
            // 
            loopStartTextBox.Enabled = false;
            loopStartTextBox.Location = new System.Drawing.Point(300, 150);
            loopStartTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loopStartTextBox.Name = "loopStartTextBox";
            loopStartTextBox.Size = new System.Drawing.Size(124, 23);
            loopStartTextBox.TabIndex = 8;
            loopStartTextBox.Text = "0";
            loopStartTextBox.KeyPress += textValidation_KeyPress;
            // 
            // loopStartLabel
            // 
            loopStartLabel.AutoSize = true;
            loopStartLabel.Enabled = false;
            loopStartLabel.Location = new System.Drawing.Point(18, 153);
            loopStartLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loopStartLabel.Name = "loopStartLabel";
            loopStartLabel.Size = new System.Drawing.Size(116, 15);
            loopStartLabel.TabIndex = 9;
            loopStartLabel.Text = "Loop Start (Samples)";
            // 
            // loopEndLabel
            // 
            loopEndLabel.AutoSize = true;
            loopEndLabel.Enabled = false;
            loopEndLabel.Location = new System.Drawing.Point(18, 195);
            loopEndLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loopEndLabel.Name = "loopEndLabel";
            loopEndLabel.Size = new System.Drawing.Size(112, 15);
            loopEndLabel.TabIndex = 11;
            loopEndLabel.Text = "Loop End (Samples)";
            // 
            // loopEndTextBox
            // 
            loopEndTextBox.Enabled = false;
            loopEndTextBox.Location = new System.Drawing.Point(300, 192);
            loopEndTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loopEndTextBox.Name = "loopEndTextBox";
            loopEndTextBox.Size = new System.Drawing.Size(124, 23);
            loopEndTextBox.TabIndex = 10;
            loopEndTextBox.Text = "0";
            loopEndTextBox.KeyPress += textValidation_KeyPress;
            // 
            // NumberOfSamplesLabel
            // 
            NumberOfSamplesLabel.AutoSize = true;
            NumberOfSamplesLabel.Enabled = false;
            NumberOfSamplesLabel.Location = new System.Drawing.Point(18, 238);
            NumberOfSamplesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            NumberOfSamplesLabel.Name = "NumberOfSamplesLabel";
            NumberOfSamplesLabel.Size = new System.Drawing.Size(114, 15);
            NumberOfSamplesLabel.TabIndex = 13;
            NumberOfSamplesLabel.Text = "Number Of Samples";
            // 
            // numberOfSamplesTextBox
            // 
            numberOfSamplesTextBox.Enabled = false;
            numberOfSamplesTextBox.Location = new System.Drawing.Point(300, 234);
            numberOfSamplesTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numberOfSamplesTextBox.Name = "numberOfSamplesTextBox";
            numberOfSamplesTextBox.Size = new System.Drawing.Size(124, 23);
            numberOfSamplesTextBox.TabIndex = 12;
            numberOfSamplesTextBox.Text = "1";
            numberOfSamplesTextBox.KeyPress += textValidation_KeyPress;
            // 
            // outputSelection
            // 
            outputSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            outputSelection.Filter = "scd files (*.scd)|*.scd";
            outputSelection.Index = -1;
            outputSelection.IsPlayable = false;
            outputSelection.IsSaveMode = true;
            outputSelection.IsSwappable = false;
            outputSelection.Location = new System.Drawing.Point(15, 57);
            outputSelection.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            outputSelection.MaximumSize = new System.Drawing.Size(994, 36);
            outputSelection.MinimumSize = new System.Drawing.Size(529, 30);
            outputSelection.Name = "outputSelection";
            outputSelection.Size = new System.Drawing.Size(529, 31);
            outputSelection.TabIndex = 3;
            // 
            // mediaSelection
            // 
            mediaSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mediaSelection.Filter = resources.GetString("mediaSelection.Filter");
            mediaSelection.Index = -1;
            mediaSelection.IsPlayable = false;
            mediaSelection.IsSaveMode = false;
            mediaSelection.IsSwappable = false;
            mediaSelection.Location = new System.Drawing.Point(14, 14);
            mediaSelection.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaSelection.MaximumSize = new System.Drawing.Size(994, 36);
            mediaSelection.MinimumSize = new System.Drawing.Size(529, 30);
            mediaSelection.Name = "mediaSelection";
            mediaSelection.Size = new System.Drawing.Size(530, 30);
            mediaSelection.TabIndex = 0;
            // 
            // SCDCreator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(440, 317);
            Controls.Add(NumberOfSamplesLabel);
            Controls.Add(numberOfSamplesTextBox);
            Controls.Add(loopEndLabel);
            Controls.Add(loopEndTextBox);
            Controls.Add(loopStartLabel);
            Controls.Add(loopStartTextBox);
            Controls.Add(label1);
            Controls.Add(scdTypeComboBox);
            Controls.Add(outputSelection);
            Controls.Add(generateButton);
            Controls.Add(mediaSelection);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "SCDCreator";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Standalone SCD Converter";
            Load += SCDCreator_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private FilePicker mediaSelection;
        private System.Windows.Forms.Button generateButton;
        private FilePicker outputSelection;
        private System.Windows.Forms.ComboBox scdTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loopStartTextBox;
        private System.Windows.Forms.Label loopStartLabel;
        private System.Windows.Forms.Label loopEndLabel;
        private System.Windows.Forms.TextBox loopEndTextBox;
        private System.Windows.Forms.Label NumberOfSamplesLabel;
        private System.Windows.Forms.TextBox numberOfSamplesTextBox;
    }
}