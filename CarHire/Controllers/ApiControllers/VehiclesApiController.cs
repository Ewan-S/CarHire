using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarHire.Controllers
{
    using CarHireDataAccess;
    using CarHireDataAccess.Models.Vehicles;
    using CarHireDataAccess.Repositories;

    public class VehiclesApiController : ApiController
    {
        private readonly CarHireContext context = CarHireContext.CreateNoProxy();

        [HttpGet]
        [ActionName("Cars")]
        public IEnumerable<Car> GetAllCars()
        {
            using (var carRepo = new CarRepository(this.context))
            {
                return carRepo.AllCars().ToList();
            }
        }

        [HttpGet]
        [ActionName("Car")]
        public Car GetCarById(Guid vehicleId)
        {
            using (var carRepo = new CarRepository(this.context))
            {
                return carRepo.GetCarByCarId(vehicleId, c => c.Manufacturer);
            }
        }

        [HttpPost]
        [ActionName("Car")]
        public void NewCar(Car car)
        {
            //our validation goes here  if we need

            using (var carRepo = new CarRepository(this.context))
            {
                carRepo.Insert(car);
            }
        }

        [HttpPut]
        [ActionName("Car")]
        public void UpdateCar(Car car)
        {
            using (var carRepo = new CarRepository(this.context))
            {
                carRepo.UpdateCar(car);
            }
        }

        [HttpDelete]
        [ActionName("Car")]
        public void DeleteCar(Guid vehicleId)
        {
            using (var carRepo = new CarRepository(this.context))
            {
                var car = carRepo.GetCarByCarId(vehicleId);

                if(car != null)
                    carRepo.Delete(car);
            }
        }

    }
}
