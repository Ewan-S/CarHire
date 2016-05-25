using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using System.Data.Entity;

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

        public override IDbSet<UserAccount> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Van> Vans { get; set; }

        public DbSet<Loan> Loans { get; set; }

        //public DbSet<Rating> itemRatings { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<UserAccount>().ToTable("Users").Property(p => p.Id).HasColumnName("User Id");
            modelBuilder.Entity<Location>().ToTable("Locations");


            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        public static CarHireContext Create()
        {
            return new CarHireContext();
        }
    }
}