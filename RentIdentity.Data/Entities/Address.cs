using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string AptNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }
}