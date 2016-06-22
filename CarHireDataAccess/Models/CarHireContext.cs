//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace CarHire.Models
//{
//    using System.Data.Entity;

//    using CarHire.Models.Locations;
//    using CarHire.Models.User_Classes;
//    using CarHire.Models.Vehicles;

//    using Microsoft.Ajax.Utilities;
//    using Microsoft.AspNet.Identity.EntityFramework;

//    public class CarHireContext : IdentityDbContext<UserAccount>
//    {
//        public CarHireContext()
//            : base("CarHireConnection")
//        {
//            Database.SetInitializer(new CreateDatabaseIfNotExists<CarHireContext>());
//            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarHireContext>());
//            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarHireContext, Configuration>());
//            //base.OnModelCreating(modelBuilder);

//            this.Configuration.LazyLoadingEnabled = true;
//        }

//        public static CarHireContext Create() => new CarHireContext();

//        public DbSet<StoreLocation> StoreLocations { get; set; }
//        public DbSet<BusinessHours> BusinessHours { get; set; }

//        public DbSet<Address> Addresses { get; set; }

//        public DbSet<UserLocation> UserLocations { get; set; }

//        public override IDbSet<UserAccount> Users { get; set; }
//        public IDbSet<IdentityUserRole> UsersRoles { get; set; }

//        public DbSet<Car> Cars { get; set; }
//        public DbSet<Manufacturer> Manufacturers { get; set; }

//        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<UserAccount>().ToTable("Users").Property(p => p.Id).HasColumnName("User Id");
//            modelBuilder.Entity<UserLocation>().ToTable("UsersLocations");

//            modelBuilder.Entity<StoreLocation>().ToTable("StoreLocations")/*.HasMany(e => e.Vehicles).WithRequired(e => e.StoreLocation)*/;

//            //modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers").HasMany(m => m.Models);

//            modelBuilder.Entity<Car>().ToTable("Cars").HasRequired(e => e.StoreLocation);


//            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRoles");
//            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsersLogins");
//            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsersClaims");

//            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
//        }
//    }
//}