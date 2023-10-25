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
    public class MonetaryDonationsController : Controller
    {
        private Disaster_Relief_FoundationEntities1 db = new Disaster_Relief_FoundationEntities1();

        // GET: MonetaryDonations
        public ActionResult Index()
        {
            var monetaryDonations = db.MonetaryDonations.Include(m => m.Disaster);
            return View(monetaryDonations.ToList());
        }

        // GET: MonetaryDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonetaryDonation monetaryDonation = db.MonetaryDonations.Find(id);
            if (monetaryDonation == null)
            {
                return HttpNotFound();
            }
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Create
        public ActionResult Create()
        {
            ViewBag.DisasterDonorID = new SelectList(db.Disasters, "DisasterID", "Location");
            return View();
        }

        // POST: MonetaryDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisasterDonorID,DisasterID,Amount,Date,status")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                db.MonetaryDonations.Add(monetaryDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterDonorID = new SelectList(db.Disasters, "DisasterID", "Location", monetaryDonation.DisasterDonorID);
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonetaryDonation monetaryDonation = db.MonetaryDonations.Find(id);
            if (monetaryDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterDonorID = new SelectList(db.Disasters, "DisasterID", "Location", monetaryDonation.DisasterDonorID);
            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisasterDonorID,DisasterID,Amount,Date,status")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monetaryDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterDonorID = new SelectList(db.Disasters, "DisasterID", "Location", monetaryDonation.DisasterDonorID);
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonetaryDonation monetaryDonation = db.MonetaryDonations.Find(id);
            if (monetaryDonation == null)
            {
                return HttpNotFound();
            }
            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonetaryDonation monetaryDonation = db.MonetaryDonations.Find(id);
            db.MonetaryDonations.Remove(monetaryDonation);
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
