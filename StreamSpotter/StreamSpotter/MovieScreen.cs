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
        private bool inWishlist;
        public MovieScreen(Result movie, WindowsController windowsController, bool inWishlist)
        {
            InitializeComponent();
            this.movie = movie;
            this.windowsController = windowsController;
            this.inWishlist = inWishlist;
            titleLabel.Text = movie.title;
            overviewLabel.Text = movie.overview;
            ratingLabel.Text = "IMDb Rating: " + (float)movie.imdbRating/10 + " / 10";
            if(inWishlist)
            {
                button3.Text = "Remove from Wishlist";
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            windowsController.goBackToSearchListUI(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inWishlist)
            {
                windowsController.removeMovieFromWishlist(movie);
                button3.Text = "Add to Wishlist";
                inWishlist = false;
            }
            else
            {
                windowsController.addMovieToWishlist(movie);
                button3.Text = "Remove from Wishlist";
                inWishlist = true;
            }
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

        private void profileButton_Click(object sender, EventArgs e)
        {
            profilePanel.Visible = true;
        }

        private void wishlistButton_Click(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
		}

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (movie.streamingInfo.netflix != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.netflix.us.link);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (movie.streamingInfo.disney != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.disney.us.link);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(movie.);
        }
    }
}
