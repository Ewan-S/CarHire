using System;
using System.Collections.Generic;

namespace CarHireService
{
    using System.ServiceModel;

    using CarHireDataAccess.Models.Vehicles;

    [ServiceContract]
    public interface ICarHireServiceSoap
    {
        [OperationContract]
        IEnumerable<Car> GetAllCars();

        [OperationContract]
        Car GetCarById(Guid vehicleId);

        [OperationContract]
        void NewCar(Car car);

        [OperationContract]
        void UpdateCar(Car car);

        [OperationContract]
        void DeleteCar(Guid vehicleId);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

    }
}