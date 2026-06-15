using PuxApp.Models;
using PuxApp.Services;

namespace PuxApp.Extensions
{
    /// <summary>
    /// Obsahuje metody pro registraci endpointů.
    /// </summary>
    public static class Endpoints
    {
        /// <summary>
        /// Zaregistruje endpointy aplikace.
        /// </summary>
        /// <param name="app">Instance webové aplikace.</param>
        public static void MapApplicationEndpoints(this WebApplication app)
        {
            app.MapPost("/api/analyse", HandleAnalyseRequest);

            app.MapGet("/ping", () => Results.Ok("pong"));
        }

        /// <summary>
        /// Zpracuje požadavek na analýzu adresáře a vrací seznam souborů v daném adresáři.
        /// </summary>
        /// <param name="request">Data zadaná uživatelem z webu.</param>
        /// <param name="scanner">Služba pro načtení obsahu adresáře.</param>
        /// <returns>HTTP odpověď s výsledkem analýzy.</returns>
        static IResult HandleAnalyseRequest(AnalyseRequest request, DirectoryAnalysisService analysisService)
        {
            try
            {
                var result = analysisService.Analyse(request.Path);

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        }
    }
}
