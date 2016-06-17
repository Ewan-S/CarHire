namespace CarHire.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using CarHire.Models.Base_Classes;

    //[Table("Cars")]
    public class Car : Vehicle
    {
        public Car() {}

        public int NumDoors { get; set; }

        public int NumSeats { get; set; }

    }
}