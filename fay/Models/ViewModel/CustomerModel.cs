using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fay.Models.ViewModel
{
    public class addCustomerView
    {
        [Key]
        public int id_pelanggan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "ID Number")]
        public string no_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Name")]
        public string nama { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Address")]
        public string alamat { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone 1")]
        public string no_tlp1 { get; set; }
        [Display(Name = "Phone 2 (Optional)")]
        public string no_tlp2 { get; set; }

    }

    public class CustomerProfileView
    {
        [Key]
        public int id_pelanggan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "ID Number")]
        public string no_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Name")]
        public string nama { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Address")]
        public string alamat { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Phone 1")]
        public string no_tlp1 { get; set; }
        [Display(Name = "Phone 2 (Optional)")]
        public string no_tlp2 { get; set; }

    }

    public class CustomerDataView
    {

        public IEnumerable<CustomerProfileView> CustomerProfile { get; set; }
    }
}