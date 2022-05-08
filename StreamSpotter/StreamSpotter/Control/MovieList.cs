using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StreamSpotter
{
    public class MovieList
    {
        private const int BOX_HEIGHT = 160;
        private const int BOX_WIDTH = 80;

        private List<Result> movieList;
        private List<Result> filterList;
        Panel panel;
        Form form;
        WindowsController windowsController;
        WishlistTracker wishlistTracker;

        public MovieList()
        {
            movieList = new List<Result>();
            filterList = new List<Result>();
            DatabaseAccess databaseAccess = new DatabaseAccess();
            wishlistTracker = new WishlistTracker();
            wishlistTracker.changeCurrentWishlist(0, "0");
        }
        public MovieList(Panel panel, Form form, WindowsController windowsController)
        {
            movieList = new List<Result>();
            filterList = new List<Result>();
            this.panel = panel;
            this.form = form;
            this.windowsController = windowsController;
            DatabaseAccess databaseAccess = new DatabaseAccess();
            wishlistTracker = new WishlistTracker();
            int id = windowsController.currentProfile.getID();
            wishlistTracker.changeCurrentWishlist(id, id.ToString());
        }

        //gather all information from json file to put into the movieList
        public bool populateSearchList(Result[] searchResults)//(string [,] searchResults)
        {
            movieList = new List<Result>();
            filterList = new List<Result>();

            for (int i = 0; i < searchResults.GetLength(0); i++)
            {
                movieList.Add(searchResults[i]);
                filterList.Add(searchResults[i]);
            }
            return movieList.Count != 0;
        }
        public bool populateWishlist()
        {
            movieList = new List<Result>();
            filterList = new List<Result>();

            Result[] list = wishlistTracker.getCurrentWishlist();
            bool works = true;
            if (list != null && list.Length != 0) 
            {
                for (int x = 0; x < list.Length; x++)
                {
                    movieList.Add(list[x]);
                    filterList.Add(list[x]);
                }
            }
            else
                works = false;
            return works;
        }

        public bool populateRecommendedList()
        {
            movieList = new List<Result>();

            Result[] list = windowsController.getRecommendations();


            bool works = true;
            if (list != null && list.Length != 0)
            {
                for (int x = 0; x < list.Length; x++)
                {
                    movieList.Add(list[x]);
                    filterList.Add(list[x]);
                }
            }
            else
                works = false;
            return works;
        }
        public Result getMovie(int index)
        {
            if (filterList != null && index < filterList.Count && index >= 0) 
                return filterList[index];
            return null;
        }
        /*******************************************************************************************************
         * Passes the getCurrentWishlist command to the WishlistTracker
         * RETURN: wishlist that was gathered from the WishlistTracker
         *******************************************************************************************************/
        public Result[] getWishlist()
        {
            return wishlistTracker.getCurrentWishlist();
        }
        /*******************************************************************************************************
         * Passes the addToCurrentWishlist command to WishlistTracker
         * PARAMS: Result result, the Result to be added to the current wishlist
         *******************************************************************************************************/
        public void addToWishlist(Result result)
        {
            wishlistTracker.addToCurrentWishlist(result);
        }
        /*******************************************************************************************************
         * Passes the removeFromCurrentWishlist command to the WishlistTracker
         * PARAMS: Result result, the Result to be removed from the current wishlist
         *******************************************************************************************************/
        public void removeFromWishlist(Result result)
        {
            wishlistTracker.removeFromCurrentWishlist(result.imdbID);
        }
        /*******************************************************************************************************
         * Passes the changeCurrentWishlist command to WishListTracker
         * PARAMS: int profileID, ID of the profile to change to
         *                 string listName, name of the wishlist to change to
         *******************************************************************************************************/
        public void changeCurrentWishlist(int profileID, string listName)
        {
            wishlistTracker.changeCurrentWishlist(profileID, listName);
        }
        /*******************************************************************************************************
         * Passes the updateRecommendations command to WishlistTracker
         * PARAMS: int profileID, ID of the profile to update recommendations for
         *******************************************************************************************************/
        public void updateRecommendations(int profileID)
        {
            wishlistTracker.updateRecommendations(profileID);
        }
        /*******************************************************************************************************
         * Passes the getRecommendations command to the WishlistTracker
         * PARAMS: int profileID, ID of the profile to retrieve stored recommendations for
         * RETURN: Array of Results gathered from the WishListTracker
         *******************************************************************************************************/
        public Result[] getRecommendations(int profileID)
        {
            return wishlistTracker.getRecommendations(profileID);
        }
        public bool filterByStreamingService(String service)
        {
            filterList = new List<Result>();
            for (int x = 0; x < movieList.Count; x++)
            {
                if (movieList[x].streamingInfo.disney != null && service.Equals("Disney+"))
                    filterList.Add(movieList[x]);
                else if (movieList[x].streamingInfo.netflix != null && service.Equals("Netflix"))
                    filterList.Add(movieList[x]);
                else if (movieList[x].streamingInfo.hulu != null && service.Equals("Hulu"))
                    filterList.Add(movieList[x]);
                else if (movieList[x].streamingInfo.prime != null && service.Equals("Prime"))
                    filterList.Add(movieList[x]);
            }
            return filterList.Count != 0;
        }
        public bool filterByMovie()
        {
            filterList = new List<Result>();
            for (int x = 0; x < movieList.Count; x++)
            {
                if (movieList[x].isMovie())
                    filterList.Add(movieList[x]);
            }
            return filterList.Count != 0;
        }

        public bool filterByShow()
        {
            filterList = new List<Result>();
            for (int x = 0; x < movieList.Count; x++)
            {
                if (!movieList[x].isMovie())
                    filterList.Add(movieList[x]);
            }
            return filterList.Count != 0;
        }

        public bool filterByRating()
        {
            filterList = new List<Result>();

            for (int x = 0; x < movieList.Count; x++)
            {
                filterList.Add(movieList[x]);
            }

            int n = filterList.Count;
            for (int i = 1; i < n; ++i)
            {
                Result key = filterList[i];
                int j = i - 1;

                while (j >= 0 && filterList[j].imdbRating < key.imdbRating)
                {
                    filterList[j + 1] = filterList[j];
                    j = j - 1;
                }
                filterList[j + 1] = key;
            }
            return filterList.Count != 0;
        }

        public bool filterByNewest()
        {
            filterList = new List<Result>();

            for (int x = 0; x < movieList.Count; x++)
            {
                filterList.Add(movieList[x]);
            }

            int n = filterList.Count;
            for (int i = 1; i < n; ++i)
            {
                Result key = filterList[i];
                int j = i - 1;

                while (j >= 0 && filterList[j].year < key.year)
                {
                    filterList[j + 1] = filterList[j];
                    j = j - 1;
                }
                filterList[j + 1] = key;
            }
            return filterList.Count != 0;
        }

        public bool filterByOldest()
        {
            filterList = new List<Result>();

            for (int x = 0; x < movieList.Count; x++)
            {
                filterList.Add(movieList[x]);
            }

            int n = filterList.Count;
            for (int i = 1; i < n; ++i)
            {
                Result key = filterList[i];
                int j = i - 1;

                while (j >= 0 && filterList[j].year > key.year)
                {
                    filterList[j + 1] = filterList[j];
                    j = j - 1;
                }
                filterList[j + 1] = key;
            }
            return filterList.Count != 0;
        }

        public bool filterByShorter()
        {
            filterList = new List<Result>();

            for (int x = 0; x < movieList.Count; x++)
            {
                filterList.Add(movieList[x]);
            }

            int n = filterList.Count;
            for (int i = 1; i < n; ++i)
            {
                Result key = filterList[i];
                int j = i - 1;

                while (j >= 0 && filterList[j].runtime > key.runtime)
                {
                    filterList[j + 1] = filterList[j];
                    j = j - 1;
                }
                filterList[j + 1] = key;
            }
            return filterList.Count != 0;
        }

        public bool filterByLonger()
        {
            filterList = new List<Result>();

            for (int x = 0; x < movieList.Count; x++)
            {
                filterList.Add(movieList[x]);
            }

            int n = filterList.Count;
            for (int i = 1; i < n; ++i)
            {
                Result key = filterList[i];
                int j = i - 1;

                while (j >= 0 && filterList[j].runtime < key.runtime)
                {
                    filterList[j + 1] = filterList[j];
                    j = j - 1;
                }
                filterList[j + 1] = key;
            }
            return filterList.Count != 0;
        }

        public bool noFilter()
        {
            filterList = new List<Result>();
            for (int x = 0; x < movieList.Count; x++) 
            {
                filterList.Add(movieList[x]);
            }
            return filterList.Count != 0;
        }
        public int getListSize()
        {
            return filterList.Count;
        }
        public void printList()
        {
            panel.MouseDown -= new System.Windows.Forms.MouseEventHandler(MovieSelect);
            panel.Controls.Clear();
            Point point;

            panel.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);

            //adds the list to the panel
            int num = 0;
            foreach (Result movie in filterList)
            {
                Label title = new Label();
                title.Text = movie.title;
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, num * BOX_HEIGHT + 10);
                title.Location = point;
                title.Width = 400;
                title.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                panel.Controls.Add(title);

                Label description = new Label();
                description.Text = movie.overview;
                description.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, num * BOX_HEIGHT + 40);
                description.Location = point;
                description.Size = new System.Drawing.Size(400, BOX_HEIGHT - 40);
                description.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                panel.Controls.Add(description);

                //Panel poster = new Panel();
                //poster.BackColor = System.Drawing.SystemColors.GrayText;
                //point = new Point(20, num * BOX_HEIGHT + 10);
                //poster.Location = point;
                //poster.Size = new System.Drawing.Size(100, BOX_HEIGHT - 20);
                //poster.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                //panel.Controls.Add(poster);

                PictureBox poster = new PictureBox();
                poster.BackColor = System.Drawing.SystemColors.GrayText;
                point = new Point(20, num * BOX_HEIGHT + 10);
                poster.Location = point;
                poster.Size = new System.Drawing.Size(100, BOX_HEIGHT - 20);
                poster.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                poster.ImageLocation = "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png";
                if(movie.posterURLs.original != null)
                {
                    poster.ImageLocation = movie.posterURLs.original;
                }
                poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(poster);

                num++;
            }
        }

        public void printRecommendedList()
        {
            panel.Controls.Clear();
            Point point;

            panel.MouseDown += new System.Windows.Forms.MouseEventHandler(RecommendedMovieSelect);
            panel.AutoScroll = true;

            //adds the list to the panel
            int num = 0;
            foreach (Result movie in movieList)
            {
                PictureBox poster = new PictureBox();
                poster.BackColor = System.Drawing.SystemColors.GrayText;
                point = new Point(num * ((int)(panel.Height / 1.5)), 0);
                poster.Location = point;
                poster.Size = new System.Drawing.Size((int)(panel.Height / 1.5), panel.Height - 17);// ((int)(panel.Height / 10)));
                poster.MouseDown += new System.Windows.Forms.MouseEventHandler(RecommendedMovieSelect);
                poster.ImageLocation = "https://www.salonlfc.com/wp-content/uploads/2018/01/image-not-found-scaled.png";
                if (movie.posterURLs.original != null)
                {
                    poster.ImageLocation = movie.posterURLs.original;
                }
                poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(poster);

                num++;
            }
        }

        private void MovieSelect(object sender, MouseEventArgs e)
        {
            Point formPoint = form.Location;
            windowsController.openMovieScreen(form, Control.MousePosition.Y - formPoint.Y - panel.AutoScrollPosition.Y - 100);
        }


        private void RecommendedMovieSelect(object sender, MouseEventArgs e)
        {
            Point formPoint = form.Location;
            windowsController.openRecMovieScreen(form, panel, Control.MousePosition.X - formPoint.X - panel.AutoScrollPosition.X);
        }
    }
}
