using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Auctioneer.Models;
using System.Data.Entity;
using System.Web.Script.Services;
using System.Web.Services;
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
                .Where(a => a.IsAwarded != true && a.EndTime > currentTime)
                .OrderByDescending(a => a.Id)
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

        public ActionResult Profit()
        {
            return View();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JsonResult GetProfit()
        {
            var orders = _context.Orders.GroupBy(o => o.SoldDate.Month);
            List<SalesReport> comissionList = new List<SalesReport>();
            foreach (var group in orders)
            {
                foreach (var item in group)
                {
                    var tempSale = new SalesReport()
                    {
                        Month = new DateTime(1997, item.SoldDate.Month, 13).ToString("MMMM"),
                        Comission = group.Sum(o => o.Comission)
                    };
                    comissionList.Add(tempSale);
                    break;
                }
            }
            var totalComision = _context.Orders.Sum(o => o.Comission);
            return Json(new { sales = comissionList, totalSales = totalComision });
        }
    }
}