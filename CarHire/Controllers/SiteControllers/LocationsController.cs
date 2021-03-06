﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarHire.Controllers
{
    using CarHire.ViewModels.Locations;

    using CarHireDataAccess;

    public class LocationsController : BaseController
    {
        private CarHireContext context = CarHireContext.Create();

        // GET: Locations
        [AllowAnonymous]
        public ActionResult Index() => this.View(this.context.StoreLocations.ToList());

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LocationsListPartial(IEnumerable<StoreLocationRequestModel> storeLocations)
        {
            //store locations come in ordered by distance from the javascript
            if (!storeLocations.Any())
            {
                return PartialView("LocationsListPartial", null);
            }


            var validStoreLocations = storeLocations.Select(storeLocationRequestModel => 
                                            this.context.StoreLocations.FirstOrDefault(dbStore => dbStore.LocationId == storeLocationRequestModel.id)).ToList();

            //put the valid locations into the partial view and load in the sidebar well
            return PartialView("LocationsListPartial", validStoreLocations);
        }

        [HttpPost]
        [AllowAnonymous]
        public void SetSelectedLocation(Guid locationId)
        {
            
        }

        //// GET: Locations/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = this.context.StoreLocations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// GET: Locations/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Locations/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LocationId,latitude,longtitude")] StoreLocation location)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        location.LocationId = Guid.NewGuid();
        //        this.context.StoreLocations.Add(location);
        //        this.context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(location);
        //}

        //// GET: Locations/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = this.context.StoreLocations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// POST: Locations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "LocationId,latitude,longtitude")] Location location)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.context.Entry(location).State = EntityState.Modified;
        //        this.context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(location);
        //}

        //// GET: Locations/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = this.context.StoreLocations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// POST: Locations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    StoreLocation location = this.context.StoreLocations.Find(id);
        //    this.context.StoreLocations.Remove(location);
        //    this.context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
