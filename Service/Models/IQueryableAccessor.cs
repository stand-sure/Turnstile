namespace Service.Models;

internal interface IQueryableAccessor<T>
    where T : class
{
    IQueryable<T> Queryable { get; }
}