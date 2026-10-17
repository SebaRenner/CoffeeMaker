namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly WaterTank _waterTank;

    private readonly BeanHopper _beanHopper;

    private readonly Grinder _grinder;

    private readonly ControlPanel _controlPanel;

    private readonly GroundsContainer _groundsContainer;

    public bool IsPoweredOn { get; private set; }

    public CoffeeMachine(WaterTank waterTank, BeanHopper beanHopper, Grinder grinder, ControlPanel controlPanel, GroundsContainer groundsContainer)
    {
        _waterTank = waterTank;
        _beanHopper = beanHopper;
        _grinder = grinder;
        _controlPanel = controlPanel;
        _groundsContainer = groundsContainer;
    }

    public void TurnOn()
    {
        IsPoweredOn = true;
    }

    public void TurnOff()
    {
        IsPoweredOn = false;
    } 
}
