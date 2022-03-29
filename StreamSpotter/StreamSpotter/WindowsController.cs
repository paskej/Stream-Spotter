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
        //private string[,] searchResults;
        private Result[] searchResults;
        public WindowsController()
        {
            search = new Search();
        }
        public void openHomeScreen(Form currentForm)
        {
            currentForm.Hide();
            HomeScreen homeScreen = new HomeScreen(this);
            homeScreen.Show();
        }
        public void openSearchListUI(Form currentForm, string title)
        {
            currentForm.Hide();
            search.searchResult(title, "movie");
            searchResults = search.getSearchResults();
            SearchListUI searchListUI = new SearchListUI(this);
            searchListUI.Show();
        }
        public void goBackToSearchListUI(Form currentForm)
        {
            currentForm.Hide();
            SearchListUI searchListUI = new SearchListUI(this);
            searchListUI.Show();
        }
        public void openWishListUI(Form currentForm)
        {
            currentForm.Hide();
            WishlistUI wishListUI = new WishlistUI(this);
            wishListUI.Show();
        }
        public void openMovieScreen(Form currentForm, int loc)
        {
            currentForm.Hide();

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

            MovieScreen movieScreen = new MovieScreen(movieList.getMovie(listIndex), this, inList);
            if (movieScreen != null)
                movieScreen.Show();
            else
                MessageBox.Show("No Results!");
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

        public void showProfileScreen(Form currentForm)
		{
            ProfileSelectionScreen profileScreen = new ProfileSelectionScreen();
            profileScreen.Show();
		}
    }
}
