using System.Runtime.CompilerServices;

using Bogus;

using Microsoft.EntityFrameworkCore;

using Service;
using Service.Data;
using Service.Math.Ports;
using Service.Models;
using Service.Person;

using Person = Service.Data.Person;

internal static partial class Program
{
    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddOpenApi("openapi");

        services.AddHttpClient<SomeExternalService>(ConfigureClient);

        services.AddScoped<IQueryableAccessor<Person>, QueryableAccessor<Person>>();
        services.AddScoped<IQueryableAccessor<Address>, QueryableAccessor<Address>>();

        services.AddGraphQLServer()
            .AddGlobalObjectIdentification()
            .AddQueryType()
            .AddTypeExtension<PersonQueries>()
            .AddFiltering()
            .AddSorting()
            .AddMutationType()
            .AddTypeExtension<MathMutations>();

        services.AddDbContextFactory<MyDbContext>(ConfigureDbContextOptions);
    }

    private static void ConfigureDbContextOptions(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("demo");
        optionsBuilder.UseSeeding(Seed);
    }

    private static void Seed(DbContext context, bool storeManagementPerformed)
    {
        Faker<Address?> addressFaker = new Faker<Address?>().WithRecord()
            .RuleFor(address => address!.City, faker => faker.Address.City())
            .RuleFor(address => address!.Line1, faker => faker.Address.StreetAddress())
            .RuleFor(address => address!.Line2, () => string.Empty)
            .RuleFor(address => address!.State, faker => faker.Address.State())
            .RuleFor(address => address!.Zip, faker => faker.Address.ZipCode());

        List<Address>? addresses = addressFaker.Generate(3)!;
        context.Set<Address>().AddRange(addresses);
        context.SaveChanges();

        IList<int> addressIds = addresses.Select(address => address.Id).ToList();
        var rng = new Random();

        Faker<Person?> personFaker = new Faker<Person?>().WithRecord()
            .RuleFor(person => person!.AddressId, AddressIdPicker)
            .RuleFor(person => person!.GivenName, faker => faker.Person.FirstName)
            .RuleFor(person => person!.Surname, faker => faker.Person.LastName);

        context.Set<Person>().AddRange(personFaker.Generate(10)!);
        context.SaveChanges();

        return;

        int? AddressIdPicker() => addressIds[rng.Next() % addressIds.Count];
    }

    private static void ConfigureClient(HttpClient client)
    {
        client.BaseAddress = new Uri("http://localhost:5086");
    }
}

public static class ExtensionsForBogus
{
    public static Faker<T?> WithRecord<T>(this Faker<T?> faker) where T : class
    {
        faker.CustomInstantiator(_ => RuntimeHelpers.GetUninitializedObject(typeof(T)) as T);
        return faker;
    }
}