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
        private ProfileSelectionScreen profileScreen;
        public WindowsController()
        {
            search = new Search();
            searchScreenLast = true;
            profileController = new ProfileController();
            currentProfile = profileController.GetProfile(profileController.getCurrentProfile());
        }
        public void openHomeScreen(Form currentForm)
        {
            currentForm.Hide();
            HomeScreen homeScreen = new HomeScreen(this);
            homeScreen.Show();
        }
        public void openSearchListUI(Form currentForm, string title)
        {
            searchScreenLast = true;
            currentForm.Hide();
            search.searchResult(title, "movie");
            searchResults = search.getSearchResults();
            SearchListUI searchListUI = new SearchListUI(this);
            searchListUI.Show();
        }
        public void goBack(Form currentForm)
        {
            currentForm.Hide();
            if(searchScreenLast)
            {
                SearchListUI searchListUI = new SearchListUI(this);
                searchListUI.Show();
            }
            else
            {
                WishlistUI wishListUI = new WishlistUI(this);
                wishListUI.Show();
            }
        }
        public void openWishListUI(Form currentForm)
        {
            searchScreenLast = false;
            currentForm.Hide();
            WishlistUI wishListUI = new WishlistUI(this);
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
            movieList.addToWishlist(movie);
        }

        public void removeMovieFromWishlist(Result movie)
        {
            movieList.removeFromWishlist(movie);
        }

        public void showProfileScreen()
		{
            profileScreen = new ProfileSelectionScreen();
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

        public void createProfileOnStartup()
		{
            //need to check if this is the first time starting on the machine.
            showProfileScreen();
            profileScreen.createNewProfileOnStart();
        }
    }
}
