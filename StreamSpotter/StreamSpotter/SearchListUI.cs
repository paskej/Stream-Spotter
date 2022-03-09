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
            windowsController.showMovieList(listPanel, this);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }
    }
}
