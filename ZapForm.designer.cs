namespace ZapRecorder2
{
    partial class ZapMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.btnLocRefresh = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnAddBlackspot = new System.Windows.Forms.Button();
            this.btnClearEverything = new System.Windows.Forms.Button();
            this.btnAddMailbox = new System.Windows.Forms.Button();
            this.btnRecording = new System.Windows.Forms.Button();
            this.btnAddRepair = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblMailboxes = new System.Windows.Forms.Label();
            this.lblVendors = new System.Windows.Forms.Label();
            this.lblHotspots = new System.Windows.Forms.Label();
            this.lblBlackspots = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.addIfMovedTextbox = new System.Windows.Forms.TextBox();
            this.recordingTimeTextbox = new System.Windows.Forms.TextBox();
            this.minBagSlotTextbox = new System.Windows.Forms.TextBox();
            this.minDurabilityTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minimumDurabilityLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.onTop = new System.Windows.Forms.CheckBox();
            this.playSound = new System.Windows.Forms.CheckBox();
            this.sellPurple = new System.Windows.Forms.CheckBox();
            this.sellBlue = new System.Windows.Forms.CheckBox();
            this.sellGreen = new System.Windows.Forms.CheckBox();
            this.sellWhite = new System.Windows.Forms.CheckBox();
            this.sellGrey = new System.Windows.Forms.CheckBox();
            this.mailPurple = new System.Windows.Forms.CheckBox();
            this.mailBlue = new System.Windows.Forms.CheckBox();
            this.mailGreen = new System.Windows.Forms.CheckBox();
            this.mailWhite = new System.Windows.Forms.CheckBox();
            this.mailGrey = new System.Windows.Forms.CheckBox();
            this.tabHotspots = new System.Windows.Forms.TabPage();
            this.btnLoadHotspots = new System.Windows.Forms.Button();
            this.btnReverseHotspots = new System.Windows.Forms.Button();
            this.btnClearSelectedHotspots = new System.Windows.Forms.Button();
            this.btnClearHotspots = new System.Windows.Forms.Button();
            this.listHotspots = new System.Windows.Forms.ListBox();
            this.tabBlackspots = new System.Windows.Forms.TabPage();
            this.btnLoadBlackspots = new System.Windows.Forms.Button();
            this.btnAddBlackspot2 = new System.Windows.Forms.Button();
            this.btnClearSelectedBlackspot = new System.Windows.Forms.Button();
            this.btnClearBlackspots = new System.Windows.Forms.Button();
            this.listBlackspots = new System.Windows.Forms.ListBox();
            this.tabMailboxes = new System.Windows.Forms.TabPage();
            this.btnLoadMailboxes = new System.Windows.Forms.Button();
            this.btnAddMailbox2 = new System.Windows.Forms.Button();
            this.btnClearSelectedMailboxes = new System.Windows.Forms.Button();
            this.btnClearAllMailboxes = new System.Windows.Forms.Button();
            this.listMailboxes = new System.Windows.Forms.ListBox();
            this.tabRepair = new System.Windows.Forms.TabPage();
            this.btnLoadRepair = new System.Windows.Forms.Button();
            this.btnAddRepair2 = new System.Windows.Forms.Button();
            this.btnClearSelectedRepair = new System.Windows.Forms.Button();
            this.btnClearAllRepair = new System.Windows.Forms.Button();
            this.listRepair = new System.Windows.Forms.ListBox();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabHotspots.SuspendLayout();
            this.tabBlackspots.SuspendLayout();
            this.tabMailboxes.SuspendLayout();
            this.tabRepair.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabHotspots);
            this.tabControl1.Controls.Add(this.tabBlackspots);
            this.tabControl1.Controls.Add(this.tabMailboxes);
            this.tabControl1.Controls.Add(this.tabRepair);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 189);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.btnLocRefresh);
            this.tabMain.Controls.Add(this.btnSaveProfile);
            this.tabMain.Controls.Add(this.btnAddBlackspot);
            this.tabMain.Controls.Add(this.btnClearEverything);
            this.tabMain.Controls.Add(this.btnAddMailbox);
            this.tabMain.Controls.Add(this.btnRecording);
            this.tabMain.Controls.Add(this.btnAddRepair);
            this.tabMain.Controls.Add(this.groupBox1);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(596, 163);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // btnLocRefresh
            // 
            this.btnLocRefresh.Location = new System.Drawing.Point(285, 134);
            this.btnLocRefresh.Name = "btnLocRefresh";
            this.btnLocRefresh.Size = new System.Drawing.Size(111, 23);
            this.btnLocRefresh.TabIndex = 19;
            this.btnLocRefresh.Text = "Refresh Location";
            this.btnLocRefresh.UseVisualStyleBackColor = true;
            this.btnLocRefresh.Click += new System.EventHandler(this.btnLocRefresh_Click);
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Location = new System.Drawing.Point(152, 19);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(111, 23);
            this.btnSaveProfile.TabIndex = 17;
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // btnAddBlackspot
            // 
            this.btnAddBlackspot.Location = new System.Drawing.Point(17, 52);
            this.btnAddBlackspot.Name = "btnAddBlackspot";
            this.btnAddBlackspot.Size = new System.Drawing.Size(111, 23);
            this.btnAddBlackspot.TabIndex = 0;
            this.btnAddBlackspot.Text = "Add Blackspot";
            this.btnAddBlackspot.UseVisualStyleBackColor = true;
            this.btnAddBlackspot.Click += new System.EventHandler(this.btnAddBlackspot_Click);
            // 
            // btnClearEverything
            // 
            this.btnClearEverything.Location = new System.Drawing.Point(152, 52);
            this.btnClearEverything.Name = "btnClearEverything";
            this.btnClearEverything.Size = new System.Drawing.Size(111, 23);
            this.btnClearEverything.TabIndex = 18;
            this.btnClearEverything.Text = "Clear Everything";
            this.btnClearEverything.UseVisualStyleBackColor = true;
            this.btnClearEverything.Click += new System.EventHandler(this.btnClearEverything_Click);
            // 
            // btnAddMailbox
            // 
            this.btnAddMailbox.Location = new System.Drawing.Point(17, 118);
            this.btnAddMailbox.Name = "btnAddMailbox";
            this.btnAddMailbox.Size = new System.Drawing.Size(111, 23);
            this.btnAddMailbox.TabIndex = 5;
            this.btnAddMailbox.Text = "Add Mailbox";
            this.btnAddMailbox.UseVisualStyleBackColor = true;
            this.btnAddMailbox.Click += new System.EventHandler(this.btnAddMailbox_Click);
            // 
            // btnRecording
            // 
            this.btnRecording.Location = new System.Drawing.Point(17, 19);
            this.btnRecording.Name = "btnRecording";
            this.btnRecording.Size = new System.Drawing.Size(111, 23);
            this.btnRecording.TabIndex = 0;
            this.btnRecording.Text = "Start Recording";
            this.btnRecording.UseVisualStyleBackColor = true;
            this.btnRecording.Click += new System.EventHandler(this.btnRecording_Click);
            // 
            // btnAddRepair
            // 
            this.btnAddRepair.Location = new System.Drawing.Point(17, 85);
            this.btnAddRepair.Name = "btnAddRepair";
            this.btnAddRepair.Size = new System.Drawing.Size(111, 23);
            this.btnAddRepair.TabIndex = 2;
            this.btnAddRepair.Text = "Add Repair NPC";
            this.btnAddRepair.UseVisualStyleBackColor = true;
            this.btnAddRepair.Click += new System.EventHandler(this.btnAddRepair_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.lblMailboxes);
            this.groupBox1.Controls.Add(this.lblVendors);
            this.groupBox1.Controls.Add(this.lblHotspots);
            this.groupBox1.Controls.Add(this.lblBlackspots);
            this.groupBox1.Location = new System.Drawing.Point(285, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Info";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(6, 73);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(0, 16);
            this.lblLocation.TabIndex = 4;
            // 
            // lblMailboxes
            // 
            this.lblMailboxes.AutoSize = true;
            this.lblMailboxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMailboxes.Location = new System.Drawing.Point(130, 36);
            this.lblMailboxes.Name = "lblMailboxes";
            this.lblMailboxes.Size = new System.Drawing.Size(83, 16);
            this.lblMailboxes.TabIndex = 3;
            this.lblMailboxes.Text = "Mailboxes: 0";
            // 
            // lblVendors
            // 
            this.lblVendors.AutoSize = true;
            this.lblVendors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendors.Location = new System.Drawing.Point(130, 16);
            this.lblVendors.Name = "lblVendors";
            this.lblVendors.Size = new System.Drawing.Size(72, 16);
            this.lblVendors.TabIndex = 2;
            this.lblVendors.Text = "Vendors: 0";
            // 
            // lblHotspots
            // 
            this.lblHotspots.AutoSize = true;
            this.lblHotspots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotspots.Location = new System.Drawing.Point(6, 16);
            this.lblHotspots.Name = "lblHotspots";
            this.lblHotspots.Size = new System.Drawing.Size(75, 16);
            this.lblHotspots.TabIndex = 1;
            this.lblHotspots.Text = "Hotspots: 0";
            // 
            // lblBlackspots
            // 
            this.lblBlackspots.AutoSize = true;
            this.lblBlackspots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackspots.Location = new System.Drawing.Point(6, 36);
            this.lblBlackspots.Name = "lblBlackspots";
            this.lblBlackspots.Size = new System.Drawing.Size(88, 16);
            this.lblBlackspots.TabIndex = 0;
            this.lblBlackspots.Text = "Blackspots: 0";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.numericUpDown1);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.saveSettingsButton);
            this.tabSettings.Controls.Add(this.addIfMovedTextbox);
            this.tabSettings.Controls.Add(this.recordingTimeTextbox);
            this.tabSettings.Controls.Add(this.minBagSlotTextbox);
            this.tabSettings.Controls.Add(this.minDurabilityTextbox);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.minimumDurabilityLabel);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.onTop);
            this.tabSettings.Controls.Add(this.playSound);
            this.tabSettings.Controls.Add(this.sellPurple);
            this.tabSettings.Controls.Add(this.sellBlue);
            this.tabSettings.Controls.Add(this.sellGreen);
            this.tabSettings.Controls.Add(this.sellWhite);
            this.tabSettings.Controls.Add(this.sellGrey);
            this.tabSettings.Controls.Add(this.mailPurple);
            this.tabSettings.Controls.Add(this.mailBlue);
            this.tabSettings.Controls.Add(this.mailGreen);
            this.tabSettings.Controls.Add(this.mailWhite);
            this.tabSettings.Controls.Add(this.mailGrey);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(596, 163);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(297, 103);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 23;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Blackspot Radius";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(403, 8);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(185, 23);
            this.saveSettingsButton.TabIndex = 21;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // addIfMovedTextbox
            // 
            this.addIfMovedTextbox.Location = new System.Drawing.Point(297, 78);
            this.addIfMovedTextbox.Name = "addIfMovedTextbox";
            this.addIfMovedTextbox.Size = new System.Drawing.Size(100, 20);
            this.addIfMovedTextbox.TabIndex = 20;
            this.addIfMovedTextbox.Text = "30";
            // 
            // recordingTimeTextbox
            // 
            this.recordingTimeTextbox.Location = new System.Drawing.Point(297, 55);
            this.recordingTimeTextbox.Name = "recordingTimeTextbox";
            this.recordingTimeTextbox.Size = new System.Drawing.Size(100, 20);
            this.recordingTimeTextbox.TabIndex = 19;
            this.recordingTimeTextbox.Text = "2000";
            // 
            // minBagSlotTextbox
            // 
            this.minBagSlotTextbox.Location = new System.Drawing.Point(297, 32);
            this.minBagSlotTextbox.Name = "minBagSlotTextbox";
            this.minBagSlotTextbox.Size = new System.Drawing.Size(100, 20);
            this.minBagSlotTextbox.TabIndex = 18;
            this.minBagSlotTextbox.Text = "1";
            // 
            // minDurabilityTextbox
            // 
            this.minDurabilityTextbox.Location = new System.Drawing.Point(297, 9);
            this.minDurabilityTextbox.Name = "minDurabilityTextbox";
            this.minDurabilityTextbox.Size = new System.Drawing.Size(100, 20);
            this.minDurabilityTextbox.TabIndex = 17;
            this.minDurabilityTextbox.Text = "0.4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Add if moved";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Recorder Sleep Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Minimum Free Bag Slots";
            // 
            // minimumDurabilityLabel
            // 
            this.minimumDurabilityLabel.AutoSize = true;
            this.minimumDurabilityLabel.Location = new System.Drawing.Point(175, 12);
            this.minimumDurabilityLabel.Name = "minimumDurabilityLabel";
            this.minimumDurabilityLabel.Size = new System.Drawing.Size(94, 13);
            this.minimumDurabilityLabel.TabIndex = 13;
            this.minimumDurabilityLabel.Text = "Minimum Durability";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "* Settings are also automatically saved when you close the window";
            // 
            // onTop
            // 
            this.onTop.AutoSize = true;
            this.onTop.Checked = true;
            this.onTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTop.Location = new System.Drawing.Point(94, 138);
            this.onTop.Name = "onTop";
            this.onTop.Size = new System.Drawing.Size(59, 17);
            this.onTop.TabIndex = 11;
            this.onTop.Text = "OnTop";
            this.onTop.UseVisualStyleBackColor = true;
            // 
            // playSound
            // 
            this.playSound.AutoSize = true;
            this.playSound.Checked = true;
            this.playSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playSound.Location = new System.Drawing.Point(8, 138);
            this.playSound.Name = "playSound";
            this.playSound.Size = new System.Drawing.Size(80, 17);
            this.playSound.TabIndex = 10;
            this.playSound.Text = "Play Sound";
            this.playSound.UseVisualStyleBackColor = true;
            // 
            // sellPurple
            // 
            this.sellPurple.AutoSize = true;
            this.sellPurple.Location = new System.Drawing.Point(94, 104);
            this.sellPurple.Name = "sellPurple";
            this.sellPurple.Size = new System.Drawing.Size(76, 17);
            this.sellPurple.TabIndex = 9;
            this.sellPurple.Text = "Sell Purple";
            this.sellPurple.UseVisualStyleBackColor = true;
            // 
            // sellBlue
            // 
            this.sellBlue.AutoSize = true;
            this.sellBlue.Location = new System.Drawing.Point(94, 81);
            this.sellBlue.Name = "sellBlue";
            this.sellBlue.Size = new System.Drawing.Size(67, 17);
            this.sellBlue.TabIndex = 8;
            this.sellBlue.Text = "Sell Blue";
            this.sellBlue.UseVisualStyleBackColor = true;
            // 
            // sellGreen
            // 
            this.sellGreen.AutoSize = true;
            this.sellGreen.Location = new System.Drawing.Point(94, 58);
            this.sellGreen.Name = "sellGreen";
            this.sellGreen.Size = new System.Drawing.Size(75, 17);
            this.sellGreen.TabIndex = 7;
            this.sellGreen.Text = "Sell Green";
            this.sellGreen.UseVisualStyleBackColor = true;
            // 
            // sellWhite
            // 
            this.sellWhite.AutoSize = true;
            this.sellWhite.Checked = true;
            this.sellWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sellWhite.Location = new System.Drawing.Point(94, 35);
            this.sellWhite.Name = "sellWhite";
            this.sellWhite.Size = new System.Drawing.Size(74, 17);
            this.sellWhite.TabIndex = 6;
            this.sellWhite.Text = "Sell White";
            this.sellWhite.UseVisualStyleBackColor = true;
            // 
            // sellGrey
            // 
            this.sellGrey.AutoSize = true;
            this.sellGrey.Checked = true;
            this.sellGrey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sellGrey.Location = new System.Drawing.Point(94, 12);
            this.sellGrey.Name = "sellGrey";
            this.sellGrey.Size = new System.Drawing.Size(68, 17);
            this.sellGrey.TabIndex = 5;
            this.sellGrey.Text = "Sell Grey";
            this.sellGrey.UseVisualStyleBackColor = true;
            // 
            // mailPurple
            // 
            this.mailPurple.AutoSize = true;
            this.mailPurple.Checked = true;
            this.mailPurple.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mailPurple.Location = new System.Drawing.Point(8, 104);
            this.mailPurple.Name = "mailPurple";
            this.mailPurple.Size = new System.Drawing.Size(78, 17);
            this.mailPurple.TabIndex = 4;
            this.mailPurple.Text = "Mail Purple";
            this.mailPurple.UseVisualStyleBackColor = true;
            // 
            // mailBlue
            // 
            this.mailBlue.AutoSize = true;
            this.mailBlue.Checked = true;
            this.mailBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mailBlue.Location = new System.Drawing.Point(8, 81);
            this.mailBlue.Name = "mailBlue";
            this.mailBlue.Size = new System.Drawing.Size(69, 17);
            this.mailBlue.TabIndex = 3;
            this.mailBlue.Text = "Mail Blue";
            this.mailBlue.UseVisualStyleBackColor = true;
            // 
            // mailGreen
            // 
            this.mailGreen.AutoSize = true;
            this.mailGreen.Checked = true;
            this.mailGreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mailGreen.Location = new System.Drawing.Point(8, 58);
            this.mailGreen.Name = "mailGreen";
            this.mailGreen.Size = new System.Drawing.Size(77, 17);
            this.mailGreen.TabIndex = 2;
            this.mailGreen.Text = "Mail Green";
            this.mailGreen.UseVisualStyleBackColor = true;
            // 
            // mailWhite
            // 
            this.mailWhite.AutoSize = true;
            this.mailWhite.Checked = true;
            this.mailWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mailWhite.Location = new System.Drawing.Point(8, 35);
            this.mailWhite.Name = "mailWhite";
            this.mailWhite.Size = new System.Drawing.Size(76, 17);
            this.mailWhite.TabIndex = 1;
            this.mailWhite.Text = "Mail White";
            this.mailWhite.UseVisualStyleBackColor = true;
            // 
            // mailGrey
            // 
            this.mailGrey.AutoSize = true;
            this.mailGrey.Location = new System.Drawing.Point(8, 12);
            this.mailGrey.Name = "mailGrey";
            this.mailGrey.Size = new System.Drawing.Size(70, 17);
            this.mailGrey.TabIndex = 0;
            this.mailGrey.Text = "Mail Gray";
            this.mailGrey.UseVisualStyleBackColor = true;
            // 
            // tabHotspots
            // 
            this.tabHotspots.Controls.Add(this.btnLoadHotspots);
            this.tabHotspots.Controls.Add(this.btnReverseHotspots);
            this.tabHotspots.Controls.Add(this.btnClearSelectedHotspots);
            this.tabHotspots.Controls.Add(this.btnClearHotspots);
            this.tabHotspots.Controls.Add(this.listHotspots);
            this.tabHotspots.Location = new System.Drawing.Point(4, 22);
            this.tabHotspots.Name = "tabHotspots";
            this.tabHotspots.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotspots.Size = new System.Drawing.Size(596, 163);
            this.tabHotspots.TabIndex = 3;
            this.tabHotspots.Text = "Hotspots";
            this.tabHotspots.UseVisualStyleBackColor = true;
            // 
            // btnLoadHotspots
            // 
            this.btnLoadHotspots.Enabled = false;
            this.btnLoadHotspots.Location = new System.Drawing.Point(490, 108);
            this.btnLoadHotspots.Name = "btnLoadHotspots";
            this.btnLoadHotspots.Size = new System.Drawing.Size(95, 23);
            this.btnLoadHotspots.TabIndex = 19;
            this.btnLoadHotspots.Text = "Load";
            this.btnLoadHotspots.UseVisualStyleBackColor = true;
            this.btnLoadHotspots.Click += new System.EventHandler(this.btnLoadHotspots_Click);
            // 
            // btnReverseHotspots
            // 
            this.btnReverseHotspots.Location = new System.Drawing.Point(490, 79);
            this.btnReverseHotspots.Name = "btnReverseHotspots";
            this.btnReverseHotspots.Size = new System.Drawing.Size(95, 23);
            this.btnReverseHotspots.TabIndex = 18;
            this.btnReverseHotspots.Text = "Reverse";
            this.btnReverseHotspots.UseVisualStyleBackColor = true;
            this.btnReverseHotspots.Click += new System.EventHandler(this.btnReverseHotspots_Click);
            // 
            // btnClearSelectedHotspots
            // 
            this.btnClearSelectedHotspots.Location = new System.Drawing.Point(490, 21);
            this.btnClearSelectedHotspots.Name = "btnClearSelectedHotspots";
            this.btnClearSelectedHotspots.Size = new System.Drawing.Size(95, 23);
            this.btnClearSelectedHotspots.TabIndex = 17;
            this.btnClearSelectedHotspots.Text = "Clear Selected";
            this.btnClearSelectedHotspots.UseVisualStyleBackColor = true;
            this.btnClearSelectedHotspots.Click += new System.EventHandler(this.btnClearSelectedHotspots_Click);
            // 
            // btnClearHotspots
            // 
            this.btnClearHotspots.Location = new System.Drawing.Point(490, 50);
            this.btnClearHotspots.Name = "btnClearHotspots";
            this.btnClearHotspots.Size = new System.Drawing.Size(95, 23);
            this.btnClearHotspots.TabIndex = 15;
            this.btnClearHotspots.Text = "Clear Hotspots";
            this.btnClearHotspots.UseVisualStyleBackColor = true;
            this.btnClearHotspots.Click += new System.EventHandler(this.btnClearHotspots_Click);
            // 
            // listHotspots
            // 
            this.listHotspots.FormattingEnabled = true;
            this.listHotspots.Location = new System.Drawing.Point(12, 21);
            this.listHotspots.Name = "listHotspots";
            this.listHotspots.Size = new System.Drawing.Size(472, 121);
            this.listHotspots.TabIndex = 16;
            // 
            // tabBlackspots
            // 
            this.tabBlackspots.Controls.Add(this.btnLoadBlackspots);
            this.tabBlackspots.Controls.Add(this.btnAddBlackspot2);
            this.tabBlackspots.Controls.Add(this.btnClearSelectedBlackspot);
            this.tabBlackspots.Controls.Add(this.btnClearBlackspots);
            this.tabBlackspots.Controls.Add(this.listBlackspots);
            this.tabBlackspots.Location = new System.Drawing.Point(4, 22);
            this.tabBlackspots.Name = "tabBlackspots";
            this.tabBlackspots.Size = new System.Drawing.Size(596, 163);
            this.tabBlackspots.TabIndex = 4;
            this.tabBlackspots.Text = "Blackspots";
            this.tabBlackspots.UseVisualStyleBackColor = true;
            // 
            // btnLoadBlackspots
            // 
            this.btnLoadBlackspots.Enabled = false;
            this.btnLoadBlackspots.Location = new System.Drawing.Point(490, 108);
            this.btnLoadBlackspots.Name = "btnLoadBlackspots";
            this.btnLoadBlackspots.Size = new System.Drawing.Size(95, 23);
            this.btnLoadBlackspots.TabIndex = 21;
            this.btnLoadBlackspots.Text = "Load";
            this.btnLoadBlackspots.UseVisualStyleBackColor = true;
            this.btnLoadBlackspots.Click += new System.EventHandler(this.btnLoadBlackspots_Click);
            // 
            // btnAddBlackspot2
            // 
            this.btnAddBlackspot2.Location = new System.Drawing.Point(490, 21);
            this.btnAddBlackspot2.Name = "btnAddBlackspot2";
            this.btnAddBlackspot2.Size = new System.Drawing.Size(95, 23);
            this.btnAddBlackspot2.TabIndex = 20;
            this.btnAddBlackspot2.Text = "Add Blackspot";
            this.btnAddBlackspot2.UseVisualStyleBackColor = true;
            this.btnAddBlackspot2.Click += new System.EventHandler(this.btnAddBlackspot2_Click);
            // 
            // btnClearSelectedBlackspot
            // 
            this.btnClearSelectedBlackspot.Location = new System.Drawing.Point(490, 50);
            this.btnClearSelectedBlackspot.Name = "btnClearSelectedBlackspot";
            this.btnClearSelectedBlackspot.Size = new System.Drawing.Size(95, 23);
            this.btnClearSelectedBlackspot.TabIndex = 19;
            this.btnClearSelectedBlackspot.Text = "Clear Selected";
            this.btnClearSelectedBlackspot.UseVisualStyleBackColor = true;
            this.btnClearSelectedBlackspot.Click += new System.EventHandler(this.btnClearSelectedBlackspot_Click);
            // 
            // btnClearBlackspots
            // 
            this.btnClearBlackspots.Location = new System.Drawing.Point(490, 79);
            this.btnClearBlackspots.Name = "btnClearBlackspots";
            this.btnClearBlackspots.Size = new System.Drawing.Size(95, 23);
            this.btnClearBlackspots.TabIndex = 17;
            this.btnClearBlackspots.Text = "Clear Blackspots";
            this.btnClearBlackspots.UseVisualStyleBackColor = true;
            this.btnClearBlackspots.Click += new System.EventHandler(this.btnClearBlackspots_Click);
            // 
            // listBlackspots
            // 
            this.listBlackspots.FormattingEnabled = true;
            this.listBlackspots.Location = new System.Drawing.Point(12, 21);
            this.listBlackspots.Name = "listBlackspots";
            this.listBlackspots.Size = new System.Drawing.Size(472, 121);
            this.listBlackspots.TabIndex = 18;
            // 
            // tabMailboxes
            // 
            this.tabMailboxes.Controls.Add(this.btnLoadMailboxes);
            this.tabMailboxes.Controls.Add(this.btnAddMailbox2);
            this.tabMailboxes.Controls.Add(this.btnClearSelectedMailboxes);
            this.tabMailboxes.Controls.Add(this.btnClearAllMailboxes);
            this.tabMailboxes.Controls.Add(this.listMailboxes);
            this.tabMailboxes.Location = new System.Drawing.Point(4, 22);
            this.tabMailboxes.Name = "tabMailboxes";
            this.tabMailboxes.Size = new System.Drawing.Size(596, 163);
            this.tabMailboxes.TabIndex = 5;
            this.tabMailboxes.Text = "Mailboxes";
            this.tabMailboxes.UseVisualStyleBackColor = true;
            // 
            // btnLoadMailboxes
            // 
            this.btnLoadMailboxes.Enabled = false;
            this.btnLoadMailboxes.Location = new System.Drawing.Point(490, 108);
            this.btnLoadMailboxes.Name = "btnLoadMailboxes";
            this.btnLoadMailboxes.Size = new System.Drawing.Size(95, 23);
            this.btnLoadMailboxes.TabIndex = 23;
            this.btnLoadMailboxes.Text = "Load";
            this.btnLoadMailboxes.UseVisualStyleBackColor = true;
            this.btnLoadMailboxes.Click += new System.EventHandler(this.btnLoadMailboxes_Click);
            // 
            // btnAddMailbox2
            // 
            this.btnAddMailbox2.Location = new System.Drawing.Point(490, 21);
            this.btnAddMailbox2.Name = "btnAddMailbox2";
            this.btnAddMailbox2.Size = new System.Drawing.Size(95, 23);
            this.btnAddMailbox2.TabIndex = 22;
            this.btnAddMailbox2.Text = "Add Mailbox";
            this.btnAddMailbox2.UseVisualStyleBackColor = true;
            this.btnAddMailbox2.Click += new System.EventHandler(this.btnAddMailbox2_Click);
            // 
            // btnClearSelectedMailboxes
            // 
            this.btnClearSelectedMailboxes.Location = new System.Drawing.Point(490, 50);
            this.btnClearSelectedMailboxes.Name = "btnClearSelectedMailboxes";
            this.btnClearSelectedMailboxes.Size = new System.Drawing.Size(95, 23);
            this.btnClearSelectedMailboxes.TabIndex = 21;
            this.btnClearSelectedMailboxes.Text = "Clear Selected";
            this.btnClearSelectedMailboxes.UseVisualStyleBackColor = true;
            this.btnClearSelectedMailboxes.Click += new System.EventHandler(this.btnClearSelectedMailboxes_Click);
            // 
            // btnClearAllMailboxes
            // 
            this.btnClearAllMailboxes.Location = new System.Drawing.Point(490, 79);
            this.btnClearAllMailboxes.Name = "btnClearAllMailboxes";
            this.btnClearAllMailboxes.Size = new System.Drawing.Size(95, 23);
            this.btnClearAllMailboxes.TabIndex = 19;
            this.btnClearAllMailboxes.Text = "Clear Mailboxes";
            this.btnClearAllMailboxes.UseVisualStyleBackColor = true;
            this.btnClearAllMailboxes.Click += new System.EventHandler(this.btnClearAllMailboxes_Click);
            // 
            // listMailboxes
            // 
            this.listMailboxes.FormattingEnabled = true;
            this.listMailboxes.Location = new System.Drawing.Point(12, 21);
            this.listMailboxes.Name = "listMailboxes";
            this.listMailboxes.Size = new System.Drawing.Size(472, 121);
            this.listMailboxes.TabIndex = 20;
            // 
            // tabRepair
            // 
            this.tabRepair.Controls.Add(this.btnLoadRepair);
            this.tabRepair.Controls.Add(this.btnAddRepair2);
            this.tabRepair.Controls.Add(this.btnClearSelectedRepair);
            this.tabRepair.Controls.Add(this.btnClearAllRepair);
            this.tabRepair.Controls.Add(this.listRepair);
            this.tabRepair.Location = new System.Drawing.Point(4, 22);
            this.tabRepair.Name = "tabRepair";
            this.tabRepair.Size = new System.Drawing.Size(596, 163);
            this.tabRepair.TabIndex = 6;
            this.tabRepair.Text = "Repair";
            this.tabRepair.UseVisualStyleBackColor = true;
            // 
            // btnLoadRepair
            // 
            this.btnLoadRepair.Enabled = false;
            this.btnLoadRepair.Location = new System.Drawing.Point(490, 108);
            this.btnLoadRepair.Name = "btnLoadRepair";
            this.btnLoadRepair.Size = new System.Drawing.Size(95, 23);
            this.btnLoadRepair.TabIndex = 22;
            this.btnLoadRepair.Text = "Load";
            this.btnLoadRepair.UseVisualStyleBackColor = true;
            this.btnLoadRepair.Click += new System.EventHandler(this.btnLoadRepair_Click);
            // 
            // btnAddRepair2
            // 
            this.btnAddRepair2.Location = new System.Drawing.Point(490, 21);
            this.btnAddRepair2.Name = "btnAddRepair2";
            this.btnAddRepair2.Size = new System.Drawing.Size(95, 23);
            this.btnAddRepair2.TabIndex = 21;
            this.btnAddRepair2.Text = "Add Repair";
            this.btnAddRepair2.UseVisualStyleBackColor = true;
            this.btnAddRepair2.Click += new System.EventHandler(this.btnAddRepair2_Click);
            // 
            // btnClearSelectedRepair
            // 
            this.btnClearSelectedRepair.Location = new System.Drawing.Point(490, 50);
            this.btnClearSelectedRepair.Name = "btnClearSelectedRepair";
            this.btnClearSelectedRepair.Size = new System.Drawing.Size(95, 23);
            this.btnClearSelectedRepair.TabIndex = 20;
            this.btnClearSelectedRepair.Text = "Clear Selected";
            this.btnClearSelectedRepair.UseVisualStyleBackColor = true;
            this.btnClearSelectedRepair.Click += new System.EventHandler(this.btnClearSelectedRepair_Click);
            // 
            // btnClearAllRepair
            // 
            this.btnClearAllRepair.Location = new System.Drawing.Point(490, 79);
            this.btnClearAllRepair.Name = "btnClearAllRepair";
            this.btnClearAllRepair.Size = new System.Drawing.Size(95, 23);
            this.btnClearAllRepair.TabIndex = 18;
            this.btnClearAllRepair.Text = "Clear Repair";
            this.btnClearAllRepair.UseVisualStyleBackColor = true;
            this.btnClearAllRepair.Click += new System.EventHandler(this.btnClearAllRepair_Click);
            // 
            // listRepair
            // 
            this.listRepair.FormattingEnabled = true;
            this.listRepair.Location = new System.Drawing.Point(12, 21);
            this.listRepair.Name = "listRepair";
            this.listRepair.Size = new System.Drawing.Size(472, 121);
            this.listRepair.TabIndex = 19;
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "xml";
            this.dlgSaveFile.Filter = "XML Profiles|*.xml";
            this.dlgSaveFile.Title = "Save a Profile";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 191);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(604, 167);
            this.txtLog.TabIndex = 20;
            this.txtLog.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Location: ";
            // 
            // ZapMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 358);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ZapMainForm";
            this.Text = "ZapRecorder2";
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabHotspots.ResumeLayout(false);
            this.tabBlackspots.ResumeLayout(false);
            this.tabMailboxes.ResumeLayout(false);
            this.tabRepair.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.CheckBox onTop;
        private System.Windows.Forms.CheckBox playSound;
        private System.Windows.Forms.CheckBox sellPurple;
        private System.Windows.Forms.CheckBox sellBlue;
        private System.Windows.Forms.CheckBox sellGreen;
        private System.Windows.Forms.CheckBox sellWhite;
        private System.Windows.Forms.CheckBox sellGrey;
        private System.Windows.Forms.CheckBox mailPurple;
        private System.Windows.Forms.CheckBox mailBlue;
        private System.Windows.Forms.CheckBox mailGreen;
        private System.Windows.Forms.CheckBox mailWhite;
        private System.Windows.Forms.CheckBox mailGrey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addIfMovedTextbox;
        private System.Windows.Forms.TextBox recordingTimeTextbox;
        private System.Windows.Forms.TextBox minBagSlotTextbox;
        private System.Windows.Forms.TextBox minDurabilityTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label minimumDurabilityLabel;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnAddBlackspot;
        private System.Windows.Forms.Button btnClearEverything;
        private System.Windows.Forms.Button btnAddMailbox;
        private System.Windows.Forms.Button btnRecording;
        private System.Windows.Forms.Button btnAddRepair;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMailboxes;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.Label lblHotspots;
        private System.Windows.Forms.Label lblBlackspots;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TabPage tabHotspots;
        private System.Windows.Forms.TabPage tabBlackspots;
        private System.Windows.Forms.TabPage tabMailboxes;
        private System.Windows.Forms.Button btnLoadHotspots;
        private System.Windows.Forms.Button btnReverseHotspots;
        private System.Windows.Forms.Button btnClearSelectedHotspots;
        private System.Windows.Forms.Button btnClearHotspots;
        private System.Windows.Forms.ListBox listHotspots;
        private System.Windows.Forms.Button btnLoadBlackspots;
        private System.Windows.Forms.Button btnAddBlackspot2;
        private System.Windows.Forms.Button btnClearSelectedBlackspot;
        private System.Windows.Forms.Button btnClearBlackspots;
        private System.Windows.Forms.ListBox listBlackspots;
        private System.Windows.Forms.Button btnLoadMailboxes;
        private System.Windows.Forms.Button btnAddMailbox2;
        private System.Windows.Forms.Button btnClearSelectedMailboxes;
        private System.Windows.Forms.Button btnClearAllMailboxes;
        private System.Windows.Forms.ListBox listMailboxes;
        private System.Windows.Forms.TabPage tabRepair;
        private System.Windows.Forms.Button btnLoadRepair;
        private System.Windows.Forms.Button btnAddRepair2;
        private System.Windows.Forms.Button btnClearSelectedRepair;
        private System.Windows.Forms.Button btnClearAllRepair;
        private System.Windows.Forms.ListBox listRepair;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnLocRefresh;
        private System.Windows.Forms.Label label2;
    }
}

