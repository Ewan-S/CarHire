namespace CarHire.Models.Base_Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;

    using CarHire.Models.Vehicles;

    public abstract class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleId { get; set; }

        public Guid StoreLocationId { get; set; }
        [ForeignKey("StoreLocationId")]
        public virtual StoreLocation StoreLocation { get; set; }

        public Guid ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public string ModelName { get; set; }

        public string EngineSize { get; set; }

        public string Registration { get; set; }

        public string ColourHex { get; set; }

        //[NotMapped]
        public Color Colour => ColorTranslator.FromHtml(this.ColourHex);

        public DateTime ManufactureDate { get; set; }

        public bool IsAutomatic { get; set; }

        public VehicleType Type { get; set; }

    }

    public enum VehicleType
    {
        Car = 0,
        Van = 1,
        PeopleCarrier = 2,
        SUV = 3
    }
}