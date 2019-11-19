using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Classes
{
    public class Api
    {
        public class Response
        {
            public string access_token { get; set; }
        }

        private IConfiguration _configuration;
        private HttpClient _http;

        public Api(IConfiguration configuration, HttpClient http)
        {
            _configuration = configuration.GetSection("App");
            _http = http;
        }

        public async Task<Response> GetAccessToken()
        {
            try
            {
                var url = _configuration["url"];
                
                var form = new FormUrlEncodedContent(new []
                    {
                        new KeyValuePair<string, string>("id", "test"),
                    }
                );

                var responseMessage = await _http.PostAsync(url, form);
                var json = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Response>(json);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}