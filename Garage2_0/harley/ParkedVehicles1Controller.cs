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

namespace Garage2_0.Controllers
{
    public class ParkedVehicles1Controller : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: ParkedVehicles1
        public ActionResult Index()
        {
#if true
            /*
                        DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                contacts.AsEnumerable().Join(orders.AsEnumerable(),
                order => order.Field<Int32>("ContactID"),
                contact => contact.Field<Int32>("ContactID"),
                (contact, order) => new
                {
                    ContactID = contact.Field<Int32>("ContactID"),
                    SalesOrderID = order.Field<Int32>("SalesOrderID"),
                    FirstName = contact.Field<string>("FirstName"),
                    Lastname = contact.Field<string>("Lastname"),
                    TotalDue = order.Field<decimal>("TotalDue")
                });
            */

            var dataset =
                db.Vehicle
                .Include(omega => omega.Type)
                .Include(omega => omega.Member)
                .OrderByDescending(omega => omega.ParkedTime.ToString())
                .Select(
                    omega => new ParkedVehicleProjection01Ext01 {
                        Id         = omega.Id,
                        TypeId     = omega.TypeId,
                        TypeName   = omega.Type.Type,
                        MemberId   = omega.MemberId,
                        MemberName = omega.Member.Name,
                        RegNum     = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake    = omega.CarMake,
                        Model      = omega.Model
                    }
                );
            return View(dataset);
#else
            var dataset =
                db.Vehicle
                .OrderByDescending(omega => omega.ParkedTime.ToString())
                .Select(
                    omega => new ParkedVehicleProjection01Ext01 {
                        Id         = omega.Id,
                        TypeId     = omega.TypeId,
                        TypeName   = (omega.TypeId).ToString(),
                        MemberId   = omega.MemberId,
                        MemberName = (omega.MemberId).ToString(),
                        RegNum = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake    = omega.CarMake,
                        Model      = omega.Model
                    }
                );
            return View(dataset);
            // return View(dataset.ToList());
#endif
        }

        public ActionResult DetailedIndex()
        {
            var dataset =
                db.Vehicle
                .Include(omega => omega.Type)
                .Include(omega => omega.Member)
                .OrderByDescending(omega => omega.ParkedTime.ToString())
                .Select(
                    omega => new ParkedVehicleExt01
                    {
                        Id         = omega.Id,
                        TypeId     = omega.TypeId,
                        MemberId   = omega.MemberId,
                        TypeName   = omega.Type.Type,
                        MemberName = omega.Member.Name,
                        Colour     = omega.Colour,
                        NumOfWeels = omega.NumOfWeels,
                        RegNum     = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake    = omega.CarMake,
                        Model      = omega.Model
                    }
                );

            return View(dataset);
            // return View(db.Vehicle);
        }

        // GET: ParkedVehicles1/Details/5
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

        // GET: ParkedVehicles1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeId,MemberId,RegNum,Colour,ParkedTime,NumOfWeels,CarMake,Model")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles1/Edit/5
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

        // POST: ParkedVehicles1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeId,MemberId,RegNum,Colour,ParkedTime,NumOfWeels,CarMake,Model")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles1/Delete/5
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

        // POST: ParkedVehicles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.Vehicle.Find(id);
            db.Vehicle.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
