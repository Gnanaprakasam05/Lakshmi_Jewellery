using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Services
{

    public class HttpServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient HttpClient => _httpClientFactory.CreateClient();
    }
}
