﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auctioneer.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        
        [Required]
        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Starting Price")]
        public int StartingPrice { get; set; }

        [Required]    
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        public string Details { get; set; }

        public bool IsAwarded { get; set; }

        public string AwardedId { get; set; }

        public bool HasBids { get; set; }
        
        [Required]
        public string Image { get; set; }

        public bool IsRemoved { get; set; }
       
    }
}