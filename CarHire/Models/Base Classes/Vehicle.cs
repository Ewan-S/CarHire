namespace CarHire.Models.Base_Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleId { get; set; }

        public string ModelName { get; set; }

        public string EngineSize { get; set; }

        public string Registration { get; set; }

        public string Colour { get; set; }

        public int NumberOfWheels { get; set; }

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