using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auctioneer.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using Auctioneer.ViewModels;
using Dapper;

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
            List<Auction> auctions = new List<Auction>();
            List<Bid> bids = new List<Bid>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                auctions = db.Query<Auction>("SELECT * FROM Auctions").ToList();
                bids = db.Query<Bid>("SELECT * FROM Bids").ToList();
            }
//            var auctions = _context.Auctions
//                .Include(u => u.User)
//                .ToList();
//
//            var bids = _context.Bids
//                .Include(u => u.User)
//                .Include(a => a.Auction)
//                .ToList();

            MainIndexViewModel auctionBidModel = new MainIndexViewModel
            {
                Auctions = auctions,
                Bids = bids
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