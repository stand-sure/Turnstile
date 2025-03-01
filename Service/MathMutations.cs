namespace Service;

using HotChocolate.Language;

using JetBrains.Annotations;

[ExtendObjectType(OperationType.Mutation)]
[PublicAPI]
[UsedImplicitly]
internal class MathMutations
{
    [GraphQLType<DecimalResultType>]
    public Task<DecimalResult> AddAsync(
        [Service] ExampleClient client,
        [GraphQLType<DecimalBinaryOperationInputType>] DecimalBinaryOperationInput input,
        CancellationToken cancellationToken)
    {
        return client.SendAddRequest(input, cancellationToken);
    }
}