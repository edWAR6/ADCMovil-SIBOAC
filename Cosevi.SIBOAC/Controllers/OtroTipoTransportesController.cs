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
    public class OtroTipoTransportesController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: OtroTipoTransportes
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.OTROTIPOTRANSPORTE.ToList());
        }

        public string Verificar(string id)
        {
            string mensaje = "";
            bool exist = db.OTROTIPOTRANSPORTE.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El codigo " + id + " ya esta registrado";
            }
            return mensaje;
        }

        // GET: OtroTipoTransportes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            if (otroTipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(otroTipoTransporte);
        }

        // GET: OtroTipoTransportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtroTipoTransportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] OtroTipoTransporte otroTipoTransporte)
        {
            if (ModelState.IsValid)
            {
                db.OTROTIPOTRANSPORTE.Add(otroTipoTransporte);
                string mensaje = Verificar(otroTipoTransporte.Id);
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
                    return View(otroTipoTransporte);
                }
            }

            return View(otroTipoTransporte);
        }

        // GET: OtroTipoTransportes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            if (otroTipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(otroTipoTransporte);
        }

        // POST: OtroTipoTransportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] OtroTipoTransporte otroTipoTransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otroTipoTransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otroTipoTransporte);
        }

        // GET: OtroTipoTransportes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            if (otroTipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(otroTipoTransporte);
        }

        // POST: OtroTipoTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            if (otroTipoTransporte.Estado == "I")
                otroTipoTransporte.Estado = "A";
            else
                otroTipoTransporte.Estado = "I";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: OtroTipoTransportes/RealDelete/5
        public ActionResult RealDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            if (otroTipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(otroTipoTransporte);
        }

        // POST: OtroTipoTransportes/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(string id)
        {
            OtroTipoTransporte otroTipoTransporte = db.OTROTIPOTRANSPORTE.Find(id);
            db.OTROTIPOTRANSPORTE.Remove(otroTipoTransporte);
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
