namespace SmartFridge.Model;

public class ConsolePrinter : IPrinter
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}