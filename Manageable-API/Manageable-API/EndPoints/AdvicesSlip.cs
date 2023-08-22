using Carter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manageable_API.EndPoints
{
    public class AdvicesSlip : CarterModule
    {
        public AdvicesSlip() : base("/theadvisor")
        {
            
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //https://api.adviceslip.com/#endpoint-random
            app.MapGet("/help", () =>
            {
                return Results.Ok(new { descricao = "Tras conselhos diversos", data_informacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });
            });
        }
    }
}
