using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auctioneer.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        public string Details { get; set; }
    }
}