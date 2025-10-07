using Microsoft.EntityFrameworkCore;
using OmahRealEstate.Web.Data.Entities;

namespace OmahRealEstate.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();
            // Here you can add code to seed your database with initial data if needed.
        }


    }
}
