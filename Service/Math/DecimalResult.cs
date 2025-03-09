namespace Service.Math;

internal record DecimalResult(decimal Value) : Result<decimal>(Value);