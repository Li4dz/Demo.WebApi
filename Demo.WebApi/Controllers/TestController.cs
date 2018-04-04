using Demo.Common.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    public class TestController : BaseAPIController
    {
        [HttpGet]
        [Route("api/Test/Get")]
        public IHttpActionResult Get()
        {
            string Nombre = "Web Api - Works !!!";
            return Ok(Nombre);
        }
    }
}