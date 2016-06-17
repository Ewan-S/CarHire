using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarHire.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
              
            }

            return View();
        }
    }
}
