using MDO.Desktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDO.Desktop.Services
{
    public class DatabaseApiClient : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public DatabaseApiClient(string baseUrl)
        {
            
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ApiResponse<T>> SendRequestAsync<T>(string url, HttpMethod method, object payload = null)
        {
            HttpResponseMessage response;

            if (method == HttpMethod.Get)
                response = await _httpClient.GetAsync(url);
            else
            {
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync(url, content);
            }


            var responseContent = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);

            if (apiResponse == null)
            {
                MessageBox.Show("Internet connection error!");

                return new ApiResponse<T>
                {
                    Code = 0,
                    Message = "Internet connection error!",
                    Data = default(T),
                    Errors = null
                };
            }

            return apiResponse;
        }
    }
}
