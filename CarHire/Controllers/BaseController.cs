namespace CarHire.Controllers
{
    using System.Web.Mvc;

    using CarHireDataAccess;
    using CarHireDataAccess.Models.Session;

    public class BaseController : Controller
    {
        public readonly CarHireContext db = new CarHireContext();

        public SessionObject GetSessionObject() => this.Session["Session"] as SessionObject;

        public void NewSessionObject() => this.Session["Session"] = new SessionObject();
    }
}