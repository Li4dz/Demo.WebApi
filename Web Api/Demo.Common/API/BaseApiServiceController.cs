using Demo.Common.JSON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.API
{
    public class BaseApiServiceController
    {
        public IJsonManager IJsonManager { get; set; }
        protected HttpClient HttpClient;

        public BaseApiServiceController()
        {
            IJsonManager = new JsonManager();
            this.HttpClient = new HttpClient();
            this.HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlWebAPI"]);
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ObtenerCredenciales());
        }

        private string ObtenerCredenciales()
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "usuario", "123456")));
        }
    }
}
