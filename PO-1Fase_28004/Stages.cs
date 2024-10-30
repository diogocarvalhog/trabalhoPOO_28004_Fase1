namespace ConcertManager
    {
        public class Stages
        {
            private string Location { get; set; }
            private int Capacity { get; set; }

            public Stages(string location, int capacity)
            {
                this.Location = location;
                this.Capacity = capacity;
            }

            public string location
            {
                get { return this.Location; }
                set { this.Location = value; }
            }

            public int capacity
            {
                get { return this.Capacity; }
                set { this.Capacity = value; }
            }
        }
    }

