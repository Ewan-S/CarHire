using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarHire.Controllers
{
    using CarHire.ViewModels.Car;

    using CarHireDataAccess.Models.Locations;
    using CarHireDataAccess.Models.Vehicles;
    using CarHireDataAccess.Repositories;

    public class VehiclesController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(Guid? locationId)
        {
            using(var storeRepo = new StoreLocationRepo(this.db))
            using (var carRepo = new CarRepository(this.db))
            {
                List<Car> validCars;
                StoreLocation store;

                if (locationId.HasValue)
                {
                    store = storeRepo.GetStoreById(locationId.Value);
                    validCars = carRepo.CarsByLocationId(locationId.Value, c => c.Manufacturer).ToList();
                }
                else
                {
                    store = null;
                    validCars = carRepo.AllCars(c => c.Manufacturer).ToList();
                }

                var model = new CarIndexViewModel { Cars = validCars, selectedLocation = store};

                return View("~/Views/Car/Index.cshtml", model);
            }
        }

        //// GET: Vehicles/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// GET: Vehicles/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Vehicles/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "VehicleId,ModelName,EngineSize,Registration,Colour,NumberOfWheels,ManufactureDate,IsAutomatic,Type")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        vehicle.VehicleId = Guid.NewGuid();
        //        db.Vehicles.Add(vehicle);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(vehicle);
        //}

        //// GET: Vehicles/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: Vehicles/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "VehicleId,ModelName,EngineSize,Registration,Colour,NumberOfWheels,ManufactureDate,IsAutomatic,Type")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicle);
        //}

        //// GET: Vehicles/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: Vehicles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
