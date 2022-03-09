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
        private APIController apiController;
        private string[,] searchResults;
        public WindowsController()
        {
            apiController = new APIController();
        }
        public void openHomeScreen(Form currentForm)
        {
            currentForm.Hide();
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
        }
        public void openSearchListUI(Form currentForm, string title)
        {
            currentForm.Hide();
            apiController.FindMovieSync("movie", "netflix", title);
            searchResults = apiController.getSearchResult();
            SearchListUI searchListUI = new SearchListUI(this);
            searchListUI.Show();
        }
        public void openMovieScreen(Form currentForm, int loc)
        {
            currentForm.Hide();

            int listIndex = loc / 160;

            MovieScreen movieScreen = new MovieScreen(movieList.getMovie(listIndex));
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
