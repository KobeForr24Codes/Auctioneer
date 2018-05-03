using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class BidFormViewModel
    {
        [Required]
        [Display(Name = "Enter Your Bid")]
        public string BidAmount { get; set; }
        
        public Auction Auction { get; set; }

        
    }
}