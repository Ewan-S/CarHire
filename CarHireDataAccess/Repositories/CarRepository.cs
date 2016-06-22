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
        //we're passing in the class properties that we want to include in the lookup
        public Car GetCarByCarId(Guid id, params Expression<Func<Car, object>>[] includeExpressions)
        {
            IQueryable<Car> cars = base.Get(car => car.VehicleId == id);

            return this.AddIncludes(cars, includeExpressions).FirstOrDefault();
        }

        public IEnumerable<Car> AllCars(params Expression<Func<Car, object>>[] includeExpressions)
        {
            IQueryable<Car> cars = base.Get();

            return this.AddIncludes(cars, includeExpressions);
        }

        public IEnumerable<Car> CarsByLocationId(Guid Id, params Expression<Func<Car, object>>[] includeExpressions)
        {
            IQueryable<Car> cars = base.Get(car => car.StoreLocationId == Id);

            return this.AddIncludes(cars, includeExpressions);
        }

        public IEnumerable<Car> CarsByModelName(string modelName, params Expression<Func<Car, object>>[] includeExpressions)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                return null;
            }

            IQueryable<Car> cars = base.Get(car => car.ModelName.Contains(modelName));

            return this.AddIncludes(cars, includeExpressions);
        }

        private IQueryable<Car> AddIncludes(IQueryable<Car> cars, params Expression<Func<Car, object>>[] includeExpressions)
        {
            foreach (var includeExpression in includeExpressions)
            {
                cars = cars.Include(includeExpression);
            }

            return cars;
        }

        public void UpdateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            var existingrecord = this.GetCarByCarId(car.VehicleId);

            if (existingrecord == null)
            {
                return;
            }

            //dont update Id, and im assuming the model, manufacturer, and manuf date wont change
            existingrecord.StoreLocation = car.StoreLocation;
            existingrecord.StoreLocationId = car.StoreLocationId;
            existingrecord.Registration = car.Registration;
            existingrecord.ColourHex = car.ColourHex;
            existingrecord.NumSeats = car.NumSeats;
            existingrecord.NumDoors = car.NumDoors;
            existingrecord.EngineSize = car.EngineSize;

            this.Context.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}