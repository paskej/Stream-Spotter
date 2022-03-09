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
        private Result movie;
        public MovieScreen(Result movie)
        {
            InitializeComponent();
            this.movie = movie;
            titleLabel.Text = movie.title;
            overviewLabel.Text = movie.overview;
            ratingLabel.Text = "IMDb Rating: " + movie.imdbRating + " / 10";
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

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
