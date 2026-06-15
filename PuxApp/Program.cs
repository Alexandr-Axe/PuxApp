using PuxApp.Models;
using PuxApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DirectoryScanner>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/analyse", HandleAnalyseRequest);

app.Run();

/// <summary>
/// Zpracuje požadavek na analýzu adresáře a vrací seznam souborů v daném adresáři.
/// </summary>
/// <param name="request">Data zadaná uživatelem z webu.</param>
/// <param name="scanner">Služba pro načtení obsahu adresáře.</param>
/// <returns>HTTP odpověď s výsledkem analýzy.</returns>
static IResult HandleAnalyseRequest(AnalyseRequest request, DirectoryScanner scanner)
{
    try
    {
        var files = scanner.ReturnFilesFromDirectory(request.Path);
        return Results.Ok(files);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
}