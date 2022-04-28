using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    public partial class WishlistUI : Form
    {
        private WindowsController windowsController;

        public WishlistUI(WindowsController windowsController)
        {
            InitializeComponent();
            this.windowsController = windowsController;
            if (!windowsController.showWishList(listPanel, this))
            {
                listPanel.Controls.Add(listEmptyLabel);
                listEmptyLabel.Visible = true;
            }
            //Location = new Point(0, 0);
            button3.Text = (string)windowsController.currentProfile.getProfileName();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            WindowsController winController = WindowsController.getInstance();
            winController.showProfileScreen(this);
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmptyLabel.Visible = false;
            if (comboBox2.SelectedIndex == 0)
            {
                if (!windowsController.unFilter())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                if (!windowsController.filterByService((string)comboBox2.SelectedItem))
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                if (!windowsController.filterByService((string)comboBox2.SelectedItem))
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmptyLabel.Visible = false;
            if (comboBox1.SelectedIndex == 0)
            {
                if (!windowsController.unFilter())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (!windowsController.filterByMovie())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (!windowsController.filterByShow())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                if (!windowsController.filterByRating())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (!windowsController.filterByNewest())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                if (!windowsController.filterByOldest())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                if (!windowsController.filterByShorter())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                if (!windowsController.filterByLonger())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
        }

        public void formatPage()
        {
            //
            //comboBox1 filter
            //
            comboBox1.Location = new Point((this.Width - comboBox1.Width - 15), (panel1.Height + 1));


            //
            //Button HomeButton
            //
            HomeButton.Location = new Point(5, 10);


            //
            //Panel panel1 top bar
            //
            panel1.Width = this.Width;


            //
            //Panel listPanel
            //
            listPanel.Location = new Point(0, 81);
            listPanel.Width = this.Width;
            listPanel.Height = this.Height - listPanel.Location.Y - 35;


            //
            //Label listEmptyLabel
            //
            listEmptyLabel.Location = new Point((int)((listPanel.Width / 2) - (listEmptyLabel.Width / 2)), (int)((listPanel.Height / 2) - (listEmptyLabel.Height / 2)) - 40);


            //
            //Button button1 menu
            //


            //
            //Panel profilePanel
            //


            //
            //Button button3 profile
            //
            button3.Location = new Point((this.Width - button3.Width - 5 - 15),(10));


            //
            //ComboBox comboBox2 service
            //
            comboBox2.Location = new Point((this.Width - comboBox1.Width - comboBox2.Width - 15), (panel1.Height + 1));

        }

        private void WishlistUI_Load(object sender, EventArgs e)
        {
            formatPage();
        }

        private void WishlistUI_ResizeEnd(object sender, EventArgs e)
        {
            formatPage();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listEmptyLabel.Visible = false;
            if (comboBox1.SelectedIndex == 0)
            {
                if (!windowsController.unFilter())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (!windowsController.filterByMovie())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                if (!windowsController.filterByShow())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                if (!windowsController.filterByRating())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                if (!windowsController.filterByNewest())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                if (!windowsController.filterByOldest())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                if (!windowsController.filterByShorter())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                if (!windowsController.filterByLonger())
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
        }

        private void WishlistUI_Resize(object sender, EventArgs e)
        {
            formatPage();
        }
    }
}
