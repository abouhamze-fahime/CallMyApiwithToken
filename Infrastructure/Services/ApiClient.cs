using Infrastructure.Interface;
using Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private string apiUrl = "https://localhost:44331/api/Person/GetPersonByBuilding";
  
        public List<ApiRess> GetAsync2(string building ,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = _httpClient.GetStringAsync(apiUrl + "/" + building);
            List<ApiRess> lst = JsonConvert.DeserializeObject<List<ApiRess>>(response.Result);
            return lst;
        }
    
        public List<ApiRess> GetAsyn3(BodyInfo body , string token)
        {
           
            List<ApiRess> _Result = null;
            var address = "https://localhost:44331/api/Person/GetPeopleBySomeInfo/info";
            using (HttpClient Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (HttpRequestMessage bodyRequest = new HttpRequestMessage(HttpMethod.Post, address))
                {
                    bodyRequest.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> responseApi = Client.PostAsync(address, bodyRequest.Content, new System.Threading.CancellationToken(false));
                    if (responseApi.Result.StatusCode == HttpStatusCode.OK)
                    {
                        if (responseApi.Result.IsSuccessStatusCode)
                        {
                            Task<string> finalRes = responseApi.Result.Content.ReadAsStringAsync();
                            _Result = JsonConvert.DeserializeObject<List<ApiRess>>(finalRes.Result).ToList();
                            return _Result;
                        }
                    }
                    return null;
                }
            }
        }

        public ApiRess AddAsync(ApiRess apiRess)
        {
            ApiRess _Result = null;
            var address = "https://localhost:44331/api/Person/AddPerson";
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage bodyRequest = new HttpRequestMessage(HttpMethod.Post, address))
                {
                    bodyRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRess), Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> responseApi = Client.PostAsync(address, bodyRequest.Content, new System.Threading.CancellationToken(false));
                    if (responseApi.Result.StatusCode == HttpStatusCode.OK)
                    {
                        if (responseApi.Result.IsSuccessStatusCode)
                        {
                            Task<string> finalRes = responseApi.Result.Content.ReadAsStringAsync();
                            _Result = JsonConvert.DeserializeObject<ApiRess>(finalRes.Result);
                            return _Result;
                        }
                    }
                    return null;
                }
            }
        }

        public ApiRess DeleteAsync(int personId)
        {
            ApiRess _Result = null;
            var address = "https://localhost:44331/api/Person/DeletePerson";
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage bodyRequest = new HttpRequestMessage(HttpMethod.Delete, address))
                {
                   
                    Task<HttpResponseMessage> responseApi = Client.DeleteAsync(address+"/"+ personId,  new System.Threading.CancellationToken(false));
                    if (responseApi.Result.StatusCode == HttpStatusCode.OK)
                    {
                        if (responseApi.Result.IsSuccessStatusCode)
                        {
                            Task<string> finalRes = responseApi.Result.Content.ReadAsStringAsync();
                            _Result = JsonConvert.DeserializeObject<ApiRess>(finalRes.Result);
                            return _Result;
                        }
                    }
                    return null;
                }
            }
        }

        public ApiRess UpdatePerson(ApiRess body)
        {
            ApiRess _Result = null;
            var address = "https://localhost:44331/api/Person/UpdatePerson";
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage bodyRequest = new HttpRequestMessage(HttpMethod.Put, address))
                {
                    bodyRequest.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> responseApi = Client.PutAsync(address, bodyRequest.Content, new System.Threading.CancellationToken(false));
                    if (responseApi.Result.StatusCode == HttpStatusCode.OK)
                    {
                        if (responseApi.Result.IsSuccessStatusCode)
                        {
                            Task<string> finalRes = responseApi.Result.Content.ReadAsStringAsync();
                            _Result = JsonConvert.DeserializeObject<ApiRess>(finalRes.Result);
                            return _Result;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
