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
    class Order
    {
        private int orderCount { get; set; } = 1;
        public string OrderNo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        private List<Ticket> TicketList = new List<Ticket>();

        public Order() { OrderNo = Convert.ToString(orderCount); orderCount++; }
        public void AddTicket(Ticket ticket)
        {
            TicketList.Add(ticket);
        }
        public List<Ticket> GetTicketList()
        {
            return TicketList;
        }
        public override string ToString()
        {
            return "OrderNo: " + OrderNo + " OrderDateTime" + OrderDateTime + " Amount: " + Amount + " Status: " + Status;
        }
    }
}
