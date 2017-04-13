using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Property")]
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Broker")]
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
        [ForeignKey("Landlords")]
        public int LandlordId { get; set; }
        public ICollection<Landlord> Landlords { get; set; }
        [ForeignKey("RentalUnits")]
        public int RentalUnitId { get; set; }
        public ICollection<RentalUnit> RentalUnits { get; set; }
    }
}