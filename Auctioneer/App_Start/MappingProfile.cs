using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auctioneer.Dtos;
using Auctioneer.Models;
using AutoMapper;

namespace Auctioneer.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Auction, AuctionDto>();
            Mapper.CreateMap<AuctionDto, Auction>();
        }
    }
}