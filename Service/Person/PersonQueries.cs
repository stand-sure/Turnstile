using HotChocolate.Language;

using Service.Models;

namespace Service.Person;

using JetBrains.Annotations;

using Service.Data;

[ExtendObjectType(OperationType.Query)]
[UsedImplicitly]
[PublicAPI]
internal class PersonQueries
{
    [UsePaging]
    [UseFiltering<PersonFilterInputType>]
    [UseSorting<PersonSortInputType>]
    [GraphQLType<ListType<PersonType>>]
    public IEnumerable<Person> GetPersons(
        [Service] IQueryableAccessor<Person> queryableAccessor,
        CancellationToken cancellationToken)
    {
        return queryableAccessor.Queryable;
    }

    public Person? GetPerson(
        int id,
        [Service] IQueryableAccessor<Person> queryableAccessor,
        CancellationToken cancellationToken)
    {
        IQueryable<Person> q = from person in queryableAccessor.Queryable
            where person.Id == id
            select person;

        return q.SingleOrDefault();
    }
}