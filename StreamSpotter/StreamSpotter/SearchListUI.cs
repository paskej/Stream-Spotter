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
        //need to do show list upon start up somehow
        public SearchListUI()
        {
            InitializeComponent();
            movieList = new MovieList(listPanel, this);
            movieList.populateList();
            movieList.printList();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            WindowsController windowsController = new WindowsController();
            windowsController.openHomeScreen(this);
        }

        private void listPanel_Click(object sender, EventArgs e)
        {
            //once the list is set up adjust to click location stuff
            //this is a test for now
            WindowsController windowsController = new WindowsController();
            windowsController.openMovieScreen(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //delete this once the list works
            WindowsController windowsController = new WindowsController();
            windowsController.openMovieScreen(this);
        }
    }
}
