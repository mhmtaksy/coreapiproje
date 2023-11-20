using Microsoft.EntityFrameworkCore;

namespace coreapiproje.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        { 

        }
        public DbSet<Magazalar> magazalars { get; set; }
        public DbSet<Kiyafetler> kiyafetlers { get; set; }
        public DbSet<Elemanlar> elemanlars { get; set; } 
        public DbSet<Müsteriler> müsterilers { get; set; }

    }
}
