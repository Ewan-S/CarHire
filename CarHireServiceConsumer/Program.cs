using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHireServiceConsumer
{
    using CarHireServiceConsumer.CarHireService;

    class Program
    {
        static void Main(string[] args)
        {

            var client = new CarHireServiceSoapClient();

            try
            {
                //// Use the 'client' variable to call operations on the service.
                var allCars = client.GetAllCars();

                if (allCars == null || !allCars.Any())
                {
                    Console.WriteLine("No cars returned");
                }

                foreach (var car in allCars)
                {
                    Console.WriteLine("Model:" + car.ModelName + ", Manufacturer: " + car.Manufacturer.ManufacturerName);
                }
            }
            catch (Exception e) // global ex hand - bad
            {
            }
            finally
            {
                //// Always close the client.
                client.Close();
            }

            Console.ReadLine();
        }
    }
}
