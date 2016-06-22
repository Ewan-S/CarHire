using System.Collections.Generic;

namespace CarHire.ViewModels.Car
{
    using CarHireDataAccess.Models.Locations;
    using CarHireDataAccess.Models.Vehicles;

    public class CarIndexViewModel
    {
        public StoreLocation selectedLocation { get; set; }

        public IEnumerable<Car> Cars { get; set; } 
    }
}