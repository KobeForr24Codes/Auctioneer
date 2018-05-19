using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auctioneer.Dtos;
using Auctioneer.Models;
using AutoMapper;

namespace Auctioneer.Controllers.Api
{
    public class AuctionsController : ApiController
    {
        private ApplicationDbContext _context;

        public AuctionsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/auctions
        public IEnumerable<AuctionDto> GetAuctions()
        {
            return _context.Auctions.ToList().Select(Mapper.Map<Auction, AuctionDto>);
        }

        //GET /api/auctions/1
        public AuctionDto GetAuction(int id)
        {
            var auction = _context.Auctions.SingleOrDefault(a => a.Id == id);

            if (auction == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Auction, AuctionDto>(auction);
        }

        [HttpPost]
        public AuctionDto CreateAuction(AuctionDto auctionDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var auction = Mapper.Map<AuctionDto, Auction>(auctionDto);
            _context.Auctions.Add(auction);
            _context.SaveChanges();

            auctionDto.Id = auction.Id;

            return auctionDto;
        }
        
    }
}
