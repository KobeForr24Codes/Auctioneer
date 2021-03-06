﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Auctioneer.Models
{
    public class Order
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

        public DateTime SoldDate { get; set; }
        
        public double Amount { get; set; }

        public double Comission { get; set; }
    }
}