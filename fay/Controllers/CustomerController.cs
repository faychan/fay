using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fay.Models.DB;
using fay.Models.EntityManager;
using fay.Models.ViewModel;
//using fay.Security;

namespace fay.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
       ////[AuthorizeRoles("Admin")]
        public ActionResult Index()
        {
            return View();
        }

      // //[AuthorizeRoles("Admin")]
        public ActionResult CustomerPartial()
        {
            if (User.Identity.IsAuthenticated == true)
            {

                CustomerManager CM = new CustomerManager();
                CustomerDataView CDV = CM.GetoutbondDataView();
                return PartialView(CDV);

            }
            return View();
        }

      // //[AuthorizeRoles("Admin")]
        public ActionResult AdminCustomerPartial()
        {
            return View();
        }

       ////[AuthorizeRoles("Admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
       ////[AuthorizeRoles("Admin")]
        public ActionResult Add(addCustomerView acv)
        {
            if (ModelState.IsValid)
            {
                CustomerManager CM = new CustomerManager();
                CM.AddCustomer(acv);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isError = true;
            }
            return View();
        }

      // //[AuthorizeRoles("Admin")]
        public ActionResult DeleteCustomer(int id_pelanggan)
        {
            using (DemoEntities1 db = new DemoEntities1())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mn = db.pelanggans.Where(o => o.id_pelanggan.Equals(id_pelanggan));
                        if (mn.Any())
                        {
                            db.pelanggans.Remove(mn.FirstOrDefault());
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


     //  //[AuthorizeRoles("Admin")]
        public ActionResult CustomerHistory(int id_pelanggan)
        {
            OrderManager om = new OrderManager();
            OrderDataView odv = om.GetOrderDataViewBy(id_pelanggan);
            return PartialView(odv);
        }

        public ActionResult EditCustomer(
            int id_pelanggan, string customerID, string customerName, string customerAddress, string customerPhoneOne, string customerPhoneTwo)
        {

            CustomerProfileView CPV = new CustomerProfileView();
            CPV.alamat = customerAddress;
            CPV.nama = customerName;
            CPV.no_id = customerID;
            CPV.id_pelanggan = id_pelanggan;
            CPV.no_tlp1 = customerPhoneOne;
            CPV.no_tlp2 = customerPhoneTwo;

            using (DemoEntities1 db = new DemoEntities1())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        pelanggan p = db.pelanggans.Find(id_pelanggan);
                        p.alamat = CPV.alamat;
                        p.nama = CPV.nama;
                        p.no_id = CPV.no_id;
                        p.no_tlp1 = CPV.no_tlp1;
                        p.no_tlp2 = CPV.no_tlp2;
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
                success = true
            });
        }
    }
}