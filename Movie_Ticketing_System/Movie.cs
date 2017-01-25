using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticketing_System
{
    class Movie
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Classification { get; set; }
        public DateTime OpeningDate { get; set; }
        public List<string> GenreList { get; set; } = new List<string>();

        public Movie() { }
        public Movie(string title, int duration, string classification, DateTime openingdate, List<string> genrelist)
        {
            Title = title;
            Duration = duration;
            Classification = classification;
            OpeningDate = openingdate;
            GenreList = genrelist;
        }
        public override string ToString()
        {
            return String.Format("{0,-35}{1,-9}{2,-20}{3,-14}{4}", Title, Duration, Classification, OpeningDate);
        }
    }
}
