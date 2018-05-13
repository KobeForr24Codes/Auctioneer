using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.Dtos
{
    public class AuctionDto
    {
        public int Id { get; set; }
       
        [Required]
        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
         
        [Required]
        public int StartingPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        public string Details { get; set; }

        public bool IsAwarded { get; set; }

        public string AwardedId { get; set; }

        public bool HasBids { get; set; }

    }
}