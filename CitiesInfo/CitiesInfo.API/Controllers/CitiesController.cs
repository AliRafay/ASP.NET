using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CitiesInfo.API.Controllers
{
    //[Route("api/[Controller]")] //Controller = Cities
    // OR //
    [Route("api/cities")] //do this for all Requests or do Indivisually 
    [ApiController]
    public class CitiesController : ControllerBase
    {
        //[HttpGet("api/cities")] // Indivisual Route, has to be specified for every single request
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.StaticDataStoreObj.Cities);
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(CitiesDataStore.StaticDataStoreObj.Cities.FirstOrDefault(city => city.Id == id));
            //FirstOrDefault is a LINQ Function that returns the first element that satisfies the condition or default.
        }

        //public string Message()
        //{
        //    return "hello";
        //}
    }
}
