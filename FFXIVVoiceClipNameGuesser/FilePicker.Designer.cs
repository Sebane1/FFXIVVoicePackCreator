
using System.ComponentModel;
using System.Windows.Forms;

namespace FFXIVVoicePackCreator {
    partial class FilePicker {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.filePath = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.useGameFileCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePath.Location = new System.Drawing.Point(151, 5);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(256, 20);
            this.filePath.TabIndex = 0;
            this.filePath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseDown);
            this.filePath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseMove);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(411, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Select";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(110, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // checkBox1
            // 
            this.useGameFileCheckBox.AutoSize = true;
            this.useGameFileCheckBox.Location = new System.Drawing.Point(3, 7);
            this.useGameFileCheckBox.Name = "checkBox1";
            this.useGameFileCheckBox.Size = new System.Drawing.Size(95, 17);
            this.useGameFileCheckBox.TabIndex = 3;
            this.useGameFileCheckBox.Text = "Use Game File";
            this.useGameFileCheckBox.UseVisualStyleBackColor = true;
            this.useGameFileCheckBox.CheckedChanged += new System.EventHandler(this.useGameFileCheckBox_CheckedChanged);
            // 
            // FilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.useGameFileCheckBox);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.filePath);
            this.Name = "FilePicker";
            this.Size = new System.Drawing.Size(489, 31);
            this.Load += new System.EventHandler(this.filePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label labelName;
        private CheckBox useGameFileCheckBox;

        public Label LabelName { get => labelName; set => labelName = value; }
        public TextBox FilePath { get => filePath; set => filePath = value; }
        [
   Category("Index"),
   Description("Sort Order")
   ]
        public int Index { get => index; set => index = value; }
    }
}
