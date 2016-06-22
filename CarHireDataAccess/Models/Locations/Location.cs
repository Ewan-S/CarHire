namespace CarHireDataAccess.Models.Locations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using CarHireDataAccess.Models.User_Classes;
    using CarHireDataAccess.Models.Vehicles;

    public class Location
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationId { get; set; }

        public double latitude { get; set; }
        public double longtitude { get; set; }

        public virtual Address Address { get; set; }

        public Location() { }

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longtitude = longitude;
        }
    }

    public class UserLocation : Location { }

    public class StoreLocation : Location
    {
        public string StoreName { get; set; }

        //escaping potential ' in the storename
        public string EscapedStoreName => HttpUtility.JavaScriptStringEncode(this.StoreName.Replace("'","\'"));

        public string TelephoneNumber { get; set; }

        public ICollection<BusinessHours> BusinessHours { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }

}