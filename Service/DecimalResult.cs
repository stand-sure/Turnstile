namespace Service;

internal record DecimalResult(decimal Value) : Result<decimal>(Value);