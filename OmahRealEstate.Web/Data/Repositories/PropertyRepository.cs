using OmahRealEstate.Web.Data.Entities;
using OmahRealEstate.Web.Data.Repositories.Interfaces;

namespace OmahRealEstate.Web.Data.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(DataContext context) : base(context)
        {
            
        }
    }
}
