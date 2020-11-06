using System;
using Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CitiesInfo.API.Controllers
{
    [Route("api/testDatabase")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        //private readonly CityInfoContext context;
        //public DummyController(CityInfoContext ctx)  //this contructor will initiate cityInfoContext 
        //{
        //    context = ctx ?? throw new ArgumentNullException(nameof(ctx));
        //}

        //[HttpGet]
        //public IActionResult TestDatabase()
        //{
        //    return Ok();
        //}
    }
}
