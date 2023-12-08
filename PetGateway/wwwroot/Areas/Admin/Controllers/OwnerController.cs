using Microsoft.AspNetCore.Mvc;

namespace PetGateway.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OwnerController : Controller
    {
        private readonly IPetGatewayRepository repo;

        public OwnerController(IPetGatewayRepository repository)
        {
            repo = repository;
        }

        public IActionResult Index()
        {
            var owners = repo.GetAllOwners().OrderBy(o => o.LastName).ToList();
            return View(owners);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Owner());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var owner = repo.GetOwnerById(id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        [HttpPost]
        public IActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                if (owner.OwnerId == 0)
                    repo.AddOwner(owner);
                else
                    repo.UpdateOwner(owner);
                repo.SaveChanges();
                return RedirectToAction("Index", "Owner");
            }
            else
            {
                ViewBag.Action = (owner.OwnerId == 0) ? "Add" : "Edit";
                return View(owner);
            }
        }

     
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var owner = repo.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }

            repo.DeleteOwner(id);
            repo.SaveChanges();

            return RedirectToAction("Index", "Owner");

        }
    }
}
