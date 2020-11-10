using AutoMapper;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles
{
    public class PlaceToVisitProfile : Profile
    {
        public PlaceToVisitProfile()
        {
            CreateMap<PlaceToVisit, PlacesToVisitDto>();
        }
    }
}
