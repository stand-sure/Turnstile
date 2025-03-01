namespace Service;

internal static class MathRouteConfig
{
    public static void MapMathRoutes(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder group = routeBuilder.MapGroup("math");

        group.MapPost("add", RouteHandlers.Add)
            .Produces<Result<decimal>>()
            .WithTags("math");
    }
}