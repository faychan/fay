using fay.Models.DB;
using fay.Models.EntityManager;
using fay.Models.ViewModel;
//using fay.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fay.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
       //[AuthorizeRoles("Admin")]
        public ActionResult Index()
        {
            return View();
        }

       //[AuthorizeRoles("Admin")]
        public ActionResult OrderPartial()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                OrderManager OM = new OrderManager();
                OrderDataView ODV = OM.GetOrderDataView();
                return PartialView(ODV);

            }
            return View();
        }

        // GET: Order
       //[AuthorizeRoles("Admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
       //[AuthorizeRoles("Admin")]
        public ActionResult Add(addOrderView aOV)
        {
            if (ModelState.IsValid)
            {
                OrderManager OM = new OrderManager();
                OM.AddOrder(aOV);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isError = true;
            }
            return View();
        }


        [HttpPost]
       //[AuthorizeRoles("Admin")]
        public ActionResult GetoutbondData(string id_outbond)
        {
            Console.WriteLine("outbondData Triggered, Fetching for id_outbond " + id_outbond);
            outbond outbond;
            try
            {
                using (DemoEntities db = new DemoEntities())
                {
                    int MID = int.Parse(id_outbond);
                    outbond = db.outbonds.Where(o => o.id_outbond.Equals(MID))?.FirstOrDefault();
                }
                return Json(new
                {
                    success = true,
                    harga = outbond.harga
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false
                });
            }

            return Json(new
            {
                success = false
            });


        }

       //[AuthorizeRoles("Admin")]
        public ActionResult DeleteOrder(int orderID)
        {
            using (DemoEntities db = new DemoEntities())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var or = db.laporans.Where(o => o.id_laporan.Equals(orderID));
                        if (or.Any())
                        {
                            db.laporans.Remove(or.FirstOrDefault());
                            db.SaveChanges();
                        }

                        dbContext.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                    }

                }
            }
            return Json(new { success = true });
        }

    }
}