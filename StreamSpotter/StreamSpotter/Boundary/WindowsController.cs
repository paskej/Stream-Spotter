using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    public class WindowsController
    {
        private MovieList movieList;
        private Search search;
        private Result[] searchResults;
        bool searchScreenLast;
        public ProfileController profileController;
        public Profile currentProfile;
        public ProfileSelectionScreen profileScreen;
        private static WindowsController instance;
        private WindowsController()
        {
            search = new Search();
            searchScreenLast = true;
            profileController = new ProfileController();
            currentProfile = profileController.GetProfile(profileController.getCurrentProfile());
        }
        public static WindowsController getInstance()
        {
            if(instance == null)
            {
                instance = new WindowsController();
            }
            return instance;
        }
        public void openHomeScreen(Form currentForm)
        {
            currentForm.Hide();
            HomeScreen homeScreen = new HomeScreen(this);
            homeScreen.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
            if (currentForm.Height < homeScreen.MinimumSize.Height)
            {
                homeScreen.Height = homeScreen.MinimumSize.Height;
            }
            else
            {
                homeScreen.Height = currentForm.Height;
            }
            if (currentForm.Width < homeScreen.MinimumSize.Width)
            {
                homeScreen.Width = homeScreen.MinimumSize.Width;
            }
            else
            {
                homeScreen.Width = currentForm.Width;
            }

            homeScreen.Show();
        }
        public void openSearchListUI(Form currentForm, string title)
        {
            searchScreenLast = true;
            currentForm.Hide();
            search.searchResult(title, "movie");
            searchResults = search.getSearchResults();
            SearchListUI searchListUI = new SearchListUI(this);
            searchListUI.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
            if (currentForm.Height < searchListUI.MinimumSize.Height)
            {
                searchListUI.Height = searchListUI.MinimumSize.Height;
            }
            else
            {
                searchListUI.Height = currentForm.Height;
            }
            if (currentForm.Width < searchListUI.MinimumSize.Width)
            {
                searchListUI.Width = searchListUI.MinimumSize.Width;
            }
            else
            {
                searchListUI.Width = currentForm.Width;
            }

            searchListUI.Show();
        }
        public void goBack(Form currentForm)
        {
            currentForm.Hide();
            if(searchScreenLast)
            {
                SearchListUI searchListUI = new SearchListUI(this);
                searchListUI.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
                if (currentForm.Height < searchListUI.MinimumSize.Height)
                {
                    searchListUI.Height = searchListUI.MinimumSize.Height;
                }
                else
                {
                    searchListUI.Height = currentForm.Height;
                }
                if (currentForm.Width < searchListUI.MinimumSize.Width)
                {
                    searchListUI.Width = searchListUI.MinimumSize.Width;
                }
                else
                {
                    searchListUI.Width = currentForm.Width;
                }

                searchListUI.Show();
            }
            else
            {
                WishlistUI wishListUI = new WishlistUI(this);
                wishListUI.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
                if (currentForm.Height < wishListUI.MinimumSize.Height)
                {
                    wishListUI.Height = wishListUI.MinimumSize.Height;
                }
                else
                {
                    wishListUI.Height = currentForm.Height;
                }
                if (currentForm.Width < wishListUI.MinimumSize.Width)
                {
                    wishListUI.Width = wishListUI.MinimumSize.Width;
                }
                else
                {
                    wishListUI.Width = currentForm.Width;
                }
                wishListUI.Show();
            }
        }
        public void openWishListUI(Form currentForm)
        {
            searchScreenLast = false;
            currentForm.Hide();
            WishlistUI wishListUI = new WishlistUI(this);
            wishListUI.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
            if(currentForm.Height < wishListUI.MinimumSize.Height)
            {
                wishListUI.Height = wishListUI.MinimumSize.Height;
            }
            else
            {
                wishListUI.Height = currentForm.Height;
            }
            if (currentForm.Width < wishListUI.MinimumSize.Width)
            {
                wishListUI.Width = wishListUI.MinimumSize.Width;
            }
            else
            {
                wishListUI.Width = currentForm.Width;
            }

            wishListUI.Show();
        }
        public void openMovieScreen(Form currentForm, int loc)
        {
            int listIndex = loc / 160;

            bool inList = false;
            Result[] wishlist = movieList.getWishlist();
            if (wishlist != null)
            {
                foreach (Result r in wishlist)
                {
                    if (r.imdbID == movieList.getMovie(listIndex).imdbID)
                    {
                        inList = true;
                    }
                }
            }
            if(movieList.getMovie(listIndex) != null)
            {
                currentForm.Hide();
                MovieScreen movieScreen = new MovieScreen(movieList.getMovie(listIndex), this, inList);
                movieScreen.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
                if (currentForm.Height < movieScreen.MinimumSize.Height)
                {
                    movieScreen.Height = movieScreen.MinimumSize.Height;
                }
                else
                {
                    movieScreen.Height = currentForm.Height;
                }
                if (currentForm.Width < movieScreen.MinimumSize.Width)
                {
                    movieScreen.Width = movieScreen.MinimumSize.Width;
                }
                else
                {
                    movieScreen.Width = currentForm.Width;
                }

                movieScreen.Show();
            }
        }
        public bool showSearchList(Panel listPanel, Form form)
        {
            movieList = new MovieList(listPanel, form, this);
            bool listNull = movieList.populateSearchList(searchResults);
            movieList.printList();
            return listNull;
        }
        public bool showWishList(Panel listPanel, Form form)
        {
            movieList = new MovieList(listPanel, form, this);
            bool listNull = movieList.populateWishlist();
            movieList.printList();
            return listNull;
        }
        public void addMovieToWishlist(Result movie)
        {
            int currentID = currentProfile.getID();
            movieList.changeCurrentWishlist(currentID, currentID.ToString());
            movieList.addToWishlist(movie);
        }

        public void removeMovieFromWishlist(Result movie)
        {
            int currentID = currentProfile.getID();
            movieList.changeCurrentWishlist(currentID, currentID.ToString());
            movieList.removeFromWishlist(movie);
        }
        public void changeCurrentWishlist(int profileID, string listName)
        {
            if (movieList != null)
            {
                movieList.changeCurrentWishlist(profileID, listName);
            }
        }
        public void changeCurrentProfile(int profileID)
        {
            profileController.setCurrentProfile(profileID);
            currentProfile = profileController.GetProfile(profileID);
        }

        public void showProfileScreen(Form currentForm)
		{
            profileScreen = new ProfileSelectionScreen();
            profileScreen.updateFormPosition(currentForm);
            profileScreen.Show();

        }

        public bool unFilter()
        {
            bool notEmpty = movieList.noFilter();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByService(string service)
        {
            bool notEmpty = movieList.filterByStreamingService(service);
            movieList.printList();
            return notEmpty;
        }

        public bool filterByMovie()
        {
            bool notEmpty = movieList.filterByMovie();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByShow()
        {
            bool notEmpty = movieList.filterByShow();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByRating()
        {
            bool notEmpty = movieList.filterByRating();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByNewest()
        {
            bool notEmpty = movieList.filterByNewest();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByOldest()
        {
            bool notEmpty = movieList.filterByOldest();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByShorter()
        {
            bool notEmpty = movieList.filterByShorter();
            movieList.printList();
            return notEmpty;
        }

        public bool filterByLonger()
        {
            bool notEmpty = movieList.filterByLonger();
            movieList.printList();
            return notEmpty;
        }

        public void printList()
        {
            movieList.printList();
        }

        public void createProfileOnStartup()
		{
            //change to start in program.cs.
            //first check if there is a profile and if there isnt then dont let the user close the form.
            profileScreen = new ProfileSelectionScreen();
            profileScreen.Show();
            profileScreen.createNewProfileOnStart();
        }
    }
}
