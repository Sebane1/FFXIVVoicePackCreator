namespace FFXIVVoicePackCreator {
    partial class RoleplayingVoicePackCreator {
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
            this.categoryList = new System.Windows.Forms.ListBox();
            this.soundList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.AddSoundButton = new System.Windows.Forms.Button();
            this.removeSoundButton = new System.Windows.Forms.Button();
            this.clearListButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.ItemHeight = 15;
            this.categoryList.Location = new System.Drawing.Point(0, 112);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(408, 139);
            this.categoryList.TabIndex = 0;
            // 
            // soundList
            // 
            this.soundList.FormattingEnabled = true;
            this.soundList.ItemHeight = 15;
            this.soundList.Location = new System.Drawing.Point(0, 284);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(408, 139);
            this.soundList.TabIndex = 2;
            this.soundList.SelectedIndexChanged += new System.EventHandler(this.soundList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(408, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 23);
            this.textBox1.TabIndex = 4;
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(316, 56);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(88, 23);
            this.addCategoryButton.TabIndex = 5;
            this.addCategoryButton.Text = "Add Category";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Surprised",
            "Angry",
            "Furious",
            "Cheer",
            "Doze",
            "Fume",
            "Huh",
            "Chuckle",
            "Laugh",
            "No",
            "Stretch",
            "Upset",
            "Yes",
            "Happy",
            "Attack",
            "Hurt",
            "Death",
            "Casting Attack",
            "Casting Heal",
            "Casting",
            "Missed",
            "Limitbreak",
            "Invalid Target",
            "Target is not in range",
            "Target is not in line of sight",
            "You do not have the gil required"});
            this.categoryComboBox.Location = new System.Drawing.Point(64, 56);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(252, 23);
            this.categoryComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Categories";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sounds In Category";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(0, 448);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(408, 23);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // AddSoundButton
            // 
            this.AddSoundButton.Location = new System.Drawing.Point(328, 424);
            this.AddSoundButton.Name = "AddSoundButton";
            this.AddSoundButton.Size = new System.Drawing.Size(80, 23);
            this.AddSoundButton.TabIndex = 12;
            this.AddSoundButton.Text = "Add Sound";
            this.AddSoundButton.UseVisualStyleBackColor = true;
            this.AddSoundButton.Click += new System.EventHandler(this.AddSoundButton_Click);
            // 
            // removeSoundButton
            // 
            this.removeSoundButton.Location = new System.Drawing.Point(232, 424);
            this.removeSoundButton.Name = "removeSoundButton";
            this.removeSoundButton.Size = new System.Drawing.Size(96, 23);
            this.removeSoundButton.TabIndex = 13;
            this.removeSoundButton.Text = "Remove Sound";
            this.removeSoundButton.UseVisualStyleBackColor = true;
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(136, 424);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(96, 23);
            this.clearListButton.TabIndex = 14;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            // 
            // RoleplayingVoicePackCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 476);
            this.Controls.Add(this.clearListButton);
            this.Controls.Add(this.removeSoundButton);
            this.Controls.Add(this.AddSoundButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.soundList);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RoleplayingVoicePackCreator";
            this.Text = "RoleplayingVoicePackCreator";
            this.Load += new System.EventHandler(this.RoleplayingVoicePackCreator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox categoryList;
        private System.Windows.Forms.ListBox soundList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button AddSoundButton;
        private System.Windows.Forms.Button removeSoundButton;
        private System.Windows.Forms.Button clearListButton;
    }
}