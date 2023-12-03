using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PetGateway.Models
{
    public class GatewayContext : IdentityDbContext<User>
    {
        public GatewayContext(DbContextOptions<GatewayContext> options) : base(options) { }

        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<PetService> PetServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigureOwners());
            modelBuilder.ApplyConfiguration(new ConfigurePets());
            modelBuilder.ApplyConfiguration(new ConfigurePetServices());
        }
    }
}
