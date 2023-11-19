using Microsoft.EntityFrameworkCore;
using PetGateway.Models;

namespace PetGateway.Repository
{
    public class PetGatewayRepository : IPetGatewayRepository
    {
        private readonly GatewayContext context;

        public PetGatewayRepository(GatewayContext ctx)
        {
            context = ctx;
        }

        // Owner methods
        public IEnumerable<Owner> GetAllOwners()
        {
            return context.Owners.ToList();
        }

        public Owner GetOwnerById(int ownerId)
        {
            return context.Owners.Find(ownerId) ?? throw new InvalidOperationException($"Pet with ID {ownerId} not found.");
        }

        public void AddOwner(Owner owner)
        {
            context.Owners.Add(owner);
            context.SaveChanges();
        }

        public void UpdateOwner(Owner owner)
        {
            context.Owners.Update(owner);
            context.SaveChanges();
        }

        public void DeleteOwner(int ownerId)
        {
            var owner = context.Owners.Find(ownerId);
            if (owner != null)
            {
                context.Owners.Remove(owner);
                context.SaveChanges();
            }
        }

        // Pet methods
        public IQueryable<Pet> GetAllPets()
        {
            return context.Pets.Include(p => p.Owner);
        }

        public Pet GetPetById(int petId)
        {
            return context.Pets.Find(petId) ?? throw new InvalidOperationException($"Pet with ID {petId} not found.");
        }

        public void AddPet(Pet pet)
        {
            context.Pets.Add(pet);
            context.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            context.Pets.Update(pet);
            context.SaveChanges();
        }

        public void DeletePet(int petId)
        {
            var pet = context.Pets.Find(petId);
            if (pet != null)
            {
                context.Pets.Remove(pet);
                context.SaveChanges();
            }
        }

        // PetService methods
        public IEnumerable<PetService> GetAllServices()
        {
            return context.PetServices.ToList();
        }

        public PetService GetServiceById(int serviceId)
        {
            return context.PetServices.Find(serviceId) ?? throw new InvalidOperationException($"Pet with ID {serviceId} not found.");
        }

        public void AddService(PetService service)
        {
            context.PetServices.Add(service);
            context.SaveChanges();
        }

        public void UpdateService(PetService service)
        {
            context.PetServices.Update(service);
            context.SaveChanges();
        }

        public void DeleteService(int serviceId)
        {
            var service = context.PetServices.Find(serviceId);
            if (service != null)
            {
                context.PetServices.Remove(service);
                context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }



    }
}
