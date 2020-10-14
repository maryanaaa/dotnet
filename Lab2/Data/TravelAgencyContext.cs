using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data
{
    class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = 127.0.0.1; Port = 5432; Database = TravelAgency; User Id = postgres; Password = admin;");
        }
    }
}
