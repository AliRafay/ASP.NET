using Entities;
using System.Collections.Generic;

namespace Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePlacesToVisit);
        IEnumerable<PlaceToVisit> GetPlacesToVisitForCity(int cityId);
        PlaceToVisit GetPlaceToVisitForCity(int id, int cityId);
    }
}