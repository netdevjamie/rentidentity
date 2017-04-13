using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstName;

        [Display(Name = "Email Address")]
        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 50 characters.")]
        public string PhoneNumber { get; set; }

        //plan to use external image storage here, not implemented
        public string ImageUrl { get; set; }

        public ICollection<Address> Addresses { get; set; }



    }
}



