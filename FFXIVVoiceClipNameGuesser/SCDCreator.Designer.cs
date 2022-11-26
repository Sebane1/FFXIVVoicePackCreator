
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
            this.generateButton = new System.Windows.Forms.Button();
            this.scdTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loopStartTextBox = new System.Windows.Forms.TextBox();
            this.loopStartLabel = new System.Windows.Forms.Label();
            this.loopEndLabel = new System.Windows.Forms.Label();
            this.loopEndTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfSamplesLabel = new System.Windows.Forms.Label();
            this.numberOfSamplesTextBox = new System.Windows.Forms.TextBox();
            this.outputSelection = new FFXIVVoicePackCreator.FilePicker();
            this.mediaSelection = new FFXIVVoicePackCreator.FilePicker();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(19, 241);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(351, 22);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // scdTypeComboBox
            // 
            this.scdTypeComboBox.FormattingEnabled = true;
            this.scdTypeComboBox.Items.AddRange(new object[] {
            "Sound Effect",
            "Background Music",
            "Orchestrion (Experimental)"});
            this.scdTypeComboBox.Location = new System.Drawing.Point(99, 93);
            this.scdTypeComboBox.Name = "scdTypeComboBox";
            this.scdTypeComboBox.Size = new System.Drawing.Size(265, 21);
            this.scdTypeComboBox.TabIndex = 4;
            this.scdTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.scdTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Type";
            // 
            // loopStartTextBox
            // 
            this.loopStartTextBox.Enabled = false;
            this.loopStartTextBox.Location = new System.Drawing.Point(257, 130);
            this.loopStartTextBox.Name = "loopStartTextBox";
            this.loopStartTextBox.Size = new System.Drawing.Size(107, 20);
            this.loopStartTextBox.TabIndex = 8;
            this.loopStartTextBox.Text = "0";
            this.loopStartTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValidation_KeyPress);
            // 
            // loopStartLabel
            // 
            this.loopStartLabel.AutoSize = true;
            this.loopStartLabel.Enabled = false;
            this.loopStartLabel.Location = new System.Drawing.Point(15, 133);
            this.loopStartLabel.Name = "loopStartLabel";
            this.loopStartLabel.Size = new System.Drawing.Size(105, 13);
            this.loopStartLabel.TabIndex = 9;
            this.loopStartLabel.Text = "Loop Start (Samples)";
            // 
            // loopEndLabel
            // 
            this.loopEndLabel.AutoSize = true;
            this.loopEndLabel.Enabled = false;
            this.loopEndLabel.Location = new System.Drawing.Point(15, 169);
            this.loopEndLabel.Name = "loopEndLabel";
            this.loopEndLabel.Size = new System.Drawing.Size(102, 13);
            this.loopEndLabel.TabIndex = 11;
            this.loopEndLabel.Text = "Loop End (Samples)";
            // 
            // loopEndTextBox
            // 
            this.loopEndTextBox.Enabled = false;
            this.loopEndTextBox.Location = new System.Drawing.Point(257, 166);
            this.loopEndTextBox.Name = "loopEndTextBox";
            this.loopEndTextBox.Size = new System.Drawing.Size(107, 20);
            this.loopEndTextBox.TabIndex = 10;
            this.loopEndTextBox.Text = "0";
            this.loopEndTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValidation_KeyPress);
            // 
            // NumberOfSamplesLabel
            // 
            this.NumberOfSamplesLabel.AutoSize = true;
            this.NumberOfSamplesLabel.Enabled = false;
            this.NumberOfSamplesLabel.Location = new System.Drawing.Point(15, 206);
            this.NumberOfSamplesLabel.Name = "NumberOfSamplesLabel";
            this.NumberOfSamplesLabel.Size = new System.Drawing.Size(101, 13);
            this.NumberOfSamplesLabel.TabIndex = 13;
            this.NumberOfSamplesLabel.Text = "Number Of Samples";
            // 
            // numberOfSamplesTextBox
            // 
            this.numberOfSamplesTextBox.Enabled = false;
            this.numberOfSamplesTextBox.Location = new System.Drawing.Point(257, 203);
            this.numberOfSamplesTextBox.Name = "numberOfSamplesTextBox";
            this.numberOfSamplesTextBox.Size = new System.Drawing.Size(107, 20);
            this.numberOfSamplesTextBox.TabIndex = 12;
            this.numberOfSamplesTextBox.Text = "1";
            this.numberOfSamplesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValidation_KeyPress);
            // 
            // outputSelection
            // 
            this.outputSelection.Filter = "scd files (*.scd)|*.scd";
            this.outputSelection.Index = -1;
            this.outputSelection.IsSaveMode = true;
            this.outputSelection.Location = new System.Drawing.Point(13, 49);
            this.outputSelection.Name = "outputSelection";
            this.outputSelection.Size = new System.Drawing.Size(351, 31);
            this.outputSelection.TabIndex = 3;
            // 
            // mediaSelection
            // 
            this.mediaSelection.Filter = resources.GetString("mediaSelection.Filter");
            this.mediaSelection.Index = -1;
            this.mediaSelection.IsSaveMode = false;
            this.mediaSelection.Location = new System.Drawing.Point(12, 12);
            this.mediaSelection.Name = "mediaSelection";
            this.mediaSelection.Size = new System.Drawing.Size(352, 31);
            this.mediaSelection.TabIndex = 0;
            // 
            // SCDCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 275);
            this.Controls.Add(this.NumberOfSamplesLabel);
            this.Controls.Add(this.numberOfSamplesTextBox);
            this.Controls.Add(this.loopEndLabel);
            this.Controls.Add(this.loopEndTextBox);
            this.Controls.Add(this.loopStartLabel);
            this.Controls.Add(this.loopStartTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scdTypeComboBox);
            this.Controls.Add(this.outputSelection);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mediaSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SCDCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Standalone SCD Converter";
            this.Load += new System.EventHandler(this.SCDCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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