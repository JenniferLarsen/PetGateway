namespace PetGateway.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; } = string.Empty;

        public string PetType { get; set; } = string.Empty;
        public string PetColor { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public int PetAge { get; set; }
        public string PetGender { get; set; } = string.Empty;

        public int PetWeight { get; set; }

        public bool Spayed_Neutered { get; set; } = false;

        public int OwnerId { get; set; } //foreign key property
        public Owner? Owner { get; set; } = null!;//navigation property
    }
}
