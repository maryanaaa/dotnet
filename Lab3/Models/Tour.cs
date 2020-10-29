using System.Collections.Generic;

namespace Lab3.Models
{
    public class Tour
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Duration}, {Price}, {Description}";
        }
    }
}