using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class Ticket : Concerts
    {   

        public string TicketID { get; set; }


        // Constructor to initialize a Ticket object
        public Ticket(int concertID, string date, double price, string bandName)
        {
            
        }


    }
}
