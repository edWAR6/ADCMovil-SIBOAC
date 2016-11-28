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
    public class RolSIBOACsController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: RolSIBOACs
        public ActionResult Index()
        {
            return View(db.RolSIBOACs.ToList());
        }

        // GET: RolSIBOACs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSIBOAC rolSIBOAC = db.RolSIBOACs.Find(id);
            if (rolSIBOAC == null)
            {
                return HttpNotFound();
            }
            return View(rolSIBOAC);
        }

        // GET: RolSIBOACs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolSIBOACs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoRol,Descripcion")] RolSIBOAC rolSIBOAC)
        {
            if (ModelState.IsValid)
            {
                db.RolSIBOACs.Add(rolSIBOAC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolSIBOAC);
        }

        // GET: RolSIBOACs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSIBOAC rolSIBOAC = db.RolSIBOACs.Find(id);
            if (rolSIBOAC == null)
            {
                return HttpNotFound();
            }
            return View(rolSIBOAC);
        }

        // POST: RolSIBOACs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoRol,Descripcion")] RolSIBOAC rolSIBOAC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolSIBOAC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolSIBOAC);
        }

        // GET: RolSIBOACs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolSIBOAC rolSIBOAC = db.RolSIBOACs.Find(id);
            if (rolSIBOAC == null)
            {
                return HttpNotFound();
            }
            return View(rolSIBOAC);
        }

        // POST: RolSIBOACs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolSIBOAC rolSIBOAC = db.RolSIBOACs.Find(id);
            db.RolSIBOACs.Remove(rolSIBOAC);
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
