using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio2.Models;

namespace Desafio2.Controllers
{
    public class ItemPedidoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemPedidoes
        public ActionResult Index(int? pedidoId)
        {
            if (pedidoId == null)
            {
                return RedirectToAction("Index", "Pedidoes", null);
            }
            ViewBag.PedidoId = pedidoId;
            var itemsPedido = db.ItemsPedido.Include(i => i.Pedido).Include(i => i.Producto).Where(w => w.PedidoId == pedidoId);
            return View(itemsPedido.ToList());
        }

        // GET: ItemPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemsPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Create
        public ActionResult Create(int? pedidoId)
        {
            if (pedidoId == null)
            {
                return RedirectToAction("Index", "Pedidoes", null);
            }           
            ViewBag.PedidoId = pedidoId;
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre");
            return View();
        }

        // POST: ItemPedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoId,ProductoId,Cantidad")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.ItemsPedido.Add(itemPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidos, "Id", "Id", itemPedido.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemsPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "Id", "Id", itemPedido.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoId,ProductoId,Cantidad")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "Id", "Id", itemPedido.PedidoId);
            ViewBag.ProductoId = new SelectList(db.Productos, "Id", "Nombre", itemPedido.ProductoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemsPedido.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedido itemPedido = db.ItemsPedido.Find(id);
            db.ItemsPedido.Remove(itemPedido);
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
