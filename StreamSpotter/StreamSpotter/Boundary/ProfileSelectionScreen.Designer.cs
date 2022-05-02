﻿namespace StreamSpotter
{
	partial class ProfileSelectionScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileSelectionScreen));
            this.StreamSelectPanel = new System.Windows.Forms.Panel();
            this.NewProfilePanel = new System.Windows.Forms.Panel();
            this.TooManyProfilesLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveNewProfileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProfileNameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ProfileSavedLabel = new System.Windows.Forms.Label();
            this.SwitchButton = new System.Windows.Forms.Button();
            this.DisneyCheckBox = new System.Windows.Forms.CheckBox();
            this.NetflixCheckBox = new System.Windows.Forms.CheckBox();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SwitchPanel = new System.Windows.Forms.Panel();
            this.ProfileNotCreatedLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewProfileButton = new System.Windows.Forms.Button();
            this.Profile10 = new System.Windows.Forms.Button();
            this.Profile9 = new System.Windows.Forms.Button();
            this.Profile8 = new System.Windows.Forms.Button();
            this.Profile7 = new System.Windows.Forms.Button();
            this.ProfileDeletedLabel = new System.Windows.Forms.Label();
            this.Profile6 = new System.Windows.Forms.Button();
            this.Profile5 = new System.Windows.Forms.Button();
            this.Profile4 = new System.Windows.Forms.Button();
            this.Profile3 = new System.Windows.Forms.Button();
            this.Profile2 = new System.Windows.Forms.Button();
            this.Profile1 = new System.Windows.Forms.Button();
            this.DeleteProfileButton = new System.Windows.Forms.Button();
            this.serviceButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.StreamSelectPanel.SuspendLayout();
            this.NewProfilePanel.SuspendLayout();
            this.SwitchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StreamSelectPanel
            // 
            this.StreamSelectPanel.Controls.Add(this.ProfileSavedLabel);
            this.StreamSelectPanel.Controls.Add(this.SwitchButton);
            this.StreamSelectPanel.Controls.Add(this.DisneyCheckBox);
            this.StreamSelectPanel.Controls.Add(this.NetflixCheckBox);
            this.StreamSelectPanel.Controls.Add(this.MyCancelButton);
            this.StreamSelectPanel.Controls.Add(this.SaveButton);
            this.StreamSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.StreamSelectPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StreamSelectPanel.Name = "StreamSelectPanel";
            this.StreamSelectPanel.Size = new System.Drawing.Size(680, 453);
            this.StreamSelectPanel.TabIndex = 5;
            // 
            // NewProfilePanel
            // 
            this.NewProfilePanel.Controls.Add(this.TooManyProfilesLabel);
            this.NewProfilePanel.Controls.Add(this.CancelButton);
            this.NewProfilePanel.Controls.Add(this.SaveNewProfileButton);
            this.NewProfilePanel.Controls.Add(this.label1);
            this.NewProfilePanel.Controls.Add(this.ProfileNameLabel);
            this.NewProfilePanel.Controls.Add(this.NameTextBox);
            this.NewProfilePanel.Location = new System.Drawing.Point(0, 0);
            this.NewProfilePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NewProfilePanel.Name = "NewProfilePanel";
            this.NewProfilePanel.Size = new System.Drawing.Size(680, 452);
            this.NewProfilePanel.TabIndex = 12;
            this.NewProfilePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NewProfilePanel_Paint);
            // 
            // TooManyProfilesLabel
            // 
            this.TooManyProfilesLabel.AutoSize = true;
            this.TooManyProfilesLabel.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TooManyProfilesLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.TooManyProfilesLabel.Location = new System.Drawing.Point(9, 144);
            this.TooManyProfilesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TooManyProfilesLabel.Name = "TooManyProfilesLabel";
            this.TooManyProfilesLabel.Size = new System.Drawing.Size(622, 27);
            this.TooManyProfilesLabel.TabIndex = 10;
            this.TooManyProfilesLabel.Text = "Too many profiles, please remove an old profile to add a new one";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton.Location = new System.Drawing.Point(340, 259);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(131, 46);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveNewProfileButton
            // 
            this.SaveNewProfileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SaveNewProfileButton.Location = new System.Drawing.Point(160, 262);
            this.SaveNewProfileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveNewProfileButton.Name = "SaveNewProfileButton";
            this.SaveNewProfileButton.Size = new System.Drawing.Size(119, 43);
            this.SaveNewProfileButton.TabIndex = 8;
            this.SaveNewProfileButton.Text = "Save";
            this.SaveNewProfileButton.UseVisualStyleBackColor = false;
            this.SaveNewProfileButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose which streaming services you own on the Profile page";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.AutoSize = true;
            this.ProfileNameLabel.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileNameLabel.Location = new System.Drawing.Point(194, 56);
            this.ProfileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(140, 27);
            this.ProfileNameLabel.TabIndex = 6;
            this.ProfileNameLabel.Text = "Profile Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(198, 86);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(207, 37);
            this.NameTextBox.TabIndex = 5;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ProfileSavedLabel
            // 
            this.ProfileSavedLabel.AutoSize = true;
            this.ProfileSavedLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileSavedLabel.ForeColor = System.Drawing.Color.Green;
            this.ProfileSavedLabel.Location = new System.Drawing.Point(202, 188);
            this.ProfileSavedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProfileSavedLabel.Name = "ProfileSavedLabel";
            this.ProfileSavedLabel.Size = new System.Drawing.Size(214, 23);
            this.ProfileSavedLabel.TabIndex = 10;
            this.ProfileSavedLabel.Text = "Services have been saved!";
            this.ProfileSavedLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // SwitchButton
            // 
            this.SwitchButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchButton.Location = new System.Drawing.Point(439, 11);
            this.SwitchButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(152, 34);
            this.SwitchButton.TabIndex = 9;
            this.SwitchButton.Text = "Switch Profile/Back";
            this.SwitchButton.UseVisualStyleBackColor = true;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click_1);
            // 
            // DisneyCheckBox
            // 
            this.DisneyCheckBox.AutoSize = true;
            this.DisneyCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisneyCheckBox.Location = new System.Drawing.Point(328, 128);
            this.DisneyCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DisneyCheckBox.Name = "DisneyCheckBox";
            this.DisneyCheckBox.Size = new System.Drawing.Size(115, 35);
            this.DisneyCheckBox.TabIndex = 8;
            this.DisneyCheckBox.Text = "Disney+";
            this.DisneyCheckBox.UseVisualStyleBackColor = true;
            // 
            // NetflixCheckBox
            // 
            this.NetflixCheckBox.AutoSize = true;
            this.NetflixCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetflixCheckBox.Location = new System.Drawing.Point(170, 128);
            this.NetflixCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NetflixCheckBox.Name = "NetflixCheckBox";
            this.NetflixCheckBox.Size = new System.Drawing.Size(109, 35);
            this.NetflixCheckBox.TabIndex = 7;
            this.NetflixCheckBox.Text = "Netflix";
            this.NetflixCheckBox.UseVisualStyleBackColor = true;
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyCancelButton.Location = new System.Drawing.Point(328, 285);
            this.MyCancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(68, 32);
            this.MyCancelButton.TabIndex = 6;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.MyCancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(206, 285);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(68, 32);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SwitchPanel
            // 
            this.SwitchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SwitchPanel.Controls.Add(this.NewProfilePanel);
            this.SwitchPanel.Controls.Add(this.StreamSelectPanel);
            this.SwitchPanel.Controls.Add(this.ProfileNotCreatedLabel);
            this.SwitchPanel.Controls.Add(this.ExitButton);
            this.SwitchPanel.Controls.Add(this.NewProfileButton);
            this.SwitchPanel.Controls.Add(this.Profile10);
            this.SwitchPanel.Controls.Add(this.Profile9);
            this.SwitchPanel.Controls.Add(this.Profile8);
            this.SwitchPanel.Controls.Add(this.Profile7);
            this.SwitchPanel.Controls.Add(this.ProfileDeletedLabel);
            this.SwitchPanel.Controls.Add(this.Profile6);
            this.SwitchPanel.Controls.Add(this.Profile5);
            this.SwitchPanel.Controls.Add(this.Profile4);
            this.SwitchPanel.Controls.Add(this.Profile3);
            this.SwitchPanel.Controls.Add(this.Profile2);
            this.SwitchPanel.Controls.Add(this.Profile1);
            this.SwitchPanel.Controls.Add(this.DeleteProfileButton);
            this.SwitchPanel.Controls.Add(this.serviceButton);
            this.SwitchPanel.Controls.Add(this.undoButton);
            this.SwitchPanel.Controls.Add(this.redoButton);
            this.SwitchPanel.Location = new System.Drawing.Point(0, 0);
            this.SwitchPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SwitchPanel.MinimumSize = new System.Drawing.Size(680, 455);
            this.SwitchPanel.Name = "SwitchPanel";
            this.SwitchPanel.Size = new System.Drawing.Size(680, 455);
            this.SwitchPanel.TabIndex = 11;
            this.SwitchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SwitchPanel_Paint_1);
            // 
            // ProfileNotCreatedLabel
            // 
            this.ProfileNotCreatedLabel.AutoSize = true;
            this.ProfileNotCreatedLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileNotCreatedLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.ProfileNotCreatedLabel.Location = new System.Drawing.Point(114, 22);
            this.ProfileNotCreatedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProfileNotCreatedLabel.Name = "ProfileNotCreatedLabel";
            this.ProfileNotCreatedLabel.Size = new System.Drawing.Size(395, 23);
            this.ProfileNotCreatedLabel.TabIndex = 25;
            this.ProfileNotCreatedLabel.Text = "The profile you have clicked hasn\'t been created yet";
            this.ProfileNotCreatedLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(534, 11);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(56, 25);
            this.ExitButton.TabIndex = 22;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NewProfileButton
            // 
            this.NewProfileButton.Location = new System.Drawing.Point(218, 248);
            this.NewProfileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NewProfileButton.Name = "NewProfileButton";
            this.NewProfileButton.Size = new System.Drawing.Size(166, 41);
            this.NewProfileButton.TabIndex = 21;
            this.NewProfileButton.Text = "New Profile";
            this.NewProfileButton.UseVisualStyleBackColor = true;
            this.NewProfileButton.Click += new System.EventHandler(this.NewProfileButton_Click);
            // 
            // Profile10
            // 
            this.Profile10.Location = new System.Drawing.Point(418, 154);
            this.Profile10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile10.Name = "Profile10";
            this.Profile10.Size = new System.Drawing.Size(74, 30);
            this.Profile10.TabIndex = 20;
            this.Profile10.Text = "empty10";
            this.Profile10.UseVisualStyleBackColor = true;
            this.Profile10.Click += new System.EventHandler(this.Profile10_Click);
            // 
            // Profile9
            // 
            this.Profile9.Location = new System.Drawing.Point(340, 155);
            this.Profile9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile9.Name = "Profile9";
            this.Profile9.Size = new System.Drawing.Size(74, 29);
            this.Profile9.TabIndex = 19;
            this.Profile9.Text = "empty9";
            this.Profile9.UseVisualStyleBackColor = true;
            this.Profile9.Click += new System.EventHandler(this.Profile9_Click);
            // 
            // Profile8
            // 
            this.Profile8.Location = new System.Drawing.Point(262, 155);
            this.Profile8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile8.Name = "Profile8";
            this.Profile8.Size = new System.Drawing.Size(74, 30);
            this.Profile8.TabIndex = 18;
            this.Profile8.Text = "empty8";
            this.Profile8.UseVisualStyleBackColor = true;
            this.Profile8.Click += new System.EventHandler(this.Profile8_Click);
            // 
            // Profile7
            // 
            this.Profile7.Location = new System.Drawing.Point(184, 156);
            this.Profile7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile7.Name = "Profile7";
            this.Profile7.Size = new System.Drawing.Size(74, 29);
            this.Profile7.TabIndex = 17;
            this.Profile7.Text = "empty7";
            this.Profile7.UseVisualStyleBackColor = true;
            this.Profile7.Click += new System.EventHandler(this.Profile7_Click);
            // 
            // ProfileDeletedLabel
            // 
            this.ProfileDeletedLabel.AutoSize = true;
            this.ProfileDeletedLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileDeletedLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.ProfileDeletedLabel.Location = new System.Drawing.Point(148, 22);
            this.ProfileDeletedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProfileDeletedLabel.Name = "ProfileDeletedLabel";
            this.ProfileDeletedLabel.Size = new System.Drawing.Size(314, 46);
            this.ProfileDeletedLabel.TabIndex = 24;
            this.ProfileDeletedLabel.Text = "The profile you were on has been deleted,\r\n please choose a new profile\r\n";
            this.ProfileDeletedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ProfileDeletedLabel.Click += new System.EventHandler(this.ProfileDeletedLabel_Click);
            // 
            // Profile6
            // 
            this.Profile6.Location = new System.Drawing.Point(106, 156);
            this.Profile6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile6.Name = "Profile6";
            this.Profile6.Size = new System.Drawing.Size(74, 29);
            this.Profile6.TabIndex = 16;
            this.Profile6.Text = "empty6";
            this.Profile6.UseVisualStyleBackColor = true;
            this.Profile6.Click += new System.EventHandler(this.Profile6_Click);
            // 
            // Profile5
            // 
            this.Profile5.Location = new System.Drawing.Point(418, 76);
            this.Profile5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile5.Name = "Profile5";
            this.Profile5.Size = new System.Drawing.Size(74, 29);
            this.Profile5.TabIndex = 15;
            this.Profile5.Text = "empty5";
            this.Profile5.UseVisualStyleBackColor = true;
            this.Profile5.Click += new System.EventHandler(this.Profile5_Click);
            // 
            // Profile4
            // 
            this.Profile4.Location = new System.Drawing.Point(340, 76);
            this.Profile4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile4.Name = "Profile4";
            this.Profile4.Size = new System.Drawing.Size(74, 30);
            this.Profile4.TabIndex = 14;
            this.Profile4.Text = " empty4";
            this.Profile4.UseVisualStyleBackColor = true;
            this.Profile4.Click += new System.EventHandler(this.Profile4_Click);
            // 
            // Profile3
            // 
            this.Profile3.Location = new System.Drawing.Point(262, 76);
            this.Profile3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile3.Name = "Profile3";
            this.Profile3.Size = new System.Drawing.Size(74, 29);
            this.Profile3.TabIndex = 13;
            this.Profile3.Text = "empty3";
            this.Profile3.UseVisualStyleBackColor = true;
            this.Profile3.Click += new System.EventHandler(this.Profile3_Click);
            // 
            // Profile2
            // 
            this.Profile2.Location = new System.Drawing.Point(184, 76);
            this.Profile2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile2.Name = "Profile2";
            this.Profile2.Size = new System.Drawing.Size(74, 29);
            this.Profile2.TabIndex = 12;
            this.Profile2.Text = "empty2";
            this.Profile2.UseVisualStyleBackColor = true;
            this.Profile2.Click += new System.EventHandler(this.Profile2_Click);
            // 
            // Profile1
            // 
            this.Profile1.Location = new System.Drawing.Point(106, 76);
            this.Profile1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Profile1.Name = "Profile1";
            this.Profile1.Size = new System.Drawing.Size(74, 30);
            this.Profile1.TabIndex = 11;
            this.Profile1.Text = "empty1";
            this.Profile1.UseVisualStyleBackColor = true;
            this.Profile1.Click += new System.EventHandler(this.Profile1_Click_1);
            // 
            // DeleteProfileButton
            // 
            this.DeleteProfileButton.Location = new System.Drawing.Point(9, 11);
            this.DeleteProfileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteProfileButton.Name = "DeleteProfileButton";
            this.DeleteProfileButton.Size = new System.Drawing.Size(56, 25);
            this.DeleteProfileButton.TabIndex = 23;
            this.DeleteProfileButton.Text = "Delete";
            this.DeleteProfileButton.UseVisualStyleBackColor = true;
            this.DeleteProfileButton.Click += new System.EventHandler(this.DeleteProfileButton_Click);
            // 
            // serviceButton
            // 
            this.serviceButton.Location = new System.Drawing.Point(534, 41);
            this.serviceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serviceButton.Name = "serviceButton";
            this.serviceButton.Size = new System.Drawing.Size(57, 24);
            this.serviceButton.TabIndex = 26;
            this.serviceButton.Text = "Services";
            this.serviceButton.UseVisualStyleBackColor = true;
            this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.undoButton.Location = new System.Drawing.Point(12, 80);
            this.undoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(49, 26);
            this.undoButton.TabIndex = 37;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.redoButton.Location = new System.Drawing.Point(62, 80);
            this.redoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(49, 26);
            this.redoButton.TabIndex = 36;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // ProfileSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(683, 460);
            this.Controls.Add(this.SwitchPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(699, 499);
            this.Name = "ProfileSelectionScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Profile Selection";
            this.Load += new System.EventHandler(this.ProfileSelectionScreen_Load);
            this.Resize += new System.EventHandler(this.ProfileSelectionScreen_Resize);
            this.StreamSelectPanel.ResumeLayout(false);
            this.StreamSelectPanel.PerformLayout();
            this.NewProfilePanel.ResumeLayout(false);
            this.NewProfilePanel.PerformLayout();
            this.SwitchPanel.ResumeLayout(false);
            this.SwitchPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel StreamSelectPanel;
		private System.Windows.Forms.Button SwitchButton;
		private System.Windows.Forms.CheckBox DisneyCheckBox;
		private System.Windows.Forms.CheckBox NetflixCheckBox;
		private System.Windows.Forms.Button MyCancelButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Panel SwitchPanel;
		private System.Windows.Forms.Button NewProfileButton;
		private System.Windows.Forms.Button Profile10;
		private System.Windows.Forms.Button Profile9;
		private System.Windows.Forms.Button Profile8;
		private System.Windows.Forms.Button Profile7;
		private System.Windows.Forms.Button Profile6;
		private System.Windows.Forms.Button Profile5;
		private System.Windows.Forms.Button Profile4;
		private System.Windows.Forms.Button Profile3;
		private System.Windows.Forms.Button Profile2;
		private System.Windows.Forms.Button Profile1;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Panel NewProfilePanel;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button SaveNewProfileButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label ProfileNameLabel;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label TooManyProfilesLabel;
		private System.Windows.Forms.Button DeleteProfileButton;
		private System.Windows.Forms.Label ProfileDeletedLabel;
		private System.Windows.Forms.Label ProfileSavedLabel;
		private System.Windows.Forms.Label ProfileNotCreatedLabel;
		private System.Windows.Forms.Button serviceButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button undoButton;
    }
}