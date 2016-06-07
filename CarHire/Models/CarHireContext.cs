using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using System.Data.Entity;

    using CarHire.Models.Locations;
    using CarHire.Models.User_Classes;

    using Microsoft.Ajax.Utilities;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CarHireContext : IdentityDbContext<UserAccount>
    {
        public CarHireContext()
            : base("CarHireConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarHireContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarHireContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarHireContext, Configuration>());
            //base.OnModelCreating(modelBuilder);
        }
        //do we need this?
        public DbSet<StoreLocation> StoreLocations { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<BusinessHours> BusinessHours { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public override IDbSet<UserAccount> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Loan> Loans { get; set; }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<UserAccount>().ToTable("Users").Property(p => p.Id).HasColumnName("User Id");
            modelBuilder.Entity<UserLocation>().ToTable("UsersLocations");

            modelBuilder.Entity<StoreLocation>().ToTable("StoreLocations");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsersClaims");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public static CarHireContext Create()
        {
            return new CarHireContext();
        }

    }
}