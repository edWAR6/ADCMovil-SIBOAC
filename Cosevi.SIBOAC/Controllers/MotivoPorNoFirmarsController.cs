﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cosevi.SIBOAC.Models;

namespace Cosevi.SIBOAC.Controllers
{
    public class MotivoPorNoFirmarsController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: MotivoPorNoFirmars
        public ActionResult Index()
        {
            return View(db.MotivoPorNoFirmars.ToList());
        }

        // GET: MotivoPorNoFirmars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoPorNoFirmar motivoPorNoFirmar = db.MotivoPorNoFirmars.Find(id);
            if (motivoPorNoFirmar == null)
            {
                return HttpNotFound();
            }
            return View(motivoPorNoFirmar);
        }

        // GET: MotivoPorNoFirmars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotivoPorNoFirmars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] MotivoPorNoFirmar motivoPorNoFirmar)
        {
            if (ModelState.IsValid)
            {
                db.MotivoPorNoFirmars.Add(motivoPorNoFirmar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivoPorNoFirmar);
        }

        // GET: MotivoPorNoFirmars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoPorNoFirmar motivoPorNoFirmar = db.MotivoPorNoFirmars.Find(id);
            if (motivoPorNoFirmar == null)
            {
                return HttpNotFound();
            }
            return View(motivoPorNoFirmar);
        }

        // POST: MotivoPorNoFirmars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] MotivoPorNoFirmar motivoPorNoFirmar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivoPorNoFirmar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivoPorNoFirmar);
        }

        // GET: MotivoPorNoFirmars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoPorNoFirmar motivoPorNoFirmar = db.MotivoPorNoFirmars.Find(id);
            if (motivoPorNoFirmar == null)
            {
                return HttpNotFound();
            }
            return View(motivoPorNoFirmar);
        }

        // POST: MotivoPorNoFirmars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MotivoPorNoFirmar motivoPorNoFirmar = db.MotivoPorNoFirmars.Find(id);
            motivoPorNoFirmar.Estado = "I";            
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