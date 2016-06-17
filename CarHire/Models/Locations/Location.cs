﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.RegularExpressions;

    using CarHire.Models.Base_Classes;
    using CarHire.Models.Locations;
    using CarHire.Models.User_Classes;

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