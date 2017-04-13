using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("AppUser")]

    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string UserType { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public Person Person { get; set; }

    }


}