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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HomeButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listEmptyLabel = new System.Windows.Forms.Label();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(728, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 36);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "Filter";
            // 
            // HomeButton
            // 
            this.HomeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HomeButton.Location = new System.Drawing.Point(84, 10);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(79, 39);
            this.HomeButton.TabIndex = 28;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MenuButton.Location = new System.Drawing.Point(2, 10);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(76, 39);
            this.MenuButton.TabIndex = 27;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 60);
            this.panel1.TabIndex = 31;
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listPanel.Controls.Add(this.listEmptyLabel);
            this.listPanel.Location = new System.Drawing.Point(0, 100);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(850, 448);
            this.listPanel.TabIndex = 32;
            // 
            // listEmptyLabel
            // 
            this.listEmptyLabel.AutoSize = true;
            this.listEmptyLabel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmptyLabel.Location = new System.Drawing.Point(241, 188);
            this.listEmptyLabel.Name = "listEmptyLabel";
            this.listEmptyLabel.Size = new System.Drawing.Size(389, 39);
            this.listEmptyLabel.TabIndex = 5;
            this.listEmptyLabel.Text = "Nothing Is In Your Wishlist!";
            this.listEmptyLabel.Visible = false;
            // 
            // WishlistUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(850, 545);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listPanel);
            this.Name = "WishlistUI";
            this.Text = "WishlistUI";
            this.listPanel.ResumeLayout(false);
            this.listPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label listEmptyLabel;
    }
}