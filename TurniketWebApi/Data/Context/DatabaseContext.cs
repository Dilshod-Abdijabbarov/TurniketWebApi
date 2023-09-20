using Microsoft.EntityFrameworkCore;
using TurniketWebApi.Models;

namespace TurniketWebApi.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            Database.Migrate();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
