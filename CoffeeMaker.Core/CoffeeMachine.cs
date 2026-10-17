namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly WaterTank _waterTank;

    private readonly BeanHopper _beanHopper;

    private readonly Grinder _grinder;

    private readonly ControlPanel _controlPanel;

    private readonly GroundsContainer _groundsContainer;

    private static readonly IReadOnlyDictionary<CoffeeType, BrewingInstruction> BrewingInstructions =
        new Dictionary<CoffeeType, BrewingInstruction>
        {
            [CoffeeType.Espresso] = new() { WaterAmountMl = 40, BeanCount = 120 },
            [CoffeeType.Regular] = new() { WaterAmountMl = 150, BeanCount = 150 },
        };

    public bool IsPoweredOn { get; private set; }

    public CoffeeMachine(WaterTank waterTank, BeanHopper beanHopper, Grinder grinder, GroundsContainer groundsContainer)
    {
        _waterTank = waterTank;
        _beanHopper = beanHopper;
        _grinder = grinder;
        _groundsContainer = groundsContainer;

        _controlPanel = new ControlPanel(
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
