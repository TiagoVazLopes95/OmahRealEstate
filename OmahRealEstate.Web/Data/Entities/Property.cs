using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace OmahRealEstate.Web.Data.Entities
{
    public class Property : IEntity
    {
        public int Id { get; set; }

        public string PropertyType { get; set; }

        public string Parish { get; set; }

        public string District { get; set; }

        public string Municipality{ get; set; }

        public string Address { get; set; }

        public string? Floor { get; set; }

        public string Door { get; set; }

        public decimal Price { get; set; }

        public decimal? GrossArea { get; set; }

        public decimal? LivingArea { get; set; }

        public decimal? PrivateGrossArea { get; set; }

        public decimal? TotalLotSize { get; set; }

        public int ConstructionYear { get; set; }

        public bool ParkingLot { get; set; }

        public bool? Elevator { get; set; }

        public bool? Garage { get; set; }

        public int Bathrooms { get; set; }

        public int Rooms { get; set; }
    }
}
