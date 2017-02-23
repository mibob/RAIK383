using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Interfaces;
using Demo.Models;

namespace Demo.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IProductManager productManager;

        public OrderController(IProductManager prodManager)
        {
            productManager = prodManager;
        }

        public JsonResult GetSale()
        {
            var productsToSelect = productManager.GetSaleItems((decimal).01, 5).Select(p => new {
                                                                                                Id  = p.Id,
                                                                                                Name = p.Name,
                                                                                                Price = p.Price
                                                                                                });

            return Json(productsToSelect.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool MakeOrder(int[] selectedProducts)
        {
            return true;
        }

        // GET: Order
        // Gets list of all Products for the user to choose from
        public ActionResult Index()
        {
            return View(productManager.GetList());
        }

        // GET: Order/Details/5
        // Displays details of a Product
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        // Gets form for user to fill in a new order
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // Adds a new user order
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

        // GET: Order/Edit/5
        // Gets the order that user wishes to change
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        // Saves a modified user order
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

        // GET: Order/Delete/5
        // Gets confirmation page for an order user wishes to remove
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        // Deletes the order that's been confirmed
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
