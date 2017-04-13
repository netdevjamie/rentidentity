using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Tenant")]
    public class Tenant
    {
        public int Id { get; set; }

        [ForeignKey("Favorites")]
        public int FavoritesId { get; set; }
        public Favorites Favorites { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [ForeignKey("RentalUnit")]
        public int RentalUnitId { get; set; }
        public RentalUnit RentalUnit { get; set; }

    }
}