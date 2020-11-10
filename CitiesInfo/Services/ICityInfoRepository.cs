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
        bool CityExists(int cityId);
        void AddPlaceToVisit(int cityId, PlaceToVisit PlaceToVisit);
        void UpdatePlaceToVisit(int id, int cityId, PlaceToVisit PlaceToVisit);
        bool Save();
    }
}