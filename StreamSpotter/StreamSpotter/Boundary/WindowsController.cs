﻿using System;
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
        bool homeScreenLast;
        public ProfileController profileController;
        public Profile currentProfile;
        public ProfileSelectionScreen profileScreen;
        private static WindowsController instance;
        private String currSearch;
        private Stack<String> prevSearch;
        public bool wishlistChanged;
        private WindowsController()
        {
            search = new Search();
            searchScreenLast = false;
            homeScreenLast = true;
            profileController = new ProfileController();
            currentProfile = profileController.GetProfile(profileController.getCurrentProfile());
            currSearch = null;
            prevSearch = new Stack<String>();
            wishlistChanged = false;
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
            homeScreenLast = true;
            searchScreenLast = false;
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
            currentForm.Hide();
            homeScreen.Show();
            homeScreen.showList();
        }
        public String peekPrevSearch()
        {
            if(prevSearch.Count() != 0)
                return prevSearch.Peek();
            return null;
        }
        public String getPrevSearch()
        {
            return prevSearch.Pop();
        }
        public void setPrevSearch(String previousSearch)
        {
            prevSearch.Push(previousSearch);
        }
        public String getCurrSearch()
        {
            return currSearch;
        }
        public void openSearchListUI(Form currentForm, string title)
        {
            currSearch = title;
            searchScreenLast = true;
            homeScreenLast = false;
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
            currentForm.Hide();
            searchListUI.Show();
            search = new Search();
            search.searchResult(title, currentProfile.services);//
            searchResults = search.getSearchResults();
            searchListUI.showList();
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
                searchListUI.showList();
            }
            else if (homeScreenLast)
            {
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
                homeScreen.showList();
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
                wishListUI.showList();
            }
        }
        public void openWishListUI(Form currentForm)
        {
            searchScreenLast = false;
            homeScreenLast = false;
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
            currentForm.Hide();
            wishListUI.Show();
            wishListUI.showList();
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

        public void openRecMovieScreen(Form currentForm, Panel panel, int loc)
        {
            int listIndex = loc / ((int)(panel.Height / 1.5));

            bool inList = false;
            Result[] wishlist = movieList.getWishlist();
            if (wishlist != null && movieList.getMovie(0)!=null)
            {
                foreach (Result r in wishlist)
                {
                    if (r.imdbID == movieList.getMovie(listIndex).imdbID)
                    {
                        inList = true;
                    }
                }
            }
            if (movieList.getMovie(listIndex) != null)
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
        public bool showRecommendedList(Panel listPanel, Form form)
        {
            movieList = new MovieList(listPanel, form, this);
            bool listNull = movieList.populateRecommendedList();
            movieList.printRecommendedList();
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
            profileScreen.Location = new System.Drawing.Point(currentForm.Location.X, currentForm.Location.Y);
            if (currentForm.Height < profileScreen.MinimumSize.Height)
            {
                profileScreen.Height = profileScreen.MinimumSize.Height;
            }
            else
            {
                profileScreen.Height = currentForm.Height;
            }
            if (currentForm.Width < profileScreen.MinimumSize.Width)
            {
                profileScreen.Width = profileScreen.MinimumSize.Width;
            }
            else
            {
                profileScreen.Width = currentForm.Width;
            }
            profileScreen.updateFormPosition(currentForm);
            profileScreen.Show();
            currentForm.Close();

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

        public void updateRecommendations()
        {
            movieList.updateRecommendations(profileController.currentProfileID);
        }

        public Result[] getRecommendations()
        {
            return movieList.getRecommendations(profileController.currentProfileID);
        }
    }
}
