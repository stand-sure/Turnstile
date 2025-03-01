using Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();

WebApplication app = builder.Build();
app.MapRoutes();

await app.RunAsync();