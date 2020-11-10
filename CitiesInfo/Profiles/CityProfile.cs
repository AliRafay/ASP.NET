using AutoMapper;
using Entities;
using Models;

namespace Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPlacesToVisitDto>();
            CreateMap<City, CityDto>();
        }
    }
}
