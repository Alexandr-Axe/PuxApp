using PuxApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapApplicationEndpoints();

app.Run();