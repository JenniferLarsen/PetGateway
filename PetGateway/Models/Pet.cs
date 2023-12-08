using System.ComponentModel.DataAnnotations;

namespace PetGateway.Models
{
    public class Pet
    {
        public int PetId { get; set; }

		[Required(ErrorMessage = "Pet name is required.")]
		public string PetName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Pet type is required.")]
		public string PetType { get; set; } = string.Empty;
		[Required(ErrorMessage = "Pet color is required.")]
		public string PetColor { get; set; } = string.Empty;
		[Required(ErrorMessage = "Pet breed is required.")]
		public string PetBreed { get; set; } = string.Empty;
		[Range(0, int.MaxValue, ErrorMessage = "Pet age must be a non-negative number.")]
		public int PetAge { get; set; }
		[Required(ErrorMessage = "Pet gender is required.")]
		public string PetGender { get; set; } = string.Empty;
		[Range(0, int.MaxValue, ErrorMessage = "Pet weight must be a non-negative number.")]
		public int PetWeight { get; set; }

        public bool Spayed_Neutered { get; set; } = false;

        public int OwnerId { get; set; } //foreign key property
        public Owner? Owner { get; set; } = null!;//navigation property
    }
}
