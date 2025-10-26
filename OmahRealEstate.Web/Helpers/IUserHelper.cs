using Microsoft.AspNetCore.Identity;
using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Models;
using System.Security.Claims;

namespace OmahRealEstate.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task CreateUserClaims(User user, bool isPersistent, List<Claim> claimList);
    }
}
