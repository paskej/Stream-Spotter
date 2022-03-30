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
                listEmptyLabel.Visible = true;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
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
            WindowsController winController = new WindowsController();
            winController.showProfileScreen(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profilePanel.Visible = true;
        }
    }
}
