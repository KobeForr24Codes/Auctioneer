using System;
using System.Linq;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.IO;
using System.Web;

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
            //var userId = User.Identity.GetUserId();
            //var auctions = _context.Auctions
            //    .Include(a => a.User)
            //    .Where(a => a.UserId == userId)
            //    .ToList();

            //return View(auctions);

            var userId = User.Identity.GetUserId();

            var users = _context.Users.ToList();

            var currentTime = DateTime.Now;

            var auctions = _context.Auctions
                .Where(a => a.UserId == userId && a.IsAwarded != true)
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

        [Authorize]
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
                Details = viewModel.Details,
                EndTime = DateTime.Now.AddDays(viewModel.Days),
                Image = ProcessImage(viewModel.Image)
            };

            _context.Auctions.Add(auction);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public string ProcessImage(HttpPostedFileBase image)
        {
            var fileName = Path.GetFileNameWithoutExtension(image.FileName);
            var extension = Path.GetExtension(image.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            var imagePath = "~/Image/" + fileName;
            var savedFileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.SaveAs(savedFileName);
            return imagePath;

        }

        public ActionResult Pay()
        {
            return View();
        }

        public ActionResult AwardItem(int auctionId , string userId)
        {
            var result = _context.Auctions.SingleOrDefault(a => a.Id == auctionId);
            if (result != null)
            {
                result.IsAwarded = true;
                result.AwardedId = userId;
            };
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Auctions");
        }
    }
}