using Carter;
using Domain.RequestsClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Manageable_API.EndPoints
{
    public class FunTranslationsEndPoints : CarterModule
    {
        public FunTranslationsEndPoints() : base("/translatorfun") { }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            // https://funtranslations.com/api/mandalorian
            app.MapGet("/help", () =>
            {
                return Results.Ok(new { descricao = "Faz traduções de diversos tipos doidos.", data_informacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });
            });

            app.MapPost("/mandalorian", async (TranslatorFunRequest request) =>
            {
                //TODO: adicionar uma comunicação com uma API para fazer o translate sempre pra o inglês
                HttpClient client = new HttpClient();
                HttpResponseMessage resp = await client.PostAsJsonAsync("https://api.funtranslations.com/translate/mandalorian", request);
                string respString = resp.Content.ReadAsStringAsync().Result;
                TranslatorFunResponse response = new TranslatorFunResponse();
                if (respString != null)
                {
                    response = JsonSerializer.Deserialize<TranslatorFunResponse>(respString);
                }
                
                return response;
            });

            app.MapPost("/minion", async (TranslatorFunRequest request) =>
            {
                //TODO: adicionar uma comunicação com uma API para fazer o translate sempre pra o inglês
                HttpClient client = new HttpClient();
                HttpResponseMessage resp = await client.PostAsJsonAsync("https://api.funtranslations.com/translate/minion", request);
                string respString = resp.Content.ReadAsStringAsync().Result;
                TranslatorFunResponse response = new TranslatorFunResponse();
                if (respString != null)
                {
                    response = JsonSerializer.Deserialize<TranslatorFunResponse>(respString);
                }

                return response;
            });

            app.MapPost("/groot", async (TranslatorFunRequest request) =>
            {
                //TODO: adicionar uma comunicação com uma API para fazer o translate sempre pra o inglês
                HttpClient client = new HttpClient();
                HttpResponseMessage resp = await client.PostAsJsonAsync("https://api.funtranslations.com/translate/groot", request);
                string respString = resp.Content.ReadAsStringAsync().Result;
                TranslatorFunResponse response = new TranslatorFunResponse();
                if (respString != null)
                {
                    response = JsonSerializer.Deserialize<TranslatorFunResponse>(respString);
                }

                return response;
            });



        
        }
    }
}
