using Application.Adapters;
using Carter;
using Domain.RequestsClass;
using FluentValidation;
using FluentValidation.Results;
using System.Text.Json;

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
                return Results.Ok(new { descricao = "This section of APIs makes some no sense translations.", data_informacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });
            });

            app.MapPost("/mandalorian", async (
                TranslatorFunRequest request,
                IValidator<TranslatorFunRequest> validator) =>
            {
                ValidationResult resultValidation = await validator.ValidateAsync(request);
                if (!resultValidation.IsValid)
                {
                    return Results.ValidationProblem(resultValidation.ToDictionary());
                }

                string urlAPI = "https://api.funtranslations.com/translate/mandalorian";
                TranslatorFunResponse response = HttpAPIAdapter.MakePostRequest<TranslatorFunResponse>(urlAPI, request);

                return Results.Ok(response);
            });

            app.MapPost("/minion", async (
                TranslatorFunRequest request,
                IValidator<TranslatorFunRequest> validator) =>
            {
                ValidationResult resultValidation = await validator.ValidateAsync(request);
                if (!resultValidation.IsValid)
                {
                    return Results.ValidationProblem(resultValidation.ToDictionary());
                }

                string urlAPI = "https://api.funtranslations.com/translate/minion";
                TranslatorFunResponse response = HttpAPIAdapter.MakePostRequest<TranslatorFunResponse>(urlAPI, request);

                return Results.Ok(response);
            });

            app.MapPost("/groot", async (
                TranslatorFunRequest request,
                IValidator<TranslatorFunRequest> validator) =>
            {
                ValidationResult resultValidation = await validator.ValidateAsync(request);
                if (!resultValidation.IsValid)
                {
                    return Results.ValidationProblem(resultValidation.ToDictionary());
                }

                string urlAPI = "https://api.funtranslations.com/translate/groot";
                TranslatorFunResponse response = HttpAPIAdapter.MakePostRequest<TranslatorFunResponse>(urlAPI, request);

                return Results.Ok(response);
            });



        
        }
    }
}
