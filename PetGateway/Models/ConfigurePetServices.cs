using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetGateway.Models
{
    public class ConfigurePetServices : IEntityTypeConfiguration<PetService>
    {
        public void Configure(EntityTypeBuilder<PetService> entity)
        {

            entity.HasData(
            new PetService { ServiceId = 1, ServiceName = "Visit", Cost = 25 },
            new PetService { ServiceId = 2, ServiceName = "X-ray", Cost = 60 },
            new PetService { ServiceId = 3, ServiceName = "Neuter", Cost = 100 },
            new PetService { ServiceId = 4, ServiceName = "Dental", Cost = 50 },
            new PetService { ServiceId = 5, ServiceName = "Vaccine", Cost = 11 },
            new PetService { ServiceId = 6, ServiceName = "Anesthesia", Cost = 60 }
            );
        }
    }
}
