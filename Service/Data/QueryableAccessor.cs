namespace Service.Data;

using Microsoft.EntityFrameworkCore;

using Service.Models;

internal class QueryableAccessor<T>(IDbContextFactory<MyDbContext> dbContextFactory) : IQueryableAccessor<T> where T : class
{
    public IQueryable<T> Queryable => dbContextFactory.CreateDbContext().Set<T>().AsNoTracking();
}