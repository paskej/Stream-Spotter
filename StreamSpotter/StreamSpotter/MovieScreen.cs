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
    public partial class MovieScreen : Form
    {
        private Movie movie;
        public MovieScreen()//Movie movie)
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            WindowsController windowsController = new WindowsController();
            windowsController.openHomeScreen(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsController windowsController = new WindowsController();
            windowsController.openSearchListUI(this);
        }
    }
}
