
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
            this.playButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePath
            // 
            this.filePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePath.Location = new System.Drawing.Point(140, 3);
            this.filePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(328, 23);
            this.filePath.TabIndex = 0;
            this.filePath.TextChanged += new System.EventHandler(this.filePath_TextChanged);
            this.filePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.filePath_DragDrop);
            this.filePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.filePath_DragEnter);
            this.filePath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseDown);
            this.filePath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.filePicker_MouseMove);
            // 
            // openButton
            // 
            this.openButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openButton.Location = new System.Drawing.Point(476, 3);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(52, 22);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Select";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(4, 0);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(95, 28);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "surprised";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useGameFileCheckBox
            // 
            this.useGameFileCheckBox.AutoSize = true;
            this.useGameFileCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useGameFileCheckBox.Location = new System.Drawing.Point(536, 3);
            this.useGameFileCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.useGameFileCheckBox.Name = "useGameFileCheckBox";
            this.useGameFileCheckBox.Size = new System.Drawing.Size(108, 22);
            this.useGameFileCheckBox.TabIndex = 3;
            this.useGameFileCheckBox.Text = "Use Game File";
            this.useGameFileCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useGameFileCheckBox.UseVisualStyleBackColor = true;
            this.useGameFileCheckBox.CheckedChanged += new System.EventHandler(this.useGameFileCheckBox_CheckedChanged);
            // 
            // playButton
            // 
            this.playButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playButton.Location = new System.Drawing.Point(107, 3);
            this.playButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(25, 22);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.Controls.Add(this.useGameFileCheckBox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.playButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.openButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.filePath, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(648, 28);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(300, 28);
            this.Name = "FilePicker";
            this.Size = new System.Drawing.Size(648, 28);
            this.Load += new System.EventHandler(this.filePicker_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label labelName;
        private CheckBox useGameFileCheckBox;
        private Button playButton;
        private TableLayoutPanel tableLayoutPanel1;

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
