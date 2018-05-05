using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class MainIndexViewModel
    {
        public IEnumerable<Bid> Bids { get; set; }

        public IEnumerable<Auction> Auctions { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}