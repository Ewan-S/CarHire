using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Repositories
{
    using System.Data.Entity;
    using System.Linq.Expressions;

    using CarHire.Models;

    using Microsoft.Ajax.Utilities;
    using Microsoft.Owin.Security.Facebook;

    public class CarRepository : Repo<Car>, IDisposable
    {
        public CarRepository(CarHireContext dataContext)
        {
            Context = dataContext;
            base.Repository(Context);
        }

        public Car GetCarByCarId(Guid Id) => base.Get(car => car.VehicleId == Id).FirstOrDefault();

        public IEnumerable<Car> Include(params Expression<Func<Car, object>>[] includes)
        {
            var a = base.Get();
            if (includes != null)
            {
                a = includes.Aggregate(base.Get(), (current, include) => current.Include(include));
            }

            return a;
        }


        public IEnumerable<Car> AllCars => base.Get();

        public IEnumerable<Car> CarsByLocationId(Guid Id) => base.Get(car => car.StoreLocationId == Id);

        public IEnumerable<Car> CarsByModelName(string modelName) => base.Get(car => car.ModelName.Contains(modelName));

        public void Dispose()
        {

        }
    }
}