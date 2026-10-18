namespace CoffeeMaker.Core.Events;

public record CoffeeBrewed(CoffeeType CoffeeType) : DomainEvent;
