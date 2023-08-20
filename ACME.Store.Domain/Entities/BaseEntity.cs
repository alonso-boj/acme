using System;

namespace ACME.Store.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public DateTime? LastUpdatedAt { get; private set; } = null;
}
