using System;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TourID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime TripDate { get; set; }
        public int Discount { get; set; }

        public Customer Customer { get; set; }
        public Tour Tour { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Customer}, {Tour}, {TripDate}, {Discount}";
        }
    }
}