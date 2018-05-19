using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auctioneer.Models;

namespace Auctioneer.ViewModels
{
    public class AuctionFormViewModel
    {
        [Required(ErrorMessage = "Please enter the item's name")]
        [Display(Name = "Item Name")]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please enter the description of the item.")]
        public string Details { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input must be a number.")]
        [Required(ErrorMessage = "Please enter the starting price.")]
        [Display(Name = "Starting Price")]
        public string StartingPrice { get; set; }

        [Required(ErrorMessage = "Please select the number of days.")]
        [Display(Name = "How many days?")]
        public int Days { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        public HttpPostedFileBase Image { get; set; }
    }

}