namespace Service.Math.Ports;

using HotChocolate.Language;

using JetBrains.Annotations;

using Service.Math;
using Service.Math.Adapters;
using Service.Math.Inputs;

[ExtendObjectType(OperationType.Mutation)]
[PublicAPI]
[UsedImplicitly]
internal class MathMutations
{
    [GraphQLType<DecimalResultType>]
    public Task<DecimalResult> AddAsync(
        [Service] SomeExternalService client,
        [GraphQLType<DecimalBinaryOperationInputType>] DecimalBinaryOperationInput input,
        CancellationToken cancellationToken)
    {
        return client.AddAsync(input, cancellationToken);
    }
}