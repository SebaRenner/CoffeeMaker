namespace CoffeeMaker.Core;

public class Button
{
    private readonly Action _onPressed;

    public string Pictogram { get; init; }

    public Button(string pictogram, Action onPressed)
    {
        Pictogram = pictogram;
        _onPressed = onPressed;
    }

    public void Press() => _onPressed();
}
