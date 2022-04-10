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

        public Recommendations()
        {
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
                int genreInt = -1;
                genreInt = getFavoriteGenre(wishlist);
                //string text = apic.FindMovieSync()
            }
            return recommendations;
        }

        private int getFavoriteGenre(Result[] wishlist)
        {
            ArrayList counts = new ArrayList();
            counts.Add(new Point(1, 0));
            counts.Add(new Point(2, 0));
            counts.Add(new Point(3, 0));
            counts.Add(new Point(4, 0));
            counts.Add(new Point(5, 0));
            counts.Add(new Point(6, 0));
            counts.Add(new Point(7, 0));
            counts.Add(new Point(12, 0));
            counts.Add(new Point(14, 0));
            counts.Add(new Point(16, 0));
            counts.Add(new Point(18, 0));
            counts.Add(new Point(27, 0));
            counts.Add(new Point(28, 0));
            counts.Add(new Point(35, 0));
            counts.Add(new Point(36, 0));
            counts.Add(new Point(37, 0));
            counts.Add(new Point(53, 0));
            counts.Add(new Point(80, 0));
            counts.Add(new Point(99, 0));
            counts.Add(new Point(878, 0));
            counts.Add(new Point(9648, 0));
            counts.Add(new Point(10402, 0));
            counts.Add(new Point(10749, 0));
            counts.Add(new Point(10751, 0));
            counts.Add(new Point(10752, 0));
            counts.Add(new Point(10764, 0));
            counts.Add(new Point(10767, 0));
            return 0;
        }
    }
}
/*{
"14":"Fantasy","16":"Animation","18":"Drama",,"27":"Horror","28":"Action",
"3":"Game Show","35":"Comedy","36":"History","37":"Western","4":"Musical","5":"Sport",
"53":"Thriller","6":"Short","7":"Adult","80":"Crime","878":"Science Fiction","9648":"Mystery",
"99":"Documentary"}*/