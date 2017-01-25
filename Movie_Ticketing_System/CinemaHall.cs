using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Ticketing_System
{
    class CinemaHall
    {
        public string Name { get; set; }
        public int HallNo { get; set; }
        public int Capacity { get; set; }

        public CinemaHall() { }
        public CinemaHall(string name, int hallno, int capacity)
        {
            Name = name;
            HallNo = hallno;
            Capacity = capacity;
        }
        public override string ToString()
        {
            return "Name: " + Name + " HallNo: " + HallNo + " Capacity: " + Capacity;
        }
    }
}
