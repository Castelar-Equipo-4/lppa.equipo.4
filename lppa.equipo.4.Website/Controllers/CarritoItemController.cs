using lppa.equipo._4.Data.Model;
using lppa.equipo._4.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lppa.equipo._4.Website.Controllers
{
    public class CarritoItemController : Controller
    {
        private RestoDbContext db = new RestoDbContext();

        // GET: CarritoItem
        public ActionResult Index()
        {
            var carritoItem = db.CarritoItem.Include(c => c.Carrito);
            try
            {
                return View(carritoItem.ToList());
            }
            catch (Exception)
            {
                return View();
                throw;
            }  
            //return carritoItem.Count() == 0 ? View() : View(carritoItem.ToList());
        }

        // GET: CarritoItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoItem carritoItem = db.CarritoItem.Find(id);
            if (carritoItem == null)
            {
                return HttpNotFound();
            }
            return View(carritoItem);
        }

        // GET: CarritoItem/Create
        public ActionResult Create()
        {
            ViewBag.CarritoId = new SelectList(db.Carrito, "Id", "Cookie");
            return View();
        }

        // POST: CarritoItem/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarritoId,ObrasId,Price,Quantity,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] CarritoItem carritoItem)
        {
            if (ModelState.IsValid)
            {
                db.CarritoItem.Add(carritoItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarritoId = new SelectList(db.Carrito, "Id", "Cookie", carritoItem.CarritoId);
            return View(carritoItem);
        }

        // GET: CarritoItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoItem carritoItem = db.CarritoItem.Find(id);
            if (carritoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarritoId = new SelectList(db.Carrito, "Id", "Cookie", carritoItem.CarritoId);
            return View(carritoItem);
        }

        // POST: CarritoItem/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarritoId,ObrasId,Price,Quantity,CreatedOn,CreatedBy,ChangedOn,ChangedBy")] CarritoItem carritoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carritoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarritoId = new SelectList(db.Carrito, "Id", "Cookie", carritoItem.CarritoId);
            return View(carritoItem);
        }

        // GET: CarritoItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarritoItem carritoItem = db.CarritoItem.Find(id);
            if (carritoItem == null)
            {
                return HttpNotFound();
            }
            return View(carritoItem);
        }

        // POST: CarritoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarritoItem carritoItem = db.CarritoItem.Find(id);
            db.CarritoItem.Remove(carritoItem);
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
