using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
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
    }
}
