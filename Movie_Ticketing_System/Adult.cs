using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticketing_System
{
    class Adult:Ticket
    {
        public bool PopcornOffer { get; set; }

        public Adult() { }
        public Adult(Screening screening, bool popcornoffer) : base(screening)
        {
            PopcornOffer = popcornoffer;
        }
        public override double CalculatePrice()
        {
            double totalprice = 0.0;
            if (Screening.ScreeningType == "3D")
            {
                if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                {
                    totalprice = 14.00;
                }
                totalprice = 11.00;
            }
            else
            {
                if (new List<DayOfWeek>() { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(Screening.ScreeningDateTime.DayOfWeek))
                {
                    totalprice = 12.50;
                }
                totalprice = 8.50;
            }
            if (PopcornOffer)
                totalprice += 3;
            return totalprice;
        }
        public override string ToString()
        {
            return base.ToString() + " PopcornOffer: " + PopcornOffer;
        }
    }
}
