using Microsoft.EntityFrameworkCore;

using Service.Data;
using Service.Routing;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();

WebApplication app = builder.Build();
app.MapRoutes();

await using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
{
    var factory = ActivatorUtilities.GetServiceOrCreateInstance<IDbContextFactory<MyDbContext>>(scope.ServiceProvider);
    MyDbContext context = await factory.CreateDbContextAsync();
    context.Database.EnsureCreated();
}

await app.RunAsync();