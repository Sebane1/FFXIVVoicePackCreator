namespace FFXIVVoicePackCreator {
    partial class Troubleshooting {
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
            this.troubleshootingBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // troubleshootingBox
            // 
            this.troubleshootingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.troubleshootingBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.troubleshootingBox.Location = new System.Drawing.Point(4, 4);
            this.troubleshootingBox.Name = "troubleshootingBox";
            this.troubleshootingBox.ReadOnly = true;
            this.troubleshootingBox.Size = new System.Drawing.Size(709, 463);
            this.troubleshootingBox.TabIndex = 0;
            this.troubleshootingBox.Text = "";
            // 
            // Troubleshooting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 470);
            this.Controls.Add(this.troubleshootingBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Troubleshooting";
            this.Text = "Troubleshooting";
            this.Load += new System.EventHandler(this.Troubleshooting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox troubleshootingBox;
    }
}