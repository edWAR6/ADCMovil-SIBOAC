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
    public class CirculacionsController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: Circulacions
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.CIRCULACION.ToList());
        }

        public string Verificar(int id)
        {
            string mensaje = "";
            bool exist = db.CIRCULACION.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El codigo " + id + " ya esta registrado";
            }
            return mensaje;
        }

        // GET: Circulacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulacion circulacion = db.CIRCULACION.Find(id);
            if (circulacion == null)
            {
                return HttpNotFound();
            }
            return View(circulacion);
        }

        // GET: Circulacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Circulacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] Circulacion circulacion)
        {
            if (ModelState.IsValid)
            {
                db.CIRCULACION.Add(circulacion);
                string mensaje = Verificar(circulacion.Id);
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
                    return View(circulacion);
                }
            }

            return View(circulacion);
        }

        // GET: Circulacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulacion circulacion = db.CIRCULACION.Find(id);
            if (circulacion == null)
            {
                return HttpNotFound();
            }
            return View(circulacion);
        }

        // POST: Circulacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] Circulacion circulacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circulacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(circulacion);
        }

        // GET: Circulacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulacion circulacion = db.CIRCULACION.Find(id);
            if (circulacion == null)
            {
                return HttpNotFound();
            }
            return View(circulacion);
        }

        // POST: Circulacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circulacion circulacion = db.CIRCULACION.Find(id);
            if (circulacion.Estado == "A")
                circulacion.Estado = "I";
            else
                circulacion.Estado = "A";
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Circulacions/RealDelete/5
        public ActionResult RealDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circulacion circulacion = db.CIRCULACION.Find(id);
            if (circulacion == null)
            {
                return HttpNotFound();
            }
            return View(circulacion);
        }

        // POST: Circulacions/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(int id)
        {
            Circulacion circulacion = db.CIRCULACION.Find(id);
            db.CIRCULACION.Remove(circulacion);
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
