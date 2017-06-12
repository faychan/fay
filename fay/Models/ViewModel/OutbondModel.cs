using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fay.Models.ViewModel
{
    public class addoutbondView
    {
        [Key]
        public int id_outbond { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string keterangan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Price")]
        public int harga { get; set; }
    }

    public class outbondProfileView
    {
        [Key]
        public int id_outbond { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string keterangan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Price")]
        public int harga { get; set; }
    }

    public class outbondDataView
    {
        public IEnumerable<outbondProfileView> outbondProfile { get; set; }
    }
}