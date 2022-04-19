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
    class Recommendations
    {
        private static int LIST_LENGTH = 27;
        private APIController apic;
        private Merge merge;
        public Recommendations()
        {
            apic = new APIController();
            merge = new Merge();
        }
        public Result[] getRecommendations(Result[] wishlist)
        {
            Result[] recommendations = null;
            if(wishlist == null)
            {

            }
            else
            {
                string favoriteType, favoriteGenre;
                int genreInt = getFavoriteGenre(wishlist);
                favoriteGenre = translateGenre(genreInt);
                favoriteType = getFavoriteType(wishlist);
                string text = apic.FindMovieSync(favoriteType, "netflix", favoriteGenre);
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(text);
                text = apic.FindMovieSync(favoriteType, "disney", favoriteGenre);
                RootObject tempRo = JsonConvert.DeserializeObject<RootObject>(text);
                ro = merge.mergeLists(ro, tempRo);
                recommendations = ro.results;
            }
            return recommendations;
        }

        private int getFavoriteGenre(Result[] wishlist)
        {
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
/*{
"14":"Fantasy","16":"Animation","18":"Drama",,"27":"Horror","28":"Action",
"3":"Game Show","35":"Comedy","36":"History","37":"Western","4":"Musical","5":"Sport",
"53":"Thriller","6":"Short","7":"Adult","80":"Crime","878":"Science Fiction","9648":"Mystery",
"99":"Documentary"}*/