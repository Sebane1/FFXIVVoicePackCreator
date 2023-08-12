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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleplayingVoicePackCreator));
            this.categoryList = new System.Windows.Forms.ListBox();
            this.soundList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRoleplayingVoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameTextBox = new System.Windows.Forms.TextBox();
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
            this.addAllCategoriesButton = new System.Windows.Forms.Button();
            this.removeCategoryButton = new System.Windows.Forms.Button();
            this.discordButton = new System.Windows.Forms.Button();
            this.donateButton = new System.Windows.Forms.Button();
            this.quickImport = new System.Windows.Forms.Button();
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
            this.categoryList.SelectedIndexChanged += new System.EventHandler(this.categoryList_SelectedIndexChanged);
            // 
            // soundList
            // 
            this.soundList.AllowDrop = true;
            this.soundList.FormattingEnabled = true;
            this.soundList.ItemHeight = 15;
            this.soundList.Location = new System.Drawing.Point(0, 300);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(408, 139);
            this.soundList.TabIndex = 2;
            this.soundList.SelectedIndexChanged += new System.EventHandler(this.soundList_SelectedIndexChanged);
            this.soundList.DragDrop += new System.Windows.Forms.DragEventHandler(this.soundList_DragDrop);
            this.soundList.DragEnter += new System.Windows.Forms.DragEventHandler(this.soundList_DragEnter);
            this.soundList.DoubleClick += new System.EventHandler(this.soundList_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.legacyWindowToolStripMenuItem,
            this.getRoleplayingVoiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(408, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // legacyWindowToolStripMenuItem
            // 
            this.legacyWindowToolStripMenuItem.Name = "legacyWindowToolStripMenuItem";
            this.legacyWindowToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.legacyWindowToolStripMenuItem.Text = "Legacy Window";
            this.legacyWindowToolStripMenuItem.Click += new System.EventHandler(this.legacyWindowToolStripMenuItem_Click);
            // 
            // getRoleplayingVoiceToolStripMenuItem
            // 
            this.getRoleplayingVoiceToolStripMenuItem.Name = "getRoleplayingVoiceToolStripMenuItem";
            this.getRoleplayingVoiceToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.getRoleplayingVoiceToolStripMenuItem.Text = "Roleplaying Voice";
            this.getRoleplayingVoiceToolStripMenuItem.Click += new System.EventHandler(this.getRoleplayingVoiceToolStripMenuItem_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(64, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(340, 23);
            this.nameTextBox.TabIndex = 4;
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(224, 56);
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
            "Cannot use",
            "Not yet ready",
            "You do not have the gil required"});
            this.categoryComboBox.Location = new System.Drawing.Point(64, 56);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(160, 23);
            this.categoryComboBox.TabIndex = 7;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
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
            this.label4.Location = new System.Drawing.Point(0, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sounds In Category";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(0, 464);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(408, 23);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // AddSoundButton
            // 
            this.AddSoundButton.Location = new System.Drawing.Point(328, 440);
            this.AddSoundButton.Name = "AddSoundButton";
            this.AddSoundButton.Size = new System.Drawing.Size(80, 23);
            this.AddSoundButton.TabIndex = 12;
            this.AddSoundButton.Text = "Add Sound";
            this.AddSoundButton.UseVisualStyleBackColor = true;
            this.AddSoundButton.Click += new System.EventHandler(this.AddSoundButton_Click);
            // 
            // removeSoundButton
            // 
            this.removeSoundButton.Location = new System.Drawing.Point(232, 440);
            this.removeSoundButton.Name = "removeSoundButton";
            this.removeSoundButton.Size = new System.Drawing.Size(96, 23);
            this.removeSoundButton.TabIndex = 13;
            this.removeSoundButton.Text = "Remove Sound";
            this.removeSoundButton.UseVisualStyleBackColor = true;
            this.removeSoundButton.Click += new System.EventHandler(this.removeSoundButton_Click);
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(136, 440);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(96, 23);
            this.clearListButton.TabIndex = 14;
            this.clearListButton.Text = "Clear List";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // addAllCategoriesButton
            // 
            this.addAllCategoriesButton.Location = new System.Drawing.Point(312, 56);
            this.addAllCategoriesButton.Name = "addAllCategoriesButton";
            this.addAllCategoriesButton.Size = new System.Drawing.Size(92, 23);
            this.addAllCategoriesButton.TabIndex = 15;
            this.addAllCategoriesButton.Text = "Add Template";
            this.addAllCategoriesButton.UseVisualStyleBackColor = true;
            this.addAllCategoriesButton.Click += new System.EventHandler(this.addAllCategoriesButton_Click);
            // 
            // removeCategoryButton
            // 
            this.removeCategoryButton.Location = new System.Drawing.Point(296, 252);
            this.removeCategoryButton.Name = "removeCategoryButton";
            this.removeCategoryButton.Size = new System.Drawing.Size(112, 23);
            this.removeCategoryButton.TabIndex = 16;
            this.removeCategoryButton.Text = "Remove Category";
            this.removeCategoryButton.UseVisualStyleBackColor = true;
            this.removeCategoryButton.Click += new System.EventHandler(this.removeCategoryButton_Click);
            // 
            // discordButton
            // 
            this.discordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discordButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.discordButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.discordButton.Location = new System.Drawing.Point(256, 0);
            this.discordButton.Name = "discordButton";
            this.discordButton.Size = new System.Drawing.Size(75, 23);
            this.discordButton.TabIndex = 59;
            this.discordButton.Text = "Discord";
            this.discordButton.UseVisualStyleBackColor = false;
            this.discordButton.Click += new System.EventHandler(this.discordButton_Click);
            // 
            // donateButton
            // 
            this.donateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.donateButton.BackColor = System.Drawing.Color.IndianRed;
            this.donateButton.ForeColor = System.Drawing.Color.White;
            this.donateButton.Location = new System.Drawing.Point(332, 0);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(75, 23);
            this.donateButton.TabIndex = 58;
            this.donateButton.Text = "Donate";
            this.donateButton.UseVisualStyleBackColor = false;
            this.donateButton.Click += new System.EventHandler(this.donateButton_Click);
            // 
            // quickImport
            // 
            this.quickImport.Location = new System.Drawing.Point(0, 440);
            this.quickImport.Name = "quickImport";
            this.quickImport.Size = new System.Drawing.Size(88, 23);
            this.quickImport.TabIndex = 61;
            this.quickImport.Text = "Quick Import";
            this.quickImport.UseVisualStyleBackColor = true;
            this.quickImport.Click += new System.EventHandler(this.quickImport_Click);
            // 
            // RoleplayingVoicePackCreator
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(408, 488);
            this.Controls.Add(this.quickImport);
            this.Controls.Add(this.discordButton);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.removeCategoryButton);
            this.Controls.Add(this.addAllCategoriesButton);
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
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.soundList);
            this.Controls.Add(this.categoryList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "RoleplayingVoicePackCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roleplaying Voice Pack Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoleplayingVoicePackCreator_FormClosing);
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
        private System.Windows.Forms.TextBox nameTextBox;
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
        private System.Windows.Forms.Button addAllCategoriesButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Button removeCategoryButton;
        private System.Windows.Forms.ToolStripMenuItem legacyWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getRoleplayingVoiceToolStripMenuItem;
        private System.Windows.Forms.Button discordButton;
        private System.Windows.Forms.Button donateButton;
        private System.Windows.Forms.Button quickImport;
    }
}