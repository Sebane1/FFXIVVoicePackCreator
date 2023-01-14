
namespace FFXIVVoicePackCreator {
    partial class VoiceSelection {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceSelection));
            this.addToVoiceListButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.voiceListComboBox = new System.Windows.Forms.ComboBox();
            this.raceListComboBox = new System.Windows.Forms.ComboBox();
            this.sexListComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // addToVoiceListButton
            // 
            this.addToVoiceListButton.Location = new System.Drawing.Point(374, 7);
            this.addToVoiceListButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addToVoiceListButton.Name = "addToVoiceListButton";
            this.addToVoiceListButton.Size = new System.Drawing.Size(86, 24);
            this.addToVoiceListButton.TabIndex = 41;
            this.addToVoiceListButton.Text = "Select";
            this.addToVoiceListButton.UseVisualStyleBackColor = true;
            this.addToVoiceListButton.Click += new System.EventHandler(this.addToVoiceListButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 15);
            this.label12.TabIndex = 40;
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
            this.voiceListComboBox.Location = new System.Drawing.Point(284, 7);
            this.voiceListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.voiceListComboBox.Name = "voiceListComboBox";
            this.voiceListComboBox.Size = new System.Drawing.Size(83, 23);
            this.voiceListComboBox.TabIndex = 39;
            // 
            // raceListComboBox
            // 
            this.raceListComboBox.FormattingEnabled = true;
            this.raceListComboBox.Location = new System.Drawing.Point(160, 7);
            this.raceListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.raceListComboBox.Name = "raceListComboBox";
            this.raceListComboBox.Size = new System.Drawing.Size(116, 23);
            this.raceListComboBox.TabIndex = 38;
            // 
            // sexListComboBox
            // 
            this.sexListComboBox.FormattingEnabled = true;
            this.sexListComboBox.Items.AddRange(new object[] {
            "Masculine",
            "Feminine"});
            this.sexListComboBox.Location = new System.Drawing.Point(61, 7);
            this.sexListComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sexListComboBox.Name = "sexListComboBox";
            this.sexListComboBox.Size = new System.Drawing.Size(92, 23);
            this.sexListComboBox.TabIndex = 37;
            // 
            // VoiceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 40);
            this.Controls.Add(this.addToVoiceListButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.voiceListComboBox);
            this.Controls.Add(this.raceListComboBox);
            this.Controls.Add(this.sexListComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "VoiceSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voice Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addToVoiceListButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox voiceListComboBox;
        private System.Windows.Forms.ComboBox raceListComboBox;
        private System.Windows.Forms.ComboBox sexListComboBox;
    }
}