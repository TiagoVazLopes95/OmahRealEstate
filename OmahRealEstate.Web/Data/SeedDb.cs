using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Helpers;

namespace OmahRealEstate.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        /// <summary>
        /// Here you can add code to seed your database with initial data if needed.
        /// </summary>
        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();
            
            var user = await _userHelper.GetUserByEmailAsync("demoappemail.255@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Tiago",
                    LastName = "Lopes",
                    Email = "demoappemail.255@gmail.com",
                    UserName = "demoappemail.255@gmail.com",
                };

                var result = await _userHelper.AddUserAsync(user,"123456");

                if(!result.Succeeded)
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }
            }
        }


    }
}
