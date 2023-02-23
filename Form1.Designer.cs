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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.copyrightInfoStr = new System.Windows.Forms.Label();
            this.automationSetupGroupBox = new System.Windows.Forms.GroupBox();
            this.layoutFileGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxNumRowsNumBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPaddingNumBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutFileSelector = new System.Windows.Forms.ComboBox();
            this.gameModFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.browseGameModFolderButton = new System.Windows.Forms.Button();
            this.gameModFolderPathLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.iconImagesGroupBox = new System.Windows.Forms.GroupBox();
            this.browseIconImagesButton = new System.Windows.Forms.Button();
            this.iconImagesFolderPathLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.automateButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.automationSetupGroupBox.SuspendLayout();
            this.layoutFileGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumRowsNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPaddingNumBox)).BeginInit();
            this.gameModFolderGroupBox.SuspendLayout();
            this.iconImagesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightInfoStr
            // 
            this.copyrightInfoStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightInfoStr.AutoSize = true;
            this.copyrightInfoStr.ForeColor = System.Drawing.Color.Gray;
            this.copyrightInfoStr.Location = new System.Drawing.Point(372, 6);
            this.copyrightInfoStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.copyrightInfoStr.Name = "copyrightInfoStr";
            this.copyrightInfoStr.Size = new System.Drawing.Size(174, 15);
            this.copyrightInfoStr.TabIndex = 1;
            this.copyrightInfoStr.Text = "© Pear, 2023 All rights reserved.";
            // 
            // automationSetupGroupBox
            // 
            this.automationSetupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.automationSetupGroupBox.Controls.Add(this.layoutFileGroupBox);
            this.automationSetupGroupBox.Controls.Add(this.gameModFolderGroupBox);
            this.automationSetupGroupBox.Controls.Add(this.iconImagesGroupBox);
            this.automationSetupGroupBox.Location = new System.Drawing.Point(8, 18);
            this.automationSetupGroupBox.Name = "automationSetupGroupBox";
            this.automationSetupGroupBox.Size = new System.Drawing.Size(536, 263);
            this.automationSetupGroupBox.TabIndex = 3;
            this.automationSetupGroupBox.TabStop = false;
            this.automationSetupGroupBox.Text = "Automation Setup";
            // 
            // layoutFileGroupBox
            // 
            this.layoutFileGroupBox.Controls.Add(this.groupBox1);
            this.layoutFileGroupBox.Controls.Add(this.label1);
            this.layoutFileGroupBox.Controls.Add(this.layoutFileSelector);
            this.layoutFileGroupBox.Enabled = false;
            this.layoutFileGroupBox.Location = new System.Drawing.Point(6, 171);
            this.layoutFileGroupBox.Name = "layoutFileGroupBox";
            this.layoutFileGroupBox.Size = new System.Drawing.Size(524, 87);
            this.layoutFileGroupBox.TabIndex = 11;
            this.layoutFileGroupBox.TabStop = false;
            this.layoutFileGroupBox.Text = "Layout File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxNumRowsNumBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.iconPaddingNumBox);
            this.groupBox1.Location = new System.Drawing.Point(262, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 68);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Icon Sheet";
            // 
            // maxNumRowsNumBox
            // 
            this.maxNumRowsNumBox.Location = new System.Drawing.Point(114, 35);
            this.maxNumRowsNumBox.Name = "maxNumRowsNumBox";
            this.maxNumRowsNumBox.Size = new System.Drawing.Size(136, 23);
            this.maxNumRowsNumBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Max Number of Rows:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Padding:";
            // 
            // iconPaddingNumBox
            // 
            this.iconPaddingNumBox.Location = new System.Drawing.Point(6, 35);
            this.iconPaddingNumBox.Name = "iconPaddingNumBox";
            this.iconPaddingNumBox.Size = new System.Drawing.Size(102, 23);
            this.iconPaddingNumBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select a layout:";
            // 
            // layoutFileSelector
            // 
            this.layoutFileSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutFileSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutFileSelector.FormattingEnabled = true;
            this.layoutFileSelector.Location = new System.Drawing.Point(6, 48);
            this.layoutFileSelector.Name = "layoutFileSelector";
            this.layoutFileSelector.Size = new System.Drawing.Size(250, 23);
            this.layoutFileSelector.TabIndex = 0;
            // 
            // gameModFolderGroupBox
            // 
            this.gameModFolderGroupBox.Controls.Add(this.browseGameModFolderButton);
            this.gameModFolderGroupBox.Controls.Add(this.gameModFolderPathLabel);
            this.gameModFolderGroupBox.Controls.Add(this.label6);
            this.gameModFolderGroupBox.Location = new System.Drawing.Point(6, 25);
            this.gameModFolderGroupBox.Name = "gameModFolderGroupBox";
            this.gameModFolderGroupBox.Size = new System.Drawing.Size(524, 69);
            this.gameModFolderGroupBox.TabIndex = 11;
            this.gameModFolderGroupBox.TabStop = false;
            this.gameModFolderGroupBox.Text = "Game/Mod Folder";
            // 
            // browseGameModFolderButton
            // 
            this.browseGameModFolderButton.Location = new System.Drawing.Point(6, 20);
            this.browseGameModFolderButton.Name = "browseGameModFolderButton";
            this.browseGameModFolderButton.Size = new System.Drawing.Size(512, 25);
            this.browseGameModFolderButton.TabIndex = 5;
            this.browseGameModFolderButton.Text = "Browse";
            this.browseGameModFolderButton.UseVisualStyleBackColor = true;
            this.browseGameModFolderButton.Click += new System.EventHandler(this.BrowseGameModFolderButton_Click);
            // 
            // gameModFolderPathLabel
            // 
            this.gameModFolderPathLabel.AutoSize = true;
            this.gameModFolderPathLabel.Location = new System.Drawing.Point(36, 47);
            this.gameModFolderPathLabel.Name = "gameModFolderPathLabel";
            this.gameModFolderPathLabel.Size = new System.Drawing.Size(29, 15);
            this.gameModFolderPathLabel.TabIndex = 9;
            this.gameModFolderPathLabel.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Path:";
            // 
            // iconImagesGroupBox
            // 
            this.iconImagesGroupBox.Controls.Add(this.browseIconImagesButton);
            this.iconImagesGroupBox.Controls.Add(this.iconImagesFolderPathLabel);
            this.iconImagesGroupBox.Controls.Add(this.label3);
            this.iconImagesGroupBox.Enabled = false;
            this.iconImagesGroupBox.Location = new System.Drawing.Point(6, 98);
            this.iconImagesGroupBox.Name = "iconImagesGroupBox";
            this.iconImagesGroupBox.Size = new System.Drawing.Size(524, 69);
            this.iconImagesGroupBox.TabIndex = 10;
            this.iconImagesGroupBox.TabStop = false;
            this.iconImagesGroupBox.Text = "Icon Images";
            // 
            // browseIconImagesButton
            // 
            this.browseIconImagesButton.Location = new System.Drawing.Point(6, 20);
            this.browseIconImagesButton.Name = "browseIconImagesButton";
            this.browseIconImagesButton.Size = new System.Drawing.Size(512, 25);
            this.browseIconImagesButton.TabIndex = 5;
            this.browseIconImagesButton.Text = "Browse";
            this.browseIconImagesButton.UseVisualStyleBackColor = true;
            this.browseIconImagesButton.Click += new System.EventHandler(this.BrowseIconImagesButton_Click);
            // 
            // iconImagesFolderPathLabel
            // 
            this.iconImagesFolderPathLabel.AutoSize = true;
            this.iconImagesFolderPathLabel.Location = new System.Drawing.Point(36, 47);
            this.iconImagesFolderPathLabel.Name = "iconImagesFolderPathLabel";
            this.iconImagesFolderPathLabel.Size = new System.Drawing.Size(29, 15);
            this.iconImagesFolderPathLabel.TabIndex = 9;
            this.iconImagesFolderPathLabel.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Path:";
            // 
            // automateButton
            // 
            this.automateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.automateButton.Enabled = false;
            this.automateButton.Location = new System.Drawing.Point(7, 285);
            this.automateButton.Name = "automateButton";
            this.automateButton.Size = new System.Drawing.Size(539, 25);
            this.automateButton.TabIndex = 7;
            this.automateButton.Text = "Automate!";
            this.automateButton.UseVisualStyleBackColor = true;
            this.automateButton.Click += new System.EventHandler(this.AutomateButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(3, 2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 15);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 317);
            this.Controls.Add(this.copyrightInfoStr);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.automateButton);
            this.Controls.Add(this.automationSetupGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IconAutomatorPro";
            this.automationSetupGroupBox.ResumeLayout(false);
            this.layoutFileGroupBox.ResumeLayout(false);
            this.layoutFileGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumRowsNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPaddingNumBox)).EndInit();
            this.gameModFolderGroupBox.ResumeLayout(false);
            this.gameModFolderGroupBox.PerformLayout();
            this.iconImagesGroupBox.ResumeLayout(false);
            this.iconImagesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label copyrightInfoStr;
        private GroupBox automationSetupGroupBox;
        private ComboBox layoutFileSelector;
        private Button browseIconImagesButton;
        private Button automateButton;
        private Label label3;
        private Label iconImagesFolderPathLabel;
        private Label statusLabel;
        private GroupBox iconImagesGroupBox;
        private GroupBox layoutFileGroupBox;
        private Label label1;
        private NumericUpDown iconPaddingNumBox;
        private GroupBox groupBox1;
        private Label label2;
        private NumericUpDown maxNumRowsNumBox;
        private Label label4;
        private GroupBox gameModFolderGroupBox;
        private Button browseGameModFolderButton;
        private Label gameModFolderPathLabel;
        private Label label6;
    }
}