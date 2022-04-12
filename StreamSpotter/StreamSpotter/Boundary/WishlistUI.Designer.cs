namespace StreamSpotter
{
    partial class WishlistUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WishlistUI));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HomeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listEmptyLabel = new System.Windows.Forms.Label();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.profilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(None)"});
            this.comboBox1.Location = new System.Drawing.Point(1456, 120);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 64);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "Filter";
            // 
            // HomeButton
            // 
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(234, 23);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(158, 76);
            this.HomeButton.TabIndex = 28;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.HomeButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1700, 116);
            this.panel1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(12, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 76);
            this.button1.TabIndex = 31;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listPanel.Controls.Add(this.listEmptyLabel);
            this.listPanel.Location = new System.Drawing.Point(0, 194);
            this.listPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(1700, 868);
            this.listPanel.TabIndex = 32;
            // 
            // listEmptyLabel
            // 
            this.listEmptyLabel.AutoSize = true;
            this.listEmptyLabel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmptyLabel.Location = new System.Drawing.Point(468, 372);
            this.listEmptyLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.listEmptyLabel.Name = "listEmptyLabel";
            this.listEmptyLabel.Size = new System.Drawing.Size(763, 77);
            this.listEmptyLabel.TabIndex = 5;
            this.listEmptyLabel.Text = "Nothing Is In Your Wishlist!";
            this.listEmptyLabel.Visible = false;
            // 
            // profilePanel
            // 
            this.profilePanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.profilePanel.Controls.Add(this.button3);
            this.profilePanel.Location = new System.Drawing.Point(8, 116);
            this.profilePanel.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(222, 95);
            this.profilePanel.TabIndex = 33;
            this.profilePanel.Visible = false;
            this.profilePanel.MouseLeave += new System.EventHandler(this.profilePanel_MouseLeave);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(6, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 76);
            this.button3.TabIndex = 4;
            this.button3.Text = "Profile";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "(All Services)",
            "Netflix",
            "Disney+"});
            this.comboBox2.Location = new System.Drawing.Point(1154, 120);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(284, 64);
            this.comboBox2.TabIndex = 34;
            this.comboBox2.Text = "Service";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // WishlistUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1700, 1056);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "WishlistUI";
            this.Text = "WishlistUI";
            this.panel1.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label listEmptyLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel profilePanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}