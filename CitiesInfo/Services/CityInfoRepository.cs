using Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext c)
        {
            _context = c ??
                throw new ArgumentNullException(nameof(c));
        }
        public City GetCity(int cityId, bool includePlacesToVisit)
        {
            if (includePlacesToVisit)
            {
                return _context.Cities
                    .Include(c => c.PlacesToVisit)
                    .Where(c => c.Id == cityId)
                    .FirstOrDefault();
            }
            return _context.Cities
                .Where(c => c.Id == cityId)
                .FirstOrDefault();
        }
        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public IEnumerable<PlaceToVisit> GetPlacesToVisitForCity(int cityId)
        {
            return _context.PlacesToVisit
                 .Where(p => p.CityId == cityId).ToList();
        }

        public PlaceToVisit GetPlaceToVisitForCity(int id, int cityId)
        {
            return _context.PlacesToVisit
                .Where(p=>p.Id == id && p.CityId == cityId).FirstOrDefault();
        }

        //we could have used the GetCity method but it returns whole object or null,
        //CityExists is a cleaner approach
        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public void AddPlaceToVisit(int cityId, PlaceToVisit PlaceToVisit)
        {
            var city = GetCity(cityId, false);
            city.PlacesToVisit.Add(PlaceToVisit); //in-memory addition, need to use save after this
        }
        public void UpdatePlaceToVisit(int id, int cityId, PlaceToVisit PlaceToVisit)  
        {
            //in our case this is empty, it will do nothing, but makes code more stable for future changes
        }

        public void RemovePlaceToVisit(PlaceToVisit PlaceToVisit)
        {
            _context.PlacesToVisit.Remove(PlaceToVisit); //in-memory removal, need to use save after this
        }
        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
