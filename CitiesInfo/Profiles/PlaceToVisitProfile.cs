using AutoMapper;

namespace Profiles
{
    public class PlaceToVisitProfile : Profile
    {
        public PlaceToVisitProfile()
        {
            CreateMap<Entities.PlaceToVisit, Models.PlacesToVisitDto>();
            CreateMap<Models.PlacesToVisitForCreationDto, Entities.PlaceToVisit>();
            CreateMap<Models.PlacesToVisitForUpdateDto, Entities.PlaceToVisit>().ReverseMap(); //applies reverse mapping as well
        }
    }
}
