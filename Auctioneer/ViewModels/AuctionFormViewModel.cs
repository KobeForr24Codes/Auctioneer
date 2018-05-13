using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class AuctionFormViewModel
    {
        [Required]
        [Display(Name = "Item Name")]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required] public string Details { get; set; }

        [Required]
        [Display(Name = "Starting Price")]
        public string StartingPrice { get; set; }

        [Required]
        [Display(Name = "How many Days?")]
        public int Days { get; set; }

        public DateTime EndDate { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }

}