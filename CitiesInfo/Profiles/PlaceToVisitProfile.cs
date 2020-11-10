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
            CreateMap<Entities.PlaceToVisit, Models.PlacesToVisitDto>();
            CreateMap<Models.PlacesToVisitForCreationDto, Entities.PlaceToVisit>();
            CreateMap<Models.PlacesToVisitForUpdateDto, Entities.PlaceToVisit>();
        }
    }
}
