using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lppa.equipo._4.Services;

namespace lppa.equipo._4.Website.Controllers
{
    public class ObrasController : Controller
    {
        readonly IArtistaData db;

        public ObrasController()
        {
            db = new InMemoryArtistaData();
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
    }
}
