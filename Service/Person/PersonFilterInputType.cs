namespace Service.Person;

using HotChocolate.Data.Filters;

using JetBrains.Annotations;

using Service.Data;

[UsedImplicitly]
internal class PersonFilterInputType : FilterInputType<Person>;