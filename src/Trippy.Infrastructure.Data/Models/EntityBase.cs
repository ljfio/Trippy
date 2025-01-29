namespace Trippy.Infrastructure.Data.Models;

public abstract class EntityBase
{
    public int Id { get; set; }

    public byte[] RowVersion { get; set; } = [];
}