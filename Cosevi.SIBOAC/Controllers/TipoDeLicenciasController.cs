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
    public class TipoDeLicenciasController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: TipoDeLicencias
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.TIPO_LICENCIA.ToList());
        }



        public string Verificar(string id)
        {
            string mensaje = "";
            bool exist = db.TIPO_LICENCIA.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El código " + id + " ya esta registrado";
            }
            return mensaje;
        }



        // GET: TipoDeLicencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            if (tipoDeLicencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeLicencia);
        }

        // GET: TipoDeLicencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeLicencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] TipoDeLicencia tipoDeLicencia)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_LICENCIA.Add(tipoDeLicencia);
                string mensaje = Verificar(tipoDeLicencia.Id);
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
                    return View(tipoDeLicencia);
                }
            }

            return View(tipoDeLicencia);
        }

        // GET: TipoDeLicencias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            if (tipoDeLicencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeLicencia);
        }

        // POST: TipoDeLicencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] TipoDeLicencia tipoDeLicencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeLicencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeLicencia);
        }

        // GET: TipoDeLicencias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            if (tipoDeLicencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeLicencia);
        }

        // POST: TipoDeLicencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            if (tipoDeLicencia.Estado == "I")
                tipoDeLicencia.Estado = "A";
            else
                tipoDeLicencia.Estado = "I";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TipoDeLicencias/Delete/5
        public ActionResult RealDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            if (tipoDeLicencia == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeLicencia);
        }

        // POST: TipoDeLicencias/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(string id)
        {
            TipoDeLicencia tipoDeLicencia = db.TIPO_LICENCIA.Find(id);
            db.TIPO_LICENCIA.Remove(tipoDeLicencia);
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
