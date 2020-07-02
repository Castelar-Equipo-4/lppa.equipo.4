using lppa.equipo._4.BLL;
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
    public class ObrasController : BaseController
    {
        private BaseDataService<Obras> db;
        public ObrasController()
        {
            db = new BaseDataService<Obras>();
        }

  
        public ActionResult Index()
        {
            var model = db.Get();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Obras obras)
        {
            this.CheckAuditPattern(obras, true);
            var list = db.ValidateModel(obras);
            if (ModelIsValid(list))
                return View(obras);
            try
            {
                db.Create(obras);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(obras);
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var obras = db.GetById(id.Value);
            if (obras == null)
            {
                Logger.Instance.LogException(new Exception("Obras HttpNotFound"));
                return HttpNotFound();
            }
            return View(obras);
        }
        [HttpPost]
        public ActionResult Edit(Obras obras)
        {
            this.CheckAuditPattern(obras);
            var list = db.ValidateModel(obras);
            if (ModelIsValid(list))
                return View(obras);
            try
            {
                db.Update(obras);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(obras);
            }

        }
    
    }
}
