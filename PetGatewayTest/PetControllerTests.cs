using System.Collections.Generic;

namespace PetGateway.Tests.Controllers
{
    [TestClass]
    public class PetControllerTests
    {
        private readonly Mock<IPetGatewayRepository> _mockRepo;

        public PetControllerTests()
        {
            _mockRepo = new Mock<IPetGatewayRepository>();
        }

        [TestMethod]//return pets for owner ckc
        public void Index_ShouldReturnPetsForSpecificOwner()
        {

            var owner = new Owner { OwnerId = 4, FirstName = "Candy", LastName = "Coleman" };
            var pets = new List<Pet>()
            {
                new Pet { PetId = 1, Name = "Amy", Owner = owner },
                new Pet { PetId = 2, Name = "Jen", Owner = owner }
            };

            _mockRepo.Setup(m => m.GetAllPets())
                .Returns(pets.AsQueryable());
            _mockRepo.Setup(m => m.GetAllOwners())
                .Returns(new List<Owner>() { owner });

            var controller = new PetController(_mockRepo.Object);


            var result = controller.Index(owner.OwnerId);


            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(pets, viewResult.Model);
        }

        [TestMethod] //return of all pets ckc
        public void ViewAll_ShouldReturnAllPets()
        {

            var owner = new Owner { OwnerId = 4, FirstName = "Candy", LastName = "Coleman" };
            var pets = new List<Pet>()
            {
                new Pet { PetId = 1, Name = "Jen", Owner = owner },
                new Pet { PetId = 2, Name = "Amy", Owner = owner }
            };

            _mockRepo.Setup(m => m.GetAllPets())
                .Returns(pets.AsQueryable());
            _mockRepo.Setup(m => m.GetAllOwners())
                .Returns(new List<Owner>() { owner });

            var controller = new PetController(_mockRepo.Object);


            var result = controller.ViewAll();


            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(pets, viewResult.Model);
        }

        [TestMethod] //edit review of new pets ckc
        public void Add_ShouldReturnEditViewWithNewPetAndListOfOwners()
        {

            var owner = new Owner { OwnerId = 1, FirstName = "Candy", LastName = "Coleman" };
            _mockRepo.Setup(m => m.GetAllOwners())
                .Returns(new List<Owner>() { owner });

            var controller = new PetController(_mockRepo.Object);


            var result = controller.Add(owner.OwnerId);


            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual("Add", viewResult.ViewData["Action"]);
            Assert.IsInstanceOfType(viewResult.Model, typeof(Pet));
            Assert.IsInstanceOfType(viewResult.ViewData["Owners"], typeof(SelectList));
        }

        [TestMethod] //not found invalid id ckc
        public void Edit_ShouldReturnNotFoundForInvalidId()
        {

            var controller = new PetController(_mockRepo.Object);


            var result = controller.Edit(0);


            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod] //list of existing pets and owners ckc
        public void Edit_ShouldReturnEditViewWithExistingPetAndListOfOwners()
        {

            var owner = new Owner { OwnerId = 1, FirstName = "Candy", LastName = "Coleman" };
            var pet = new Pet { PetId = 1, Name = "Jen", Owner = owner };

            _mockRepo.Setup(m => m.GetPetById(1))