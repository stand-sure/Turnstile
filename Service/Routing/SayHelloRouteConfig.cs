namespace Service.Routing;

internal static class SayHelloRouteConfig
{
    public static void MapSayHelloRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder groupBuilder = routeBuilder.MapGroup("/say-hello");

        groupBuilder.MapGet("/", HelloRouteHandlers.SayHello)
            .Produces<string>()
            .WithTags("hello")
            .WithDescription("says hello to `name`");
    }
}