﻿using lppa.equipo._4.BLL;
using lppa.equipo._4.Data.Model;
using lppa.equipo._4.Data.Services;
using lppa.equipo._4.Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lppa.equipo._4.Website.Controllers
{
    [Authorize]
    public class ArtistController : BaseController
    {
        private BaseDataService<Artist> db;
        public ArtistController()
        {
            db = new BaseDataService<Artist>();
        }

        public ActionResult Index()
        {

            //var i = 0;
            //var result = 15 / i;

            var list = db.Get();
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var list = db.ValidateModel(artist);
            if (ModelIsValid(list))
                return View(artist);
            try
            {
                db.Create(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                Logger.Instance.LogException(new Exception("Artist HttpNotFound"));
                return HttpNotFound();
            }
            return View(artist);
        }
        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            this.CheckAuditPattern(artist);
            var list = db.ValidateModel(artist);
            if (ModelIsValid(list))
                return View(artist);
            try
            {
                db.Update(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                Logger.Instance.LogException(new Exception("Artist HttpNotFound"));
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            try
            {
                db.Delete(artist);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
    }
}
