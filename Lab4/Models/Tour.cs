using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Tour
    {
        public int ID { get; set; }
        
        [Display(Name = "Назва")]
        public string Name { get; set; }
        
        [Display(Name = "Тривалість")]
        public int Duration { get; set; }
        
        [Display(Name = "Ціна")]
        public float Price { get; set; }
        
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Duration}, {Price}, {Description}";
        }
    }
}