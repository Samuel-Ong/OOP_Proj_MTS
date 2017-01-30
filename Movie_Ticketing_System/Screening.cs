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
    class Screening
    {
        private static int screeningCount { get; set; } = 1001;
        public string ScreeningNo { get; set; }
        public DateTime ScreeningDateTime { get; set; }
        private string screeningType;
        public string ScreeningType
        { 
            get { return ScreeningType; }
            set { if (value == "2D" || value == "3D") screeningType = value; }
        }


        public int SeatsRemaining { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Movie Movie { get; set; }

        public Screening() { }
        public Screening(DateTime screeningdatetime, string screeningtype, CinemaHall cinemahall, Movie movie)
        {
            ScreeningNo = Convert.ToString(screeningCount);
            screeningCount++;
            ScreeningDateTime = screeningdatetime;
            ScreeningType = screeningType;
            SeatsRemaining = cinemahall.Capacity;
            CinemaHall = cinemahall;
            Movie = movie;
        }
        public override string ToString()
        {
            return "ScreeningDateTime: " + ScreeningDateTime + " Type: " + ScreeningType + " Cinema Hall: " + CinemaHall + " Movie " + Movie;
        }
    }
}
