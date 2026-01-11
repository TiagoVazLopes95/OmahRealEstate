using System.ComponentModel.DataAnnotations;

namespace OmahRealEstate.Web.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]   
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public int Age { get; set; }


        [Required]
        public string City { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Confirm { get; set; }

    }
}
