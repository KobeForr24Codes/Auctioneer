using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
using Dapper;
using Microsoft.AspNet.Identity;

namespace Auctioneer.Controllers
{
    public class BidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Bids
        public ActionResult Index()
        {
            return View();
        }

        public void UpdateHasBids(int id)
        {
            
            
            
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(BidFormViewModel viewModel)
        {  

            var bid = new Bid()
            {
                UserId = User.Identity.GetUserId(),
                AuctionId = Convert.ToInt32(viewModel.Auction.Id),
                Amount = Convert.ToInt32(viewModel.BidAmount)
            };

            var result = _context.Auctions.SingleOrDefault(a => a.Id == viewModel.Auction.Id);
            if (result != null)
            {
                result.HasBids = true;
            }
            
            _context.Bids.Add(bid);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Display(int id)
        {
            var viewModel = new BidFormViewModel
            {
                Auction = _context.Auctions.SingleOrDefault(a => a.Id == id)
            };
            
            return View(viewModel);
        }

        

    }
}