using System;
using System.Collections.Generic;
using System.Linq;

namespace CarHireService
{
    using System.Data.Entity;

    using CarHireDataAccess;
    using CarHireDataAccess.Models.Vehicles;
    using CarHireDataAccess.Repositories;

    // NOTE: In order to launch WCF Test Client for testing this service, please select CarHireService.svc or CarHireService.svc.cs at the Solution Explorer and start debugging.
    public class CarHireService : ICarHireServiceRest, ICarHireServiceSoap
    {
        private readonly CarHireContext context = CarHireContext.CreateNoProxy();

        public IEnumerable<Car> GetAllCars()
        {
            using (var carRepo = new CarRepository(this.context))
            {
                return carRepo.AllCars(c => c.Manufacturer).ToList();
            }
        }

        public Car GetCarById(Guid vehicleId)
        {
            using (var carRepo = new CarRepository(this.context))
            {
                var a = carRepo.GetCarByCarId(vehicleId, c => c.Manufacturer);
                return a;
            }
        }

        public void NewCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(Guid vehicleId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Car> RestGetAllCars()
        {
            using (var context = new CarHireContext())
            {
                return context.Cars.ToList();
            }
        }

        public Car RestGetCarById(string vehicleId)
        {
            using (var context = new CarHireContext())
            {
                Guid id;
                return Guid.TryParse(vehicleId, out id)
                    ? context.Cars.FirstOrDefault(c => c.VehicleId == id) 
                    : null;
            }
        }

        public void RestNewCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void RestUpdateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void RestDeleteCar(string vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
