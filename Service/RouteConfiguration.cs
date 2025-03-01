namespace Service;

internal static class RouteConfiguration
{
    public static void MapRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapOpenApi("/{documentName}.json");
        routeBuilder.MapSayHelloRoutes();
        routeBuilder.MapMathRoutes();
        routeBuilder.MapGraphQL();
    }
}