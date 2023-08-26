using Domain.RequestsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Adapters
{
    public class HttpAPIAdapter
    {
        public static T MakePostRequest<T>(string urlApi, object request) where T : new()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage HttpResp = client.PostAsJsonAsync(urlApi, request).Result;
            string respStr = HttpResp.Content.ReadAsStringAsync().Result;
            T response = new();
            if(respStr != null) { 
            
                response = JsonSerializer.Deserialize<T>(respStr);
            }

            return response;
        }
    }
}
