namespace CoffeeMaker.Core;

public class CoffeeMachine
{
    private readonly WaterTank _waterTank;

    public bool IsPoweredOn { get; private set; }

    public CoffeeMachine(WaterTank waterTank)
    {
        _waterTank = waterTank;
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
