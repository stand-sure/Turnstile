namespace Service.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id))]
[Table(nameof(Person))]
[PublicAPI]
internal record Person(
    [property: Key] int Id,
    string GivenName,
    string Surname)
{
    public int? AddressId { get; set; }
    
    [ForeignKey(nameof(AddressId))]
    public Address? Address { get; set; }
}