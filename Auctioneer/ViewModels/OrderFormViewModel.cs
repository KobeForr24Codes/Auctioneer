using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class OrderFormViewModel
    {
        public Auction Auctions { get; set; }

        public ApplicationUser Users { get; set; }

        public string Address { get; set; }

        public int HighestBid { get; set; }
    }
}