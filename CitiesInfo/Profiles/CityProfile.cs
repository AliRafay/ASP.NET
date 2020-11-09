using AutoMapper;
using Entities;
using Models;
using System.Collections.Generic;

namespace Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPlacesToVisitDto>();
            CreateMap<City, CityDto>();
            //CreateMap<IEnumerable<City>, IEnumerable<CityWithoutPlacesToVisitDto>>();
            //CreateMap(typeof(IEnumerable<>), typeof(IEnumerable<>));
        }
    }
}
