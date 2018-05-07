using System.ComponentModel.DataAnnotations;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class BidFormViewModel
    {
        [Required]
        [Display(Name = "Enter Your Bid")]
        public int Amount { get; set; }

        public Auction Auction { get; set; }

        public int HighestBid { get; set; }
    }
}