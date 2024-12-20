// ----------------------------------------------------------------------
// Student: Diogo Graça
// Email: a28004@alunos.ipca.pt
// 
// This class represents a concert and inherits from the Stages class. 
// It includes details such as the concert's unique identifier, name, 
// date, price, and the band performing. This class is used to manage 
// concert information and interact with other related entities such as bands and stages.
// 
// Features:
// - Represents the concert with properties like ConcertID, name, date, price, and band name.
// - Inherits from Stages, inheriting location and capacity properties.
// - Provides getter and setter methods for each property.
// 
// Regions:
// - Fields: Contains private fields for the properties.
// - Constructor: Initializes the concert with all required details.
// - Properties: Includes properties for the concert's name, date, price, band name, and concert ID.
// ----------------------------------------------------------------------

using ConcertManager;

public class Concerts : Stages
{
    #region Fields

    private int ConcertID { get; set; } // Add ConcertID
    private string Name { get; set; }
    private string Date { get; set; }
    private double Price { get; set; }
    private string BandName { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="Concerts"/> class.
    /// </summary>
    /// <param name="location">The location of the concert.</param>
    /// <param name="capacity">The capacity of the stage.</param>
    /// <param name="name">The name of the concert.</param>
    /// <param name="concertID">The unique identifier of the concert.</param>
    /// <param name="date">The date of the concert.</param>
    /// <param name="price">The ticket price for the concert.</param>
    /// <param name="bandName">The name of the band performing the concert.</param>
    public Concerts(string location, int capacity, string name, int concertID, string date, double price, string bandName) : base(location, capacity)
    {
        this.ConcertID = concertID;
        this.Name = name;
        this.Date = date;
        this.Price = price;
        this.BandName = bandName;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name of the band performing the concert.
    /// </summary>
    public string bandName
    {
        get { return this.BandName; }
        set { this.BandName = value; }
    }

    /// <summary>
    /// Gets or sets the unique identifier of the concert.
    /// </summary>
    public int concertID
    {
        get { return this.ConcertID; }
        set { this.ConcertID = value; }
    }

    /// <summary>
    /// Gets or sets the name of the concert.
    /// </summary>
    public string name
    {
        get { return this.Name; }
        set { this.Name = value; }
    }

    /// <summary>
    /// Gets or sets the date of the concert.
    /// </summary>
    public string date
    {
        get { return this.Date; }
        set { this.Date = value; }
    }

    /// <summary>
    /// Gets or sets the ticket price for the concert.
    /// </summary>
    public double price
    {
        get { return this.Price; }
        set { this.Price = value; }
    }

    #endregion
}