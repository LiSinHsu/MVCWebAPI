using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public partial class DisbursedAmt
    {
        [Display(Name = "Month")]
        public string Month { get; set; }
        [Display(Name = "disbursed_amount")]
        public string disbursed_amount { get; set; }
        [Display(Name = "disbursed_number")]
        public string disbursed_number { get; set; }
        [Display(Name = "remarks")]
        public string remarks { get; set; }
    }
}