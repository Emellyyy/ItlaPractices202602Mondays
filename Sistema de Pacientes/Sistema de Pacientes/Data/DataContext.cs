using Microsoft.EntityFrameworkCore;

namespace PatientRegistry.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=PatientRegistryDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}