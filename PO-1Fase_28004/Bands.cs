using ConcertManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class Bands : Concerts
    {
        private string BandName { get; set; }
        private string Genre { get; set; }
        private string Members { get; set; }

        public Bands(string location, int capacity, string name, string date, string bandName, string bandGenre, string bandMembers) : base(location, capacity, name, date)
        {
            this.BandName = bandName;
            this.Genre = bandGenre; 
            this.Members = bandMembers;
        }

        public string bandName
        {
            get { return this.BandName; }
            set { this.BandName = value; }
        }

        public string genre
        {
            get { return this.Genre; }
            set { this.Genre = value; }
        }
        public string members
        {
            get { return this.Members; }
            set { this.Members = value; }
        }
    }
}
