using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Broker")]
    public class Broker
    {
        [Key]
        public int Id { get; set; }
        public bool IsLandlord { get; set; }

        public virtual Person Person { get; set; }

        [ForeignKey("BrokerLicense")]
        public int BrokerLicenseId { get; set; }
        [ForeignKey("Properties")]
        public int  PropertyId { get; set; }
        [ForeignKey("Landlords")]
        public int LandlordId { get; set; }
        public BrokerLicense BrokerLicense { get; set; }
        public ICollection<Landlord> Landlords { get; set; }
        public ICollection<Property> Properties { get; set; }

    }
}