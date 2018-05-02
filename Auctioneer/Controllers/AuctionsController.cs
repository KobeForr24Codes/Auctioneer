using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
using Microsoft.AspNet.Identity;

namespace Auctioneer.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionsController()
        {
            _context = new ApplicationDbContext();
        }

        //[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuctionFormViewModel viewModel)
        {
            var auction = new Auction()
            {
                UserId = User.Identity.GetUserId(),
                StartDate = viewModel.Auction.StartDate,
                StartingPrice = viewModel.Auction.StartingPrice,
                ItemName = viewModel.Auction.ItemName,
                Details = viewModel.Auction.Details
            };

            _context.Auctions.Add(auction);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}