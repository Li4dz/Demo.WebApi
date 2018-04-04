using Demo.Common.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Demo.Common.Structs.DemoStructs;

namespace Demo.Common.API
{
    public abstract class ApiClient
    {
        private string _CREDENCIALES { get; set; }
        public IJsonManager JsonManager { get; private set; }

        public ApiClient()
        {
            var _USER = "RGOMEZ";
            var _PASS = "123456";

            _CREDENCIALES = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _USER, _PASS)));
            this.JsonManager = new JsonManager();
        }

        private HttpResponseMessage SendRequest<T>(HttpClient client, string httpVerb, string requestUri, T data)
        {
            var _BDATA = JsonManager.CreateBinaryData(data);

            HttpResponseMessage response = new HttpResponseMessage();
            switch (httpVerb)
            {
                case HttpVerbs.POST:
                    response = client.PostAsJsonAsync(requestUri, _BDATA).Result;
                    break;
                case HttpVerbs.GET:
                    if (data != null)
                    {
                        string dataB64 = JsonManager.CreateStringB64FromData(data);
                        response = client.GetAsync(string.Concat(requestUri, "?jsonB64=", dataB64)).Result;
                    }
                    else
                    {
                        response = client.GetAsync(requestUri).Result;
                    }
                    break;
                case HttpVerbs.PUT:         //UPDATE
                    response = client.PutAsJsonAsync(requestUri, _BDATA).Result;
                    break;
                case HttpVerbs.DELETE:
                    break;
            }
            return response;
        }

        public T CallService<T>(Dictionary<string, string> HttpData, string httpVerb, string httpMethod, object TData = null) where T : new()
        {
            var _URI = HttpData["URI"];
            var _REQUEST_URI = HttpData["ReqURI"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);

                var response = this.SendRequest(client, httpVerb, string.Concat(_REQUEST_URI, httpMethod), TData);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    return new T();
                }
            }
        }
    }
}
