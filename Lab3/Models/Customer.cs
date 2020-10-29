using System.Collections.Generic;

namespace Lab3.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public string FullName => LastName + " " + FirstName + " " + Surname;

        public override string ToString()
        {
            return $"{ID}, {LastName}, {FirstName}, {Surname}, {PhoneNumber}, {Address}";
        }
    }
}