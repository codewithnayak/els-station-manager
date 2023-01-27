using Microsoft.EntityFrameworkCore;

namespace StationManagerApi.Db
{
    public class StationDbContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public StationDbContext(DbContextOptions options) : base(options)
        {
            // if(options.ContextType.)}

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StationConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            
            modelBuilder.Entity<Station>()
                 .HasOne(a => a.Address)
                 .WithOne(b => b.Station)
                 .HasForeignKey<Address>(a => a.StationId);
        }
    }
}
