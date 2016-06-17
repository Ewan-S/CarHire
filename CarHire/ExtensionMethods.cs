using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarHire
{
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq.Expressions;

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

    public static class IQueryable
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }

    public static class IList
    {
        private static readonly Random Rng = new Random();

        public static T GetRandom<T>(this IList<T> collection) => collection[Rng.Next(collection.Count)];
    }
}