using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Auctioneer.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuctionsController()
        {
            _context = new ApplicationDbContext();
        }

        //Returns the auctioned items of the logged in user
        [Authorize]
        public ViewResult Index()
        {
            var userId = User.Identity.GetUserId();
            var auctions = _context.Auctions
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .ToList();

            return View(auctions);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Create auction and user must be logged in
        //POST 
        [Authorize]
        [HttpPost]
        public ActionResult Create(AuctionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }
            var auction = new Auction()
            {
                UserId = User.Identity.GetUserId(),
                StartDate = DateTime.Now,
                StartingPrice = Convert.ToInt32(viewModel.StartingPrice),
                ItemName = viewModel.ItemName,
                Details = viewModel.Details
            };

            _context.Auctions.Add(auction);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}