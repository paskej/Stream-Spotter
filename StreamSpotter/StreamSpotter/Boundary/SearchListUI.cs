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
     * SearchListUI displays the list of results that the user had entered and allows the user to edit the list
     *******************************************************************************************************/
    public partial class SearchListUI : Form
    {
        //private MovieList movieList;
        private WindowsController windowsController;
        private Handler handler;

        /*******************************************************************************************************
         * Constructor to initialize the objects
         * PARAMS: WindowsController windowsController
         *******************************************************************************************************/
        //need to do show list upon start up somehow
        public SearchListUI(WindowsController windowsController)
        {
            
            this.windowsController = WindowsController.getInstance();
            InitializeComponent();

            listPanel.Controls.Add(loadingLabel);
            loadingLabel.Visible = true;

            ProfileButton.Text = (string)windowsController.currentProfile.getProfileName();
        }
        /*******************************************************************************************************
        * Method to show the list of search results
        *******************************************************************************************************/
        public void showList()
        {
            if (!windowsController.showSearchList(listPanel, this))
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
        * Method to search for new movies and shows based off search
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (SearchBar.TextLength == 0)
                    MessageBox.Show("Please enter a search!");
                else
                {
                    windowsController.setPrevSearch(windowsController.getCurrSearch());
                    //search with the api
                    //then we load the searhlistUI
                    windowsController = WindowsController.getInstance();
                    windowsController.openSearchListUI(this, SearchBar.Text);
                }
            }
        }

        /*******************************************************************************************************
        * Method to pop up the users wishlist
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void button2_Click(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }
        /*******************************************************************************************************
        * Method to pop up the users wishlist
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void button1_Click_1(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }
        /*******************************************************************************************************
        * Method to pop up the profile screen
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void button2_Click_1(object sender, EventArgs e)
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
                if(!windowsController.filterByService((string)comboBox2.SelectedItem))
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
            //Button HomeButton;
            //
            HomeButton.Location = new Point(36, 10);


            //
            //ComboBox comboBox1;
            //
            comboBox1.Location = new Point((this.Width - comboBox1.Width - 15), (panel1.Height + 1));


            //
            //Panel panel1;
            //
            panel1.Width = this.Width;


            //
            //Panel listPanel;
            //
            listPanel.Location = new Point(0, 81);
            listPanel.Width = this.Width;
            listPanel.Height = this.Height - listPanel.Location.Y - 35;


            //
            //TextBox SearchBar;
            //
            SearchBar.Width = (int)(this.Width / 3);
            if(SearchBar.Width > 400)
            {
                SearchBar.Width = 400;
            }
            SearchBar.Location = new Point((int)((this.Width / 2) - (SearchBar.Width / 2)), 10);


            //
            //Label listEmptyLabel;
            //
            listEmptyLabel.Location = new Point((int)((listPanel.Width / 2) - (listEmptyLabel.Width / 2)), (int)((listPanel.Height / 2) - (listEmptyLabel.Height / 2)) - 40);


            //
            //label loadingLabel
            //
            loadingLabel.Location = new Point((int)((listPanel.Width / 2) - (loadingLabel.Width / 2)), (int)((listPanel.Height / 2) - (loadingLabel.Height / 2)) - 40);


            //
            //ComboBox comboBox2;
            //
            comboBox2.Location = new Point((this.Width - comboBox1.Width - comboBox2.Width - 15), (panel1.Height + 1));


            //
            //Button menuButton;
            //


            //
            //Panel profilePanel;
            //


            //
            //Button wishlistButton;
            //
            wishlistButton.Location = new Point((this.Width - ProfileButton.Width - 110), (10));


            //
            //Button ProfileButton;
            //
            ProfileButton.Location = new Point((this.Width - ProfileButton.Width - 5 - 15), (10));
            ProfileButton.Text = windowsController.currentProfile.profileName;

            //
            //Button ProfileButton;
            //


            //
            //Button ProfileButton;
            //

        }
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void SearchListUI_Load(object sender, EventArgs e)
        {
            formatPage();
        }
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void SearchListUI_ResizeEnd(object sender, EventArgs e)
        {
            formatPage();
        }
        /*******************************************************************************************************
        * Method to go back a previous search
        *******************************************************************************************************/
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(windowsController.peekPrevSearch() != null)
            {
                windowsController.openSearchListUI(this, windowsController.getPrevSearch());
            }
        }
        /*******************************************************************************************************
        * Method to format the current screen when resized
        * PARAMS: object sender, EventArgs e
        *******************************************************************************************************/
        private void SearchListUI_Resize(object sender, EventArgs e)
        {
            formatPage();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*******************************************************************************************************
         * Method to close the form
         * PARAMS: object sender, EventArgs e
         *******************************************************************************************************/
        private void SearchListUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        /*******************************************************************************************************
         * Method to close the form
         * PARAMS: object sender, EventArgs e
         *******************************************************************************************************/
        private void SearchListUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
