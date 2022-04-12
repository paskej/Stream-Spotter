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
    public partial class SearchListUI : Form
    {
        //private MovieList movieList;
        private WindowsController windowsController;

        //need to do show list upon start up somehow
        public SearchListUI(WindowsController windowsController)
        {
            InitializeComponent();
            this.windowsController = windowsController;
            if (!windowsController.showSearchList(listPanel, this))
            {
                listPanel.Controls.Add(listEmptyLabel);
                listEmptyLabel.Visible = true;
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }

        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (SearchBar.TextLength == 0)
                    MessageBox.Show("Please enter a search!");
                else
                {
                    //search with the api
                    //then we load the searhlistUI
                    windowsController = new WindowsController();
                    windowsController.openSearchListUI(this, SearchBar.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profilePanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }

        private void profilePanel_MouseLeave(object sender, EventArgs e)
        {
            Point formPoint = this.Location;
            int mousePositionX = Control.MousePosition.X - formPoint.X - profilePanel.AutoScrollPosition.X;
            int mousePositionY = Control.MousePosition.Y - formPoint.Y - profilePanel.AutoScrollPosition.Y;// - 100;
            if (mousePositionX < profilePanel.Location.X || mousePositionY < profilePanel.Location.Y ||
                mousePositionX > (profilePanel.Location.X + profilePanel.Width) || mousePositionY > (profilePanel.Location.Y + profilePanel.Height))
            {
                profilePanel.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            profilePanel.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowsController winController = new WindowsController();
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
                if(!windowsController.filterByService((string)comboBox2.SelectedItem))
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
    }
}
