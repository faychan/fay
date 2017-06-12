using fay.Models.DB;
using fay.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fay.Models.EntityManager
{
    public class OrderManager
    {

        public void AddOrder(addOrderView m)
        {

            using (DemoEntities db = new DemoEntities())
            {
                outbond mn = db.outbonds.Find(m.id_outbond);
                mn.harga = mn.harga;
                mn.id_outbond = mn.id_outbond;
                mn.keterangan = mn.keterangan;

                laporan lp = new laporan();
                lp.id_outbond = m.id_outbond;
                lp.id_pelanggan = m.id_pelanggan;
                lp.keterangan = m.keterangan;
                //lp.Meja = m.Meja;
                lp.quantity = m.quantity;
                lp.harga = m.harga;
                lp.jumlah = m.jumlah;

                db.laporans.Add(lp);
                db.SaveChanges();

            }
        }
        public List<OrderProfileView> GetAllOrders()
        {

            List<OrderProfileView> orders = new List<OrderProfileView>();
            using (DemoEntities db = new DemoEntities())
            {
                OrderProfileView OV;

                //var orderData = db.laporans.ToList(); ???

                foreach (laporan l in db.laporans)
                {
                    OV = new OrderProfileView();
                    OV.id_laporan = l.id_laporan;

                    pelanggan pelanggan = db.pelanggans.Where(o => o.id_pelanggan.Equals(l.id_pelanggan)).FirstOrDefault();

                    OV.namapelanggan = pelanggan.nama;

                    outbond outbond = db.outbonds.Where(o => o.id_outbond.Equals(l.id_outbond)).FirstOrDefault();
                 //   OV.namaoutbond = outbond.nama;

                    OV.harga = l.harga;
                    OV.jumlah = l.jumlah;
                    OV.keterangan = l.keterangan;
                    //OV.Meja = l.Meja;
                    OV.quantity = l.quantity;
                    orders.Add(OV);
                }
            }

            orders.Reverse();
            return orders;
        }

        public List<OrderProfileView> GetAllOrdersBy(int id_pelanggan)
        {

            List<OrderProfileView> orders = new List<OrderProfileView>();
            using (DemoEntities db = new DemoEntities())
            {
                OrderProfileView OV;

                //var orderData = db.laporans.ToList(); ???
                var uL = db.laporans.Where(o => o.id_pelanggan.Equals(id_pelanggan));
                foreach (laporan l in uL)
                {
                    OV = new OrderProfileView();
                    OV.id_laporan = l.id_laporan;

                    pelanggan pelanggan = db.pelanggans.Where(o => o.id_pelanggan.Equals(l.id_pelanggan)).FirstOrDefault();

                    OV.namapelanggan = pelanggan.nama;

                    outbond outbond = db.outbonds.Where(o => o.id_outbond.Equals(l.id_outbond)).FirstOrDefault();
                  //  OV.namaoutbond = outbond.nama;

                    OV.harga = l.harga;
                    OV.jumlah = l.jumlah;
                    OV.keterangan = l.keterangan;
                   // OV.Meja = l.Meja;
                    OV.quantity = l.quantity;
                    orders.Add(OV);
                }
            }

            orders.Reverse();
            return orders;
        }

        public OrderDataView GetOrderDataViewBy(int id_pelanggan)
        {
            OrderDataView ODV = new OrderDataView();
            List<OrderProfileView> orders = GetAllOrdersBy(id_pelanggan);
            ODV.orders = orders;
            return ODV;
        }

        public OrderDataView GetOrderDataView()
        {
            OrderDataView ODV = new OrderDataView();
            List<OrderProfileView> orders = GetAllOrders();
            ODV.orders = orders;
            return ODV;
        }


    }
}