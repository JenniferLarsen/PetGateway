using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PetGateway.Models
{
    public class ConfigurePets : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> entity)
        {
            //seed initial data
            entity.HasData(

                new Pet
                {
                    PetId = 1,
                    PetName = "Very",
                    PetType = "canine",
                    PetColor = "black and grey",
                    PetBreed = "Yorkshire Terrier",
                    PetAge = 6,
                    PetGender = "male",
                    PetWeight = 13,
                    Spayed_Neutered = true,
                    OwnerId = 1
                },
                new Pet
                {
                    PetId = 2,
                    PetName = "Cooper",
                    PetType = "canine",
                    PetColor = "black and grey",
                    PetBreed = "Yorkshire Terrier",
                    PetAge = 10,
                    PetGender = "male",
                    PetWeight = 11,
                    Spayed_Neutered = true,
                    OwnerId = 2
                },
                new Pet
                {
                    PetId = 3,
                    PetName = "Jasmine",
                    PetType = "feline",
                    PetColor = "grey",
                    PetBreed = "tabby",
                    PetAge = 16,
                    PetGender = "female",
                    PetWeight = 18,
                    Spayed_Neutered = true,
                    OwnerId = 2
                }

                );
        }
    }
}
