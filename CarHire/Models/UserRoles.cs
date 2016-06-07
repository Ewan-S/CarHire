using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using CarHire.Models.User_Classes;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal class UserRoles
    {
        public void AddAdminAndRoles()
        {
            CarHireContext context = new CarHireContext();

            // Access the application context and create result variables.
            IdentityResult roleResult;
            IdentityResult adminUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("isAdmin"))
            {
                roleResult = roleMgr.Create(new IdentityRole { Name = "isAdmin" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<UserAccount>(new UserStore<UserAccount>(context));
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
            adminUserResult = userMgr.Create(appUser, "aA1234.");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("admin@BCR.com").Id, "isAdmin"))
            {
                adminUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin@BCR.com").Id, "isAdmin");
            }
        }
    }
}