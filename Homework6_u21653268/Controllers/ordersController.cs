using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework6_u21653268.Models;
using PagedList;

namespace Homework6_u21653268.Controllers
{
    public class ordersController : Controller
    {
        private DataService dataService = new DataService();
        private BikeStoresEntities db = new BikeStoresEntities();

        // GET: orders

        public ActionResult Index(int? page)
        {
            List<Order> orders = dataService.getAllOrders();
            foreach(var i in orders)
            {
                i.order_items = dataService.getOrderItems(i.order_id);
                foreach(var thing in i.order_items)
                {
                    thing.product = db.products.Find(thing.product_id);
                }
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(orders.OrderBy(o => o.order_id).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(DateTime searchDate, int? page)
        {
            List<Order> orders;

            if (searchDate != null)
            {
                page = 1;
                orders = dataService.getAllSearchedOrders(searchDate);

            }
            else
            {
                orders = dataService.getAllOrders();
            }

            foreach (var i in orders)
            {
                i.order_items = dataService.getOrderItems(i.order_id);
                foreach (var thing in i.order_items)
                {
                    thing.product = db.products.Find(thing.product_id);
                }
            }



            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(orders.OrderBy(o => o.order_id).ToPagedList(pageNumber, pageSize));
        }

        // GET: orders/Details/5
        public ActionResult Report()
        {
            List<ReportVM> reportData = dataService.getReportData();

            return View(reportData);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);

            List<StoreProduct> storeProducts = new List<StoreProduct>();

            storeProducts = dataService.getProductsPerStore(id);

            StoreProductVM viewModel = new StoreProductVM();
            viewModel.StoreProducts = storeProducts;
            viewModel.product_id = id;
            viewModel.productObj = product;

            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ProductDetails", viewModel);
        }


    }
}
