using AutoMapper;
using Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CitiesInfo.API.Controllers
{
    [Route("api/cities/{cityId}/PlacesToVisit")]
    [ApiController]
    public class PlacesToVisitController : ControllerBase
    {
        private readonly ILogger<PlacesToVisitController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepo;
        private readonly IMapper _mapper;

        //Dependency Injections
        public PlacesToVisitController(
            //services
            ILogger<PlacesToVisitController> l,
            IMailService m,                                                    
            ICityInfoRepository c,
            IMapper mapper)
        {
            _logger = l ??
                throw new ArgumentNullException(nameof(l));
            _mailService = m ??
                throw new ArgumentNullException(nameof(m));
            _cityInfoRepo = c ??
                throw new ArgumentNullException(nameof(c));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPlacesToVisit(int cityId)
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);

            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }

            var placesToVisitForCity = _cityInfoRepo.GetPlacesToVisitForCity(cityId);
            if (placesToVisitForCity == null)
            {
                //logger.LogInformation($"City with id={cityId} was Not Found");
                return NotFound();
            }
            //var result = new List<PlacesToVisitDto>();
            //foreach (var ptv in placesToVisitForCity)
            //{
            //    result.Add(new PlacesToVisitDto()
            //    {
            //        Id = ptv.Id,
            //        Name = ptv.Name,
            //        Description = ptv.Description
            //    });
            //}
            return Ok(_mapper.Map<IEnumerable<PlacesToVisitDto>>(placesToVisitForCity));
        }

        [HttpGet("{id}", Name = "GetPlaceToVisit")]
        public IActionResult GetPlaceToVisit(int id, int cityId)
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }
            var placeToVisitForCity = _cityInfoRepo.GetPlaceToVisitForCity(id,cityId);

            if (placeToVisitForCity == null)
            {
                return NotFound();
            }

            //var result = new PlacesToVisitDto()
            //{
            //    Id = placeToVisitForCity.Id,
            //    Name = placeToVisitForCity.Name,
            //    Description = placeToVisitForCity.Description
            //};
            return Ok(_mapper.Map<PlacesToVisitDto>(placeToVisitForCity));
        }

        [HttpPost]
        public IActionResult CreatePlaceToVisit(int cityId, PlacesToVisitForCreationDto newPlaceToVisit)
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }

            //database will automatically create id
            //int maxIdPlacesToVisit = CitiesDataStore.StaticDataStoreObj.Cities.SelectMany(c => c.PlacesToVisit).Max(p => p.Id);

            //PlacesToVisitDto finalPlaceToVisit = new PlacesToVisitDto()
            //{
            //    Id = ++maxIdPlacesToVisit,
            //    Name = newPlaceToVisit.Name,
            //    Description = newPlaceToVisit.Description
            //};
            var FinalPlaceToVisit = _mapper.Map<Entities.PlaceToVisit>(newPlaceToVisit); //mapping from api to entity

            _cityInfoRepo.AddPlaceToVisit(cityId, FinalPlaceToVisit); //adding to in-memory database
            _cityInfoRepo.Save(); //saving changes to database

            //we want to return placesToVisitDto object, not entity object, so we need to map it back

            var createdPlaceToVisit = _mapper.Map<PlacesToVisitDto>(FinalPlaceToVisit);

            return CreatedAtRoute("GetPlaceToVisit",  //Route name , Route values, and Object
                new { id = createdPlaceToVisit.Id, cityId }, //this is for 201 location 
                createdPlaceToVisit);                        //this is the returning object
        }

        [HttpPut("{id}")]
        public IActionResult FullUpdatePlaceToVisit(int id, int cityId, PlacesToVisitForUpdateDto updatedPlace)
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }

            //PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            //if (placeFromStore == null)
            //{
            //    return NotFound();
            //}

            var placeToVisitEntity = _cityInfoRepo.GetPlaceToVisitForCity(id, cityId);
            if (placeToVisitEntity == null)
            {
                return NotFound();
            }

            //placeFromStore.Name = updatedPlace.Name;
            //placeFromStore.Description = updatedPlace.Description;

            _mapper.Map(updatedPlace, placeToVisitEntity);  //this will map/change the entity object from source to destination with overriding 

            _cityInfoRepo.UpdatePlaceToVisit(id, cityId, placeToVisitEntity); //empty, will do nothing, for stabalization

            _cityInfoRepo.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdatePlaceToVisit(int id, int cityId,
                    JsonPatchDocument<PlacesToVisitForUpdateDto> patchDoc) //using updateDto because we dont want to patch id
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            //if (city == null)
            //{
            //    return NotFound();
            //}
            //PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            //if (placeFromStore == null)
            //{
            //    return NotFound();
            //}

            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }

            var placeToVisitEntity = _cityInfoRepo.GetPlaceToVisitForCity(id, cityId);
            if (placeToVisitEntity == null)
            {
                return NotFound();
            }

            //var PlaceToVisitToPatch = new PlacesToVisitForUpdateDto() //because we need to patch while keeping validations in check
            //{
            //    Name = placeFromStore.Name,
            //    Description = placeFromStore.Description
            //};

            var PlaceToVisitToPatch = _mapper.Map<PlacesToVisitForUpdateDto>(placeToVisitEntity);
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

            //placeFromStore.Name = PlaceToVisitToPatch.Name;
            //placeFromStore.Description = PlaceToVisitToPatch.Description;

            _mapper.Map(PlaceToVisitToPatch, placeToVisitEntity);  //this will map/change the entity object from source to destination with overriding 

            _cityInfoRepo.UpdatePlaceToVisit(id, cityId, placeToVisitEntity); //empty, will do nothing, for stabalization

            _cityInfoRepo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaceToVisit(int id, int cityId)
        {
            //var city = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == cityId);
            //if (city == null)
            //{
            //    return NotFound();
            //}
            //PlacesToVisitDto placeFromStore = city.PlacesToVisit.FirstOrDefault(place => place.Id == id);

            //if (placeFromStore == null)
            //{
            //    return NotFound();
            //}

            if (!_cityInfoRepo.CityExists(cityId))
            {
                return NotFound();
            }

            //city.PlacesToVisit.Remove(placeFromStore);

            var PlaceToVisitEntity = _cityInfoRepo.GetPlaceToVisitForCity(id, cityId);

            _cityInfoRepo.RemovePlaceToVisit(PlaceToVisitEntity);

            _cityInfoRepo.Save();

            _mailService.Send("Place To Visit Deleted!",
                $"Place To Visit: \"{PlaceToVisitEntity.Name}\" with Id: {PlaceToVisitEntity.Id} Deleted.");

            return NoContent();
        }
    }

}
