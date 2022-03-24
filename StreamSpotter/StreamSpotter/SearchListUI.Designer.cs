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
            this.MenuButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.listPanel = new System.Windows.Forms.Panel();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.listEmptyLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.profilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuButton
            // 
            this.MenuButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MenuButton.Location = new System.Drawing.Point(2, 10);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(76, 39);
            this.MenuButton.TabIndex = 20;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            // 
            // HomeButton
            // 
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(84, 10);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(79, 39);
            this.HomeButton.TabIndex = 21;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // profileButton
            // 
            this.profileButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.profileButton.Location = new System.Drawing.Point(747, 10);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(91, 39);
            this.profileButton.TabIndex = 22;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(728, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 36);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.Text = "Filter";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.SearchBar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 60);
            this.panel1.TabIndex = 25;
            // 
            // SearchBar
            // 
            this.SearchBar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar.Location = new System.Drawing.Point(275, 12);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(278, 35);
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
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(850, 448);
            this.listPanel.TabIndex = 26;
            // 
            // profilePanel
            // 
            this.profilePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.profilePanel.Controls.Add(this.wishlistButton);
            this.profilePanel.Location = new System.Drawing.Point(739, 60);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(111, 46);
            this.profilePanel.TabIndex = 27;
            this.profilePanel.Visible = false;
            this.profilePanel.MouseLeave += new System.EventHandler(this.profilePanel_MouseLeave);
            // 
            // wishlistButton
            // 
            this.wishlistButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wishlistButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wishlistButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.wishlistButton.Location = new System.Drawing.Point(2, 4);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(105, 39);
            this.wishlistButton.TabIndex = 23;
            this.wishlistButton.Text = "Wishlist";
            this.wishlistButton.UseVisualStyleBackColor = false;
            this.wishlistButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // listEmptyLabel
            // 
            this.listEmptyLabel.AutoSize = true;
            this.listEmptyLabel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmptyLabel.Location = new System.Drawing.Point(209, 188);
            this.listEmptyLabel.Name = "listEmptyLabel";
            this.listEmptyLabel.Size = new System.Drawing.Size(417, 39);
            this.listEmptyLabel.TabIndex = 4;
            this.listEmptyLabel.Text = "Nothing Matched Your Search!";
            this.listEmptyLabel.Visible = false;
            // 
            // SearchListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(850, 548);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.comboBox1);
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

        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Panel profilePanel;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Label listEmptyLabel;
    }
}