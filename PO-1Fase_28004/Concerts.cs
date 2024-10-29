using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class Concerts : Stages
    {
        private string Name { get; set; }
        private string Date { get; set; }

        public Concerts(string location, int capacity, string name, string date) : base(location, capacity)
        {
            this.Name = name;
            this.Date = date;
        }

        public string name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public string date
        {
            get { return this.Date; }
            set { this.Date = value; }
        }
    }
}
