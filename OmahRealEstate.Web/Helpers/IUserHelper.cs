using Microsoft.AspNetCore.Identity;
using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Models;

namespace OmahRealEstate.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
