using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CitiesInfo.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpPost("api/cities")]
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
