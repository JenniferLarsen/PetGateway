

using PetGateway.Models;


namespace PetGatewayTest
{
    public class OwnerTests
    {
        [Fact]
        public void FullName_ReturnsCorrectFullName()
        {
            // Arrange
            var owner = new Owner
            {
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            var fullName = owner.FullName;

            // Assert
            Assert.Equal("John Doe", fullName);
        }

        [Fact]
        public void Pets_Initialization()
        {
            // Arrange
            var owner = new Owner();

            // Act
            var pets = owner.Pets;

            // Assert
            Assert.NotNull(pets);
            Assert.IsType<HashSet<Pet>>(pets);
        }

        [Fact]
        public void Pets_CanBeAddedToCollection()
        {
            // Arrange
            var owner = new Owner();
            var pet = new Pet();

            // Act
            owner.Pets.Add(pet);

            // Assert
            Assert.Contains(pet, owner.Pets);
        }

    }
}