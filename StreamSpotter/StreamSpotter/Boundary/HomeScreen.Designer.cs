namespace StreamSpotter
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.label3 = new System.Windows.Forms.Label();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.recommendedPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.recommendedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter Movie/Show:";
            // 
            // ProfileButton
            // 
            this.ProfileButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ProfileButton.Location = new System.Drawing.Point(804, 14);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(105, 39);
            this.ProfileButton.TabIndex = 4;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Recommended:";
            // 
            // SearchBar
            // 
            this.SearchBar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar.Location = new System.Drawing.Point(296, 252);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(263, 35);
            this.SearchBar.TabIndex = 25;
            this.SearchBar.Text = "Search";
            this.SearchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBar_KeyPress);
            // 
            // wishlistButton
            // 
            this.wishlistButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wishlistButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wishlistButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.wishlistButton.Location = new System.Drawing.Point(15, 14);
            this.wishlistButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(105, 39);
            this.wishlistButton.TabIndex = 23;
            this.wishlistButton.Text = "Wishlist";
            this.wishlistButton.UseVisualStyleBackColor = false;
            this.wishlistButton.Click += new System.EventHandler(this.wishlistButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.BackgroundImage = global::StreamSpotter.Properties.Resources.Logo;
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPictureBox.Location = new System.Drawing.Point(320, -26);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(240, 222);
            this.logoPictureBox.TabIndex = 26;
            this.logoPictureBox.TabStop = false;
            // 
            // recommendedPanel
            // 
            this.recommendedPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.recommendedPanel.Controls.Add(this.hScrollBar1);
            this.recommendedPanel.Controls.Add(this.label2);
            this.recommendedPanel.Controls.Add(this.label1);
            this.recommendedPanel.Location = new System.Drawing.Point(0, 400);
            this.recommendedPanel.Name = "recommendedPanel";
            this.recommendedPanel.Size = new System.Drawing.Size(900, 150);
            this.recommendedPanel.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "test1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(862, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(668, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "test 2 wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(0, 128);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(900, 21);
            this.hScrollBar1.TabIndex = 2;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.recommendedPanel);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.wishlistButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(927, 605);
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.ResizeEnd += new System.EventHandler(this.HomeScreen_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.recommendedPanel.ResumeLayout(false);
            this.recommendedPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel recommendedPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

