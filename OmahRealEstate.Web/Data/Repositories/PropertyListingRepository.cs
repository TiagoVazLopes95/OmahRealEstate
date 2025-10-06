using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Data.Repositories.Interfaces;

namespace OmahRealEstate.Web.Data.Repositories
{
    public class PropertyListingRepository : GenericRepository<PropertyListing>, IPropertyListingRepository
    {
        public PropertyListingRepository(DataContext context) : base(context)
        {
            
        }
    }

}
