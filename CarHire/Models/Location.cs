using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public Location(double Latitude, double Longitude)
        {
            this.latitude = Latitude;
            this.longtitude = Longitude;
        }
    }
}