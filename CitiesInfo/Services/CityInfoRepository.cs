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

    }
}
