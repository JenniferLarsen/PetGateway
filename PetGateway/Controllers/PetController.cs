using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetGateway.Models;

namespace PetGateway.Controllers
{
    public class PetController : Controller
    {
        private GatewayContext context { get; set; }
        public PetController(GatewayContext ctx) => context = ctx;

        //view all pets for a specific owner
        public IActionResult Index(int ownerId)
        {
            var owner = context.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.OwnerId == ownerId);

            if (owner == null)
            {
                return NotFound();
            }

            // Pass the List<Sample.Models.Pet> to the view
            var pets = owner.Pets.ToList();

            return View(pets);
        }

        // Display the form to add a new pet for a specific owner
        [HttpGet]
        public IActionResult Add(int ownerId)
        {
            ViewBag.OwnerId = ownerId;
            return View();
        }

        // Process the form submission to add a new pet
        [HttpPost]
        public IActionResult Add(int ownerId, Pet pet)
        {
            if (ModelState.IsValid)
            {
                pet.OwnerId = ownerId;
                context.Pets.Add(pet);
                context.SaveChangesAsync();
                return RedirectToAction("Index", new { ownerId });
            }

            ViewBag.OwnerId = ownerId;
            return View(pet);
        }

        // Display the form to edit a specific pet
        [HttpGet]
        [Route("pet/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var pet = context.Pets.Find(id);

            if (pet == null)
            {
                return NotFound();
            }

            // Get the owner information
            var owner = context.Owners.Find(pet.OwnerId);
            // Set owner information in ViewBag
            ViewBag.OwnerFullName = $"{owner.FirstName} {owner.LastName}";

            return View(pet);
        }

        [HttpPost]
        [Route("pet/Edit/{id}")]
        public IActionResult Edit(int id, Pet pet)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    // Adding a new pet
                    pet.OwnerId = ViewBag.OwnerId;
                    context.Pets.Add(pet);
                }
                else
                {
                    // Editing an existing pet
                    var existingPet = context.Pets.Find(id);

                    if (existingPet == null)
                    {
                        return NotFound();
                    }

                    // Update existing pet properties
                    existingPet.PetName = pet.PetName;
                    existingPet.PetType = pet.PetType;
                    existingPet.PetColor = pet.PetColor;
                    existingPet.PetBreed = pet.PetBreed;
                    existingPet.PetAge = pet.PetAge;
                    existingPet.PetGender = pet.PetGender;
                    existingPet.PetWeight = pet.PetWeight;
                    existingPet.Spayed_Neutered = pet.Spayed_Neutered;

                    context.Pets.Update(existingPet);
                }

                context.SaveChanges();
                return RedirectToAction("Index", new { ownerId = ViewBag.OwnerId });
            }

            ViewBag.Action = (id == 0) ? "Add" : "Edit";
            ViewBag.OwnerId = pet.OwnerId;
            return View(pet);
        }


        // Delete a specific pet
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pet = context.Pets.Find(id);

            if (pet == null)
            {
                return NotFound();
            }

            context.Pets.Remove(pet);
            context.SaveChangesAsync();
            return RedirectToAction("Index", new { ownerId = pet.OwnerId });
        }
    }
}
