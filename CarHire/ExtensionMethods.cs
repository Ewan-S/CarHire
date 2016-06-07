using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire
{
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    public class ExtensionMethods
    {
        public static void ViewValidationErrors(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }
            }

            throw e;
        }
    }
}