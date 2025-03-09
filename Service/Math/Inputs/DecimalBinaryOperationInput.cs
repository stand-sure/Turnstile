namespace Service.Math.Inputs;

internal record DecimalBinaryOperationInput(decimal Left, decimal Right) : BinaryOperationInput<decimal>(Left, Right);