using fay.Models.DB;
using fay.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fay.Models.EntityManager
{
    public class CustomerManager
    {


        public void AddCustomer(addCustomerView c)
        {

            using (DemoEntities1 db = new DemoEntities1())
            {

                pelanggan p = new pelanggan();
                p.no_id = c.no_id;
                p.nama = c.nama;
                p.alamat = c.alamat;
                p.no_tlp1 = c.no_tlp1;
                p.no_tlp2 = c.no_tlp2;

                db.pelanggans.Add(p);
                db.SaveChanges();

            }
        }

        public List<CustomerProfileView> GetAllCustomers()
        {
            List<CustomerProfileView> customers = new List<CustomerProfileView>();
            using (DemoEntities1 db = new DemoEntities1())
            {
                CustomerProfileView CV;
                var customer = db.pelanggans.ToList();
                foreach (pelanggan p in db.pelanggans)
                {
                    CV = new CustomerProfileView();
                    CV.alamat = p.alamat;
                    CV.nama = p.nama;
                    CV.no_id = p.no_id;
                    CV.id_pelanggan = p.id_pelanggan;
                    CV.no_tlp1 = p.no_tlp1;
                    CV.no_tlp2 = p.no_tlp2;
                    customers.Add(CV);
                }
                return customers;
            }
        }
        public CustomerDataView GetoutbondDataView()
        {
            CustomerDataView CDV = new CustomerDataView();
            List<CustomerProfileView> customers = GetAllCustomers();
            CDV.CustomerProfile = customers;
            return CDV;
        }
    }
}