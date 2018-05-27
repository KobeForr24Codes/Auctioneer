using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Auctioneer.Models;
using Auctioneer.ViewModels;
using Microsoft.AspNet.Identity;

namespace Auctioneer.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Orders
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManage))
            {
                var orders = _context.Orders.Include(a => a.Auction).ToList();
                return View(orders);
            }
            else
            {

                var userId = User.Identity.GetUserId();
                var orders = _context.Orders
                    .Where(o => o.SellerId == userId)
                    .Include(a => a.Auction)
                    .ToList();

                return View(orders);
            }

        }

        // GET: Orders
        public ActionResult MyOrders()
        {
            var userId = User.Identity.GetUserId();
            var orders = _context.Orders
                .Where(o => o.UserId == userId)
                .Include(a => a.Auction)
                .ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult Create(OrderFormViewModel viewModel)
        {
            var auctionFromDb = _context.Auctions.SingleOrDefault(a => a.Id == viewModel.Auctions.Id);

            if (auctionFromDb == null)
            {
                return RedirectToAction("Index", "Home");
            }

            auctionFromDb.IsRemoved = true;

            var order = new Order()
            {
                UserId = User.Identity.GetUserId(),
                AuctionId = viewModel.Auctions.Id,
                Address = viewModel.Address,
                SellerId = auctionFromDb.UserId,
                SoldDate = DateTime.Now,
                Amount = viewModel.HighestBid
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("MyOrders", "Orders");
        }

        public ActionResult Sales(string dateFrom, string dateTo)
        {
            

            try
            {
                var From = DateTime.Parse(dateFrom);
                var To = DateTime.Parse(dateTo);


                ViewBag.datefroms = From;
                ViewBag.datetos = To;

                var userId = User.Identity.GetUserId();
                var orders = _context.Orders
                    .Where(o => o.SellerId == userId && o.SoldDate >= From && o.SoldDate <= To)
                    .Include(a => a.Auction)
                    .ToList();

                var totalSales = _context.Orders
                    .Where(o => o.SellerId == userId && o.SoldDate >= From && o.SoldDate <= To)
                    .Sum(o => (int?)o.Amount);

                ViewBag.total = totalSales == 0 ? 0 : totalSales;

                return View(orders);
            }
            catch (Exception e)
            {
                var userId = User.Identity.GetUserId();
                var orders = _context.Orders
                    .Where(o => o.SellerId == userId)
                    .Include(a => a.Auction)
                    .ToList();

                var totalSales = _context.Orders
                    .Where(o => o.SellerId == userId)
                    .Sum(o => (int?)o.Amount);

                ViewBag.total = totalSales == 0 ? 0 : totalSales;

                return View(orders);
            }
        }
    }
}