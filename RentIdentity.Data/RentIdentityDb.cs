using System.Data.Entity.ModelConfiguration.Conventions;
using RentIdentity.Data;
using RentIdentity.Data.Entities;

namespace RentIdentity.Data
{
    using System.Data.Entity;

    public partial class RentIdentityDb : DbContext
    {
        public RentIdentityDb()
            : base("name=RentIdentityDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Broker> Brokers { get; set; }
        public virtual DbSet<Landlord> Landlords { get; set; }

        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<RentalUnit> RentalUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Add(new RemoveEFUnderscore());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AppUser>();

            modelBuilder.Entity<Person>();

            modelBuilder.Entity<Broker>();

            modelBuilder.Entity<Landlord>();

            modelBuilder.Entity<Property>();

            modelBuilder.Entity<Tenant>();

            modelBuilder.Entity<RentalUnit>();

        }
    }
}
