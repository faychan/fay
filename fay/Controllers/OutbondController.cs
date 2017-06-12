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
        public ActionResult UpdateoutbondData(int id_outbond, string keterangan, int harga)
        {
            outbondProfileView MPV = new outbondProfileView();
            MPV.id_outbond = id_outbond;
            MPV.keterangan = keterangan;
            MPV.harga = harga;

            using (DemoEntities1 db = new DemoEntities1())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        outbond m = db.outbonds.Find(MPV.id_outbond);
                        m.keterangan = MPV.keterangan;
                        m.harga = MPV.harga;

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
                id_outbond = MPV.id_outbond,
                keterangan = MPV.keterangan,
                harga = MPV.harga
            });
        }

       //[AuthorizeRoles("Admin")]
        public ActionResult DeleteUser(int id_outbond)
        {
            using (DemoEntities1 db = new DemoEntities1())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mn = db.outbonds.Where(o => o.id_outbond.Equals(id_outbond));
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