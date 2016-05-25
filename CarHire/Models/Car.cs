namespace CarHire.Models
{
    using CarHire.Models.Base_Classes;

    public class Car : Vehicle
    {
        public Car() {}

        public int NumDoors { get; set; }
    }
}