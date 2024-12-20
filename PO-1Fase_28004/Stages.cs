// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class represents a stage object, which has a location and a capacity.
// It provides the necessary constructors and properties to manage these attributes.
// 
// Features:
// - Allows setting and retrieving the location of the stage.
// - Allows setting and retrieving the capacity of the stage.
// - The class is abstract and meant to be inherited by other classes for further functionality.
// 
// Regions:
// - Fields: Contains private fields for location and capacity.
// - Constructor: Initializes the stage object with location and capacity.
// - Properties: Provides access to location and capacity through properties.
// ----------------------------------------------------------------------

namespace ConcertManager
{
    // Create a class called Stages
    public abstract class Stages
    {
        #region Fields

        // Create private fields for location and capacity
        private string Location { get; set; }
        private int Capacity { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Stages"/> class.
        /// </summary>
        /// <param name="location">The location of the stage.</param>
        /// <param name="capacity">The capacity of the stage.</param>
        public Stages(string location, int capacity)
        {
            this.Location = location;
            this.Capacity = capacity;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the location of the stage.
        /// </summary>
        public string location
        {
            get { return this.Location; }
            set { this.Location = value; }
        }

        /// <summary>
        /// Gets or sets the capacity of the stage.
        /// </summary>
        public int capacity
        {
            get { return this.Capacity; }
            set { this.Capacity = value; }
        }

        #endregion
    }
}