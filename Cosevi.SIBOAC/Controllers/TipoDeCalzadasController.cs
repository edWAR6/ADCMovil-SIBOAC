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
    public class TipoDeCalzadasController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: TipoDeCalzadas
        public ActionResult Index()
        {
            return View(db.TIPOCALZADA.ToList());
        }

        // GET: TipoDeCalzadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCalzada tipoDeCalzada = db.TIPOCALZADA.Find(id);
            if (tipoDeCalzada == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCalzada);
        }

        // GET: TipoDeCalzadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeCalzadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] TipoDeCalzada tipoDeCalzada)
        {
            if (ModelState.IsValid)
            {
                db.TIPOCALZADA.Add(tipoDeCalzada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeCalzada);
        }

        // GET: TipoDeCalzadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCalzada tipoDeCalzada = db.TIPOCALZADA.Find(id);
            if (tipoDeCalzada == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCalzada);
        }

        // POST: TipoDeCalzadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] TipoDeCalzada tipoDeCalzada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeCalzada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeCalzada);
        }

        // GET: TipoDeCalzadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeCalzada tipoDeCalzada = db.TIPOCALZADA.Find(id);
            if (tipoDeCalzada == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeCalzada);
        }

        // POST: TipoDeCalzadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeCalzada tipoDeCalzada = db.TIPOCALZADA.Find(id);
            db.TIPOCALZADA.Remove(tipoDeCalzada);
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
