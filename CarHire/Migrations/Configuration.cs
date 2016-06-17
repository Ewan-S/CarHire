namespace CarHire.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;

    using CarHire.Models;
    using CarHire.Models.Base_Classes;
    using CarHire.Models.Locations;
    using CarHire.Models.User_Classes;
    using CarHire.Models.Vehicles;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CarHireContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        private CarHireContext context;

        //  This method will be called after migrating to the latest version.
        protected override void Seed(CarHireContext context)
        {
            this.context = context;

            //if (Debugger.IsAttached == false)
            //    Debugger.Launch();

            try
            {
                this.CreateAdminAccountAndRoles();
                context.SaveChanges();

                this.CreateLocations();
                context.SaveChanges();

                this.AddManufacturers();
                context.SaveChanges();

                this.AddCars();
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                ExtensionMethods.ViewValidationErrors(e);
            }
        }

        private List<Manufacturer> manufacturers = new List<Manufacturer>
                                    {
                                        new Manufacturer("Acura"),
                                        new Manufacturer("Alfa Romeo"),
                                        new Manufacturer("AMC"),
                                        new Manufacturer("Audi"),
                                        new Manufacturer("Avanti"),
                                        new Manufacturer("Bentley"),
                                        new Manufacturer("Cadillac"),
                                        new Manufacturer("Chevrolet"),
                                        new Manufacturer("DeLorean"),
                                        new Manufacturer("Chrysler"),
                                    };

        private void AddManufacturers()
        {
            foreach (var manufacturer in this.manufacturers)
            {
                this.context.Manufacturers.Add(manufacturer);
            }
        }

        private void AddCars()
        {
            var randonGen = new Random();
            
            var count = 0;
            foreach (var storeLocation in this.context.StoreLocations)
            {
                Color randomColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));

                var manufacturer = this.context.Manufacturers.ToList().GetRandom();
                var car = new Car
                {
                    Manufacturer = manufacturer,
                    ManufacturerId = manufacturer.ManufacturerId,
                    StoreLocation = storeLocation,
                    StoreLocationId = storeLocation.LocationId,
                    ModelName = "test model:" + count,
                    ManufactureDate = DateTime.Now,
                    //trim the alpha from the ARGB
                    ColourHex = "#"+randomColor.Name.Substring(2, randomColor.Name.Length - 2).ToUpper(),
                    EngineSize = "v1.0",
                    NumDoors = 4,
                    Registration = "AA00AAA",
                    Type = VehicleType.Car
                };

                context.Cars.Add(car);

                count++;
            }
        }

        public void CreateAdminAccountAndRoles()
        {
            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userManager = new UserManager<UserAccount>(new UserStore<UserAccount>(this.context));
            var appUser = new UserAccount
            {
                UserName = "admin@BCR.com",
                Email = "admin@BCR.com",
                FirstName = "admin",
                LastName = "istrator",
                PhoneNumber = "03069 990703",

                BillingAddress = new Address()
                {
                    Line1 = "74 Manor Rd",
                    City = "Dorchester",
                    County = "Dorset",
                    Postcode = "DT1 2AZ",
                    Country = "UK",

                }
            };

            var createAdminUserResult = userManager.Create(appUser, "aA1234.");

            if (!createAdminUserResult.Succeeded)
            {

            }

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userManager.IsInRole(userManager.FindByEmail("admin@BCR.com").Id, "Admin"))
            {
                var addAdminToRoleResult = userManager.AddToRole(userManager.FindByEmail("admin@BCR.com").Id, "Admin");

                if (!addAdminToRoleResult.Succeeded)
                {

                }
            }
        }

        public void CreateLocations()
        {
            var newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(sl => sl.LocationId, new StoreLocation
            {
                LocationId = newId,
                latitude = 52.10307,
                longtitude = -0.86037,
                StoreName = "Milton Keynes. Hard times",
                Address = new Address { Line1 = "Unnamed Rd", City = "Milton Keynes", Postcode = "MK19", Country = "UK" },
                TelephoneNumber = "03069 990682",
                BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
            });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,
                    latitude = 51.634968,
                    longtitude = -0.562017,
                    StoreName = "Home County Cars",
                    Address = new Address { Line1 = "17 Kings Cl", City = "Chalfont Saint Giles", County = "Buckinghamshire", Town = "", Postcode = "HP8 4HW", Country = "UK" },
                    TelephoneNumber = "07700 900709",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,

                    latitude = 53.564941,
                    longtitude = -0.136356,
                    StoreName = "T' Northern Car Company",
                    Address = new Address { Line1 = "21 Wybers Way", City = "Grimsby", County = "North East Lincolnshire", Town = "", Postcode = "DN37 9QR", Country = "UK" },
                    TelephoneNumber = "07700 900863",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,

                    latitude = 51.490440,
                    longtitude = -0.144367,
                    StoreName = "City Cars",
                    Address = new Address { Line1 = "123 Fake street", City = "Pimlico", County = "London", Town = "", Postcode = "SW1V", Country = "UK" },
                    TelephoneNumber = "07700 900700",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,

                    latitude = 52.034056,
                    longtitude = -4.552255,
                    StoreName = "Miner's Motors",
                    Address = new Address { Line1 = "2 Parcllyn", City = "Abercych", County = "Pembrokeshire", Town = "Boncath", Postcode = "SA37 0HA", Country = "UK" },
                    TelephoneNumber = "07700 900722",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,
                    latitude = 54.263513,
                    longtitude = -6.635742,
                    StoreName = "Paddy's Craic Dealership",
                    Address = new Address { Line1 = "Tullybrone Rd", City = "Tassagh", County = "Armagh", Town = "Armagh", Postcode = "BT60 2QL", Country = "UK" },
                    TelephoneNumber = "07700 900435",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,
                    latitude = 53.442103,
                    longtitude = -2.989681,
                    StoreName = "Merseyside Motors",
                    Address = new Address { Line1 = "66 - 68 Bedford Rd", City = "Bootle", County = "Merseyside", Postcode = "L20 7DW", Country = "UK" },
                    TelephoneNumber = "07700 900094",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });

            newId = Guid.NewGuid();
            this.context.StoreLocations.AddOrUpdate(
                l => l.LocationId,
                new StoreLocation
                {
                    LocationId = newId,
                    latitude = 58.026351,
                    longtitude = -4.114644,
                    StoreName = "Highland Hondas",
                    Address = new Address { Line1 = "104 Knockarthur", City = "Rogart", County = "Highland", Postcode = "IV28 3YE", Country = "UK" },
                    TelephoneNumber = "08081 570188",
                    BusinessHours = new List<BusinessHours>
                                    {
                                        new BusinessHours { LocationId = newId, Day = Day.Monday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Tuesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Wednesday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Thursday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Friday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Saturday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                        new BusinessHours { LocationId = newId, Day = Day.Sunday, OpeningTime = new DateTime(1753, 1, 1, 8, 0, 0), ClosingTime = new DateTime(1753, 1, 1, 17, 0, 0) },
                                    }
                });
        }
    }
}
