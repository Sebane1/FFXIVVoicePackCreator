
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
            this.addToVoiceListButton.Location = new System.Drawing.Point(321, 6);
            this.addToVoiceListButton.Name = "addToVoiceListButton";
            this.addToVoiceListButton.Size = new System.Drawing.Size(74, 22);
            this.addToVoiceListButton.TabIndex = 41;
            this.addToVoiceListButton.Text = "Add Voice";
            this.addToVoiceListButton.UseVisualStyleBackColor = true;
            this.addToVoiceListButton.Click += new System.EventHandler(this.addToVoiceListButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
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
            this.voiceListComboBox.Location = new System.Drawing.Point(243, 6);
            this.voiceListComboBox.Name = "voiceListComboBox";
            this.voiceListComboBox.Size = new System.Drawing.Size(72, 21);
            this.voiceListComboBox.TabIndex = 39;
            // 
            // raceListComboBox
            // 
            this.raceListComboBox.FormattingEnabled = true;
            this.raceListComboBox.Location = new System.Drawing.Point(137, 6);
            this.raceListComboBox.Name = "raceListComboBox";
            this.raceListComboBox.Size = new System.Drawing.Size(100, 21);
            this.raceListComboBox.TabIndex = 38;
            // 
            // sexListComboBox
            // 
            this.sexListComboBox.FormattingEnabled = true;
            this.sexListComboBox.Items.AddRange(new object[] {
            "Masculine",
            "Feminine"});
            this.sexListComboBox.Location = new System.Drawing.Point(52, 6);
            this.sexListComboBox.Name = "sexListComboBox";
            this.sexListComboBox.Size = new System.Drawing.Size(79, 21);
            this.sexListComboBox.TabIndex = 37;
            // 
            // VoiceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 35);
            this.Controls.Add(this.addToVoiceListButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.voiceListComboBox);
            this.Controls.Add(this.raceListComboBox);
            this.Controls.Add(this.sexListComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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