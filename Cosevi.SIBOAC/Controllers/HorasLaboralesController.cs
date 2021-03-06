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
    public class HorasLaboralesController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: HorasLaborales
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.HORASLABORALES.ToList());
        }



        public string Verificar(int id)
        {
            string mensaje = "";
            bool exist = db.HORASLABORALES.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El código " + id + " ya esta registrado";
            }
            return mensaje;
        }



        // GET: HorasLaborales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            if (horasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(horasLaborales);
        }

        // GET: HorasLaborales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorasLaborales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] HorasLaborales horasLaborales)
        {
            if (ModelState.IsValid)
            {
                db.HORASLABORALES.Add(horasLaborales);
                string mensaje = Verificar(horasLaborales.Id);
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
                    return View(horasLaborales);
                }

            }

            return View(horasLaborales);
        }

        // GET: HorasLaborales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            if (horasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(horasLaborales);
        }

        // POST: HorasLaborales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] HorasLaborales horasLaborales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horasLaborales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horasLaborales);
        }

        // GET: HorasLaborales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            if (horasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(horasLaborales);
        }

        // POST: HorasLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            if (horasLaborales.Estado == "A")
                horasLaborales.Estado = "I";
            else
                horasLaborales.Estado = "A";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: HorasLaborales/RealDelete/5
        public ActionResult RealDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            if (horasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(horasLaborales);
        }

        // POST: HorasLaborales/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(int id)
        {
            HorasLaborales horasLaborales = db.HORASLABORALES.Find(id);
            db.HORASLABORALES.Remove(horasLaborales);
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
