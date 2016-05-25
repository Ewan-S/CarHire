using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Repositories
{
    using System.Data.Entity;

    using CarHire.Models;

    using Microsoft.Ajax.Utilities;
    using Microsoft.Owin.Security.Facebook;

    public class CarRepository : Repo<Car>
    {
        public CarRepository(DbContext dataContext)
        {
            Context = dataContext;
            base.Repository(Context);
        }

        public IEnumerable<Car> CarById(Guid Id) => base.Get(car => car.VehicleId == Id);

        public IEnumerable<Car> CarByModelName(string modelName) => base.Get(car => car.ModelName.Contains(modelName));
    }
}