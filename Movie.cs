using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1_Zihun
{
    class Movie
    {
        private int id;

        public int Id
        {
            get { return id; }
        }

        public string Title { get; set; }
        public Genre MovieGenre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int Duration { get; set; }

        public Movie(int id, string title, Genre genre, DateTime date, double rating, int duration)
        {
            this.id = id;
            Title = title;
            MovieGenre = genre;
            ReleaseDate = date;
            Rating = rating;
            Duration = duration;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Id + " | " + Title + " | " + MovieGenre + " | " + ReleaseDate.ToShortDateString() + " | " + Rating + " | " + Duration + " хв");
        }
    }
}