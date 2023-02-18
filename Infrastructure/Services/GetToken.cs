using Infrastructure.Interface;
using Infrastructure.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace Infrastructure.Services
{
     public  class GetToken  :IGetToken
    {
        //private IHttpClientFactory _httpClientFactory;

        //public GetToken(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}
        public string GetToken2(LoginModel user)
        {
            string baseAddress = "https://localhost:44331/api/Auth";
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage bodyRequest = new HttpRequestMessage(HttpMethod.Post, baseAddress))
                {
                    bodyRequest.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    HttpResponseMessage responseApi = Client.PostAsync(baseAddress, bodyRequest.Content, new System.Threading.CancellationToken(false)).Result;
                    //if (responseApi.StatusCode == HttpStatusCode.OK)
                    //{
                    if (responseApi.IsSuccessStatusCode)
                    {
                        var finalRes = responseApi.Content.ReadAsStringAsync().Result;
                        var _Result = finalRes;

                        if (_Result != null)
                        {
                            //JToken jobject = JObject.Parse(_Result);
                            //TokenModel c = new TokenModel()
                            //{
                            //    token = (jobject["token"].ToString())
                            //};

                            //JObject dataa = JObject.Parse(_Result);
                            //JObject dataa2 = JObject.Parse(_Result);
                            //JToken res = dataa.SelectToken("result");
                            //ResponseText = res.ToString();
                            return _Result;
                        }
                        else
                        {
                            return "Response is null";
                        };
                    }
                    // }
                    else
                    {
                        return "There is Error";
                    }
                }
            }

        }
    }
}
