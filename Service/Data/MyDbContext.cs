namespace Service.Data;

using Microsoft.EntityFrameworkCore;

internal class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
}