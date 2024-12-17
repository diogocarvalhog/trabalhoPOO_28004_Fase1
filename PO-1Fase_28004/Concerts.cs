/**--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Author: Diogo Carvalho Graça  
Email: a28004@alunos.ipca.pt  

This code is free and open for anyone to use, modify, share, or improve without restrictions. It exists in the public domain or is released without any claim of copyright protection.  

Brief: Create a class named Concerts that inherits from Stages. This class will have a name and date property.

 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    // Create a class called Concerts that inherits from Stages
    public class Concerts : Stages
    {
        private string Name { get; set; }
        private string Date { get; set; }
        private double Price { get; set; }

        // Create a constructor that takes in location, capacity, name, and date
        public Concerts(string location, int capacity, string name, string date, double price) : base(location, capacity)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }

        // Create a property for name
        public string name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        // Create a property for date
        public string date
        {
            get { return this.Date; }
            set { this.Date = value; }
        }
        public double price
        {
            get { return this.Price; }
            set { this.Price = value; }
        }
    }
}
