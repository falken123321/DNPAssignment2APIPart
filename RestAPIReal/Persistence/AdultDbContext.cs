using LoginExample.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class AdultDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataBase");
        }
    }
}