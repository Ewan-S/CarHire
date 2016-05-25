namespace CarHire.Controllers
{
    using System;
    using System.Web.Mvc;

    using CarHire.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";


            using (var context = new CarHireContext())
            {
                context.Cars.Add(new Car { VehicleId = Guid.NewGuid(), ModelName = "Car", ManufactureDate = new DateTime(1994,2,1)});

                context.SaveChanges();
            }

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}