using Carter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        }
    }
}
