using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            return RedirectToAction("MyBids", "Bids");
        }

        [Authorize]
        public ActionResult Display(int id)
        {
            bool hasBidsFromDb;

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                hasBidsFromDb = db.Query<Auction>("SELECT HasBids FROM Auctions WHERE Id ='" + id + "'").ToList().First().HasBids;
            }

            if (hasBidsFromDb == false)
            {
                var viewModel = new BidFormViewModel
                {
                    Auction = _context.Auctions.Include(u => u.User).SingleOrDefault(a => a.Id == id),
                    HighestBid = 0
                };

                return View(viewModel);
            }
            else
            {
                var viewModel = new BidFormViewModel
                {
                    Auction = _context.Auctions.SingleOrDefault(a => a.Id == id),
                    HighestBid = _context.Bids.Where(a => a.AuctionId == id).Max(a => a.Amount)
                };

                return View(viewModel);
            }
            
        }

        [Authorize]
        public ActionResult MyBids()
        {
            var userId = User.Identity.GetUserId();
            var auctions = _context.Auctions
                .Include(u => u.User)
                .ToList();

            var bids = _context.Bids.Where(b => b.UserId == userId)
                .GroupBy(b => b.AuctionId)
                .Select(b => b.FirstOrDefault())
                .ToList();

            

            var allBids = _context.Bids.Include(u => u.User).ToList();

            var auctionBidModel = new MyBidsViewModel
            {
                Bids = bids,
                AllBids = allBids,
                Auctions = auctions,
            };

            return View(auctionBidModel);
        }
    }
}