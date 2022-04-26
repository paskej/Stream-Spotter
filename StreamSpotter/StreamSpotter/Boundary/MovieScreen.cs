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
        private static int BUTTON_CHANGE = 30;
        public MovieScreen(Result movie, WindowsController windowsController, bool inWishlist)
        {
            this.movie = movie;
            this.windowsController = windowsController;
            this.inWishlist = inWishlist;
            InitializeComponent();
            titleBox.Text = movie.title;
            overviewLabel.Text = movie.overview;
            ratingLabel.Text = "IMDb Rating: " + (float)movie.imdbRating/10 + " / 10";

            if (movie.streamingInfo.netflix == null)
            {
                pictureBox4.Visible = false;
                pictureBox2.Location = new Point(203, 292);
            }
            if (movie.streamingInfo.disney == null)
            {
                pictureBox2.Visible = false;
            }
            if(inWishlist)
            {
                button3.Width = button3.Width + BUTTON_CHANGE;
                button3.Text = "Remove from Wishlist";
            }
            if (movie.posterURLs.original != null)
            {
                pictureBox1.ImageLocation = movie.posterURLs.original;
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            windowsController.openHomeScreen(this);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            windowsController.goBack(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inWishlist)
            {
                windowsController.removeMovieFromWishlist(movie);
                windowsController.wishlistChanged = true;
                button3.Width = button3.Width - BUTTON_CHANGE;
                button3.Text = "Add to Wishlist";
                inWishlist = false;
            }
            else
            {
                windowsController.addMovieToWishlist(movie);
                windowsController.wishlistChanged = true;
                button3.Width = button3.Width + BUTTON_CHANGE;
                button3.Text = "Remove from Wishlist";
                inWishlist = true;
            }
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

        private void pictureBox4_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (movie.streamingInfo.netflix == null)
            {
                pictureBox4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movie.streamingInfo.disney != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.disney.us.link);
            }
            else if (movie.streamingInfo.netflix != null)
            {
                System.Diagnostics.Process.Start(movie.streamingInfo.netflix.us.link);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            windowsController.showProfileScreen(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            windowsController.openWishListUI(this);
        }

        private void MovieScreen_ResizeEnd(object sender, EventArgs e)
        {
            //pictureBox1.Height = (int)((this.Height - pictureBox1.Location.Y) * 0.7);
            formatPage();


            
        }

        private void MovieScreen_Load(object sender, EventArgs e)
        {
            pictureBox5.ImageLocation = movie.backdropURLs.original;

            formatPage();
            




            //pictureBox5.Height = this.Height;
            //pictureBox5.Width = this.Width;


            //titleLabel.Parent = pictureBox5;
            //titleLabel.BackColor = Color.Transparent;

            //ratingLabel.Parent = pictureBox5;
            //ratingLabel.BackColor = Color.Transparent;

            //playButton.Parent = pictureBox5;
            //playButton.BackColor = Color.Transparent;

            //button3.Parent = pictureBox5;
            //button3.BackColor = Color.Transparent;

            //pictureBox1.Parent = pictureBox5;

            //pictureBox1.Location = new Point(0,0);
        }

        //
        //calculating placements and sizes
        //
        private void formatPage()
        {
            //title
            string titleLength = titleBox.Text;
            titleBox.Width = (int)(this.Width * 6 / 16);
            titleBox.Height = 60;
            if(titleLength.Length > 13)
            {
                titleBox.Height = 120;
            }
            int titleHeight = titleBox.Height;
            titleBox.Location = new Point((int)(this.Width * 3 / 32), (25));


            //discription
            string discriptionLength = overviewLabel.Text;
            int numOfRows = discriptionLength.Length / 60;
            int discriptionHeight = numOfRows * 16 + 8;
            overviewLabel.Width = (int)(this.Width * 6 / 16);
            overviewLabel.Height = discriptionHeight;
            overviewLabel.Location = new Point((int)(this.Width * 3 / 32), (30 + titleHeight));


            //rating
            ratingLabel.Width = (int)(this.Width * 6 / 16);
            ratingLabel.Location = new Point((int)(this.Width * 3 / 32), (40 + titleHeight + discriptionHeight));


            //play button
            playButton.Width = (int)(this.Width * 5.5 / 32);
            playButton.Location = new Point((int)(this.Width * 3 / 32), (65 + titleHeight + discriptionHeight));


            //wishlist button
            button3.Width = (int)(this.Width * 5.5 / 32);
            button3.Location = new Point((int)(this.Width * 9 / 32), (65 + titleHeight + discriptionHeight));


            //netflix icon
            int iconHeight = (int)(this.Width * 1 / 32);
            pictureBox4.Height = iconHeight;
            pictureBox4.Width = iconHeight;
            pictureBox4.Location = new Point((this.Width * 3 / 32), (95 + titleHeight + discriptionHeight));


            //disney icon
            pictureBox2.Height = iconHeight;
            pictureBox2.Width = iconHeight;
            if(movie.streamingInfo.netflix == null)
            {
                pictureBox2.Location = new Point((this.Width * 3 / 32), (95 + titleHeight + discriptionHeight));
            }
            else
            {
                pictureBox2.Location = new Point((this.Width * 5 / 32), (95 + titleHeight + discriptionHeight));
            }

            //scroll bar
            vScrollBar1.Width = 20;
            vScrollBar1.Height = this.Height - pictureBox3.Height;
            vScrollBar1.Location = new Point(this.Width - (int)(vScrollBar1.Width * 1.5) - 5, pictureBox3.Location.Y + pictureBox3.Height);


            //top bar
            pictureBox3.Width = this.Width + 20;


            //information panel
            infoPanel.Width = this.Width * 8 / 16;
            infoPanel.Height = 110 + titleHeight + discriptionHeight + iconHeight;
            infoPanel.Location = new Point((int)(this.Width * 4 / 16), (100) - vScrollBar1.Value * 3);


            //poster
            pictureBox1.Width = (int)(this.Width * 4 / 16);
            pictureBox1.Height = (int)(pictureBox1.Width * 1.5);
            pictureBox1.Location = new Point((int)(this.Width * 1 / 16), (int)(infoPanel.Location.Y + 50));


            //background picture
            pictureBox5.Height = this.Height;
            pictureBox5.Width = this.Width;
            pictureBox5.Location = new Point(-8, 42 - (int)(vScrollBar1.Value / 4));

            //home button
            HomeButton.Location = new Point(36, 7);

            //
            //Button wishlistButton;
            //
            wishlistButton.Location = new Point((this.Width - ProfileButton.Width - 102), (7));


            //
            //Button ProfileButton;
            //
            ProfileButton.Location = new Point((this.Width - ProfileButton.Width - 5 - 15), (7));
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            formatPage();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            formatPage();
        }

        private void MovieScreen_SizeChanged(object sender, EventArgs e)
        {
            formatPage();
        }
    }
}
