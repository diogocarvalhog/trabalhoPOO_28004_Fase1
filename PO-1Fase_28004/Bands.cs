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
    /// <summary>
    /// Represents a band that performs concerts.
    /// </summary>
    public class Bands
    {
        #region Fields

        private string BandName { get; set; }
        private string Genre { get; set; }
        private string Members { get; set; }
        private List<Concerts> Concerts { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Bands"/> class.
        /// </summary>
        /// <param name="bandName">The name of the band.</param>
        /// <param name="bandGenre">The genre of the band.</param>
        /// <param name="bandMembers">The members of the band.</param>
        public Bands(string bandName, string bandGenre, string bandMembers)
        {
            this.BandName = bandName;
            this.Genre = bandGenre;
            this.Members = bandMembers;
            this.Concerts = new List<Concerts>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the band name.
        /// </summary>
        public string bandName
        {
            get { return this.BandName; }
            set { this.BandName = value; }
        }

        /// <summary>
        /// Gets or sets the genre of the band.
        /// </summary>
        public string genre
        {
            get { return this.Genre; }
            set { this.Genre = value; }
        }

        /// <summary>
        /// Gets or sets the members of the band.
        /// </summary>
        public string members
        {
            get { return this.Members; }
            set { this.Members = value; }
        }

        /// <summary>
        /// Gets the list of concerts for the band.
        /// </summary>
        public List<Concerts> concerts
        {
            get { return this.Concerts; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a concert to the band's concert list.
        /// </summary>
        /// <param name="concert">The concert to be added.</param>
        public void AddConcert(Concerts concert)
        {
            if (concert != null)
            {
                this.Concerts.Add(concert);
            }
        }

        /// <summary>
        /// Removes a concert from the band's concert list.
        /// </summary>
        /// <param name="concert">The concert to be removed.</param>
        public void RemoveConcert(Concerts concert)
        {
            if (concert != null && this.Concerts.Contains(concert))
            {
                this.Concerts.Remove(concert);
            }
        }

        #endregion
    }
}