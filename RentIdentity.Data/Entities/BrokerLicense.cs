using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("BrokerLicense")]
    public class BrokerLicense
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public string State { get; set; }
    }
}