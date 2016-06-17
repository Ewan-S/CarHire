using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire.Controllers
{
    using System.Web.Mvc;

    using CarHire.Models;
    using CarHire.Models.Session_Class;

    public class BaseController : Controller
    {
        public readonly CarHireContext db = new CarHireContext();

        public SessionObject GetSessionObject() => this.Session["Session"] as SessionObject;

        public void NewSessionObject() => this.Session["Session"] = new SessionObject();
    }
}