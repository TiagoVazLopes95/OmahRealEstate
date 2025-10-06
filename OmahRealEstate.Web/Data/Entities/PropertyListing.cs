using System.ComponentModel.DataAnnotations;

namespace OmahRealEstate.Web.Data.Entities
{
    public class PropertyListing : IEntity
    {
        public int Id { get; set; }

        public Property Property { get; set; }

        public string Location => Property.Municipality;

        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy  hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime ListingDate { get; set; }

        public bool IsActive { get; set; }
    }
}
