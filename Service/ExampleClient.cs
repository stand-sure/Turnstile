using System.Text.Json;

namespace Service;

internal class ExampleClient(HttpClient client)
{
    public async Task<DecimalResult> SendAddRequest(
        DecimalBinaryOperationInput input,
        CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/math/add", input, cancellationToken: cancellationToken);

        string json = await response.Content.ReadAsStringAsync(cancellationToken);

        var result = JsonSerializer.Deserialize<DecimalResult>(json, JsonSerializerOptions.Web);

        return result ?? new DecimalResult(0);
    }
}