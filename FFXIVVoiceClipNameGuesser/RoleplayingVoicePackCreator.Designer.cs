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
            categoryList = new System.Windows.Forms.ListBox();
            soundList = new System.Windows.Forms.ListBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            legacyWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            getRoleplayingVoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nameTextBox = new System.Windows.Forms.TextBox();
            addCategoryButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            categoryComboBox = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            exportToArtemisButton = new System.Windows.Forms.Button();
            AddSoundButton = new System.Windows.Forms.Button();
            removeSoundButton = new System.Windows.Forms.Button();
            clearListButton = new System.Windows.Forms.Button();
            addAllCategoriesButton = new System.Windows.Forms.Button();
            removeCategoryButton = new System.Windows.Forms.Button();
            discordButton = new System.Windows.Forms.Button();
            donateButton = new System.Windows.Forms.Button();
            quickImport = new System.Windows.Forms.Button();
            exportToPenumbraButton = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // categoryList
            // 
            categoryList.FormattingEnabled = true;
            categoryList.ItemHeight = 15;
            categoryList.Location = new System.Drawing.Point(0, 112);
            categoryList.Name = "categoryList";
            categoryList.Size = new System.Drawing.Size(408, 139);
            categoryList.TabIndex = 0;
            categoryList.SelectedIndexChanged += categoryList_SelectedIndexChanged;
            // 
            // soundList
            // 
            soundList.AllowDrop = true;
            soundList.FormattingEnabled = true;
            soundList.ItemHeight = 15;
            soundList.Location = new System.Drawing.Point(0, 300);
            soundList.Name = "soundList";
            soundList.Size = new System.Drawing.Size(408, 139);
            soundList.TabIndex = 2;
            soundList.SelectedIndexChanged += soundList_SelectedIndexChanged;
            soundList.DragDrop += soundList_DragDrop;
            soundList.DragEnter += soundList_DragEnter;
            soundList.DoubleClick += soundList_DoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, legacyWindowToolStripMenuItem, getRoleplayingVoiceToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(408, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // legacyWindowToolStripMenuItem
            // 
            legacyWindowToolStripMenuItem.Name = "legacyWindowToolStripMenuItem";
            legacyWindowToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            legacyWindowToolStripMenuItem.Text = "Legacy Window";
            legacyWindowToolStripMenuItem.Click += legacyWindowToolStripMenuItem_Click;
            // 
            // getRoleplayingVoiceToolStripMenuItem
            // 
            getRoleplayingVoiceToolStripMenuItem.Name = "getRoleplayingVoiceToolStripMenuItem";
            getRoleplayingVoiceToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            getRoleplayingVoiceToolStripMenuItem.Text = "Get Artemis";
            getRoleplayingVoiceToolStripMenuItem.Click += getRoleplayingVoiceToolStripMenuItem_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(64, 32);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(340, 23);
            nameTextBox.TabIndex = 4;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // addCategoryButton
            // 
            addCategoryButton.Location = new System.Drawing.Point(224, 56);
            addCategoryButton.Name = "addCategoryButton";
            addCategoryButton.Size = new System.Drawing.Size(88, 23);
            addCategoryButton.TabIndex = 5;
            addCategoryButton.Text = "Add Category";
            addCategoryButton.UseVisualStyleBackColor = true;
            addCategoryButton.Click += addCategoryButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Items.AddRange(new object[] { "Surprised", "Angry", "Furious", "Cheer", "Doze", "Fume", "Huh", "Chuckle", "Laugh", "No", "Stretch", "Upset", "Yes", "Happy", "Attack", "Melee Attack", "Casted Attack", "Hurt", "Death", "Casting Attack", "Casting Heal", "Casting", "Missed", "Limitbreak", "Invalid Target", "Target is not in range", "Target is not in line of sight", "Cannot use", "Not yet ready", "You do not have the gil required" });
            categoryComboBox.Location = new System.Drawing.Point(64, 56);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new System.Drawing.Size(160, 23);
            categoryComboBox.TabIndex = 7;
            categoryComboBox.SelectedIndexChanged += categoryComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 15);
            label2.TabIndex = 8;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(0, 84);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 25);
            label3.TabIndex = 9;
            label3.Text = "Categories";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(0, 272);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(189, 25);
            label4.TabIndex = 10;
            label4.Text = "Sounds In Category";
            // 
            // exportToArtemisButton
            // 
            exportToArtemisButton.Location = new System.Drawing.Point(0, 464);
            exportToArtemisButton.Name = "exportToArtemisButton";
            exportToArtemisButton.Size = new System.Drawing.Size(204, 23);
            exportToArtemisButton.TabIndex = 11;
            exportToArtemisButton.Text = "Export To Artemis Roleplaying Kit";
            exportToArtemisButton.UseVisualStyleBackColor = true;
            exportToArtemisButton.Click += exportButton_Click;
            // 
            // AddSoundButton
            // 
            AddSoundButton.Location = new System.Drawing.Point(328, 440);
            AddSoundButton.Name = "AddSoundButton";
            AddSoundButton.Size = new System.Drawing.Size(80, 23);
            AddSoundButton.TabIndex = 12;
            AddSoundButton.Text = "Add Sound";
            AddSoundButton.UseVisualStyleBackColor = true;
            AddSoundButton.Click += AddSoundButton_Click;
            // 
            // removeSoundButton
            // 
            removeSoundButton.Location = new System.Drawing.Point(232, 440);
            removeSoundButton.Name = "removeSoundButton";
            removeSoundButton.Size = new System.Drawing.Size(96, 23);
            removeSoundButton.TabIndex = 13;
            removeSoundButton.Text = "Remove Sound";
            removeSoundButton.UseVisualStyleBackColor = true;
            removeSoundButton.Click += removeSoundButton_Click;
            // 
            // clearListButton
            // 
            clearListButton.Location = new System.Drawing.Point(136, 440);
            clearListButton.Name = "clearListButton";
            clearListButton.Size = new System.Drawing.Size(96, 23);
            clearListButton.TabIndex = 14;
            clearListButton.Text = "Clear List";
            clearListButton.UseVisualStyleBackColor = true;
            clearListButton.Click += clearListButton_Click;
            // 
            // addAllCategoriesButton
            // 
            addAllCategoriesButton.Location = new System.Drawing.Point(312, 56);
            addAllCategoriesButton.Name = "addAllCategoriesButton";
            addAllCategoriesButton.Size = new System.Drawing.Size(92, 23);
            addAllCategoriesButton.TabIndex = 15;
            addAllCategoriesButton.Text = "Add Template";
            addAllCategoriesButton.UseVisualStyleBackColor = true;
            addAllCategoriesButton.Click += addAllCategoriesButton_Click;
            // 
            // removeCategoryButton
            // 
            removeCategoryButton.Location = new System.Drawing.Point(296, 252);
            removeCategoryButton.Name = "removeCategoryButton";
            removeCategoryButton.Size = new System.Drawing.Size(112, 23);
            removeCategoryButton.TabIndex = 16;
            removeCategoryButton.Text = "Remove Category";
            removeCategoryButton.UseVisualStyleBackColor = true;
            removeCategoryButton.Click += removeCategoryButton_Click;
            // 
            // discordButton
            // 
            discordButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            discordButton.BackColor = System.Drawing.Color.RoyalBlue;
            discordButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            discordButton.Location = new System.Drawing.Point(256, 0);
            discordButton.Name = "discordButton";
            discordButton.Size = new System.Drawing.Size(75, 23);
            discordButton.TabIndex = 59;
            discordButton.Text = "Discord";
            discordButton.UseVisualStyleBackColor = false;
            discordButton.Click += discordButton_Click;
            // 
            // donateButton
            // 
            donateButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            donateButton.BackColor = System.Drawing.Color.IndianRed;
            donateButton.ForeColor = System.Drawing.Color.White;
            donateButton.Location = new System.Drawing.Point(332, 0);
            donateButton.Name = "donateButton";
            donateButton.Size = new System.Drawing.Size(75, 23);
            donateButton.TabIndex = 58;
            donateButton.Text = "Donate";
            donateButton.UseVisualStyleBackColor = false;
            donateButton.Click += donateButton_Click;
            // 
            // quickImport
            // 
            quickImport.Location = new System.Drawing.Point(0, 440);
            quickImport.Name = "quickImport";
            quickImport.Size = new System.Drawing.Size(88, 23);
            quickImport.TabIndex = 61;
            quickImport.Text = "Quick Import";
            quickImport.UseVisualStyleBackColor = true;
            quickImport.Click += quickImport_Click;
            // 
            // exportToPenumbraButton
            // 
            exportToPenumbraButton.Location = new System.Drawing.Point(204, 464);
            exportToPenumbraButton.Name = "exportToPenumbraButton";
            exportToPenumbraButton.Size = new System.Drawing.Size(204, 23);
            exportToPenumbraButton.TabIndex = 62;
            exportToPenumbraButton.Text = "Export As Hybrid Penumbra Mod";
            exportToPenumbraButton.UseVisualStyleBackColor = true;
            exportToPenumbraButton.Click += exportToPenumbraButton_click;
            // 
            // RoleplayingVoicePackCreator
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(408, 488);
            Controls.Add(exportToPenumbraButton);
            Controls.Add(quickImport);
            Controls.Add(discordButton);
            Controls.Add(donateButton);
            Controls.Add(removeCategoryButton);
            Controls.Add(addAllCategoriesButton);
            Controls.Add(clearListButton);
            Controls.Add(removeSoundButton);
            Controls.Add(AddSoundButton);
            Controls.Add(exportToArtemisButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(categoryComboBox);
            Controls.Add(label1);
            Controls.Add(addCategoryButton);
            Controls.Add(nameTextBox);
            Controls.Add(soundList);
            Controls.Add(categoryList);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "RoleplayingVoicePackCreator";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Artemis Sound Pack Creator";
            FormClosing += RoleplayingVoicePackCreator_FormClosing;
            Load += RoleplayingVoicePackCreator_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button exportToArtemisButton;
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
        private System.Windows.Forms.Button exportToPenumbraButton;
    }
}