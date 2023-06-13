using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DatasDbContext : DbContext
    {
        public DatasDbContext(DbContextOptions<DatasDbContext> options) : base(options)
        {

        }
        public DbSet<Datas> Datas { get; set; }
        //能夠讓建表有特定的狀態        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datas>().Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
