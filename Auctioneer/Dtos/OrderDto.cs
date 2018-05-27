using System;
using Auctioneer.Models;

namespace Auctioneer.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Auction Auction { get; set; }

        public int AuctionId { get; set; }

        public string Address { get; set; }

        public DateTime? DeliveredDate { get; set; }

        public bool IsDelivered { get; set; }

        public string SellerId { get; set; }

        public DateTime? SoldDate { get; set; }

        public int Amount { get; set; }
    }
}