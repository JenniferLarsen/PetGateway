using Microsoft.AspNetCore.Mvc;
using PetGateway.Models;

namespace PetGateway.Controllers
{
    public class OwnerController : Controller
    {
        private GatewayContext context { get; set; }
        public OwnerController(GatewayContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var owners = context.Owners.OrderBy(o => o.LastName).ToList();
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
            var owner = context.Owners.Find(id);
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
                    context.Owners.Add(owner);
                else
                    context.Owners.Update(owner);
                context.SaveChanges();
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
            var owner = context.Owners.Find(id);

            if (owner == null)
            {
                return NotFound();
            }

            context.Owners.Remove(owner);
            context.SaveChanges();

            return RedirectToAction("Index", "Owner");

        }
    }
}
