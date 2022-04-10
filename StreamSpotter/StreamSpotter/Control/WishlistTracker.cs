using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
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

        public void changeCurrentWishlist(int profileID, string listName)
        {
            currentWishlist = da.getWishlist(profileID, listName);
            currentProfile = profileID;
            currentListName = listName;
        }
        public Result[] getCurrentWishlist()
        {
            return currentWishlist;
        }

        public void removeFromCurrentWishlist(string imdbID)
        {
            da.removeFromWishlist(currentProfile, currentListName, imdbID);
        }

        public void addToCurrentWishlist(Result movie)
        {
            da.addToWishlist(currentProfile, currentListName, movie);
        }

        public bool isInCurrentWishlist(string imdbID)
        {
            bool isIn = false;
            foreach(Result result in currentWishlist)
            {
                if(result.imdbID == imdbID)
                {
                    isIn = true;
                }
            }
            return isIn;
        }

    }
}
