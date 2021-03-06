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
    public class TipoDeIdentificacionPorTipoVehiculoesController : Controller
    {
        private PC_HH_AndroidEntities db = new PC_HH_AndroidEntities();

        // GET: TipoDeIdentificacionPorTipoVehiculoes
        public ActionResult Index()
        {
            ViewBag.Type = TempData["Type"] != null ? TempData["Type"].ToString() : "";
            ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : "";
            var list =
             (
                from t in db.TIPOIDEVEHICULOXTIPOVEH
                join ti in db.TIPOIDEVEHICULO on new { Id = t.CodigoTipoIDEVehiculo } equals new { Id = ti.Id } into ti_join
                from ti in ti_join.DefaultIfEmpty()
                join tv in db.TIPOVEH on new { Id = t.CodigoTipoVeh } equals new { Id = tv.Id } into tv_join
                from tv in tv_join.DefaultIfEmpty()
                select new
                {
                    CodigoTipoIDEVehiculo= t.CodigoTipoIDEVehiculo,
                    CodigoTipoVeh = t.CodigoTipoVeh,
                    Estado= t.Estado,
                    FechaDeInicio= t.FechaDeInicio,
                    FechaDeFin = t.FechaDeFin,
                    DescripcionCodigoTipoIDEVehiculo = ti.Descripcion,
                    DescripcionCodigoTipoVeh = tv.Descripcion
                }).ToList()

              .Select(x => new TipoDeIdentificacionPorTipoVehiculo
              {
                  CodigoTipoIDEVehiculo = x.CodigoTipoIDEVehiculo,
                  CodigoTipoVeh = x.CodigoTipoVeh,
                  Estado = x.Estado,
                  FechaDeInicio = x.FechaDeInicio,
                  FechaDeFin = x.FechaDeFin,
                  DescripcionCodigoTipoIDEVehiculo = x.DescripcionCodigoTipoIDEVehiculo,
                  DescripcionCodigoTipoVeh = x.DescripcionCodigoTipoVeh

              });
            return View(list);
        }

        // GET: TipoDeIdentificacionPorTipoVehiculoes/Details/5
        public ActionResult Details(string Codigo, int? CodVeh)
        {
            if (Codigo== null ||CodVeh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var list =
               (
                  from t in db.TIPOIDEVEHICULOXTIPOVEH
                  join ti in db.TIPOIDEVEHICULO on new { Id = t.CodigoTipoIDEVehiculo } equals new { Id = ti.Id } into ti_join
                  where t.CodigoTipoIDEVehiculo == Codigo  && t.CodigoTipoVeh == CodVeh
                  from ti in ti_join.DefaultIfEmpty()
                  join tv in db.TIPOVEH on new { Id = t.CodigoTipoVeh } equals new { Id = tv.Id } into tv_join
                  from tv in tv_join.DefaultIfEmpty()
                  select new
                  {
                      CodigoTipoIDEVehiculo = t.CodigoTipoIDEVehiculo,
                      CodigoTipoVeh = t.CodigoTipoVeh,
                      Estado = t.Estado,
                      FechaDeInicio = t.FechaDeInicio,
                      FechaDeFin = t.FechaDeFin,
                      DescripcionCodigoTipoIDEVehiculo = ti.Descripcion,
                      DescripcionCodigoTipoVeh = tv.Descripcion
                  }).ToList()
                .Select(x => new TipoDeIdentificacionPorTipoVehiculo
                {
                    CodigoTipoIDEVehiculo = x.CodigoTipoIDEVehiculo,
                    CodigoTipoVeh = x.CodigoTipoVeh,
                    Estado = x.Estado,
                    FechaDeInicio = x.FechaDeInicio,
                    FechaDeFin = x.FechaDeFin,
                    DescripcionCodigoTipoIDEVehiculo = x.DescripcionCodigoTipoIDEVehiculo,
                    DescripcionCodigoTipoVeh = x.DescripcionCodigoTipoVeh

                }).SingleOrDefault();

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: TipoDeIdentificacionPorTipoVehiculoes/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> itemsTipoIdVehiculo = db.TIPOIDEVEHICULO
           .Select(o => new SelectListItem
           {
               Value = o.Id,
               Text = o.Descripcion
           });
            ViewBag.ComboTipoIdVehiculo = itemsTipoIdVehiculo;
            IEnumerable<SelectListItem> itemsTipoVeh = db.TIPOVEH
             .Select(c => new SelectListItem
             {
                 Value = c.Id.ToString(),
                 Text = c.Descripcion
             });
            ViewBag.ComboCodVeh = itemsTipoVeh;
            return View();
        }

        // POST: TipoDeIdentificacionPorTipoVehiculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoTipoIDEVehiculo,CodigoTipoVeh,Estado,FechaDeInicio,FechaDeFin")] TipoDeIdentificacionPorTipoVehiculo tipoDeIdentificacionPorTipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.TIPOIDEVEHICULOXTIPOVEH.Add(tipoDeIdentificacionPorTipoVehiculo);
                string mensaje = Verificar(tipoDeIdentificacionPorTipoVehiculo.CodigoTipoIDEVehiculo,
                                              tipoDeIdentificacionPorTipoVehiculo.CodigoTipoVeh);
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
                    return View(tipoDeIdentificacionPorTipoVehiculo);
                }
            }

            return View(tipoDeIdentificacionPorTipoVehiculo);
        }

        public string Verificar(string Codigo, int? CodVeh)
        {
            string mensaje = "";
            bool exist = db.TIPOIDEVEHICULOXTIPOVEH.Any(x => x.CodigoTipoIDEVehiculo == Codigo
                                                    && x.CodigoTipoVeh == CodVeh);
            if (exist)
            {
                mensaje = "El registro con los siguientes datos ya se encuentra registrados:" +
                           " código de tipo identificación vehículo " + Codigo +
                           ", código tipo vehículo" + CodVeh;

            }
            return mensaje;
        }

        // GET: TipoDeIdentificacionPorTipoVehiculoes/Edit/5
        public ActionResult Edit(string Codigo, int? CodVeh)
        {
            if (Codigo == null || CodVeh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list =
              (
                 from t in db.TIPOIDEVEHICULOXTIPOVEH
                 join ti in db.TIPOIDEVEHICULO on new { Id = t.CodigoTipoIDEVehiculo } equals new { Id = ti.Id } into ti_join
                 where t.CodigoTipoIDEVehiculo == Codigo && t.CodigoTipoVeh == CodVeh
                 from ti in ti_join.DefaultIfEmpty()
                 join tv in db.TIPOVEH on new { Id = t.CodigoTipoVeh } equals new { Id = tv.Id } into tv_join
                 from tv in tv_join.DefaultIfEmpty()
                 select new
                 {
                     CodigoTipoIDEVehiculo = t.CodigoTipoIDEVehiculo,
                     CodigoTipoVeh = t.CodigoTipoVeh,
                     Estado = t.Estado,
                     FechaDeInicio = t.FechaDeInicio,
                     FechaDeFin = t.FechaDeFin,
                     DescripcionCodigoTipoIDEVehiculo = ti.Descripcion,
                     DescripcionCodigoTipoVeh = tv.Descripcion
                 }).ToList()
               .Select(x => new TipoDeIdentificacionPorTipoVehiculo
               {
                   CodigoTipoIDEVehiculo = x.CodigoTipoIDEVehiculo,
                   CodigoTipoVeh = x.CodigoTipoVeh,
                   Estado = x.Estado,
                   FechaDeInicio = x.FechaDeInicio,
                   FechaDeFin = x.FechaDeFin,
                   DescripcionCodigoTipoIDEVehiculo = x.DescripcionCodigoTipoIDEVehiculo,
                   DescripcionCodigoTipoVeh = x.DescripcionCodigoTipoVeh

               }).SingleOrDefault();

            if (list == null)
            {
                return HttpNotFound();
            }

            ViewBag.ComboTipoIdVehiculo = new SelectList(db.TIPOIDEVEHICULO.OrderBy(x => x.Descripcion), "Id", "Descripcion", Codigo);
            ViewBag.ComboCodVeh = new SelectList(db.TIPOVEH.OrderBy(x => x.Descripcion), "Id".ToString(), "Descripcion", CodVeh);

            return View(list);
        }

        // POST: TipoDeIdentificacionPorTipoVehiculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoTipoIDEVehiculo,CodigoTipoVeh,Estado,FechaDeInicio,FechaDeFin")] TipoDeIdentificacionPorTipoVehiculo tipoDeIdentificacionPorTipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeIdentificacionPorTipoVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeIdentificacionPorTipoVehiculo);
        }

        // GET: TipoDeIdentificacionPorTipoVehiculoes/Delete/5
        public ActionResult Delete(string Codigo, int? CodVeh)
        {
            if (Codigo  == null|| CodVeh ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list =
              (
                 from t in db.TIPOIDEVEHICULOXTIPOVEH
                 join ti in db.TIPOIDEVEHICULO on new { Id = t.CodigoTipoIDEVehiculo } equals new { Id = ti.Id } into ti_join
                 where t.CodigoTipoIDEVehiculo == Codigo && t.CodigoTipoVeh == CodVeh
                 from ti in ti_join.DefaultIfEmpty()
                 join tv in db.TIPOVEH on new { Id = t.CodigoTipoVeh } equals new { Id = tv.Id } into tv_join
                 from tv in tv_join.DefaultIfEmpty()
                 select new
                 {
                     CodigoTipoIDEVehiculo = t.CodigoTipoIDEVehiculo,
                     CodigoTipoVeh = t.CodigoTipoVeh,
                     Estado = t.Estado,
                     FechaDeInicio = t.FechaDeInicio,
                     FechaDeFin = t.FechaDeFin,
                     DescripcionCodigoTipoIDEVehiculo = ti.Descripcion,
                     DescripcionCodigoTipoVeh = tv.Descripcion
                 }).ToList()
               .Select(x => new TipoDeIdentificacionPorTipoVehiculo
               {
                   CodigoTipoIDEVehiculo = x.CodigoTipoIDEVehiculo,
                   CodigoTipoVeh = x.CodigoTipoVeh,
                   Estado = x.Estado,
                   FechaDeInicio = x.FechaDeInicio,
                   FechaDeFin = x.FechaDeFin,
                   DescripcionCodigoTipoIDEVehiculo = x.DescripcionCodigoTipoIDEVehiculo,
                   DescripcionCodigoTipoVeh = x.DescripcionCodigoTipoVeh

               }).SingleOrDefault();

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: TipoDeIdentificacionPorTipoVehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string Codigo, int? CodVeh)
        {
            TipoDeIdentificacionPorTipoVehiculo tipoDeIdentificacionPorTipoVehiculo = db.TIPOIDEVEHICULOXTIPOVEH.Find(Codigo,CodVeh);
            if (tipoDeIdentificacionPorTipoVehiculo.Estado == "I")
                tipoDeIdentificacionPorTipoVehiculo.Estado = "A";
            else
                tipoDeIdentificacionPorTipoVehiculo.Estado = "I";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TipoDeIdentificacionPorTipoVehiculoes/RealDelete/5
        public ActionResult RealDelete(string Codigo, int? CodVeh)
        {
            if (Codigo == null || CodVeh == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var list =
              (
                 from t in db.TIPOIDEVEHICULOXTIPOVEH
                 join ti in db.TIPOIDEVEHICULO on new { Id = t.CodigoTipoIDEVehiculo } equals new { Id = ti.Id } into ti_join
                 where t.CodigoTipoIDEVehiculo == Codigo && t.CodigoTipoVeh == CodVeh
                 from ti in ti_join.DefaultIfEmpty()
                 join tv in db.TIPOVEH on new { Id = t.CodigoTipoVeh } equals new { Id = tv.Id } into tv_join
                 from tv in tv_join.DefaultIfEmpty()
                 select new
                 {
                     CodigoTipoIDEVehiculo = t.CodigoTipoIDEVehiculo,
                     CodigoTipoVeh = t.CodigoTipoVeh,
                     Estado = t.Estado,
                     FechaDeInicio = t.FechaDeInicio,
                     FechaDeFin = t.FechaDeFin,
                     DescripcionCodigoTipoIDEVehiculo = ti.Descripcion,
                     DescripcionCodigoTipoVeh = tv.Descripcion
                 }).ToList()
               .Select(x => new TipoDeIdentificacionPorTipoVehiculo
               {
                   CodigoTipoIDEVehiculo = x.CodigoTipoIDEVehiculo,
                   CodigoTipoVeh = x.CodigoTipoVeh,
                   Estado = x.Estado,
                   FechaDeInicio = x.FechaDeInicio,
                   FechaDeFin = x.FechaDeFin,
                   DescripcionCodigoTipoIDEVehiculo = x.DescripcionCodigoTipoIDEVehiculo,
                   DescripcionCodigoTipoVeh = x.DescripcionCodigoTipoVeh

               }).SingleOrDefault();

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: TipoDeIdentificacionPorTipoVehiculoes/RealDelete/5
        [HttpPost, ActionName("RealDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RealDeleteConfirmed(string Codigo, int? CodVeh)
        {
            TipoDeIdentificacionPorTipoVehiculo tipoDeIdentificacionPorTipoVehiculo = db.TIPOIDEVEHICULOXTIPOVEH.Find(Codigo, CodVeh);
            db.TIPOIDEVEHICULOXTIPOVEH.Remove(tipoDeIdentificacionPorTipoVehiculo);
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
