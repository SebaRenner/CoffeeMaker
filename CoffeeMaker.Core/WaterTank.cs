namespace CoffeeMaker.Core;

public class WaterTank
{
    private const int MaxVolumeMl = 1000;

    public int CurrentVolumeMl { get; private set; }

    public WaterTank()
    {
        CurrentVolumeMl = 0;
    }

    public void FillToMax()
    {
        CurrentVolumeMl = MaxVolumeMl;
    }
}
