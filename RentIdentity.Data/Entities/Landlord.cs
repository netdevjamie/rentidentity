using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Landlord")]
    public class Landlord
    {
        [Key]
        public int Id { get; set; }
        public bool HasBroker { get; set; }

        [ForeignKey("Brokers")]
        public int BrokerId { get; set; }
        public ICollection<Broker> Brokers { get; set; }
    }
}