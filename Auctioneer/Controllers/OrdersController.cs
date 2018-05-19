using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
                    .Where(o => o.UserId == userId)
                    .Include(a => a.Auction)
                    .ToList();

                return View("MyOrders", orders);
            }
            
        }

        [Authorize]
        public ActionResult Create(OrderFormViewModel viewModel)
        {
            var order = new Order()
            {
                UserId = User.Identity.GetUserId(),
                AuctionId = viewModel.Auctions.Id,
                Address = viewModel.Address
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}