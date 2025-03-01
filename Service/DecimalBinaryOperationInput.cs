namespace Service;

internal record DecimalBinaryOperationInput(decimal Left, decimal Right) : BinaryOperationInput<decimal>(Left, Right);