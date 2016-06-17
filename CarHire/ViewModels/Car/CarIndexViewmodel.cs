using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.ViewModels.Car
{
    using CarHire.Models;

    public class CarIndexViewModel
    {
        public StoreLocation selectedLocation { get; set; }

        public IEnumerable<Car> Cars { get; set; } 
    }
}