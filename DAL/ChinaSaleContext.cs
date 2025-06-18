using final_project.Moddels;
using Microsoft.EntityFrameworkCore;

namespace final_project.DAL
{
    public class ChinaSaleContext: DbContext
    {
      
        public DbSet<User>  Users{ get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<GiftCategory> GiftCategories { get; set; }
        public ChinaSaleContext(DbContextOptions<ChinaSaleContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
