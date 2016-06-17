namespace CarHire.Models.User_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your UserAccount class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UserAccount : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Phone Number")]
        public override string PhoneNumber { get; set; }
        //currency

        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        public Address BillingAddress { get; set; }

        //[Required]
        public Guid AddressID { get; set; }

        public virtual ICollection<Loan> RentedVehicles { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserAccount> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}