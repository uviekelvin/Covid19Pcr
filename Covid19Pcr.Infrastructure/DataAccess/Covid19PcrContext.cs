using Covid19Pcr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Covid19Pcr.Infrastructure.DataAccess
{
    public class Covid19PcrContext : DbContext
    {

        public Covid19PcrContext(DbContextOptions<Covid19PcrContext> options) : base(options) { }


        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Labs> Labs { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<TestDays> TestDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
