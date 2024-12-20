// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class manages a collection of bands. It allows for adding and removing bands
// from a list. The class provides a list of all bands and methods for modifying 
// the list of bands (adding/removing bands).
// 
// Features:
// - Provides methods to add and remove bands to/from the list.
// - Holds a list of Bands objects.
// - Provides access to the list of bands via a property.
// 
// Regions:
// - Fields: Contains a private field for the list of bands.
// - Constructor: Initializes a new list of bands.
// - Methods: Includes methods to add and remove bands from the list.
// ----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    public class ListBands
    {
        #region Fields

        private List<Bands> bandsList;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBands"/> class.
        /// </summary>
        public ListBands()
        {
            this.bandsList = new List<Bands>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of all bands.
        /// </summary>
        public List<Bands> BandsList
        {
            get { return this.bandsList; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a band to the list of bands.
        /// </summary>
        /// <param name="band">The band to be added.</param>
        public void AddBand(Bands band)
        {
            if (band != null)
            {
                this.bandsList.Add(band);
            }
        }

        /// <summary>
        /// Removes a band from the list of bands.
        /// </summary>
        /// <param name="band">The band to be removed.</param>
        public void RemoveBand(Bands band)
        {
            if (band != null && this.bandsList.Contains(band))
            {
                this.bandsList.Remove(band);
            }
        }

        #endregion
    }
}