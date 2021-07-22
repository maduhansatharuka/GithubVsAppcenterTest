using Assessment.Test.Models;
using Assessment.Test.Services;
using Assessment.Test.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpRequestProviderService))]
namespace Assessment.Test.Services
{
    public class HttpRequestProviderService : IHttpRequestProviderService
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private object responseData;
        private JsonConverter[] serializerOptions;

        #region Constructors & initialization

        public HttpRequestProviderService()
        {

            jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
        }

        private void _constructor()
        {

        }
        #endregion

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            HttpResponseMessage response = null;

            try
            {
                HttpClient httpClient = await CreateHttpClient();
                string json = JsonConvert.SerializeObject(
                    content,
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc
                    });
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                response = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
                // comment code to send a fake call
                //await httpClient.PostAsync(url, httpContent);
                
                if (response?.IsSuccessStatusCode ?? false)
                {
                    // let it continue
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;
        }

        private async Task<HttpClient> CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            T root= default; 
            try
            {

                HttpResponseMessage response = null;


                HttpClient httpClient = await CreateHttpClient();
                response = await httpClient.GetAsync(url);
                string responseData = await response.Content.ReadAsStringAsync();
                
                 root= JsonConvert.DeserializeObject<T>(responseData);

                
            }

            catch (Exception ex) { 
            
            
            }
            return root;

        }
    }
}
