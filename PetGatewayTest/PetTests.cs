using PetGateway.Models;
using Xunit;

namespace PetGatewayTest
{
    public class PetTests
    {

        [Fact]
        public void Pet_InitializationWithValues()
        {
            // Arrange
            var owner = new Owner { OwnerId = 1, FirstName = "John", LastName = "Doe" };

            // Act
            var pet = new Pet
            {
                PetName = "Fido",
                PetType = "Dog",
                PetColor = "Brown",
                PetBreed = "Labrador",
                PetAge = 3,
                PetGender = "Male",
                PetWeight = 25,
                Spayed_Neutered = true,
                OwnerId = owner.OwnerId,
                Owner = owner
            };

            // Assert
            Assert.Equal("Fido", pet.PetName);
            Assert.Equal("Dog", pet.PetType);
            Assert.Equal("Brown", pet.PetColor);
            Assert.Equal("Labrador", pet.PetBreed);
            Assert.Equal(3, pet.PetAge);
            Assert.Equal("Male", pet.PetGender);
            Assert.Equal(25, pet.PetWeight);
            Assert.True(pet.Spayed_Neutered);
            Assert.Equal(owner.OwnerId, pet.OwnerId);
            Assert.Same(owner, pet.Owner);
        }

        [Fact]
        public void Pet_SettersAndGetters()
        {
            // Arrange
            var pet = new Pet();

            // Act
            pet.PetName = "Whiskers";
            pet.PetType = "Cat";
            pet.PetColor = "Gray";
            pet.PetBreed = "Siamese";
            pet.PetAge = 2;
            pet.PetGender = "Female";
            pet.PetWeight = 10;
            pet.Spayed_Neutered = false;
            pet.OwnerId = 2;

            // Assert
            Assert.Equal("Whiskers", pet.PetName);
            Assert.Equal("Cat", pet.PetType);
            Assert.Equal("Gray", pet.PetColor);
            Assert.Equal("Siamese", pet.PetBreed);
            Assert.Equal(2, pet.PetAge);
            Assert.Equal("Female", pet.PetGender);
            Assert.Equal(10, pet.PetWeight);
            Assert.False(pet.Spayed_Neutered);
            Assert.Equal(2, pet.OwnerId);
        }


    }
}
