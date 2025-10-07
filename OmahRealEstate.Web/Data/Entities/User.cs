using Microsoft.AspNetCore.Identity;

namespace OmahRealEstate.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";


    }
}
