using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.ViewModels.Locations
{
    using CarHire.Models;

    public class StoreLocationRequestModel
    { 
        public Guid id { get; set; }

        public decimal distance { get; set; }
    }
}