namespace CarHire.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using CarHire.Models;
    using CarHire.Models.Locations;
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

            context.StoreLocations.AddOrUpdate(
                  l => l.LocationId,
                  new StoreLocation()
                  {
                      latitude = 52.10307,
                      longtitude = -0.86037,
                      StoreName = "Milton Keynes. Hard times",
                      Address = new Address { Line1 = "Unnamed Rd", City = "Milton Keynes", Postcode = "MK19", Country = "UK" },
                      TelephoneNumber = "03069 990682",
                      BusinessHours = new List<BusinessHours> {new BusinessHours() {} }

                  }
                );

            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 51.634968,
                    longtitude = -0.562017,
                    StoreName = "Home County Cars",
                    Address = new Address { Line1 = "17 Kings Cl", City = "Chalfont Saint Giles", County = "Buckinghamshire", Town = "", Postcode = "HP8 4HW", Country = "UK" }
                });

            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 53.564941,
                    longtitude = -0.136356,
                    StoreName = "T' Northern Car Company",
                    Address = new Address { Line1 = "21 Wybers Way", City = "Grimsby", County = "North East Lincolnshire", Town = "", Postcode = "DN37 9QR", Country = "UK" }
                });

            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 51.490440,
                    longtitude = -0.144367,
                    StoreName = "City Cars",
                    Address = new Address { Line1 = "123 Fake street", City = "Pimlico", County = "London", Town = "", Postcode = "SW1V", Country = "UK" }
                });


            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 52.034056,
                    longtitude = -4.552255,
                    StoreName = "Miner's Motors",
                    Address = new Address { Line1 = "2 Parcllyn", City = "Abercych", County = "Pembrokeshire", Town = "Boncath", Postcode = "SA37 0HA", Country = "UK" }
                });

            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 54.263513,
                    longtitude = -6.635742,
                    StoreName = "Paddy's Craic Dealership",
                    Address = new Address { Line1 = "Tullybrone Rd", City = "Tassagh", County = "Armagh", Town = "Armagh", Postcode = "BT60 2QL", Country = "UK" }
                });

            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                {
                    latitude = 53.442103,
                    longtitude = -2.989681,
                    StoreName = "Merseyside Motors",
                    Address = new Address { Line1 = "66 - 68 Bedford Rd", City = "Bootle", County = "Merseyside", Postcode = "L20 7DW", Country = "UK" }
                });


            context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation()
                    {
                        latitude = 58.026351,
                        longtitude = -4.114644,
                        StoreName = "Highland Hondas",
                        Address = new Address { Line1 = "104 Knockarthur", City = "Rogart", County = "Highland", Postcode = "IV28 3YE", Country = "UK" }
                    });







            context.Cars.AddOrUpdate(
                h => h.Registration,
                // Use Name (or some other unique field) instead of Id
                new Car { ModelName = "Reliant Robin", ManufactureDate = new DateTime(1964, 7, 3), VehicleId = Guid.NewGuid(), Registration = "KM02TZT" });


            context.SaveChanges();

        }
    }
}
