using CoffeeMaker.Core.Events;

namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly Grinder _grinder;

    private readonly List<DomainEvent> _events = new();

    public WaterTank WaterTank { get; }

    public BeanHopper BeanHopper { get; }

    public GroundsContainer GroundsContainer { get; }

    public ControlPanel ControlPanel { get; }

    public IReadOnlyList<DomainEvent> Events => _events;

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

    private void TurnOn()
    {
        IsPoweredOn = true;
        AddEvent(new MachineTurnedOn());
    }

    private void TurnOff()
    {
        IsPoweredOn = false;
        AddEvent(new MachineTurnedOff());
    }

    private void Brew(CoffeeType coffeeType)
    {
        var instruction = BrewingInstructions[coffeeType];

        if (!IsPoweredOn)
        {
            Console.WriteLine("Machine is turned off.");
            return;
        }

        if (!WaterTank.HasEnoughWater(instruction.WaterAmountMl))
        {
            Console.WriteLine("Not enough water in the tank.");
            return;
        }

        if (!BeanHopper.HasEnoughBeans(instruction.BeanCount))
        {
            Console.WriteLine("Not enough beans in the hopper.");
            return;
        }

        Console.WriteLine("Brewing your coffee...");

        WaterTank.ConsumeWater(instruction.WaterAmountMl);
        BeanHopper.ConsumeBeans(instruction.BeanCount);

        AddEvent(new CoffeeBrewed(coffeeType));
        Console.WriteLine("Here you go: ☕");
    }

    private void AddEvent(DomainEvent domainEvent) => _events.Add(domainEvent);
}
