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
    public class SenalamientoesController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: Senalamientoes
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.SEÑALAMIENTO.ToList());
        }

        public string Verificar(int id)
        {
            string mensaje = "";
            bool exist = db.SEÑALAMIENTO.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El codigo " + id + " ya esta registrado";
            }
            return mensaje;
        }

        // GET: Senalamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            if (senalamiento == null)
            {
                return HttpNotFound();
            }
            return View(senalamiento);
        }

        // GET: Senalamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Senalamientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] Senalamiento senalamiento)
        {
            if (ModelState.IsValid)
            {
                db.SEÑALAMIENTO.Add(senalamiento);
                string mensaje = Verificar(senalamiento.Id);
                if (mensaje == "")
                {
                    db.SaveChanges();
                    TempData["Type"] = "success";
                    TempData["Message"] = "El registro se realizó correctamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Type = "warning";
                    ViewBag.Message = mensaje;
                    return View(senalamiento);
                }
            }

            return View(senalamiento);
        }

        // GET: Senalamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            if (senalamiento == null)
            {
                return HttpNotFound();
            }
            return View(senalamiento);
        }

        // POST: Senalamientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] Senalamiento senalamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(senalamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(senalamiento);
        }

        // GET: Senalamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            if (senalamiento == null)
            {
                return HttpNotFound();
            }
            return View(senalamiento);
        }

        // POST: Senalamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            if (senalamiento.Estado == "I")
                senalamiento.Estado = "A";
            else
                senalamiento.Estado = "I";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Senalamientoes/RealDelete/5
        public ActionResult RealDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            if (senalamiento == null)
            {
                return HttpNotFound();
            }
            return View(senalamiento);
        }

        // POST: Senalamientoes/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(int id)
        {
            Senalamiento senalamiento = db.SEÑALAMIENTO.Find(id);
            db.SEÑALAMIENTO.Remove(senalamiento);
            db.SaveChanges();
            TempData["Type"] = "error";
            TempData["Message"] = "El registro se eliminó correctamente";
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
