namespace CarHireDataAccess
{
    using System.Data.Entity;

    using CarHireDataAccess.Models.Locations;
    using CarHireDataAccess.Models.User_Classes;
    using CarHireDataAccess.Models.Vehicles;

    using Microsoft.AspNet.Identity.EntityFramework;
    //using Microsoft.Ajax.Utilities;

    public class CarHireContext : IdentityDbContext<UserAccount>
    {
        public CarHireContext()
            : base("CarHireConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarHireContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CarHireContext>());

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarHireContext>());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarHireContext, Configuration>());
            //base.OnModelCreating(modelBuilder);

            /*ProxyCreationEnabled creates a proxy for an object which will help in tracking and lazy loading operations.
            When it is set to “true” it will prevent object from serializing in WCF
            When set to false, it kills knockout! */
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public static CarHireContext Create() => new CarHireContext();

        //used in WCF to allow objects to serialize properly
        public static CarHireContext CreateNoProxy() => new CarHireContext {Configuration = { ProxyCreationEnabled = false } };

        public DbSet<StoreLocation> StoreLocations { get; set; }
        public DbSet<BusinessHours> BusinessHours { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<UserLocation> UserLocations { get; set; }

        public override IDbSet<UserAccount> Users { get; set; }
        public IDbSet<IdentityUserRole> UsersRoles { get; set; }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>().ToTable("Users").Property(p => p.Id).HasColumnName("User Id");
            modelBuilder.Entity<UserLocation>().ToTable("UsersLocations");

            modelBuilder.Entity<StoreLocation>().ToTable("StoreLocations")/*.HasMany(e => e.Vehicles).WithRequired(e => e.StoreLocation)*/;

            //modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers").HasMany(m => m.Models);

            modelBuilder.Entity<Car>().ToTable("Cars").HasRequired(e => e.StoreLocation);


            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsersClaims");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}