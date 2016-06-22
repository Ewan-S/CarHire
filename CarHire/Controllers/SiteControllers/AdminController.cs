using System.Web.Mvc;

namespace CarHire.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
              
            }

            return View();
        }
    }
}
