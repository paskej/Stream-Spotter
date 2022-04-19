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
            windowsController = WindowsController.getInstance();

            if (windowsController.profileController.GetProfile(0) == null)
			{
                windowsController.createProfileOnStartup();
			}
        }
        public HomeScreen(WindowsController windowsController)
        {
            InitializeComponent();
            this.windowsController = windowsController;
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

        private void wishlistButton_Click(object sender, EventArgs e)
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

        private void button1_MouseLeave(object sender, EventArgs e)
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
    }
}
