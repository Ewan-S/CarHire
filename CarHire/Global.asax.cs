namespace CarHire
{
    using System;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using CarHire.Models;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var userRoleActions = new UserRoles();
       
            try
            {
                userRoleActions.AddAdminAndRoles();
            }
            catch (DbEntityValidationException e)
            {
                ExtensionMethods.ViewValidationErrors(e);
            }
        }
    }
}