using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int? ModelId { get; set; }
        public int? BrandId { get; set; }
        public int? VehicleTypeId { get; set; }
        public string Plate { get; set; }
        public string Nickname { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }


        public virtual Model? Model { get; set; }
        public virtual VehicleType? VehicleType { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}
