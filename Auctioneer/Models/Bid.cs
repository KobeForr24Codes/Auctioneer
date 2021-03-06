﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Auctioneer.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Auction Auction { get; set; }

        [Required]
        public int AuctionId { get; set; }

        [Required]
        public int Amount { get; set; }

    }
}