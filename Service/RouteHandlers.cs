namespace Service;

using Microsoft.AspNetCore.Mvc;

internal static class RouteHandlers
{
    public static string SayHello([FromQuery] string name = "world")
    {
        return $"hello {name}";
    }

    public static DecimalResult Add([FromBody] DecimalBinaryOperationInput input)
    {
        return new DecimalResult(input.Left + input.Right);
    }
}