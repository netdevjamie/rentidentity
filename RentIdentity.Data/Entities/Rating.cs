using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public string UserRating { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}