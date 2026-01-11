using Microsoft.AspNetCore.Identity;

namespace OmahRealEstate.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        //public string AboutMe { get; set; }

        //public Agency Agency { get; set; }

        //public IEnumerable<Language> Languages { get; set; };
    }
}
