using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace CitiesInfo.API.Controllers
{
    [Route("api/cities/{cityId}/PlacesToVisit")]
    [ApiController]
    public class PlacesToVisitController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPlacesToVisit(int cityId)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
                
            }
            return Ok(city.PlacesToVisit);
        }

        [HttpGet("{id}" , Name = "GetPlaceToVisit")]
        public IActionResult GetPlaceToVisit(int id, int cityId)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var place = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            if(place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public IActionResult CreatePlaceToVisit(int cityId, PlacesToVisitForCreationDto newPlaceToVisit )
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            int maxIdPlacesToVisit = CitiesDataStore.StaticDataStoreObj.Cities.SelectMany(c => c.PlacesToVisit).Max(p => p.Id);

            PlacesToVisitDto finalPlaceToVisit = new PlacesToVisitDto()
            {
                Id = ++maxIdPlacesToVisit,
                Name = newPlaceToVisit.Name
            };

            city.PlacesToVisit.Add(finalPlaceToVisit);

            return CreatedAtRoute("GetPlaceToVisit",       //Route name , Route values, and Object
                new { id= finalPlaceToVisit.Id , cityId }, 
                finalPlaceToVisit);
        }
    }
}
