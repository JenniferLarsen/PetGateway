﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetGateway.Models;

namespace PetGateway.Controllers
{
    public class PetController : Controller
    {
        private GatewayContext context { get; set; }
        public PetController(GatewayContext ctx) => context = ctx;

        //view all pets for a specific owner
        [HttpGet]
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
            ViewBag.Action = "Add";
            ViewBag.Owners = new SelectList(context.Owners, "OwnerId", "FullName"); //Added this line to create list of owners - JLL
            return View("Edit", new Pet());
        }  

        // Display the form to edit a specific pet
        [HttpGet]       
        public IActionResult Edit(int id)
        {
            var pet = context.Pets.Find(id);

            if (pet == null)
            {
                return NotFound();
            }

            //added viewbag properties to update owner list
            ViewBag.Action = "Edit";
            ViewBag.Owners = new SelectList(context.Owners, "OwnerId", "FullName", pet.OwnerId);
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
                    context.Pets.Add(pet);
                }
                else
                {                             

                    context.Pets.Update(pet);
                }

                context.SaveChanges();
                return RedirectToAction("Index",new { ownerId = pet.OwnerId });
            }

            ViewBag.Action = (pet.PetId == 0) ? "Add" : "Edit";
            //ViewBag.OwnerId = pet.OwnerId;
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
