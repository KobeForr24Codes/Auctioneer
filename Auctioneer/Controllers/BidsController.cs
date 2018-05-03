using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auctioneer.Models;

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
        public ActionResult Create(int id)
        {
            var auction = _context.Auctions.SingleOrDefault(a => a.Id == id);

            return View("Create", auction);
        }
        
    }
}