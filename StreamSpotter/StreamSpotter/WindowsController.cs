using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    class WindowsController
    {
        public WindowsController()
        {

        }
        public void openHomeScreen(Form currentForm)
        {
            currentForm.Hide();
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.Show();
        }
        public void openSearchListUI(Form currentForm)
        {
            currentForm.Hide();
            SearchListUI searchListUI = new SearchListUI();
            searchListUI.Show();
        }
        public void openMovieScreen(Form currentForm)
        {
            currentForm.Hide();
            MovieScreen movieScreen = new MovieScreen();
            movieScreen.Show();
        }
    }
}
