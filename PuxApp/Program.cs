var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/analyse", (AnalyseRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Path))
    {
        return Results.BadRequest(new { error = "Cesta nesmí být prázdná." });
    }

    return Results.Ok(new
    {
        message = "Požadavek byl úspěšně přijat.",
        path = request.Path
    });
});

app.Run();

record AnalyseRequest(string Path);