/**--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Author: Diogo Carvalho Graça  
Email: a28004@alunos.ipca.pt  

This code is free and open for anyone to use, modify, share, or improve without restrictions. It exists in the public domain or is released without any claim of copyright protection.  

Brief: Create a class named Users to store the user's info

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class Users
    {
        private string name { get; set; }           // User's name
        private int idUser { get; set; }            // Unique user ID
        private List<Bands> Tickets { get; set; }   // List of user's tickets

        public Users(string Name, int IdUser)       // Constructor to initialize the user
        {
            this.name = Name;
            this.idUser = IdUser;
            this.Tickets = new List<Bands>();
        }

        public string Name                          // Property to get/set the name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int IdUser                           // Property to get the user ID (read-only)
        {
            get { return this.idUser; }
        }

        public List<Bands> Bands                    // Property to get the list of bands
        {
            get { return this.Tickets; }
        }

        public void add(Bands ticket)               // Adds a ticket to the list
        {
            this.Tickets.Add(ticket);
        }

        public void remove(Bands ticket)            // Removes a ticket from the list
        {
            this.Tickets.Remove(ticket);
        }
    }
}