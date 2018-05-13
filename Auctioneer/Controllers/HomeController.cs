using System;
using System.Linq;
using System.Web.Mvc;
using Auctioneer.Models;
using System.Data.Entity;
using Auctioneer.ViewModels;
using Microsoft.AspNet.Identity;

namespace Auctioneer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var users = _context.Users.ToList();

            var currentTime = DateTime.Now; 

            var auctions = _context.Auctions
                .Where(a => a.UserId != userId && a.IsAwarded != true && a.EndTime > currentTime)
                .Include(u => u.User)
                .ToList();

            var bids = _context.Bids
                .Include(u => u.User)
                .Include(a => a.Auction)
                .ToList();

            var auctionBidModel = new MainIndexViewModel
            {
                Auctions = auctions,
                Bids = bids,
                Users = users
            };

            return View(auctionBidModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}