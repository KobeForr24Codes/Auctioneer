using System.ComponentModel.DataAnnotations;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class BidFormViewModel
    {
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input must be a number.")]
        [Display(Name = "Enter Your Bid")]
        public int Amount { get; set; }

        public Auction Auction { get; set; }

        public int HighestBid { get; set; }
    }
}