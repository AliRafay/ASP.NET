using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CitiesInfo.API.Controllers
{
    [Route("api/[Controller]")] //Controller = Cities
    // OR //
    //[Route("api/cities")] //do this for all Requests or do Indivisually 
    [ApiController]
    public class CitiesController : ControllerBase
    {
        //[HttpGet("api/cities")] // Indivisual Route, has to be specified for every single request
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>(){
                new {id=1 , Name="Karachi"},
                new {id=2 , Name="Lahore"},
                new {id=3 , Name="Islamabad"},
            });
        }
        //public string Message()
        //{
        //    return "hello";
        //}
    }
}
