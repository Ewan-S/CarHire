using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarHire.Models;

namespace CarHire.Controllers
{
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    using CarHire.Models.GeoLocation;
    using CarHire.ViewModels.Locations;

    using Newtonsoft.Json;

    public class LocationsController : Controller
    {
        private CarHireContext context = new CarHireContext();

        // GET: Locations
        public ActionResult Index() => this.View(this.context.StoreLocations.ToList());

        [HttpPost]
        public ActionResult LocationsListPartial(IEnumerable<StoreLocationRequestModel> storeLocations)
        {
            if (!storeLocations.Any())
            {
                return PartialView("LocationsListPartial", null);
            }

            //order store locations (passed in from the gmap) by the distance from the user
            var orderedByDistance = storeLocations.OrderBy(s => s.distance).ToList();

            //parse the list of strings back into their guids
            //var locationGuids = storeLocations.Select(Guid.Parse).ToList();

            var validStoreLocations = orderedByDistance.Select(storeLocationRequestModel => 
                                            this.context.StoreLocations.FirstOrDefault(dbStore => dbStore.LocationId == storeLocationRequestModel.id)).ToList();

            //put the valid locations into the partial view and load in the sidebar well
            return PartialView("LocationsListPartial", validStoreLocations);
        }



        // GET: Locations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = this.context.StoreLocations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,latitude,longtitude")] StoreLocation location)
        {
            if (ModelState.IsValid)
            {
                location.LocationId = Guid.NewGuid();
                this.context.StoreLocations.Add(location);
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = this.context.StoreLocations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,latitude,longtitude")] Location location)
        {
            if (ModelState.IsValid)
            {
                this.context.Entry(location).State = EntityState.Modified;
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = this.context.StoreLocations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StoreLocation location = this.context.StoreLocations.Find(id);
            this.context.StoreLocations.Remove(location);
            this.context.SaveChanges();
            return RedirectToAction("Index");
        }

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
