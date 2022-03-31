﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StreamSpotter
{
    class MovieList
    {
        private const int boxHeight = 160;
        private const int boxWidth = 850;

        private List<Result> movieList;
        Panel panel;
        Form form;
        WindowsController windowsController;
        WishlistTracker wishlistTracker;

        public MovieList(Panel panel, Form form, WindowsController windowsController)
        {
            movieList = new List<Result>();
            this.panel = panel;
            this.form = form;
            this.windowsController = windowsController;
            DatabaseAccess databaseAccess = new DatabaseAccess();
            databaseAccess.addProfileDirectory(0);
            databaseAccess.addJson(0, "list");
            wishlistTracker = new WishlistTracker();
            wishlistTracker.changeCurrentWishlist(0, "list");
        }

        //gather all information from json file to put into the movieList
        public bool populateSearchList(Result[] searchResults)//(string [,] searchResults)
        {
            movieList = new List<Result>();

            for (int i = 0; i < searchResults.GetLength(0); i++)
            {
                movieList.Add(searchResults[i]);
            }
            return movieList.Count != 0;
        }
        public bool populateWishlist()
        {
            movieList = new List<Result>();

            Result[] list = wishlistTracker.getCurrentWishlist();
            bool works = true;
            if(list!=null)
            {
                for (int x = 0; x < list.Length; x++)
                    movieList.Add(list[x]);
            }
            else
                works = false;
            return works;
        }
        public Result getMovie(int index)
        {
            if (movieList != null)
                return movieList[index];
            return null;
        }
        public Result[] getWishlist()
        {
            return wishlistTracker.getCurrentWishlist();
        }
        public void addToWishlist(Result result)
        {
            wishlistTracker.addToCurrentWishlist(result);
        }
        public void removeFromWishlist(Result result)
        {
            wishlistTracker.removeFromCurrentWishlist(result.imdbID);
        }
        public void printList()
        {
            panel.Invalidate();
            Graphics g = panel.CreateGraphics();
            Point point;

            panel.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);

            //adds the list to the panel
            int num = 0;
            foreach (Result movie in movieList)
            {
                point = new Point(0, num * boxHeight);
                Size size = new Size(boxWidth, boxHeight);
                Rectangle rec = new Rectangle(point, size);
                if (num % 2 == 0)
                    g.FillRectangle(System.Drawing.Brushes.LightBlue, rec);
                else
                    g.FillRectangle(System.Drawing.Brushes.White, rec);

                Label title = new Label();
                title.Text = movie.title;
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, num * boxHeight + 10);
                title.Location = point;
                title.Width = 200;
                title.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                panel.Controls.Add(title);

                Label description = new Label();
                description.Text = movie.overview;
                description.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, num * boxHeight + 40);
                description.Location = point;
                description.Size = new System.Drawing.Size(boxWidth - 400, boxHeight - 40);
                description.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                panel.Controls.Add(description);

                //Panel poster = new Panel();
                //poster.BackColor = System.Drawing.SystemColors.GrayText;
                //point = new Point(20, num * boxHeight + 10);
                //poster.Location = point;
                //poster.Size = new System.Drawing.Size(100, boxHeight - 20);
                //poster.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                //panel.Controls.Add(poster);

                PictureBox poster = new PictureBox();
                poster.BackColor = System.Drawing.SystemColors.GrayText;
                point = new Point(20, num * boxHeight + 10);
                poster.Location = point;
                poster.Size = new System.Drawing.Size(100, boxHeight - 20);
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

        private void MovieSelect(object sender, MouseEventArgs e)
        {
            Point formPoint = form.Location;
            windowsController.openMovieScreen(form, Control.MousePosition.Y - formPoint.Y - panel.AutoScrollPosition.Y - 100);
        }

    }
}
