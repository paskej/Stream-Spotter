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
			this.SaveButton = new System.Windows.Forms.Button();
			this.MyCancelButton = new System.Windows.Forms.Button();
			this.NetflixCheckBox = new System.Windows.Forms.CheckBox();
			this.DisneyCheckBox = new System.Windows.Forms.CheckBox();
			this.SwitchButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveButton.Location = new System.Drawing.Point(274, 350);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(91, 40);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// MyCancelButton
			// 
			this.MyCancelButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MyCancelButton.Location = new System.Drawing.Point(437, 350);
			this.MyCancelButton.Name = "MyCancelButton";
			this.MyCancelButton.Size = new System.Drawing.Size(91, 40);
			this.MyCancelButton.TabIndex = 1;
			this.MyCancelButton.Text = "Cancel";
			this.MyCancelButton.UseVisualStyleBackColor = true;
			this.MyCancelButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// NetflixCheckBox
			// 
			this.NetflixCheckBox.AutoSize = true;
			this.NetflixCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NetflixCheckBox.Location = new System.Drawing.Point(227, 156);
			this.NetflixCheckBox.Name = "NetflixCheckBox";
			this.NetflixCheckBox.Size = new System.Drawing.Size(138, 43);
			this.NetflixCheckBox.TabIndex = 2;
			this.NetflixCheckBox.Text = "Netflix";
			this.NetflixCheckBox.UseVisualStyleBackColor = true;
			this.NetflixCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// DisneyCheckBox
			// 
			this.DisneyCheckBox.AutoSize = true;
			this.DisneyCheckBox.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DisneyCheckBox.Location = new System.Drawing.Point(437, 156);
			this.DisneyCheckBox.Name = "DisneyCheckBox";
			this.DisneyCheckBox.Size = new System.Drawing.Size(144, 43);
			this.DisneyCheckBox.TabIndex = 3;
			this.DisneyCheckBox.Text = "Disney+";
			this.DisneyCheckBox.UseVisualStyleBackColor = true;
			this.DisneyCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// SwitchButton
			// 
			this.SwitchButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SwitchButton.Location = new System.Drawing.Point(585, 12);
			this.SwitchButton.Name = "SwitchButton";
			this.SwitchButton.Size = new System.Drawing.Size(203, 42);
			this.SwitchButton.TabIndex = 4;
			this.SwitchButton.Text = "Switch Profile";
			this.SwitchButton.UseVisualStyleBackColor = true;
			this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(227, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "label1";
			// 
			// ProfileSelectionScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SwitchButton);
			this.Controls.Add(this.DisneyCheckBox);
			this.Controls.Add(this.NetflixCheckBox);
			this.Controls.Add(this.MyCancelButton);
			this.Controls.Add(this.SaveButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ProfileSelectionScreen";
			this.Text = "Profile Selection";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button MyCancelButton;
		private System.Windows.Forms.CheckBox NetflixCheckBox;
		private System.Windows.Forms.CheckBox DisneyCheckBox;
		private System.Windows.Forms.Button SwitchButton;
		private System.Windows.Forms.Label label1;
	}
}