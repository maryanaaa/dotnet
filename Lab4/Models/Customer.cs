using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Customer
    {
        public int ID { get; set; }
        
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        
        [Display(Name = "По-батькові")]
        public string Surname { get; set; }
        
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Адреса")]
        public string Address { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public string FullName => LastName + " " + FirstName + " " + Surname;

        public override string ToString()
        {
            return $"{ID}, {LastName}, {FirstName}, {Surname}, {PhoneNumber}, {Address}";
        }
    }
}