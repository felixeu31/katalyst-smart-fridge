namespace SmartFridge.Model;

public class Fridge
{
    private readonly IPrinter _printer;
    private DateTime? _currentDate;
    private bool _isDoorOpen = false;
    private List<Item> _items = new List<Item>();

    public Fridge(IPrinter printer)
    {
        _printer = printer;
    }

    public void SetCurrentDate(string inputDate)
    {
        this._currentDate = Convert.ToDateTime(inputDate);
    }

    public DateTime CurrentDate()
    {
        if (!_currentDate.HasValue)
            throw new Exception("Current date is not defined");

        return _currentDate.Value;
    }

    public bool IsOpen()
    {
        return _isDoorOpen;
    }

    public void OpenDoor()
    {
        if(_isDoorOpen)
            throw new Exception("Door is already open");

        this._isDoorOpen = true;
    }

    public void CloseDoor()
    {
        if (!_isDoorOpen)
            throw new Exception("Door is already closed");

        this._isDoorOpen = false;
    }

    public void SimulateDayOver()
    {
        if (!_currentDate.HasValue)
            throw new Exception("Current date is not defined");

        _currentDate = _currentDate.Value.AddDays(1);
    }

    public void ShowDisplay()
    {
        if(!_items.Any())
            _printer.Print("Fridge is empty");

        foreach (var item in _items)
        {
            _printer.Print($"{item.Name()}: {item.CalculateRemainingDays(_currentDate)} days remaining");
        }
    }

    public void AddItem(string name, string expiry, string condition)
    {
        if (!_isDoorOpen)
            throw new Exception("Door is closed");

        var item = Item.CreateNew(name: "Peppers", expiry: "17/09/2022", condition: "sealed");

        _items.Add(item);
    }
}