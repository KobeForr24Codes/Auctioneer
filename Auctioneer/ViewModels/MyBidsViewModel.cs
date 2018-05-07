using System.Collections.Generic;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class MyBidsViewModel
    {
        public IEnumerable<Bid> Bids { get; set; }

        public IEnumerable<Bid> AllBids { get; set; }

        public IEnumerable<Auction> Auctions { get; set; }
    }
}