namespace CarHireDataAccess.Models.Vehicles
{
    using System.Runtime.Serialization;

    //[Table("Cars")]
    [DataContract]
    public class Car : Vehicle
    {
        public Car() {}

        [DataMember]
        public int NumDoors { get; set; }

        [DataMember]
        public int NumSeats { get; set; }

    }
}