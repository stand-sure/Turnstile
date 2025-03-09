namespace Service.Routing;

internal static class MathRouteConfig
{
    public static void MapMathRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder group = routeBuilder.MapGroup("math");

        group.MapPost("add", MathRouteHandlers.Add)
            .Produces<Result<decimal>>()
            .WithTags("math");
    }
}