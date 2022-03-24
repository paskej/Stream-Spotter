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
        private WindowsController windowsController;
        public MovieScreen(Result movie, WindowsController windowsController)
        {
            InitializeComponent();
            this.movie = movie;
            this.windowsController = windowsController;
            titleLabel.Text = movie.title;
            overviewLabel.Text = movie.overview;
            ratingLabel.Text = "IMDb Rating: " + movie.imdbRating + " / 10";
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            windowsController.goBackToSearchListUI(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(movie.streamingInfo.netflix != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.netflix.us.link);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(movie.streamingInfo.disney != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.disney.us.link);
            }
        }
    }
}
