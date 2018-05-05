using System;
using System.Linq;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
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

        [Authorize]
        [HttpPost]
        public ActionResult Create(BidFormViewModel viewModel)
        {
//            if (!ModelState.IsValid)
//            {
//                return RedirectToAction("Create", viewModel);
//            }
            var bid = new Bid()
            {
                UserId = User.Identity.GetUserId(),
                AuctionId = viewModel.Auction.Id,
                Amount = viewModel.Amount
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
                Auction = _context.Auctions.SingleOrDefault(a => a.Id == id),
                HighestBid = _context.Bids.Where(a => a.AuctionId == id).Max(a => a.Amount)
            };
            
            return View(viewModel);
        }

        

    }
}