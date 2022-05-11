//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    /*******************************************************************************************************
     * Recommendations gets a wishlist's favorite genre and result type (movie or series) and makes 
     * appropriate calls to the API to get a list of recommendations based off of those favorites and the
     * profile's services.
     *******************************************************************************************************/
    public class Recommendations
    {
        private static int LIST_LENGTH = 27;
        private APIController apic;
        private Merge merge;
        public Recommendations()
        {
            apic = new APIController();
            merge = new Merge();
        }
        /*******************************************************************************************************
         * Generates a list of Results that the user with the given wishlist and services might be interested 
         * in watching
         * PARAMS: Result[] wishlist, The current profile's wishlist, used for getting favorite genre and type
         *                 string[] services, The current profile's services, used to make calls to the API
         *  RETURN: Array of Results that the user might want to watch or track
         *******************************************************************************************************/
        public Result[] getRecommendations(Result[] wishlist, string[] services)
        {
            Result[] recommendations = null;
            if(wishlist == null || services == null)
            {

            }
            else
            {
                string favoriteType, favoriteGenre;
                int genreInt = getFavoriteGenre(wishlist);
                favoriteGenre = translateGenre(genreInt);
                favoriteType = getFavoriteType(wishlist);
                if (services.Length > 0)
                {
                    string text = apic.FindMovieSync(favoriteType, services[0], favoriteGenre);
                    RootObject ro = JsonConvert.DeserializeObject<RootObject>(text);
                    for (int i = 1; i < services.Length; i++)
                    {
                        text = apic.FindMovieSync(favoriteType, services[i], favoriteGenre);
                        RootObject tempRo = JsonConvert.DeserializeObject<RootObject>(text);
                        ro = merge.mergeLists(ro, tempRo);
                    }
                    recommendations = ro.results;
                }                
            }
            return recommendations;
        }
        /*******************************************************************************************************
         * Finds the favorite genre of the given wishlist using the Results' genre attribute
         * PARAMS: Result[] wishlist, list of Results used to determine the favorite genre
         * RETURN: int representing the favorite genre
         *******************************************************************************************************/
        private int getFavoriteGenre(Result[] wishlist)
        {
            //Using Points to both track the genre number and count the amount of times that genre has appeared
            Point[] counts = new Point[LIST_LENGTH];
            counts[0] = new Point(1, 0);
            counts[1] = new Point(2, 0);
            counts[2] = new Point(3, 0);
            counts[3] = new Point(4, 0);
            counts[4] = new Point(5, 0);
            counts[5] = new Point(6, 0);
            counts[6] = new Point(7, 0);
            counts[7] = new Point(12, 0);
            counts[8] = new Point(14, 0);
            counts[9] = new Point(16, 0);
            counts[10] = new Point(18, 0);
            counts[11] = new Point(27, 0);
            counts[12] = new Point(28, 0);
            counts[13] = new Point(35, 0);
            counts[14] = new Point(36, 0);
            counts[15] = new Point(37, 0);
            counts[16] = new Point(53, 0);
            counts[17] = new Point(80, 0);
            counts[18] = new Point(99, 0);
            counts[19] = new Point(878, 0);
            counts[20] = new Point(9648, 0);
            counts[21] = new Point(10402, 0);
            counts[22] = new Point(10749, 0);
            counts[23] = new Point(10751, 0);
            counts[24] = new Point(10752, 0);
            counts[25] = new Point(10764, 0);
            counts[26] = new Point(10767, 0);
            foreach(Result r in wishlist)
            {
                for(int i = 0; i < LIST_LENGTH; i++)
                {
                    Point p = counts[i];
                    foreach(int g in r.genres)
                    {
                        if (g == p.X)
                        {
                            counts[i].Y = p.Y + 1;
                        }
                    }
                }
            }
            int favorite = 0;
            for (int i = 0; i < LIST_LENGTH; i++)
            {
                if (counts[favorite].Y < counts[i].Y)
                {
                    favorite = i;
                }
            }
            return counts[favorite].X;
        }
        /*******************************************************************************************************
         * Translates a genre's number into a string usable to search on the API
         * PARAMS: int num, the number to be translated
         * RETURN: string of the genre's name
         *******************************************************************************************************/
        private string translateGenre(int num)
        {
            string s = "";
            switch (num)
            {
                case 1:
                    s = "Biology";
                    break;
                case 2:
                    s = "Film Noir";
                    break;
                case 3:
                    s = "Game Show";
                    break;
                case 4:
                    s = "Musical";
                    break;
                case 5:
                    s = "Sport";
                    break;
                case 6:
                    s = "Short";
                    break;
                case 7:
                    s = "Adult";
                    break;
                case 12:
                    s = "Adventure";
                    break;
                case 14:
                    s = "Fantasy";
                    break;
                case 16:
                    s = "Animation";
                    break;
                case 18:
                    s = "Drama";
                    break;
                case 27:
                    s = "Horror";
                    break;
                case 28:
                    s = "Action";
                    break;
                case 35:
                    s = "Comedy";
                    break;
                case 36:
                    s = "History";
                    break;
                case 37:
                    s = "Western";
                    break;
                case 53:
                    s = "Thriller";
                    break;
                case 80:
                    s = "Crime";
                    break;
                case 99:
                    s = "Documentary";
                    break;
                case 878:
                    s = "Science Fiction";
                    break;
                case 9648:
                    s = "Mystery";
                    break;
                case 10402:
                    s = "Music";
                    break;
                case 10749:
                    s = "Romance";
                    break;
                case 10751:
                    s = "Family";
                    break;
                case 10752:
                    s = "War";
                    break;
                case 10763:
                    s = "News";
                    break;
                case 10764:
                    s = "Reality";
                    break;
                case 10767:
                    s = "Talk Show";
                    break;
            }
            return s;
        }
        /*******************************************************************************************************
         * Finds the given wishlist's favorite type using the Results' isMovie() method
         * PARAMS: Result[] wishlist, wishlist to have favorite type determined
         * RETURN: string of favorite type (either "movie" or "series"
         *******************************************************************************************************/
        private string getFavoriteType(Result[] wishlist)
        {
            int movie = 0, series = 0;
            string favorite;
            foreach (Result r in wishlist)
            {
                if (r.isMovie())
                {
                    movie++;
                }
                else
                {
                    series++;
                }
            }
            if (movie >= series)
            {
                favorite = "movie";
            }
            else
            {
                favorite = "series";
            }
            return favorite;
        }
    }
}