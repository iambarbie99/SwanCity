using Microsoft.EntityFrameworkCore;
using SwanCity.Models;

namespace SwanCity.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        // Define tables
        public DbSet<Route> Routes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite database file path
            optionsBuilder.UseSqlite("Data Source=swancity.db");
        }
    }
}
