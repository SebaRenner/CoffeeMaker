namespace CoffeeMaker.Core.Events;

public abstract record DomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}
