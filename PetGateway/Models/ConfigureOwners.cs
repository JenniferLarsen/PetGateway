using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetGateway.Models
{
    public class ConfigureOwners : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> entity)
        {
            //seed initial data
            entity.HasData(

                new Owner
                {
                    OwnerId = 1,
                    FirstName = "Amy",
                    LastName = "Miles",
                    Address = "827 Cedar St",
                    City = "Webster City",
                    State = "IA",
                    PostalCode = "50595",
                    PhoneNumber = "5155126039",
                    Email = "missamylmiles@gmail.com"
                },
                 new Owner
                 {
                     OwnerId = 2,
                     FirstName = "Tracey",
                     LastName = "Larrison",
                     Address = "808 Georgia Ave",
                     City = "Palm Harbor",
                     State = "FL",
                     PostalCode = "34683",
                     PhoneNumber = "5152057809",
                     Email = "traceydele@gmail.com"
                 }
            );
        }
    }
}
