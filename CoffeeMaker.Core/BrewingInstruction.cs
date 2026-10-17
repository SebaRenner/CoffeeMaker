namespace CoffeeMaker.Core;

public record BrewingInstruction
{
    public int WaterAmountMl { get; init; }

    public int BeanCount { get; init; }
}
