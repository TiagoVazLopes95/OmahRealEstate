using System.ComponentModel.DataAnnotations;

namespace OmahRealEstate.Web.Models
{
    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
