namespace StreamSpotter
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
			// ProfileSelectionScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(800, 450);
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
	}
}