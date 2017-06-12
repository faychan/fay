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
    public class OutbondController : Controller
    {
        // GET: Outbond
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult outbondPartial()
        {
            outbondManager MM = new outbondManager();
            outbondDataView MDV = MM.GetoutbondDataView();
            return PartialView(MDV);

        }

       //[AuthorizeRoles("Admin")]
        public ActionResult AdminoutbondPartial()
        {
            return View();
        }

       //[AuthorizeRoles("Admin")]
        public ActionResult Add()
        {
            return View();
        }

       //[AuthorizeRoles("Admin")]
        public ActionResult UpdateoutbondData(int outbondID, string outbondketerangan, int outbondPrice)
        {
            outbondProfileView MPV = new outbondProfileView();
            MPV.id_outbond = outbondID;
            MPV.keterangan = outbondketerangan;
            MPV.harga = outbondPrice;

            using (DemoEntities db = new DemoEntities())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        outbond m = db.outbonds.Find(MPV.id_outbond);
                        m.harga = MPV.harga;
                        m.id_outbond = MPV.id_outbond;
                        m.keterangan = MPV.keterangan;

                        db.SaveChanges();
                        dbContext.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                    }
                }
            }

            return Json(new
            {
                success = true,
                name = MPV.keterangan,
                id = MPV.id_outbond,
                price = MPV.harga
            });
        }

       //[AuthorizeRoles("Admin")]
        public ActionResult DeleteUser(int outbondID)
        {
            using (DemoEntities db = new DemoEntities())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mn = db.outbonds.Where(o => o.id_outbond.Equals(outbondID));
                        if (mn.Any())
                        {
                            db.outbonds.Remove(mn.FirstOrDefault());
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

        [HttpPost]
       //[AuthorizeRoles("Admin")]
        public ActionResult Add(addoutbondView amv)
        {
            if (ModelState.IsValid)
            {
                outbondManager MM = new outbondManager();
                MM.Addoutbond(amv);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isError = true;
            }
            return View();
        }
    }
}