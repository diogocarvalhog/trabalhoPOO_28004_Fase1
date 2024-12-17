using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class ListBands
    {
        private List<Bands> bandsList;
        public ListBands()
        {
            this.bandsList = new List<Bands>();
        }
        public List<Bands> BandsList
        {
            get { return this.bandsList; }
        }
        public void AddBand(Bands band)
        {
            if (band != null)
            {
                this.bandsList.Add(band);
            }
        }
        public void RemoveBand(Bands band)
        {
            if (band != null && this.bandsList.Contains(band))
            {
                this.bandsList.Remove(band);
            }
        }
    }
}