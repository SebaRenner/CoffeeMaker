namespace CoffeeMaker.Core;

public class ControlPanel
{
    public Button PowerButton { get; }

    public Button EspressoButton { get; }

    public Button RegularCoffeeButton { get; }

    public ControlPanel(Action onPowerPressed, Action onEspressoPressed, Action onCoffeePressed)
    {
        PowerButton = new Button("power-symbol", onPowerPressed);
        EspressoButton = new Button("espresso-cup", onEspressoPressed);
        RegularCoffeeButton = new Button("coffee-mug", onCoffeePressed);
    }
}