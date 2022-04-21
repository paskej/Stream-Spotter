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
            InitializeComponent();
            windowsController = new WindowsController();

            if(windowsController.profileController.GetProfile(0) == null)
			{
                windowsController.createProfileOnStartup();
			}
        }
        public HomeScreen(WindowsController windowsController)
        {
            InitializeComponent();
            this.windowsController = windowsController;
            recommendedPanel.AutoScroll = true;
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            WindowsController winController = new WindowsController();
            winController.showProfileScreen();
            winController.profileScreen.updateCheckedBoxes();
        }

        private void SearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //probably should move to a windows controller
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

        private void wishlistButton_Click(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }

        public void formatPage()
        {
            //
            //Profile Button
            //
            ProfileButton.Location = new Point((this.Width - ProfileButton.Width - 5 - 15), (10));


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
        }

        private void HomeScreen_ResizeEnd(object sender, EventArgs e)
        {
            formatPage();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            formatPage();
        }
    }
}
