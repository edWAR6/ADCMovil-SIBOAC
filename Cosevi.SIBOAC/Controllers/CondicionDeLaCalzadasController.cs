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
    public class CondicionDeLaCalzadasController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: CondicionDeLaCalzadas
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            return View(db.CONDCALZADA.ToList());
        }

        public string Verificar(int id)
        {
            string mensaje = "";
            bool exist = db.CARROCERIA.Any(x => x.Id == id);
            if (exist)
            {
                mensaje = "El codigo " + id + " ya esta registrado";
            }
            return mensaje;
        }

        // GET: CondicionDeLaCalzadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            if (condicionDeLaCalzada == null)
            {
                return HttpNotFound();
            }
            return View(condicionDeLaCalzada);
        }

        // GET: CondicionDeLaCalzadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionDeLaCalzadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] CondicionDeLaCalzada condicionDeLaCalzada)
        {
            if (ModelState.IsValid)
            {
                db.CONDCALZADA.Add(condicionDeLaCalzada);
                string mensaje = Verificar(condicionDeLaCalzada.Id);
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
                    return View(condicionDeLaCalzada);
                }
            }

            return View(condicionDeLaCalzada);
        }

        // GET: CondicionDeLaCalzadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            if (condicionDeLaCalzada == null)
            {
                return HttpNotFound();
            }
            return View(condicionDeLaCalzada);
        }

        // POST: CondicionDeLaCalzadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado,FechaDeInicio,FechaDeFin")] CondicionDeLaCalzada condicionDeLaCalzada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicionDeLaCalzada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicionDeLaCalzada);
        }

        // GET: CondicionDeLaCalzadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            if (condicionDeLaCalzada == null)
            {
                return HttpNotFound();
            }
            return View(condicionDeLaCalzada);
        }

        // POST: CondicionDeLaCalzadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            if (condicionDeLaCalzada.Estado == "A")
                condicionDeLaCalzada.Estado = "I";
            else
                condicionDeLaCalzada.Estado = "A";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CondicionDeLaCalzadas/RealDelete/5
        public ActionResult RealDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            if (condicionDeLaCalzada == null)
            {
                return HttpNotFound();
            }
            return View(condicionDeLaCalzada);
        }

        // POST: CondicionDeLaCalzadas/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(int id)
        {
            CondicionDeLaCalzada condicionDeLaCalzada = db.CONDCALZADA.Find(id);
            db.CONDCALZADA.Remove(condicionDeLaCalzada);
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
