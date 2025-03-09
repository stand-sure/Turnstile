namespace Service;

using Microsoft.AspNetCore.Mvc;

using Service.Math;
using Service.Math.Inputs;

internal static class MathRouteHandlers
{
    public static DecimalResult Add([FromBody] DecimalBinaryOperationInput input)
    {
        return new DecimalResult(input.Left + input.Right);
    }
}