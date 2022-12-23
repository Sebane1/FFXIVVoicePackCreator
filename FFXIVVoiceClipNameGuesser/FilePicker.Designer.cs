
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
            this.filePath.Location = new System.Drawing.Point(114, 7);
            this.filePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(643, 23);
            this.filePath.TabIndex = 0;
            this.filePath.TextChanged += new System.EventHandler(this.filePath_TextChanged);
            this.filePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.filePath_DragDrop);
            this.filePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.filePath_DragEnter);
            this.filePath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseDown);
            this.filePath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseMove);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(765, 4);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(88, 27);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Select";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 10);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // useGameFileCheckBox
            // 
            this.useGameFileCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useGameFileCheckBox.AutoSize = true;
            this.useGameFileCheckBox.Location = new System.Drawing.Point(870, 9);
            this.useGameFileCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.useGameFileCheckBox.Name = "useGameFileCheckBox";
            this.useGameFileCheckBox.Size = new System.Drawing.Size(100, 19);
            this.useGameFileCheckBox.TabIndex = 3;
            this.useGameFileCheckBox.Text = "Use Game File";
            this.useGameFileCheckBox.UseVisualStyleBackColor = true;
            this.useGameFileCheckBox.CheckedChanged += new System.EventHandler(this.useGameFileCheckBox_CheckedChanged);
            // 
            // FilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.useGameFileCheckBox);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.filePath);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FilePicker";
            this.Size = new System.Drawing.Size(994, 36);
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
        public CheckBox UseGameFileCheckBox { get => useGameFileCheckBox; set => useGameFileCheckBox = value; }
    }
}
