using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bonus_assignment.Models;

namespace Bonus_assignment.Controllers
{
    public class ordersController : Controller
    {
        private productEntities db = new productEntities();

        // GET: orders
        public ActionResult Index()
        {
            using (var db = new productEntities())
            {
                
                return View(db.orders.ToList());
            }
        }

        public ActionResult AddQuantity(int id)
        {
            using (var db = new productEntities())
            {
                var order = db.orders.Find(id);
                if (order != null)
                {
                    order.quantity += 1; // Increment the quantity
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }


        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // Action to set the session variable and redirect to Create
        public ActionResult SetItemId(int itemId)
        {
            Session["ItemId"] = itemId;
            return RedirectToAction("Create");
        }

        // GET: orders/Create
        // GET: orders/Create
        public ActionResult Create()
        {
            var order = new Bonus_assignment.Models.order();

            // Retrieve the itemId from the session
            if (Session["ItemId"] != null)
            {
                order.item_id = (int)Session["ItemId"];
            }

            return View(order);
        }

        // POST: orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,userid,item_id,quantity,order_date")] order order)
        {
            if (ModelState.IsValid)
            {
                // Check if an order with the same item_id and userid already exists
                var existingOrder = db.orders.FirstOrDefault(o => o.item_id == order.item_id && o.userid == order.userid);
                if (existingOrder == null)
                {
                    // No existing order found, create a new one
                    db.orders.Add(order);
                }
                else
                {
                    // Existing order found, increment the quantity
                    existingOrder.quantity += order.quantity; // Increment by the quantity provided in the form
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }


        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,userid,item_id,quantity,order_date")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
