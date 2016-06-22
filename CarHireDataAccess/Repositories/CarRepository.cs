namespace CarHireDataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using CarHireDataAccess.Models.Vehicles;

    //using Microsoft.Ajax.Utilities;
    //using Microsoft.Owin.Security.Facebook;

    public class CarRepository : Repo<Car>, IDisposable
    {
        public CarRepository(CarHireContext dataContext)
        {
            this.Context = dataContext;
            base.Repository(this.Context);
        }

        //params allows us to pass multiple objects in to a single parameter
        public Car GetCarByCarId(Guid Id, params Expression<Func<Car, object>>[] includeExpressions)
        {
            IQueryable<Car> cars = base.Get(car => car.VehicleId == Id);

            foreach (var includeExpression in includeExpressions)
            {
                cars = cars.Include(includeExpression);
            }

            return cars.FirstOrDefault();
        }

        public IQueryable<Car> AllCars(params Expression<Func<Car, object>>[] includeExpressions)
        {
            IQueryable<Car> cars = base.Get();

            foreach (var includeExpression in includeExpressions)
            {
                cars = cars.Include(includeExpression);
            }

            return cars;
        }

        public IEnumerable<Car> CarsByLocationId(Guid Id) => base.Get(car => car.StoreLocationId == Id);

        public IEnumerable<Car> CarsByModelName(string modelName) => base.Get(car => car.ModelName.Contains(modelName));

        public void Dispose()
        {

        }
    }
}