namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly Grinder _grinder;

    public WaterTank WaterTank { get; }

    public BeanHopper BeanHopper { get; }

    public GroundsContainer GroundsContainer { get; }

    public ControlPanel ControlPanel { get; }

    private static readonly IReadOnlyDictionary<CoffeeType, BrewingInstruction> BrewingInstructions =
        new Dictionary<CoffeeType, BrewingInstruction>
        {
            [CoffeeType.Espresso] = new() { WaterAmountMl = 40, BeanCount = 120 },
            [CoffeeType.Regular] = new() { WaterAmountMl = 150, BeanCount = 150 },
        };

    public bool IsPoweredOn { get; private set; }

    public CoffeeMachine(WaterTank waterTank, BeanHopper beanHopper, GroundsContainer groundsContainer)
    {
        _grinder = new Grinder();

        WaterTank = waterTank;
        BeanHopper = beanHopper;
        GroundsContainer = groundsContainer;

        ControlPanel = new ControlPanel(
            onPowerPressed: TogglePower,
            onEspressoPressed: () => Brew(CoffeeType.Espresso),
            onCoffeePressed: () => Brew(CoffeeType.Regular));
    }

    private void TogglePower()
    {
        if (IsPoweredOn) TurnOff();
        else TurnOn();
    }

    private void TurnOn() => IsPoweredOn = true;

    private void TurnOff() => IsPoweredOn = false;

    private void Brew(CoffeeType coffeeType)
    {
        var instruction = BrewingInstructions[coffeeType];

        throw new NotImplementedException();
    }
}
