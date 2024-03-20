using Microsoft.EntityFrameworkCore;
using TShop.Models;

namespace TShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TheatreShow> TheatreShows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TShopUser> TShopUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TheatreShow)
                .WithMany(ts => ts.Tickets)
                .HasForeignKey(t => t.TheatreShowId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);
        }
    }
}
