using Demo.Common.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Common.API
{
    public class BaseAPIController : ApiController
    {
        public IJsonManager JsonManager { get; private set; }

        public BaseAPIController()
        {
            this.JsonManager = new JsonManager();
        }
    }
}
