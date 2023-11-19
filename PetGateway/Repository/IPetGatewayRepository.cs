using PetGateway.Models;

namespace PetGateway.Repository
{
    public interface IPetGatewayRepository
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(int ownerId);
        void AddOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(int ownerId);

        IQueryable<Pet> GetAllPets();
        Pet GetPetById(int petId);
        void AddPet(Pet pet);
        void UpdatePet(Pet pet);
        void DeletePet(int petId);

        IEnumerable<PetService> GetAllServices();
        PetService GetServiceById(int serviceId);
        void AddService(PetService service);
        void UpdateService(PetService service);
        void DeleteService(int serviceId);
        void SaveChanges();
    }
}
