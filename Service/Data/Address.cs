namespace Service.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(Id))]
[Table(nameof(Address))]
[PublicAPI]
internal record Address(
    [property: Key] int Id,
    string Line1,
    string Line2,
    string City,
    string State,
    string Zip);