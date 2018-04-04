using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Demo.WebApi.Controllers.Maestro
{
    [RoutePrefix("api/Maestro/Precio")]
    public class PrecioController : ApiController
    {
        [HttpGet]
        [Route("Index")]
        public IHttpActionResult Index()
        {
            return Ok("Success");
        }
    }
}