/**--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Author: Diogo Carvalho Graça  
Email: a28004@alunos.ipca.pt  

This code is free and open for anyone to use, modify, share, or improve without restrictions. It exists in the public domain or is released without any claim of copyright protection.  

Brief: Create a class named Bands that inherits from Concerts. This class will have a band name, genre, and members property.

 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System; 
using ConcertManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
        // Create a class called Bands that inherits from Concerts
        public class Bands : Concerts
        {
        private string BandName { get; set; }
        private string Genre { get; set; }
        private string Members { get; set; }

        // Create a constructor that takes in location, capacity, name, date, bandName, bandGenre, and bandMembers
        public Bands(string location, int capacity, string name, string date, string bandName, string bandGenre, string bandMembers) : base(location, capacity, name, date)
        {
            this.BandName = bandName;
            this.Genre = bandGenre; 
            this.Members = bandMembers;
        }

        // Create a property for bandName
        public string bandName
        {
            get { return this.BandName; }
            set { this.BandName = value; }
        }

        // Create a property for genre
        public string genre
        {
            get { return this.Genre; }
            set { this.Genre = value; }
        }

        // Create a property for members
        public string members
        {
            get { return this.Members; }
            set { this.Members = value; }
        }
    }
}
