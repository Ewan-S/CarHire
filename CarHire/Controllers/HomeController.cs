namespace CarHire.Controllers
{
    using System;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            this.NewSessionObject();

            return this.View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

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