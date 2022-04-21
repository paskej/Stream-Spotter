﻿namespace StreamSpotter
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
            this.ProfileButton = new System.Windows.Forms.Button();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listEmptyLabel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.redoButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomeButton
            // 
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(121, 9);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.panel1.Controls.Add(this.ProfileButton);
            this.panel1.Controls.Add(this.wishlistButton);
            this.panel1.Controls.Add(this.HomeButton);
            this.panel1.Controls.Add(this.SearchBar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 60);
            this.panel1.TabIndex = 25;
            // 
            // ProfileButton
            // 
            this.ProfileButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ProfileButton.Location = new System.Drawing.Point(729, 9);
            this.ProfileButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(105, 39);
            this.ProfileButton.TabIndex = 4;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // wishlistButton
            // 
            this.wishlistButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wishlistButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wishlistButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.wishlistButton.Location = new System.Drawing.Point(8, 9);
            this.wishlistButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(105, 39);
            this.wishlistButton.TabIndex = 23;
            this.wishlistButton.Text = "Wishlist";
            this.wishlistButton.UseVisualStyleBackColor = false;
            this.wishlistButton.Click += new System.EventHandler(this.button1_Click_1);
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
            this.comboBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(144, 36);
            this.comboBox2.TabIndex = 32;
            this.comboBox2.Text = "Service";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // redoButton
            // 
            this.redoButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redoButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.redoButton.Location = new System.Drawing.Point(76, 64);
            this.redoButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(65, 32);
            this.redoButton.TabIndex = 34;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undoButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.undoButton.Location = new System.Drawing.Point(8, 64);
            this.undoButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(66, 32);
            this.undoButton.TabIndex = 35;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // SearchListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(909, 558);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.redoButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(927, 605);
            this.Name = "SearchListUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SearchListUI";
            this.Load += new System.EventHandler(this.SearchListUI_Load);
            this.ResizeEnd += new System.EventHandler(this.SearchListUI_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
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
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.Button undoButton;
    }
}