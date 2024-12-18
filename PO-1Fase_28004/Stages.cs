/**--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Author: Diogo Carvalho Graça  
Email: a28004@alunos.ipca.pt  

This code is free and open for anyone to use, modify, share, or improve without restrictions. It exists in the public domain or is released without any claim of copyright protection.  

Brief: Class that creates a stage object with location and capacity. With the needed injectors and constructors.

 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
namespace ConcertManager
    {
    // Create a class called Stages
    public abstract class Stages
        {
            // Create private fields for location and capacity
            private string Location { get; set; }
            private int Capacity { get; set; }

            // Create a constructor that takes in location and capacity
            public Stages(string location, int capacity)
            {
                this.Location = location;
                this.Capacity = capacity;
            }

            // Create a property for location
            public string location
            {
                get { return this.Location; }
                set { this.Location = value; }
            }
            // Create a property for capacity
            public int capacity
            {
                get { return this.Capacity; }
                set { this.Capacity = value; }
            }
        }
    }

