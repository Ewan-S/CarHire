namespace CarHire.Controllers
{
    using System;
    using System.Web.Mvc;

    using CarHire.Models;

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";


            using (var context = new CarHireContext())
            {
                //context.Cars.Add(new Car { VehicleId = Guid.NewGuid(), ModelName = "Car", ManufactureDate = new DateTime(1994,2,1)});

                context.SaveChanges();
            }

            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return RedirectToAction("Index", "Admin");
        }
    }
}