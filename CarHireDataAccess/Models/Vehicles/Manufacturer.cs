namespace CarHireDataAccess.Models.Vehicles
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid ManufacturerId { get; set; }

        public Manufacturer() { }

        public Manufacturer(string manufacturerName)
        {
            this.ManufacturerName = manufacturerName;
        }

        [Required]
        [DataMember]
        public string ManufacturerName { get; set; }

        //public virtual ICollection<Vehicle> Models { get; set; }
    }
}