// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class represents a user in the system, storing their email, password,
// unique ID, and a list of tickets (represented by bands). It provides methods 
// to add or remove tickets for the user and allows access to their information.
// 
// Features:
// - Stores the user's email, password, and unique ID.
// - Holds a list of tickets (Bands) associated with the user.
// - Provides methods to add or remove tickets from the user's list.
// - Allows access to user details through properties.
// 
// Regions:
// - Fields: Contains private fields for user email, password, ID, and tickets.
// - Constructor: Initializes the user with email, password, and ID.
// - Properties: Provides access to email, password, ID, and tickets.
// - Methods: Includes methods to add or remove tickets from the list.
// ----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertManager
{
    /// <summary>
    /// Represents a user in the system, with email, password, a unique ID, and a list of tickets.
    /// </summary>
    public class Users
    {
        #region Fields

        private string email { get; set; }           // User's email
        private string password { get; set; }       // User's password
        private int idUser { get; set; }            // Unique user ID
        private List<Bands> Tickets { get; set; }   // List of user's tickets

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class.
        /// </summary>
        /// <param name="Name">The name of the user (not used in the current implementation).</param>
        /// <param name="IdUser">The unique ID of the user.</param>
        /// <param name="Email">The user's email address.</param>
        /// <param name="Password">The user's password.</param>
        public Users(string Name, int IdUser, string Email, string Password)
        {
            this.idUser = IdUser;
            this.Tickets = new List<Bands>();
            this.email = Email;
            this.password = Password;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        /// <summary>
        /// Gets the unique user ID.
        /// </summary>
        public int IdUser
        {
            get { return this.idUser; }
        }

        /// <summary>
        /// Gets the list of bands (tickets) that the user owns.
        /// </summary>
        public List<Bands> Bands
        {
            get { return this.Tickets; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a ticket (band) to the user's list.
        /// </summary>
        /// <param name="ticket">The band to be added to the user's tickets list.</param>
        public void add(Bands ticket)
        {
            this.Tickets.Add(ticket);
        }

        /// <summary>
        /// Removes a ticket (band) from the user's list.
        /// </summary>
        /// <param name="ticket">The band to be removed from the user's tickets list.</param>
        public void remove(Bands ticket)
        {
            this.Tickets.Remove(ticket);
        }

        #endregion
    }
}