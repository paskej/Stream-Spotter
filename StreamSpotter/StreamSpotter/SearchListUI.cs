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
        MovieList movieList;
        WindowsController windowsController;
        //need to do show list upon start up somehow
        public SearchListUI()
        {
            InitializeComponent();
            windowsController = new WindowsController();
            windowsController.showMovieList(listPanel, this);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }
    }
}
