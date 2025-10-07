using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmahRealEstate.Web.Data.Entities;

namespace OmahRealEstate.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyListing> PropertyListings { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {            
        }
    }
}
