using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CarHire.Models.Locations;
    using CarHire.Models.User_Classes;

    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationId { get; set; }

        public double latitude { get; set; }
        public double longtitude { get; set; }

        public virtual Address Address { get; set; }

        public Location(){ }

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
        public string TelephoneNumber { get; set; }

        public List<BusinessHours> BusinessHours { get; set; }
    }

}