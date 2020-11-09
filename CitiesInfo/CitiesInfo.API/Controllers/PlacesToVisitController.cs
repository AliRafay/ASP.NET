using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Linq;


namespace CitiesInfo.API.Controllers
{
    [Route("api/cities/{cityId}/PlacesToVisit")]
    [ApiController]
    public class PlacesToVisitController : ControllerBase
    {
        private readonly ILogger<PlacesToVisitController> _logger;
        private readonly IMailService _mailService;

        //Dependency Injections
        public PlacesToVisitController(ILogger<PlacesToVisitController> l, 
            IMailService m,                                                    //services
            ICityInfoRepository CityInfoRepo)
        {
            _logger = l ?? 
                throw new ArgumentNullException(nameof(l));
            _mailService = m ?? 
                throw new ArgumentNullException(nameof(m));

        }

        [HttpGet]
        public IActionResult GetPlacesToVisit(int cityId)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                //logger.LogInformation($"City with id={cityId} was Not Found");
                return NotFound();

            }
            return Ok(city.PlacesToVisit);
        }

        [HttpGet("{id}", Name = "GetPlaceToVisit")]
        public IActionResult GetPlaceToVisit(int id, int cityId)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var place = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public IActionResult CreatePlaceToVisit(int cityId, PlacesToVisitForCreationDto newPlaceToVisit)
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
                Name = newPlaceToVisit.Name,
                Description = newPlaceToVisit.Description
            };

            city.PlacesToVisit.Add(finalPlaceToVisit);

            return CreatedAtRoute("GetPlaceToVisit",       //Route name , Route values, and Object
                new { id = finalPlaceToVisit.Id, cityId },
                finalPlaceToVisit);
        }

        [HttpPut("{id}")]
        public IActionResult FullUpdatePlaceToVisit(int id, int cityId, PlacesToVisitForUpdateDto updatedPlace)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            if (placeFromStore == null)
            {
                return NotFound();
            }

            placeFromStore.Name = updatedPlace.Name;
            placeFromStore.Description = updatedPlace.Description;


            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdatePlaceToVisit(int id, int cityId,
                    JsonPatchDocument<PlacesToVisitForUpdateDto> patchDoc) //using updateDto because we dont want to patch id
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            if (placeFromStore == null)
            {
                return NotFound();
            }

            var PlaceToVisitToPatch = new PlacesToVisitForUpdateDto() //because we need to patch while keeping validations in check
            {
                Name = placeFromStore.Name,
                Description = placeFromStore.Description
            };

            patchDoc.ApplyTo(PlaceToVisitToPatch, ModelState); //this will patch the PlaceToVisitToPatch
                                                               //passing 'modelstate' because if an invalid property is passed,
                                                               //we need to send a bad request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(PlaceToVisitToPatch))       //This will make sure that the validations are true, if not then for e.g
                                                              //name can be turned to null
            {
                return BadRequest();
            }

            placeFromStore.Name = PlaceToVisitToPatch.Name;
            placeFromStore.Description = PlaceToVisitToPatch.Description;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaceToVisit(int id, int cityId)
        {
            var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            if (placeFromStore == null)
            {
                return NotFound();
            }

            city.PlacesToVisit.Remove(placeFromStore);

            _mailService.Send("Place To Visit Deleted!",
                $"Place To Visit: \"{placeFromStore.Name}\" with Id: {placeFromStore.Id} Deleted.");

            return NoContent();
        }
    }

}
