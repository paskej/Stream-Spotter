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
            windowsController.showSearchList(listPanel, this);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }
    }
}
