using System.ComponentModel.DataAnnotations;

namespace PetGateway.Models
{
    public class Owner
    {
        
        public Owner() => Pets = new HashSet<Pet>();

        public int OwnerId { get; set; }

		[Required(ErrorMessage = "First name is required.")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last name is required.")]
		public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postal Code is required.")]
        public string PostalCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty;

		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public string Email { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Pet> Pets { get; set; } 
    }
}
