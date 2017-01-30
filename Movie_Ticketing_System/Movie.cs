//Student Number : S10171663,  s10171069
//Student name   : Samuel Ong, Seow Chong
//Module Group   : IT05
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
        private string classification;
        public string Classification
        {
            get { return classification; }
            set
            { if (new List<string>() { "G", "PG13", "NC16", "M18", "R21"}.Contains(value))
                {
                    classification = value;
                }
            }
        }
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
            string genrelist = GenreList[0];
            for (int i = 1; i < GenreList.Count; i++)
            {
                genrelist += ", " + GenreList[i];
            }
            return String.Format("{0,-35}{1,-9}{2,-20}{3,-14}{4}{5}", Title, Duration, Classification, OpeningDate, genrelist);
        }
    }
}
