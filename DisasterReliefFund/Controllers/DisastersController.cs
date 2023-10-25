using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisasterReliefFund.Models;

namespace DisasterReliefFund.Controllers


{
    [Authorize]
    public class DisastersController : Controller
    {
        private Disaster_Relief_FoundationEntities1 db = new Disaster_Relief_FoundationEntities1();

        // GET: Disasters
        public ActionResult Index()
        {
            var disasters = db.Disasters.Include(d => d.MonetaryDonation).Include(d => d.GoodsDonation);
            return View(disasters.ToList());
        }

        // GET: Disasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // GET: Disasters/Create
        public ActionResult Create()
        {
            ViewBag.DisasterID = new SelectList(db.MonetaryDonations, "DisasterDonorID", "status");
            ViewBag.DisasterID = new SelectList(db.GoodsDonations, "GoodsDonorID", "GoodsCategory");
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisasterID,Start_Date,End_Date,Location,Aid_Type")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Disasters.Add(disaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterID = new SelectList(db.MonetaryDonations, "DisasterDonorID", "status", disaster.DisasterID);
            ViewBag.DisasterID = new SelectList(db.GoodsDonations, "GoodsDonorID", "GoodsCategory", disaster.DisasterID);
            return View(disaster);
        }

        // GET: Disasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterID = new SelectList(db.MonetaryDonations, "DisasterDonorID", "status", disaster.DisasterID);
            ViewBag.DisasterID = new SelectList(db.GoodsDonations, "GoodsDonorID", "GoodsCategory", disaster.DisasterID);
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisasterID,Start_Date,End_Date,Location,Aid_Type")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterID = new SelectList(db.MonetaryDonations, "DisasterDonorID", "status", disaster.DisasterID);
            ViewBag.DisasterID = new SelectList(db.GoodsDonations, "GoodsDonorID", "GoodsCategory", disaster.DisasterID);
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disaster disaster = db.Disasters.Find(id);
            db.Disasters.Remove(disaster);
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
