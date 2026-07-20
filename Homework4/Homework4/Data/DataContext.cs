using Microsoft.EntityFrameworkCore;

namespace Homework4.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StudentRegistryDb2026;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}