﻿using System;
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
    public class GoodsDonationsController : Controller
    {
        private Disaster_Relief_FoundationEntities1 db = new Disaster_Relief_FoundationEntities1();

        // GET: GoodsDonations
        public ActionResult Index()
        {
            var goodsDonations = db.GoodsDonations.Include(g => g.Disaster);
            return View(goodsDonations.ToList());
        }

        // GET: GoodsDonations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsDonation goodsDonation = db.GoodsDonations.Find(id);
            if (goodsDonation == null)
            {
                return HttpNotFound();
            }
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Create
        public ActionResult Create()
        {
            ViewBag.GoodsDonorID = new SelectList(db.Disasters, "DisasterID", "Location");
            return View();
        }

        // POST: GoodsDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsDonorID,Date,Items,DisasterID,GoodsCategory,GoodDescription,status")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                db.GoodsDonations.Add(goodsDonation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsDonorID = new SelectList(db.Disasters, "DisasterID", "Location", goodsDonation.GoodsDonorID);
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsDonation goodsDonation = db.GoodsDonations.Find(id);
            if (goodsDonation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsDonorID = new SelectList(db.Disasters, "DisasterID", "Location", goodsDonation.GoodsDonorID);
            return View(goodsDonation);
        }

        // POST: GoodsDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsDonorID,Date,Items,DisasterID,GoodsCategory,GoodDescription,status")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodsDonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsDonorID = new SelectList(db.Disasters, "DisasterID", "Location", goodsDonation.GoodsDonorID);
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsDonation goodsDonation = db.GoodsDonations.Find(id);
            if (goodsDonation == null)
            {
                return HttpNotFound();
            }
            return View(goodsDonation);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodsDonation goodsDonation = db.GoodsDonations.Find(id);
            db.GoodsDonations.Remove(goodsDonation);
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
