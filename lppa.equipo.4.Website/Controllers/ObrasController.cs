using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lppa.equipo._4.Website.Controllers
{
    public class ObrasController : Controller
    {
        // GET: Obras
        public ActionResult Index()
        {
            return View();
        }

        // GET: Obras/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Obras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obras/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Obras/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Obras/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Obras/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Obras/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
