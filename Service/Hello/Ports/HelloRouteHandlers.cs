namespace Service;

using Microsoft.AspNetCore.Mvc;

internal static class HelloRouteHandlers
{
    public static string SayHello([FromQuery] string name = "world")
    {
        return $"hello {name}";
    }
}