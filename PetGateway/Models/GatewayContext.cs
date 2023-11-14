using Microsoft.EntityFrameworkCore;

namespace PetGateway.Models
{
    public class GatewayContext : DbContext
    {
        public GatewayContext(DbContextOptions<GatewayContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<PetService> PetServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ConfigureOwners());
            modelBuilder.ApplyConfiguration(new ConfigurePets());
            modelBuilder.ApplyConfiguration(new ConfigurePetServices());
        }
    }
}
