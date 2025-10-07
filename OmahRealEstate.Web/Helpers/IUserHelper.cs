using Microsoft.AspNetCore.Identity;
using OmahRealEstate.Web.Data.Entities;

namespace OmahRealEstate.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);   
    }
}
