using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class AdultDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //KOM TILBAGE
            //daw
                //SKAL MULIGVIS BRUGE ABSELOUT PATH
            //optionsBuilder.UseSqlite("Data Source = AdultsDb");
        }
    }
}