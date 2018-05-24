using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Auctioneer.Dtos;
using Auctioneer.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace Auctioneer.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/orders
        public IHttpActionResult GetOrders()
        {
            var userId = User.Identity.GetUserId();
            var orderDtos = _context.Orders
                .Where(o => o.SellerId == userId)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);

            return Ok(orderDtos);

        }

        //Get /api/orders/1
        public IHttpActionResult GetOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Order, OrderDto>(order));
        }

        //POST /api/orders
        [HttpPost]
        public IHttpActionResult CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + order.Id), order);
        }

        [HttpPut]
        public void UpdateOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var orderInDb = _context.Orders.SingleOrDefault(o => o.Id == id);

            if (orderInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            orderInDb.DeliveredDate = DateTime.Now;
            orderInDb.IsDelivered = true;

            _context.SaveChanges();
        }
    }
}
