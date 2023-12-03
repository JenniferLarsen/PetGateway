using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetGateway.Models;
using PetGateway.Repository;

namespace PetGateway.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        //private GatewayContext context { get; set; }
        //public PetController(GatewayContext ctx) => context = ctx;

        private readonly IPetGatewayRepository repo;

        public PetController(IPetGatewayRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public IActionResult Index(int ownerId)
        {
            var pets = repo.GetAllPets()
                .Include(p => p.Owner) // Include the Owner navigation property
                .Where(p => p.OwnerId == ownerId)
                .ToList();

            return View(pets);
        }

        //view All pets
        [HttpGet]
        public IActionResult ViewAll()
        {
            var pets = repo.GetAllPets()
                .Include(p => p.Owner) // Include the Owner navigation property
                .ToList();

            return View("Index", pets);
        }



        // Display the form to add a new pet for a specific owner
  
        [HttpGet]
        public IActionResult Add(int ownerId)
        {
            ViewBag.Action = "Add";
            ViewBag.Owners = new SelectList(repo.GetAllOwners(), "OwnerId", "FullName"); //Added this line to create list of owners - JLL
            return View("Edit", new Pet());
        }

        // Display the form to edit a specific pet
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pet = repo.GetPetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            ViewBag.Owners = new SelectList(repo.GetAllOwners(), "OwnerId", "FullName", pet.OwnerId);

            // Ensure that the OwnerId is set in the ViewBag for the Cancel button
            ViewBag.OwnerId = pet.OwnerId;

            return View(pet);
        }


        [HttpPost]       
        public IActionResult Edit(Pet pet)
        {
            if (ModelState.IsValid)
            {
                if (pet.PetId== 0)
                {
                    // Adding a new pet
                    //pet.OwnerId = ViewBag.OwnerId;//may not need - Had to comment out - was causing errors adding pet - JLL
                    repo.AddPet(pet);
                }
                else
                {                             

                    repo.UpdatePet(pet);
                }

                repo.SaveChanges();
                return RedirectToAction("Index",new { ownerId = pet.OwnerId });
            }

            ViewBag.Action = (pet.PetId == 0) ? "Add" : "Edit";
            //ViewBag.OwnerId = pet.OwnerId;
            return View(pet);
        }

        [HttpPost]
        public IActionResult Cancel(int ownerId)
        {
            // Redirect to the list of pets for the specific owner
            return RedirectToAction("Index", "Pet", new { ownerId });
        }


        // Delete a specific pet
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pet = repo.GetPetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            repo.DeletePet(id);
            repo.SaveChanges();
            return RedirectToAction("Index", new { ownerId = pet.OwnerId });
        }
    }
}
