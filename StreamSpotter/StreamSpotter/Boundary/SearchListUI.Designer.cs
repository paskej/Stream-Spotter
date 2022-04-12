namespace StreamSpotter
{
    partial class SearchListUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchListUI));
            this.HomeButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuButton = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listEmptyLabel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.profilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomeButton
            // 
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(124, 12);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(79, 39);
            this.HomeButton.TabIndex = 21;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(None)",
            "Movies Only",
            "Shows Only",
            "Highest Rating",
            "Newest First",
            "Oldest First",
            "Shortest First",
            "Longest First"});
            this.comboBox1.Location = new System.Drawing.Point(708, 62);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 36);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.Text = "Filter";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.menuButton);
            this.panel1.Controls.Add(this.HomeButton);
            this.panel1.Controls.Add(this.SearchBar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 60);
            this.panel1.TabIndex = 25;
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.menuButton.Location = new System.Drawing.Point(12, 12);
            this.menuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(105, 39);
            this.menuButton.TabIndex = 30;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar.Location = new System.Drawing.Point(275, 12);
            this.SearchBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(279, 35);
            this.SearchBar.TabIndex = 27;
            this.SearchBar.Text = "Search";
            this.SearchBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBar_KeyPress);
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listPanel.Controls.Add(this.listEmptyLabel);
            this.listPanel.Location = new System.Drawing.Point(0, 100);
            this.listPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(851, 448);
            this.listPanel.TabIndex = 26;
            // 
            // listEmptyLabel
            // 
            this.listEmptyLabel.AutoSize = true;
            this.listEmptyLabel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmptyLabel.Location = new System.Drawing.Point(195, 203);
            this.listEmptyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listEmptyLabel.Name = "listEmptyLabel";
            this.listEmptyLabel.Size = new System.Drawing.Size(417, 39);
            this.listEmptyLabel.TabIndex = 4;
            this.listEmptyLabel.Text = "Nothing Matched Your Search!";
            this.listEmptyLabel.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "(All Services)",
            "Netflix",
            "Disney+"});
            this.comboBox2.Location = new System.Drawing.Point(560, 62);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(144, 36);
            this.comboBox2.TabIndex = 32;
            this.comboBox2.Text = "Service";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // profilePanel
            // 
            this.profilePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.profilePanel.Controls.Add(this.wishlistButton);
            this.profilePanel.Controls.Add(this.ProfileButton);
            this.profilePanel.Location = new System.Drawing.Point(8, 60);
            this.profilePanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(113, 105);
            this.profilePanel.TabIndex = 33;
            this.profilePanel.Visible = false;
            this.profilePanel.MouseLeave += new System.EventHandler(this.profilePanel_MouseLeave);
            // 
            // wishlistButton
            // 
            this.wishlistButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wishlistButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wishlistButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.wishlistButton.Location = new System.Drawing.Point(4, 54);
            this.wishlistButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(105, 48);
            this.wishlistButton.TabIndex = 23;
            this.wishlistButton.Text = "Wishlist";
            this.wishlistButton.UseVisualStyleBackColor = false;
            this.wishlistButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ProfileButton
            // 
            this.ProfileButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ProfileButton.Location = new System.Drawing.Point(4, 2);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(105, 48);
            this.ProfileButton.TabIndex = 4;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // SearchListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(851, 545);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SearchListUI";
            this.Text = "SearchListUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Label listEmptyLabel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Panel profilePanel;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Button ProfileButton;
    }
}