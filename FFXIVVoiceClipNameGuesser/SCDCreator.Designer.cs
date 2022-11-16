
namespace FFXIVVoiceClipNameGuesser {
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
            this.outputSelection = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.wavSelection = new FFXIVVoiceClipNameGuesser.FilePicker();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(13, 88);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(488, 22);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // outputSelection
            // 
            this.outputSelection.Filter = "scd files (*.scd)|*.scd";
            this.outputSelection.Index = -1;
            this.outputSelection.IsSaveMode = true;
            this.outputSelection.Location = new System.Drawing.Point(13, 49);
            this.outputSelection.Name = "outputSelection";
            this.outputSelection.Size = new System.Drawing.Size(489, 31);
            this.outputSelection.TabIndex = 3;
            // 
            // wavSelection
            // 
            this.wavSelection.Filter = resources.GetString("wavSelection.Filter");
            this.wavSelection.Index = -1;
            this.wavSelection.IsSaveMode = false;
            this.wavSelection.Location = new System.Drawing.Point(12, 12);
            this.wavSelection.Name = "wavSelection";
            this.wavSelection.Size = new System.Drawing.Size(489, 31);
            this.wavSelection.TabIndex = 0;
            this.wavSelection.Load += new System.EventHandler(this.filePicker1_Load);
            // 
            // SCDCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 118);
            this.Controls.Add(this.outputSelection);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.wavSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SCDCreator";
            this.Text = "MS-ADPCM SCD Genrator (Experimental)";
            this.ResumeLayout(false);

        }

        #endregion

        private FilePicker wavSelection;
        private System.Windows.Forms.Button generateButton;
        private FilePicker outputSelection;
    }
}