using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Favorites")]
    public class Favorites
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("RentalUnits")]
        public int RentalUnitId { get; set; }
        [ForeignKey("Brokers")]
        public int BrokerId { get; set; }
        public ICollection<RentalUnit> RentalUnits { get; set; }
        public ICollection<Broker> Brokers { get; set; }
    }
}