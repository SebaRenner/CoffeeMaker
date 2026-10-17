namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly WaterTank _waterTank;

    private readonly BeanHopper _beanHopper;

    private readonly Grinder _grinder;

    private readonly ControlPanel _controlPanel;

    private readonly GroundsContainer _groundsContainer;

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
        throw new NotImplementedException();
    }
}
