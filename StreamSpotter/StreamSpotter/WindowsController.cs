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
        private string[,] searchResults;
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
            searchResults = search.getSearchResult();
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

            MovieScreen movieScreen = new MovieScreen(movieList.getMovie(listIndex), this);
            if (movieScreen != null)
                movieScreen.Show();
            else
                MessageBox.Show("No Results!");
        }
        public void showMovieList(Panel listPanel, Form form)
        {
            movieList = new MovieList(listPanel, form, this);
            movieList.populateList(searchResults);
            movieList.printList();
        }
    }
}
