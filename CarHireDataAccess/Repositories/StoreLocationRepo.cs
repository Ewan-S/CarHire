namespace CarHireDataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarHireDataAccess.Models.Locations;

    //using Microsoft.Ajax.Utilities;
    //using Microsoft.Owin.Security.Facebook;

    public class StoreLocationRepo : Repo<StoreLocation>, IDisposable
    {
        public StoreLocationRepo(CarHireContext dataContext)
        {
            this.Context = dataContext;
            base.Repository(this.Context);
        }

        public StoreLocation GetStoreById(Guid id) => base.Get(store => store.LocationId == id).FirstOrDefault();

        public IEnumerable<StoreLocation> AllStores => base.Get();

        public void Dispose()
        {

        }
    }
}