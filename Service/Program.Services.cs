using Service;

// ReSharper disable once CheckNamespace
internal static partial class Program
{
    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddOpenApi("openapi");

        services.AddHttpClient<ExampleClient>(ConfigureClient);

        services.AddGraphQLServer()
            .AddQueryType()
            .AddTypeExtension<HelloQueries>()
            .AddMutationType()
            .AddTypeExtension<MathMutations>();
    }

    private static void ConfigureClient(HttpClient client)
    {
        client.BaseAddress = new Uri("http://localhost:5086");
    }
}