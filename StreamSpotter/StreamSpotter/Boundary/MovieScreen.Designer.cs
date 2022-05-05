﻿namespace StreamSpotter
{
    partial class MovieScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieScreen));
            this.BackButton = new System.Windows.Forms.Button();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.HomeButton = new System.Windows.Forms.Button();
            this.overviewLabel = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.titleBox = new System.Windows.Forms.RichTextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BackButton.Location = new System.Drawing.Point(6, 7);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(27, 32);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "<";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ratingLabel.Location = new System.Drawing.Point(80, 155);
            this.ratingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(106, 15);
            this.ratingLabel.TabIndex = 8;
            this.ratingLabel.Text = "IMDb Rating: 5/10";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.ImageLocation = "https://www.kindpng.com/picc/m/130-1300387_tumbleweed-drawing-clip-art-tumbleweed" +
    "-png-transparent-png.png";
            this.pictureBox1.Location = new System.Drawing.Point(40, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(664, 11);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 20);
            this.button4.TabIndex = 10;
            this.button4.Text = "Profile";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(-8, -5);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(734, 49);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // HomeButton
            // 
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(40, 8);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(2);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(59, 32);
            this.HomeButton.TabIndex = 22;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // overviewLabel
            // 
            this.overviewLabel.AutoSize = true;
            this.overviewLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.overviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.overviewLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.overviewLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.overviewLabel.Location = new System.Drawing.Point(82, 67);
            this.overviewLabel.Margin = new System.Windows.Forms.Padding(2);
            this.overviewLabel.Name = "overviewLabel";
            this.overviewLabel.ReadOnly = true;
            this.overviewLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.overviewLabel.Size = new System.Drawing.Size(292, 47);
            this.overviewLabel.TabIndex = 23;
            this.overviewLabel.Text = "fsakd fijpasdn jipasdnfijn saidj fiasjd fjisad fijsa fhsdi fsad fdijs faksdflkjds" +
    "a fkjas dfkjsd afkj d safjk jkds fjks fspdi uivs fauvu ai vfu ai viuafia vfafvua" +
    " ias viufiusa vu";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(195, 182);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 21);
            this.button3.TabIndex = 7;
            this.button3.Text = "Add to Wishlist";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.ImageLocation = "";
            this.pictureBox4.Location = new System.Drawing.Point(82, 225);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox4_LoadCompleted);
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(142, 229);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.playButton.Location = new System.Drawing.Point(82, 182);
            this.playButton.Margin = new System.Windows.Forms.Padding(2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(88, 21);
            this.playButton.TabIndex = 30;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.ProfileButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ProfileButton.Location = new System.Drawing.Point(651, -2);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(79, 32);
            this.ProfileButton.TabIndex = 4;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // wishlistButton
            // 
            this.wishlistButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wishlistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wishlistButton.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.wishlistButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.wishlistButton.Location = new System.Drawing.Point(570, 3);
            this.wishlistButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(79, 32);
            this.wishlistButton.TabIndex = 23;
            this.wishlistButton.Text = "Wishlist";
            this.wishlistButton.UseVisualStyleBackColor = false;
            this.wishlistButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox5
            // 
            this.pictureBox5.ImageLocation = "https://media.nationalgeographic.org/assets/photos/186/480/0e077d4d-9209-40d5-9fd" +
    "5-4e51aeed7b37.jpg";
            this.pictureBox5.Location = new System.Drawing.Point(-8, 42);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(734, 406);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.titleBox);
            this.infoPanel.Controls.Add(this.playButton);
            this.infoPanel.Controls.Add(this.pictureBox2);
            this.infoPanel.Controls.Add(this.pictureBox4);
            this.infoPanel.Controls.Add(this.ratingLabel);
            this.infoPanel.Controls.Add(this.overviewLabel);
            this.infoPanel.Controls.Add(this.button3);
            this.infoPanel.Location = new System.Drawing.Point(140, 63);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(400, 350);
            this.infoPanel.TabIndex = 36;
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.titleBox.Location = new System.Drawing.Point(82, 3);
            this.titleBox.Name = "titleBox";
            this.titleBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.titleBox.Size = new System.Drawing.Size(284, 57);
            this.titleBox.TabIndex = 31;
            this.titleBox.Text = "Example Title";
            this.titleBox.ZoomFactor = 4F;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(702, 42);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(23, 406);
            this.vScrollBar1.TabIndex = 37;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // MovieScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(722, 453);
            this.Controls.Add(this.wishlistButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.button4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MovieScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieScreen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MovieScreen_FormClosed);
            this.Load += new System.EventHandler(this.MovieScreen_Load);
            this.ResizeEnd += new System.EventHandler(this.MovieScreen_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MovieScreen_SizeChanged);
            this.Resize += new System.EventHandler(this.MovieScreen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.RichTextBox overviewLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.RichTextBox titleBox;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
