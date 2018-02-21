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
            var dataset =
                db.Vehicle
                .Include(omega => omega.Type)
                .Include(omega => omega.Member)
                .OrderByDescending(omega => omega.ParkedTime.ToString())
                .Select(
                    omega => new ParkedVehicleProjection01Ext01
                    {
                        Id = omega.Id,
                        TypeId = omega.TypeId,
                        TypeName = omega.Type.Type,
                        MemberId = omega.MemberId,
                        MemberName = omega.Member.Name,
                        RegNum = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake = omega.CarMake,
                        Model = omega.Model
                    }
                );
            return View(dataset);
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
                        Id = omega.Id,
                        TypeId = omega.TypeId,
                        MemberId = omega.MemberId,
                        TypeName = omega.Type.Type,
                        MemberName = omega.Member.Name,
                        Colour = omega.Colour,
                        NumOfWeels = omega.NumOfWeels,
                        RegNum = omega.RegNum,
                        ParkedTime = omega.ParkedTime,
                        CarMake = omega.CarMake,
                        Model = omega.Model
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
            ICollection<VehicleType> type = db.VehicleType.ToList();
            List<SelectListItem> typeList = new List<SelectListItem>();
            foreach (var item in type)
            {
                typeList.Add(new SelectListItem
                {
                    Text = item.Type,
                    Value = item.Id.ToString()
                });
            };
            ViewBag.TypeList = typeList;

            ICollection<Member> member = db.Member.ToList();
            List<SelectListItem> memberList = new List<SelectListItem>();
            foreach (var item in member)
            {
                memberList.Add(new SelectListItem
                {
                    Text = item.Id.ToString() + "       [Medlemsnamn: " + item.Name + "]",
                    Value = item.Id.ToString()
                });
            };
            ViewBag.MemberList = memberList;

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

            ICollection<VehicleType> type = db.VehicleType.ToList();
            List<SelectListItem> typeList = new List<SelectListItem>();
            foreach (var item in type)
            {
                typeList.Add(new SelectListItem
                {
                    Text = item.Type,
                    Value = item.Id.ToString()
                });
            };
            ViewBag.TypeList = typeList;
            ViewBag.TypeSelected = parkedVehicle.Id;

            ICollection<Member> member = db.Member.ToList();
            List<SelectListItem> memberList = new List<SelectListItem>();
            foreach (var item in member)
            {
                memberList.Add(new SelectListItem
                {
                    Text = item.Id.ToString() + "       [Medlemsnamn: " + item.Name + "]",
                    Value = item.Id.ToString()
                });
            };
            ViewBag.MemberList = memberList;
            ViewBag.MemberSelected = parkedVehicle.Member.Id;

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

                // Exclude ParkedTime column from update (by HD).
                db.Entry(parkedVehicle).Property(x => x.ParkedTime).IsModified = false;

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
