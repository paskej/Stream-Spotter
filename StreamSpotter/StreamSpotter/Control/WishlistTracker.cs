//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    /*******************************************************************************************************
     *  WishlistTracker tracks the current profile and wishlist. WishlistTracker also acts as a middle-man
     *  between WindowsController and DatabaseAccess
     *******************************************************************************************************/
    public class WishlistTracker
    {
        Result[] currentWishlist;
        DatabaseAccess da;
        string currentListName;
        int currentProfile;

        public WishlistTracker()
        {
            this.currentWishlist = null;
            this.da = new DatabaseAccess();
            this.currentProfile = -1;
            this.currentListName = null;
        }
        /*******************************************************************************************************
         * Changes the current tracked wishlist and profile
         * PARAMS: int profileID, profile ID to change to
         *                 string listName, wishlist name to change to
         *******************************************************************************************************/
        public void changeCurrentWishlist(int profileID, string listName)
        {
            currentWishlist = da.getWishlist(profileID, listName);
            currentProfile = profileID;
            currentListName = listName;
        }
        /*******************************************************************************************************
         * RETURN: the currently tracked wishlist
         *******************************************************************************************************/
        public Result[] getCurrentWishlist()
        {
            return currentWishlist;
        }
        /*******************************************************************************************************
         * Passes the updateRecommendations command to DatabaseAccess
         * PARAMS: int profileID, id of the profile to update recommendations for
         *******************************************************************************************************/
        public void updateRecommendations(int profileID)
        {
            da.updateRecommendations(profileID);
        }
        /*******************************************************************************************************
         * Gets recommendations from DatabaseAccess corresponding to given profile ID
         *PARAMS: int profileID, id of the profile to retrieve recommendations for
         * RETURN: list of results from DatabaseAccess
         *******************************************************************************************************/
        public Result[] getRecommendations(int profileID)
        {
            return da.getRecommendations(profileID);
        }
        /*******************************************************************************************************
         * Passes the removeFromWishlist command to DatabaseAccess
         * PARAMS: string imdbID,  Imdb ID of the Result to be removed
         *******************************************************************************************************/
        public void removeFromCurrentWishlist(string imdbID)
        {
            da.removeFromWishlist(currentProfile, currentListName, imdbID);
        }
        /*******************************************************************************************************
         * Passes the addToWishlist command to DatabaseAccess
         * PARAMS: Result movie, the Result to be added to the wishlist
         *******************************************************************************************************/
        public void addToCurrentWishlist(Result movie)
        {
            da.addToWishlist(currentProfile, currentListName, movie);
        }
    }
}
