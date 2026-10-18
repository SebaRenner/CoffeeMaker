namespace CoffeeMaker.Core;

public class BeanHopper
{
    private const int MaxBeanCount = 500;

    public int CurrentBeanCount { get; private set; }

    public BeanHopper()
    {
        CurrentBeanCount = 0;
    }

    public void FillToMax()
    {
        CurrentBeanCount = MaxBeanCount;
    }

    internal void ConsumeBeans(int beanCount)
    {
        CurrentBeanCount -= beanCount;
    }

    internal bool HasEnoughBeans(int requiredBeanCount)
    {
        return CurrentBeanCount >= requiredBeanCount;
    }
}
