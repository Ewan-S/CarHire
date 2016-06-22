namespace CarHireDataAccess.Models.Vehicles
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.Runtime.Serialization;

    using CarHireDataAccess.Models.Locations;

    [DataContract]
    public abstract class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid VehicleId { get; set; }

        [DataMember]
        public Guid StoreLocationId { get; set; }

        [ForeignKey("StoreLocationId")]
        [DataMember]
        public virtual StoreLocation StoreLocation { get; set; }

        [DataMember]
        public Guid ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        [DataMember]
        public virtual Manufacturer Manufacturer { get; set; }

        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string EngineSize { get; set; }

        [DataMember]
        public string Registration { get; set; }

        [DataMember]
        public string ColourHex { get; set; }

        //[NotMapped]
        public Color Colour => ColorTranslator.FromHtml(this.ColourHex);

        [DataMember]
        public DateTime ManufactureDate { get; set; }

        [DataMember]
        public bool IsAutomatic { get; set; }

        [DataMember]
        public VehicleType Type { get; set; }

    }

    [DataContract]
    [Flags]
    public enum VehicleType
    {
        [EnumMember]
        Car = 0,
        [EnumMember]
        Van = 1,
        [EnumMember]
        PeopleCarrier = 2,
        [EnumMember]
        SUV = 3
    }
}