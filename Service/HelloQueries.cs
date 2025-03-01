namespace Service;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;

using HotChocolate.Language;

using JetBrains.Annotations;

[ExtendObjectType(OperationType.Query)]
[UsedImplicitly]
[PublicAPI]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
internal class HelloQueries
{
    public string SayHello(string name = "")
    {
        return RouteHandlers.SayHello(name);
    }
}