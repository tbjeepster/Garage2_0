using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2_0.DataAccessLayer;
using Garage2_0.Models;
using AutoMapper;

namespace Garage2_0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            /* HD
            return View(db.Vehicle.ToList());
            */
            /* HD */
            var dataset =
                db.Vehicle
                .OrderByDescending(omega => omega.ParkedTime.ToString())
                .Select(
                    omega => new ParkedVehicleProjection01 {
                        Id = omega.Id,
                        Type       = omega.Type,
                        RegNum     = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake    = omega.CarMake,
                        Model      = omega.Model
                    }
                );

            return View(dataset);  // or Maybe return View(dataset.ToList());
            /* End HD */
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicle.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNum,Colour,ParkedTime,NumOfWeels,CarMake,Model")] ParkedVehicle parkedVehicle)
        {

            if (ModelState.IsValid)
            {
                //LH added timestamp
                parkedVehicle.ParkedTime = DateTime.Now;

                // Normalize RegNum to upper case letters (by HD).
                parkedVehicle.RegNum = parkedVehicle.RegNum.ToUpper();

                db.Vehicle.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicle.Find(id);
           
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNum,Colour,NumOfWeels,CarMake,Model")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;

                // Normalize RegNum to upper case letters (by HD).
                var RegNum = db.Entry(parkedVehicle).Property(x => x.RegNum).CurrentValue;
                db.Entry(parkedVehicle).Property(x => x.RegNum).CurrentValue = RegNum.ToUpper();

                // Exclude ParkedTime column from update (by HD).
                db.Entry(parkedVehicle).Property(x => x.ParkedTime).IsModified = false;

                // Update rest of table row.
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicle.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.Vehicle.Find(id);
            db.Vehicle.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public ActionResult Search()
        {
            return View(db.Vehicle.ToList());
        }

        [HttpPost]
        public ActionResult Search(string option, string search)
        {
            //the first parameter is the option that we choose and the second parameter will use the textbox value 
            var model = db.Vehicle.ToList();
          
            if (option == "regnum")
            {
                 model = db.Vehicle.Where(x => x.RegNum.Contains(search) || search == null).ToList();
                
            }
            else if (option == "model")
            {
                 model = db.Vehicle.Where(x => x.CarMake.Contains(search) || search == null).ToList();
            }
            ViewBag.Count = model.Count;
            return View(model);
        }
    

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
