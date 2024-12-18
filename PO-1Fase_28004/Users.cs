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
        private string email { get; set; }           // User's email
        private string password { get; set; }       // User's password
        private int idUser { get; set; }            // Unique user ID
        private List<Bands> Tickets { get; set; }   // List of user's tickets

        public Users(string Name, int IdUser, string Email, string Password)       // Constructor to initialize the user
        {
            this.idUser = IdUser;
            this.Tickets = new List<Bands>();
            this.email = Email;
            this.password = Password;
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
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