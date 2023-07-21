namespace IconAutomatorPro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Use ER Style");
            TreeNode treeNode2 = new TreeNode("Drop Shadow", new TreeNode[] { treeNode1 });
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            copyrightInfoStr = new Label();
            automationSetupGroupBox = new GroupBox();
            iconsConfigGroupBox = new GroupBox();
            hdIconsCheckbox = new CheckBox();
            iconSheetCheckbox = new CheckBox();
            iconSheetGroupBox = new GroupBox();
            postEffectsGroupBox = new GroupBox();
            postEffectsListBox = new TreeView();
            manualInsertLocationCheckbox = new CheckBox();
            insertVerticallyCheckbox = new CheckBox();
            insertLocationGroupBox = new GroupBox();
            label9 = new Label();
            columnNumBox = new NumericUpDown();
            label8 = new Label();
            rowNumBox = new NumericUpDown();
            label7 = new Label();
            iconsHeightNumBox = new NumericUpDown();
            iconsWidthNumBox = new NumericUpDown();
            label5 = new Label();
            maxIconsPerRowColNumBox = new NumericUpDown();
            label4 = new Label();
            label2 = new Label();
            iconPaddingNumBox = new NumericUpDown();
            label1 = new Label();
            iconSheetSelector = new ComboBox();
            gameModFolderGroupBox = new GroupBox();
            browseGameModFolderButton = new Button();
            gameModFolderPathLabel = new Label();
            label6 = new Label();
            iconImagesGroupBox = new GroupBox();
            browseIconImagesButton = new Button();
            iconImagesFolderPathLabel = new Label();
            label3 = new Label();
            automateButton = new Button();
            statusLabel = new Label();
            versionStr = new Label();
            automationSetupGroupBox.SuspendLayout();
            iconsConfigGroupBox.SuspendLayout();
            iconSheetGroupBox.SuspendLayout();
            postEffectsGroupBox.SuspendLayout();
            insertLocationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)columnNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rowNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconsHeightNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconsWidthNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxIconsPerRowColNumBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPaddingNumBox).BeginInit();
            gameModFolderGroupBox.SuspendLayout();
            iconImagesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // copyrightInfoStr
            // 
            copyrightInfoStr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            copyrightInfoStr.AutoSize = true;
            copyrightInfoStr.ForeColor = Color.Gray;
            copyrightInfoStr.Location = new Point(372, 6);
            copyrightInfoStr.Margin = new Padding(2, 0, 2, 0);
            copyrightInfoStr.Name = "copyrightInfoStr";
            copyrightInfoStr.Size = new Size(174, 15);
            copyrightInfoStr.TabIndex = 1;
            copyrightInfoStr.Text = "© Pear, 2023 All rights reserved.";
            // 
            // automationSetupGroupBox
            // 
            automationSetupGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            automationSetupGroupBox.Controls.Add(iconsConfigGroupBox);
            automationSetupGroupBox.Controls.Add(gameModFolderGroupBox);
            automationSetupGroupBox.Controls.Add(iconImagesGroupBox);
            automationSetupGroupBox.Location = new Point(8, 18);
            automationSetupGroupBox.Name = "automationSetupGroupBox";
            automationSetupGroupBox.Size = new Size(536, 552);
            automationSetupGroupBox.TabIndex = 3;
            automationSetupGroupBox.TabStop = false;
            automationSetupGroupBox.Text = "Automation Setup";
            // 
            // iconsConfigGroupBox
            // 
            iconsConfigGroupBox.Controls.Add(hdIconsCheckbox);
            iconsConfigGroupBox.Controls.Add(iconSheetCheckbox);
            iconsConfigGroupBox.Controls.Add(iconSheetGroupBox);
            iconsConfigGroupBox.Enabled = false;
            iconsConfigGroupBox.Location = new Point(6, 171);
            iconsConfigGroupBox.Name = "iconsConfigGroupBox";
            iconsConfigGroupBox.Size = new Size(524, 375);
            iconsConfigGroupBox.TabIndex = 11;
            iconsConfigGroupBox.TabStop = false;
            iconsConfigGroupBox.Text = "Icons Configuration";
            // 
            // hdIconsCheckbox
            // 
            hdIconsCheckbox.AutoSize = true;
            hdIconsCheckbox.Location = new Point(89, 20);
            hdIconsCheckbox.Name = "hdIconsCheckbox";
            hdIconsCheckbox.Size = new Size(74, 19);
            hdIconsCheckbox.TabIndex = 22;
            hdIconsCheckbox.Text = "HD Icons";
            hdIconsCheckbox.UseVisualStyleBackColor = true;
            hdIconsCheckbox.CheckedChanged += HDIconsCheckbox_CheckedChanged;
            // 
            // iconSheetCheckbox
            // 
            iconSheetCheckbox.AutoSize = true;
            iconSheetCheckbox.Location = new Point(6, 20);
            iconSheetCheckbox.Name = "iconSheetCheckbox";
            iconSheetCheckbox.Size = new Size(81, 19);
            iconSheetCheckbox.TabIndex = 21;
            iconSheetCheckbox.Text = "Icon Sheet";
            iconSheetCheckbox.UseVisualStyleBackColor = true;
            iconSheetCheckbox.CheckedChanged += IconSheetCheckbox_CheckedChanged;
            // 
            // iconSheetGroupBox
            // 
            iconSheetGroupBox.Controls.Add(postEffectsGroupBox);
            iconSheetGroupBox.Controls.Add(manualInsertLocationCheckbox);
            iconSheetGroupBox.Controls.Add(insertVerticallyCheckbox);
            iconSheetGroupBox.Controls.Add(label1);
            iconSheetGroupBox.Controls.Add(iconSheetSelector);
            iconSheetGroupBox.Controls.Add(insertLocationGroupBox);
            iconSheetGroupBox.Controls.Add(label7);
            iconSheetGroupBox.Controls.Add(iconsHeightNumBox);
            iconSheetGroupBox.Controls.Add(iconsWidthNumBox);
            iconSheetGroupBox.Controls.Add(label5);
            iconSheetGroupBox.Controls.Add(maxIconsPerRowColNumBox);
            iconSheetGroupBox.Controls.Add(label4);
            iconSheetGroupBox.Controls.Add(label2);
            iconSheetGroupBox.Controls.Add(iconPaddingNumBox);
            iconSheetGroupBox.Location = new Point(6, 45);
            iconSheetGroupBox.Name = "iconSheetGroupBox";
            iconSheetGroupBox.Size = new Size(512, 324);
            iconSheetGroupBox.TabIndex = 12;
            iconSheetGroupBox.TabStop = false;
            iconSheetGroupBox.Text = "Icon Sheet";
            // 
            // postEffectsGroupBox
            // 
            postEffectsGroupBox.Controls.Add(postEffectsListBox);
            postEffectsGroupBox.Location = new Point(6, 243);
            postEffectsGroupBox.Name = "postEffectsGroupBox";
            postEffectsGroupBox.Size = new Size(500, 76);
            postEffectsGroupBox.TabIndex = 28;
            postEffectsGroupBox.TabStop = false;
            postEffectsGroupBox.Text = "Post-Effects";
            // 
            // postEffectsListBox
            // 
            postEffectsListBox.CheckBoxes = true;
            postEffectsListBox.Location = new Point(6, 18);
            postEffectsListBox.Name = "postEffectsListBox";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Use ER Style";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Drop Shadow";
            postEffectsListBox.Nodes.AddRange(new TreeNode[] { treeNode2 });
            postEffectsListBox.Size = new Size(487, 52);
            postEffectsListBox.TabIndex = 0;
            // 
            // manualInsertLocationCheckbox
            // 
            manualInsertLocationCheckbox.AutoSize = true;
            manualInsertLocationCheckbox.Location = new Point(110, 152);
            manualInsertLocationCheckbox.Name = "manualInsertLocationCheckbox";
            manualInsertLocationCheckbox.Size = new Size(147, 19);
            manualInsertLocationCheckbox.TabIndex = 24;
            manualInsertLocationCheckbox.Text = "Manual Insert Location";
            manualInsertLocationCheckbox.UseVisualStyleBackColor = true;
            manualInsertLocationCheckbox.CheckedChanged += ManualInsertLocationCheckbox_CheckedChanged;
            // 
            // insertVerticallyCheckbox
            // 
            insertVerticallyCheckbox.AutoSize = true;
            insertVerticallyCheckbox.Location = new Point(6, 152);
            insertVerticallyCheckbox.Name = "insertVerticallyCheckbox";
            insertVerticallyCheckbox.Size = new Size(105, 19);
            insertVerticallyCheckbox.TabIndex = 20;
            insertVerticallyCheckbox.Text = "Insert Vertically";
            insertVerticallyCheckbox.UseVisualStyleBackColor = true;
            // 
            // insertLocationGroupBox
            // 
            insertLocationGroupBox.Controls.Add(label9);
            insertLocationGroupBox.Controls.Add(columnNumBox);
            insertLocationGroupBox.Controls.Add(label8);
            insertLocationGroupBox.Controls.Add(rowNumBox);
            insertLocationGroupBox.Location = new Point(6, 173);
            insertLocationGroupBox.Name = "insertLocationGroupBox";
            insertLocationGroupBox.Size = new Size(499, 68);
            insertLocationGroupBox.TabIndex = 23;
            insertLocationGroupBox.TabStop = false;
            insertLocationGroupBox.Text = "Insert Location";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(249, 19);
            label9.Name = "label9";
            label9.Size = new Size(100, 15);
            label9.TabIndex = 27;
            label9.Text = "Column Number:";
            // 
            // columnNumBox
            // 
            columnNumBox.Location = new Point(251, 37);
            columnNumBox.Name = "columnNumBox";
            columnNumBox.Size = new Size(241, 23);
            columnNumBox.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(4, 19);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 25;
            label8.Text = "Row Number:";
            // 
            // rowNumBox
            // 
            rowNumBox.Location = new Point(6, 37);
            rowNumBox.Name = "rowNumBox";
            rowNumBox.Size = new Size(241, 23);
            rowNumBox.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(255, 62);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 19;
            label7.Text = "Icons Height:";
            // 
            // iconsHeightNumBox
            // 
            iconsHeightNumBox.Location = new Point(257, 80);
            iconsHeightNumBox.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            iconsHeightNumBox.Name = "iconsHeightNumBox";
            iconsHeightNumBox.Size = new Size(248, 23);
            iconsHeightNumBox.TabIndex = 18;
            // 
            // iconsWidthNumBox
            // 
            iconsWidthNumBox.Location = new Point(6, 80);
            iconsWidthNumBox.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            iconsWidthNumBox.Name = "iconsWidthNumBox";
            iconsWidthNumBox.Size = new Size(248, 23);
            iconsWidthNumBox.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 62);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 16;
            label5.Text = "Icons Width:";
            // 
            // maxIconsPerRowColNumBox
            // 
            maxIconsPerRowColNumBox.Location = new Point(257, 124);
            maxIconsPerRowColNumBox.Name = "maxIconsPerRowColNumBox";
            maxIconsPerRowColNumBox.Size = new Size(248, 23);
            maxIconsPerRowColNumBox.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(255, 106);
            label4.Name = "label4";
            label4.Size = new Size(158, 15);
            label4.TabIndex = 14;
            label4.Text = "Max Icons Per Row/Column:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 106);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 13;
            label2.Text = "Padding:";
            // 
            // iconPaddingNumBox
            // 
            iconPaddingNumBox.Location = new Point(6, 124);
            iconPaddingNumBox.Name = "iconPaddingNumBox";
            iconPaddingNumBox.Size = new Size(248, 23);
            iconPaddingNumBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 17);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 10;
            label1.Text = "Select an icon sheet:";
            // 
            // iconSheetSelector
            // 
            iconSheetSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconSheetSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            iconSheetSelector.FormattingEnabled = true;
            iconSheetSelector.Location = new Point(7, 36);
            iconSheetSelector.Name = "iconSheetSelector";
            iconSheetSelector.Size = new Size(498, 23);
            iconSheetSelector.TabIndex = 0;
            // 
            // gameModFolderGroupBox
            // 
            gameModFolderGroupBox.Controls.Add(browseGameModFolderButton);
            gameModFolderGroupBox.Controls.Add(gameModFolderPathLabel);
            gameModFolderGroupBox.Controls.Add(label6);
            gameModFolderGroupBox.Location = new Point(6, 25);
            gameModFolderGroupBox.Name = "gameModFolderGroupBox";
            gameModFolderGroupBox.Size = new Size(524, 69);
            gameModFolderGroupBox.TabIndex = 11;
            gameModFolderGroupBox.TabStop = false;
            gameModFolderGroupBox.Text = "Game/Mod Folder";
            // 
            // browseGameModFolderButton
            // 
            browseGameModFolderButton.Location = new Point(6, 20);
            browseGameModFolderButton.Name = "browseGameModFolderButton";
            browseGameModFolderButton.Size = new Size(512, 25);
            browseGameModFolderButton.TabIndex = 5;
            browseGameModFolderButton.Text = "Browse";
            browseGameModFolderButton.UseVisualStyleBackColor = true;
            browseGameModFolderButton.Click += BrowseGameModFolderButton_Click;
            // 
            // gameModFolderPathLabel
            // 
            gameModFolderPathLabel.AutoSize = true;
            gameModFolderPathLabel.Location = new Point(36, 47);
            gameModFolderPathLabel.Name = "gameModFolderPathLabel";
            gameModFolderPathLabel.Size = new Size(29, 15);
            gameModFolderPathLabel.TabIndex = 9;
            gameModFolderPathLabel.Text = "N/A";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 47);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 8;
            label6.Text = "Path:";
            // 
            // iconImagesGroupBox
            // 
            iconImagesGroupBox.Controls.Add(browseIconImagesButton);
            iconImagesGroupBox.Controls.Add(iconImagesFolderPathLabel);
            iconImagesGroupBox.Controls.Add(label3);
            iconImagesGroupBox.Enabled = false;
            iconImagesGroupBox.Location = new Point(6, 98);
            iconImagesGroupBox.Name = "iconImagesGroupBox";
            iconImagesGroupBox.Size = new Size(524, 69);
            iconImagesGroupBox.TabIndex = 10;
            iconImagesGroupBox.TabStop = false;
            iconImagesGroupBox.Text = "Icon Images";
            // 
            // browseIconImagesButton
            // 
            browseIconImagesButton.Location = new Point(6, 20);
            browseIconImagesButton.Name = "browseIconImagesButton";
            browseIconImagesButton.Size = new Size(512, 25);
            browseIconImagesButton.TabIndex = 5;
            browseIconImagesButton.Text = "Browse";
            browseIconImagesButton.UseVisualStyleBackColor = true;
            browseIconImagesButton.Click += BrowseIconImagesButton_Click;
            // 
            // iconImagesFolderPathLabel
            // 
            iconImagesFolderPathLabel.AutoSize = true;
            iconImagesFolderPathLabel.Location = new Point(36, 47);
            iconImagesFolderPathLabel.Name = "iconImagesFolderPathLabel";
            iconImagesFolderPathLabel.Size = new Size(29, 15);
            iconImagesFolderPathLabel.TabIndex = 9;
            iconImagesFolderPathLabel.Text = "N/A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 47);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 8;
            label3.Text = "Path:";
            // 
            // automateButton
            // 
            automateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            automateButton.Enabled = false;
            automateButton.Location = new Point(7, 573);
            automateButton.Name = "automateButton";
            automateButton.Size = new Size(539, 25);
            automateButton.TabIndex = 7;
            automateButton.Text = "Automate!";
            automateButton.UseVisualStyleBackColor = true;
            automateButton.Click += AutomateButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(3, 2);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 10;
            statusLabel.Visible = false;
            // 
            // versionStr
            // 
            versionStr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            versionStr.AutoSize = true;
            versionStr.ForeColor = Color.Gray;
            versionStr.Location = new Point(309, 6);
            versionStr.Margin = new Padding(2, 0, 2, 0);
            versionStr.Name = "versionStr";
            versionStr.Size = new Size(48, 15);
            versionStr.TabIndex = 11;
            versionStr.Text = "Version:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 605);
            Controls.Add(versionStr);
            Controls.Add(copyrightInfoStr);
            Controls.Add(statusLabel);
            Controls.Add(automateButton);
            Controls.Add(automationSetupGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            Text = "IconAutomatorPro";
            automationSetupGroupBox.ResumeLayout(false);
            iconsConfigGroupBox.ResumeLayout(false);
            iconsConfigGroupBox.PerformLayout();
            iconSheetGroupBox.ResumeLayout(false);
            iconSheetGroupBox.PerformLayout();
            postEffectsGroupBox.ResumeLayout(false);
            insertLocationGroupBox.ResumeLayout(false);
            insertLocationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)columnNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rowNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconsHeightNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconsWidthNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxIconsPerRowColNumBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPaddingNumBox).EndInit();
            gameModFolderGroupBox.ResumeLayout(false);
            gameModFolderGroupBox.PerformLayout();
            iconImagesGroupBox.ResumeLayout(false);
            iconImagesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label copyrightInfoStr;
        private GroupBox automationSetupGroupBox;
        private ComboBox iconSheetSelector;
        private Button browseIconImagesButton;
        private Button automateButton;
        private Label label3;
        private Label iconImagesFolderPathLabel;
        private Label statusLabel;
        private GroupBox iconImagesGroupBox;
        private GroupBox iconsConfigGroupBox;
        private Label label1;
        private NumericUpDown iconPaddingNumBox;
        private GroupBox iconSheetGroupBox;
        private Label label2;
        private NumericUpDown maxIconsPerRowColNumBox;
        private Label label4;
        private GroupBox gameModFolderGroupBox;
        private Button browseGameModFolderButton;
        private Label gameModFolderPathLabel;
        private Label label6;
        private Label versionStr;
        private Label label5;
        private NumericUpDown iconsWidthNumBox;
        private Label label7;
        private NumericUpDown iconsHeightNumBox;
        private CheckBox insertVerticallyCheckbox;
        private GroupBox insertLocationGroupBox;
        private Label label8;
        private NumericUpDown rowNumBox;
        private Label label9;
        private NumericUpDown columnNumBox;
        private CheckBox manualInsertLocationCheckbox;
        private GroupBox postEffectsGroupBox;
        private TreeView postEffectsListBox;
        private CheckBox iconSheetCheckbox;
        private CheckBox hdIconsCheckbox;
    }
}