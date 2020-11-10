using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;
namespace CitiesInfo.API.Controllers
{
    //[Route("api/[Controller]")] //Controller = Cities
    // OR //
    [Route("api/cities")] //do this for all Requests or do Indivisually 
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepo;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepo,
            IMapper mapper)
        {
            _cityInfoRepo = cityInfoRepo ??
                throw new ArgumentNullException(nameof(cityInfoRepo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        //[HttpGet("api/cities")] // Indivisual Route, has to be specified for every single request
        [HttpGet]
        //public JsonResult GetCities()
        //{
        //    return new JsonResult(CitiesDataStore.StaticDataStoreObj.Cities);
        //}
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.StaticDataStoreObj.Cities);


            var cityEntities = _cityInfoRepo.GetCities();

            //achieving below code using autoMapper

            //var results = new List<CityWithoutPlacesToVisitDto>();
            //foreach (City cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPlacesToVisitDto()
            //    {
            //        Id = cityEntity.Id,
            //        Name = cityEntity.Name,
            //        Description = cityEntity.Description
            //    });
            //}
            //var response = cityEntities.Select(x => _mapper.Map<CityWithoutPlacesToVisitDto>(x));
            var response = _mapper.Map<IEnumerable<CityWithoutPlacesToVisitDto>>(cityEntities);
            return Ok(response);
        }

        [HttpGet("{id}")]

        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == id));
        //    //FirstOrDefault is a LINQ Function that returns the first element that satisfies the condition or default.
        //}

        public IActionResult GetCity(int id, bool includePlacesToVisit = false)
        {
            //var CityToReturn = CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == id);
            //if (CityToReturn == null)
            //{
            //    return NotFound();
            //}
            //return Ok(CityToReturn);

            var city = _cityInfoRepo.GetCity(id, includePlacesToVisit);

            if (city == null)
            {
                return NotFound();
            }

            if (!includePlacesToVisit)
            {
                //var cityResult = new CityWithoutPlacesToVisitDto()
                //{
                //    Id = city.Id,
                //    Name = city.Name,
                //    Description = city.Description
                //};
                return Ok(_mapper.Map<CityWithoutPlacesToVisitDto>(city));
            }
            else
            {
                //var cityResult = new CityDto()
                //{
                //    Id = city.Id,
                //    Name = city.Name,
                //    Description = city.Description
                //};
                //foreach (var ptv in city.PlacesToVisit)
                //{
                //    cityResult.PlacesToVisit.Add(new PlacesToVisitDto()
                //    {
                //        Id = ptv.Id,
                //        Name= ptv.Name,
                //        Description = ptv.Description
                //    });
                //}
                return Ok(_mapper.Map<CityDto>(city)); //gives error if PlacesToVisit Profile doesn't exist
            }
        }
    }

}

