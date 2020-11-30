using Microsoft.EntityFrameworkCore;

using Lab5.Models;

namespace Lab5.Data
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Tour> Tours { get; set; }
    }
}