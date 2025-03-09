namespace Service.Person;

using HotChocolate.Data.Sorting;

using JetBrains.Annotations;

using Service.Data;

[UsedImplicitly]
internal class PersonSortInputType : SortInputType<Person>;