namespace CarHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using CarHire.Models;
    using CarHire.Models.User_Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<CarHire.Models.CarHireContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarHire.Models.CarHireContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Locations.AddOrUpdate(
                  l => l.LocationId,
                  new Location()
                  {
                      latitude = 52.10307,
                      longtitude = -0.86037,
                      Address = new Address { Line1 = "Unnamed Rd", City = "Milton Keynes", Postcode = "MK19", Country = "UK" }
                  }
                );

            context.Locations.AddOrUpdate(
                l => l.LocationId,
                new Location()
                    {
                        latitude = 51.634968,
                        longtitude = -0.562017,
                        Address = new Address { Line1 = "17 Kings Cl", City = "Chalfont Saint Giles", County = "Buckinghamshire", Town = "", Postcode = "HP8 4HW", Country = "UK" }
                    });

            context.Locations.AddOrUpdate(
                l => l.LocationId,
                new Location()
                    {
                        latitude = 53.564941,
                        longtitude = -0.136356,
                        Address = new Address { Line1 = "21 Wybers Way", City = "Grimsby", County = "North East Lincolnshire", Town = "", Postcode = "DN37 9QR", Country = "UK" }
                    });

            //2 Parcllyn, Abercych, Boncath, Pembrokeshire SA37 0HA, UK
            //104 Knockarthur, Rogart, Highland IV28 3YE, UK
            //66 - 68 Bedford Rd, Bootle, Merseyside L20 7DW, UK
            //6 Radnor Green, West Bromwich, West Midlands B71 1JL, UK
            //60 - 70 Lisconduff Rd, Aughnacloy, Dungannon and South Tyrone BT69, UK


            context.Cars.AddOrUpdate(
                h => h.Registration,
                // Use Name (or some other unique field) instead of Id
                new Car { ModelName = "Reliant Robin", ManufactureDate = new DateTime(1964, 7, 3), VehicleId = Guid.NewGuid(), Registration = "KM02TZT" });


            context.SaveChanges();

        }
    }
}
