namespace SmartFridge.Model;

public interface IFridgeDisplayer
{
    void ShowDisplay(IReadOnlyCollection<Item> items, DateTime currentDate);
}