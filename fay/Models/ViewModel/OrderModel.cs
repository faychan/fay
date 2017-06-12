using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fay.Models.ViewModel
{
    public class OrderProfileView
    {
        [Key]
        public int id_laporan { get; set; }
        public string namapelanggan { get; set; }
        public string namaoutbond { get; set; }
        public string keterangan { get; set; }
        public DateTime tgl_akhir { get; set; }
        public DateTime tgl_mulai { get; set; }
        public DateTime tgl_pesan { get; set; }
        public int quantity { get; set; }
        public int harga { get; set; }
        public int jumlah { get; set; }
    }
    public class OrderUser
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class OrderUsers
    {
        public IEnumerable<OrderUser> OrderUserList { get; set; }
    }

    public class Orderoutbond
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class Orderoutbonds
    {
        public IEnumerable<Orderoutbond> OrderoutbondList { get; set; }
    }
    public class OrderDataView
    {
        public IEnumerable<OrderProfileView> orders { get; set; }
    }


    public class addOrderView
    {
        [Key]
        [Display(Name = "Order ID")]
        public int id_laporan { get; set; }
        [Display(Name = "outbond Name")]
        public int id_outbond { get; set; }
        [Display(Name = "Customer Name")]
        public int id_pelanggan { get; set; }
        [Display(Name = "Order Details")]
        public string keterangan { get; set; }
        [Display(Name = "End Date")]
        public int tgl_akhir { get; set; }
        [Display(Name = "Start Date")]
        public int tgl_mulai { get; set; }
        [Display(Name = "Order Date")]
        public int tgl_pesan { get; set; }
        [Display(Name = "quantity")]
        public int quantity { get; set; }
        [Display(Name = "Price")]
        public int harga { get; set; }
        [Display(Name = "Total")]
        public int jumlah { get; set; }
    }
}