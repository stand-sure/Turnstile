namespace Service;

using System.Text.Json;

using Service.Math;
using Service.Math.Inputs;

internal class SomeExternalService(HttpClient client)
{
    public Task<DecimalResult> AddAsync(
        DecimalBinaryOperationInput input,
        CancellationToken cancellationToken)
    {
        const string requestUri = "/math/add";

        return client.PostAsJsonAsync(requestUri, input, cancellationToken).ContinueWith(AdaptResult, cancellationToken).Unwrap();

        Task<DecimalResult> AdaptResult(Task<HttpResponseMessage> message)
        {
            return message.Result.Content.ReadAsStringAsync(cancellationToken)
                .ContinueWith(DeserializeResult, cancellationToken);
        }
    }

    private static DecimalResult DeserializeResult(Task<string> json)
    {
        return JsonSerializer.Deserialize<DecimalResult>(json.Result, JsonSerializerOptions.Web) ?? new DecimalResult(0);
    }
}