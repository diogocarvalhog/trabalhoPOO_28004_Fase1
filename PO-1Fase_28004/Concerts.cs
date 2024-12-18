using ConcertManager;

public class Concerts : Stages
{
    private int ConcertID { get; set; } // Add ConcertID
    private string Name { get; set; }
    private string Date { get; set; }
    private double Price { get; set; }

    public Concerts(string location, int capacity, string name, int concertID, string date, double price): base(location, capacity)
    {
        this.ConcertID = concertID;
        this.Name = name;
        this.Date = date;
        this.Price = price;
    }

    // Property for ConcertID
    public int concertID
    {
        get { return this.ConcertID; }
        set { this.ConcertID = value; }
    }

    // Other properties...
    public string name 
    {
        get { return this.Name;}
        set { this.Name = value;}
    }

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