using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SL.Interfaces;

namespace Web.Api.Client.Services
{
    internal class JsonServiceClient
    {
        private string _baseUrl;
        private string _apiKey;
        private string _siteCode;

        public JsonServiceClient(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
        }

        public JsonServiceClient(string baseUrl, string apiKey, string siteCode): this(baseUrl, apiKey)
        {
            _siteCode = siteCode;
        }

        public TResult GetResult<TResult>(string url)
        {
            TResult result;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Add("Api-Key", _apiKey);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(FixUrl(url)).Result;

                result = response.IsSuccessStatusCode ? response.Content.ReadAsAsync<TResult>().Result : default(TResult);
            }

            return result;
        }

        public TResult PostResult<TRequest, TResult>(string url, TRequest request)
        {
            TResult result;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Add("Api-Key", _apiKey);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync(FixUrl(url), request).Result;

                result = response.IsSuccessStatusCode ? response.Content.ReadAsAsync<TResult>().Result : default(TResult);
            }

            return result;
        }

        private string FixUrl(string url) 
        {
            if (!string.IsNullOrEmpty(_siteCode)) {
                string sep = url.IndexOf("?") >=0 ? "&": "?";
                url = string.Format("{0}{1}s={2}", url, sep, _siteCode);
            }
            return url;
        }
    }
}
