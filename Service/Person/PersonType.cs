namespace Service.Person;

using JetBrains.Annotations;

using Service.Data;
using Service.Models;

[UsedImplicitly]
internal class PersonType : ObjectType<Person>
{
    protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
    {
        descriptor.ImplementsNode().ResolveNodeWith<PersonQueries>(queries => queries.GetPerson(0, null!, CancellationToken.None));
        descriptor.Field(person => person.Id).ID();
        descriptor.Field(person => person.AddressId).Ignore();
        
        descriptor.Field(person => person.Address).Type<AddressType>()
            .ResolveWith<Resolvers>(_ => Resolvers.GetAddressForPerson(null!, null!));
    }

    private sealed class Resolvers
    {
        public static Address? GetAddressForPerson([Parent] Person person, [Service] IQueryableAccessor<Address> queryableAccessor)
        {
            return queryableAccessor.Queryable.SingleOrDefault(address => address.Id == person.AddressId);
        }
    }
}