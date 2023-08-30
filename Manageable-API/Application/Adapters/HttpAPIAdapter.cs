using Domain.RequestsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Adapters
{
    public class HttpAPIAdapter
    {

        public static T PostRequest<T>(string urlApi, object request, long? reponseSize = null, int? timeout = null, long? cache = null) where T : new()
        {
            HttpClient client = new HttpClient();
            if (cache != null)
            {
                CacheControlHeaderValue cacheHeader = new CacheControlHeaderValue
                {
                    MaxAge = TimeSpan.FromSeconds(cache.Value),
                };
                client.DefaultRequestHeaders.CacheControl = cacheHeader;
            }
            
            if (timeout != null)
            {
                client.Timeout = TimeSpan.FromMilliseconds(timeout.Value);
            }
            if(reponseSize != null)
            {
                client.MaxResponseContentBufferSize = reponseSize.Value; //number of bytes as long
            }

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
