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
    public partial class HomeScreen : Form
    {
        private WindowsController windowsController;
        private Result[] recommendations;
        public HomeScreen()
        {
            windowsController = WindowsController.getInstance();
           
            
            if (windowsController.profileController.GetProfile(0) == null)
			{
                string[] tempServices = new string[2] { "netflix", "disney" };
                windowsController.currentProfile = new Profile("Profile", tempServices, -1);
                
			}
            
            InitializeComponent();
            NoProfileLabel.Visible = false;
            windowsController.showRecommendedList(recommendedPanel, this);
            formatPage();

        }
        public HomeScreen(WindowsController windowsController)
        {
            InitializeComponent();
            NoProfileLabel.Visible = false;
            this.windowsController = WindowsController.getInstance();
            recommendedPanel.AutoScroll = true;
            ProfileButton.Text = (string)windowsController.currentProfile.getProfileName();
        }

        public void showList()
        {
            if (windowsController.wishlistChanged == true)
            {
                windowsController.updateRecommendations();
                windowsController.wishlistChanged = false;
            }
            windowsController.showRecommendedList(recommendedPanel, this);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {

            WindowsController winController = WindowsController.getInstance();
            winController.showProfileScreen(this);
            winController.profileScreen.updateCheckedBoxes();
        }

        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //probably should move to a windows controller
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (windowsController.currentProfile.getID() == -1)
                {
                    NoProfileLabel.Visible = true;
                }
                else
                {
                    if (SearchBar.TextLength == 0)
                        MessageBox.Show("Please enter a search!");
                    else
                    {
                        //search with the api
                        //then we load the searhlistUI
                        windowsController = WindowsController.getInstance();
                        windowsController.openSearchListUI(this, SearchBar.Text);
                    }
                }
            }
        }

        private void wishlistButton_Click(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }

        public void checkForProfile()
		{
            if(windowsController.currentProfile.id == -1)
			{
                wishlistButton.Enabled = false;
			}
            else
			{
                wishlistButton.Enabled = true;
			}
		}
        public void formatPage()
        {

            checkForProfile();
            //
            //Profile Button
            //
            ProfileButton.Location = new Point((this.Width - ProfileButton.Width - 5 - 15), (10));
            ProfileButton.Text = windowsController.currentProfile.profileName;

            //
            //wishlist button
            //
            wishlistButton.Location = new Point(5, 10);


            //
            //logoPictureBox
            //
            logoPictureBox.Height = (int)(this.Height / 2.5);
            logoPictureBox.Width = logoPictureBox.Height;
            logoPictureBox.Location = new Point((this.Width / 2) - (logoPictureBox.Width / 2), -10);


            //
            //label3
            //
            label3.Location = new Point((this.Width / 2) - (label3.Width / 2), (this.Height / 2) - 20);


            //
            //searchBar
            //
            SearchBar.Location = new Point((this.Width / 2) - (SearchBar.Width / 2), (this.Height / 2) + 20);


            //
            //recommendedPanel
            //
            recommendedPanel.Location = new Point(0, (this.Height / 2) + 75);
            recommendedPanel.Width = this.Width - 15;
            recommendedPanel.Height = this.Height - recommendedPanel.Location.Y - 40;//change back to 28


            //
            //recommended scrollbar
            //
            hScrollBar1.Location = new Point(0, recommendedPanel.Height - 10);
            hScrollBar1.Height = 10;
            hScrollBar1.Width = recommendedPanel.Width;


            //
            //label4 recommended
            //
            label4.Location = new Point(10, (this.Height / 2) + 50);

            //
            //NoProfileLabel
            //
            NoProfileLabel.Location = new Point(this.Width / 2 - NoProfileLabel.Width / 2, SearchBar.Location.Y + SearchBar.Height);
        }

        private void HomeScreen_ResizeEnd(object sender, EventArgs e)
        {
            formatPage();
            windowsController.showRecommendedList(recommendedPanel, this);
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            formatPage();
            windowsController.showRecommendedList(recommendedPanel, this);
        }

        private void HomeScreen_Resize(object sender, EventArgs e)
        {
            formatPage();
            windowsController.showRecommendedList(recommendedPanel, this);
        }
    }
}
