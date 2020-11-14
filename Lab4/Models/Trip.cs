using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TourID { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime TripDate { get; set; }
        
        [Display(Name = "Знижка")]
        public int Discount { get; set; }

        
        [Display(Name = "Клієнт")]
        public Customer Customer { get; set; }
        
        [Display(Name = "Тур")]
        public Tour Tour { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Customer}, {Tour}, {TripDate}, {Discount}";
        }
    }
}