using System.Collections.Generic;

namespace Lab2.Models
{
    class Customer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return $"{ID}, {LastName}, {FirstName}, {Surname}, {PhoneNumber}, {Address}";
        }
    }
}
