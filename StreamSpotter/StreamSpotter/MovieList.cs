using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StreamSpotter
{
    class MovieList
    {
        private const int boxHeight = 160;
        private const int boxWidth = 850;

        private List<Movie> movieList;
        Panel panel;
        Form form;

        public MovieList(Panel panel, Form form)
        {
            movieList = new List<Movie>();
            this.panel = panel;
            this.form = form;
        }

        //gather all information from json file to put into the movieList
        public void populateList()
        {
            Movie batman = new Movie("Batman", "Dude thats a bat who is also very rich. He hunts down criminals in gotham city. He could've defeated superman.", "Netflix");
            movieList.Add(batman);
            Movie ironMan = new Movie("Iron Man", "Dude with high tech suit who is also very rich. He defends the world from enemies trying to destory it. He snapped thanos away.", "Disney+");
            movieList.Add(ironMan);
            Movie hulk = new Movie("Hulk", "He big, strong and green. He smash a lot of stuff. His actual name is Bruce Banner.", "Disney+");
            movieList.Add(hulk);
        }

        public void printList()
        {
            panel.Invalidate();
            //Graphics g = panel.CreateGraphics();
            Point point;

            //adds the list to the panel
            int num = 0;
            foreach (Movie movie in movieList)
            {
                Panel background = new Panel();
                point = new Point(0, num * boxHeight);
                background.Location = point;
                background.Size = new System.Drawing.Size(boxWidth, boxHeight);
                if (num % 2 == 0)
                    background.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                else
                    background.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                background.Click += new System.EventHandler(MovieSelect);
                panel.Controls.Add(background);

                Label title = new Label();
                title.Text = movie.getTitle();
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, 10);
                title.Location = point;
                title.Click += new System.EventHandler(MovieSelect);
                background.Controls.Add(title);

                Label description = new Label();
                description.Text = movie.getDescription();
                description.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, 40);
                description.Location = point;
                description.Size = new System.Drawing.Size(boxWidth - 400, boxHeight - 40);
                description.Click += new System.EventHandler(MovieSelect);
                background.Controls.Add(description);

                Panel poster = new Panel();
                poster.BackColor = System.Drawing.SystemColors.GrayText;
                point = new Point(20, 10);
                poster.Location = point;
                poster.Size = new System.Drawing.Size(100, boxHeight - 20);
                poster.Click += new System.EventHandler(MovieSelect);
                background.Controls.Add(poster);

                num++;
            }
        }

        private void MovieSelect(object sender, EventArgs e)
        {
            WindowsController windowsController = new WindowsController();
            windowsController.openMovieScreen(form);
        }

    }
}
