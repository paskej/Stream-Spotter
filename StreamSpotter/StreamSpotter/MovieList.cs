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

        private List<Result> movieList;
        Panel panel;
        Form form;
        WindowsController windowsController;

        public MovieList(Panel panel, Form form, WindowsController windowsController)
        {
            movieList = new List<Result>();
            this.panel = panel;
            this.form = form;
            this.windowsController = windowsController;
        }

        //gather all information from json file to put into the movieList
        public void populateList()
        {
            Result batman = new Result("Batman", "Dude thats a bat who is also very rich. He hunts down criminals in gotham city. He could've defeated superman.", "Netflix");
            movieList.Add(batman);
            Result ironMan = new Result("Iron Man", "Dude with high tech suit who is also very rich. He defends the world from enemies trying to destory it. He snapped thanos away.", "Disney+");
            movieList.Add(ironMan);
            Result hulk = new Result("Hulk", "He big, strong and green. He smash a lot of stuff. His actual name is Bruce Banner.", "Disney+");
            movieList.Add(hulk);
        }
        public Result getMovie(int index)
        {
            return movieList[index];
        }

        public void printList()
        {
            panel.Invalidate();
            //Graphics g = panel.CreateGraphics();
            Point point;

            //adds the list to the panel
            int num = 0;
            foreach (Result movie in movieList)
            {
                Panel background = new Panel();
                point = new Point(0, num * boxHeight);
                background.Location = point;
                background.Size = new System.Drawing.Size(boxWidth, boxHeight);
                if (num % 2 == 0)
                    background.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                else
                    background.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                background.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                panel.Controls.Add(background);

                Label title = new Label();
                title.Text = movie.title;
                title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, 10);
                title.Location = point;
                title.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                background.Controls.Add(title);

                Label description = new Label();
                description.Text = movie.overview;
                description.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                point = new Point(140, 40);
                description.Location = point;
                description.Size = new System.Drawing.Size(boxWidth - 400, boxHeight - 40);
                description.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                background.Controls.Add(description);

                Panel poster = new Panel();
                poster.BackColor = System.Drawing.SystemColors.GrayText;
                point = new Point(20, 10);
                poster.Location = point;
                poster.Size = new System.Drawing.Size(100, boxHeight - 20);
                poster.MouseDown += new System.Windows.Forms.MouseEventHandler(MovieSelect);
                background.Controls.Add(poster);

                num++;
            }
        }

        private void MovieSelect(object sender, MouseEventArgs e)
        {
            windowsController.openMovieScreen(form, e.Location.Y);
        }

    }
}
