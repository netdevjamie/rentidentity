using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentIdentity.Data.Entities
{
    [Table("RentalUnit")]
    public class RentalUnit
    {
        [Key]
        public int Id { get; set; }
        public string RentalUnitBrokerId { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTimeOffset DateAvailable { get; set; }
        public string RentalUnitAddress { get; set; }
        public int SquareFeet { get; set; }
        public int NumStories { get; set; }
        public int NumRooms { get; set; }
        public int NumBath { get; set; }
        public bool IsPetFriendly { get; set; }

        [ForeignKey("Tenants")]
        public int TenantId { get; set; }
        public ICollection<Tenant> Tenants { get; set; }

        [ForeignKey("Landlords")]
        public int LandlordId { get; set; }
        public ICollection<Landlord> Landlords { get; set; }
    }
}