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

            //string movie;
            //APIController apiController = new APIController();
            //movie = apiController.FindMovieSync("series", "netflix", "witcher");
            //Console.Write(movie);

            //movie = apiController.FindMovieSync("movie", "netflix", "the dark knight");
            //Console.Write(movie);

            //movie = apiController.FindMovieSync("series", "netflix", "seinfeld");
            //Console.Write(movie);

            //movie = apiController.FindMovieSync("movie", "netflix", "top%20gun");
            //Console.Write(movie);

            //IOManager io = new IOManager();
            //io.run();
            



        }
        
    }
}
