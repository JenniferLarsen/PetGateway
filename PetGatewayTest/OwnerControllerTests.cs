using System.Collections.Generic;

    namespace PetGateway.Tests
    {
        [TestClass]
        public class OwnerControllerTests
        {
            private readonly Mock<IPetGatewayRepository> _mockRepo;

            public OwnerControllerTests()
            {
                _mockRepo = new Mock<IPetGatewayRepository>();
            }

            [TestMethod] //return all owners test ckc
            public void Index_ShouldReturnAllOwners()
            {
                
                var expectedOwners = new List<Owner>()
            {
                new Owner { OwnerId = 4, FirstName = "Candy", LastName = "Coleman" },
             
            };

                _mockRepo.Setup(m => m.GetAllOwners()).Returns(expectedOwners);

                var controller = new OwnerController(_mockRepo.Object);

                
                var result = controller.Index();

                
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.AreEqual(expectedOwners, viewResult.Model);
            }

            [TestMethod] //edit all owners test ckc
            public void Add_ShouldReturnEditViewWithNewOwner()
            {
               
                var controller = new OwnerController(_mockRepo.Object);

                
                var result = controller.Add();

             
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.AreEqual("Add", viewResult.ViewData["Action"]);
                Assert.IsInstanceOfType(viewResult.Model, typeof(Owner));
            }

            [TestMethod] //return not found CKC
            public void Edit_ShouldReturnNotFoundForInvalidId()
            {
              
                var controller = new OwnerController(_mockRepo.Object);

               
                var result = controller.Edit(0);

                
                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }

            [TestMethod]
            public void Edit_ShouldReturnEditViewWithExistingOwner()
            {
                
                var owner = new Owner { OwnerId = 4, FirstName = "Candy", LastName = "Coleman" };
                _mockRepo.Setup(m => m.GetOwnerById(1)).Returns(owner);

                var controller = new OwnerController(_mockRepo.Object);

               
                var result = controller.Edit(1);

               
                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var viewResult = (ViewResult)result;
                Assert.AreEqual("Edit", viewResult.ViewData["Action"]);
                Assert.AreEqual(owner, viewResult.Model);
            }


            [TestMethod] //edit and redirect ckc
            public void Edit_ShouldAddAndRedirectToIndexForNewOwner()
            {
                var owner = new Owner { FirstName = "Candy", LastName = "Coleman" };
                _mockRepo.Setup(m => m.AddOwner(owner));

                var controller = new OwnerController(_mockRepo.Object);

                var result = controller.Edit(owner);

                Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
                var redirectResult = (RedirectToRouteResult)result;
                Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
                Assert.AreEqual("Owner", redirectResult.RouteValues["controller"]);
            }

            [TestMethod]
        