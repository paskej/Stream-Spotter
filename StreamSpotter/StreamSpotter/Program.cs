using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeScreen());

            APIController apiController = new APIController();
            apiController.Change("series", "netflix", "witcher");
            string movie = apiController.FindMovieSync();
            apiController.Change("Movie", "netflix", "the%20dark%20knight");
            //FindMovieSync();
            apiController.Change("series", "netflix", "seinfeld");
            //FindMovieSync();
            apiController.Change("Movie", "netflix", "top%20gun");
            //FindMovieSync();

            Console.Write(movie);

        }
    }
}
