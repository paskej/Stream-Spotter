//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
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
    /*******************************************************************************************************
     * WishListUI displays the list of movies and shows in the users wislist
     *******************************************************************************************************/
    public partial class WishlistUI : Form
    {
        private WindowsController windowsController;
        /*******************************************************************************************************
         * Constructor to initialize the objects
         *******************************************************************************************************/
        public WishlistUI()
        {
            this.windowsController = WindowsController.getInstance();
            InitializeComponent();

            listPanel.Controls.Add(loadingLabel);
            loadingLabel.Visible = true;

            button3.Text = (string)windowsController.currentProfile.getProfileName();
        }
        /*******************************************************************************************************
        * Method to show the list of search results
        *******************************************************************************************************/
        public void showList()
        {
            if (!windowsController.showWishList(listPanel, this))
            {
                loadingLabel.Visible = false;
                listPanel.Controls.Add(listEmptyLabel);
                listEmptyLabel.Visible = true;
            }
            else
            {
                loadingLabel.Visible = false;
            }
        }
        /*******************************************************************************************************
        * Method to pop up the home screen
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }

        /*******************************************************************************************************
        * Method to pop up the profile screen
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void button3_Click(object sender, EventArgs e)
        {
            WindowsController winController = WindowsController.getInstance();
            winController.showProfileScreen(this);
        }

        /*******************************************************************************************************
        * Method to filter by the type of specified service
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
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
            else if (comboBox2.SelectedIndex == 3)
            {
                if (!windowsController.filterByService((string)comboBox2.SelectedItem))
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                if (!windowsController.filterByService((string)comboBox2.SelectedItem))
                {
                    listPanel.Controls.Add(listEmptyLabel);
                    listEmptyLabel.Visible = true;
                }
            }
        }

        /*******************************************************************************************************
        * Method to filter by what was selected in the filter textbox
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
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
        /*******************************************************************************************************
        * Method to format the current screen when resized
        *******************************************************************************************************/
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
            //label loadingLabel
            //
            loadingLabel.Location = new Point((int)((listPanel.Width / 2) - (loadingLabel.Width / 2)), (int)((listPanel.Height / 2) - (loadingLabel.Height / 2)) - 40);

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
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void WishlistUI_Load(object sender, EventArgs e)
        {
            formatPage();
        }
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void WishlistUI_ResizeEnd(object sender, EventArgs e)
        {
            formatPage();
        }
        /*******************************************************************************************************
        * Method to filter by what was selected in the filter textbox
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
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
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void WishlistUI_Resize(object sender, EventArgs e)
        {
            formatPage();
        }
        /*******************************************************************************************************
         * Method to close the form
         * PARAMS: object sender, EventArgs e
         *******************************************************************************************************/
        private void WishlistUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /*******************************************************************************************************
         * Method to close the form
         * PARAMS: object sender, EventArgs e
         *******************************************************************************************************/
        private void WishlistUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
