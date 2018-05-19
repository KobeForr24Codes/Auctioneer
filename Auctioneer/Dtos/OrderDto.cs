using System;
using Auctioneer.Models;

namespace Auctioneer.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        
        public int AuctionId { get; set; }

        public AuctionDto Auction { get; set; }

        public string Address { get; set; }

        public DateTime DeliveredDate { get; set; }

        public bool IsDelivered { get; set; }
    }
}