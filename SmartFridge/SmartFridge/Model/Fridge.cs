namespace SmartFridge.Model;

public class Fridge
{
    private readonly IFridgeDisplayer _fridgeDisplayer;
    private DateTime? _currentDate;
    private bool _isDoorOpen = false;
    private readonly List<Item> _items = new List<Item>();

    public Fridge(IFridgeDisplayer fridgeDisplayer)
    {
        _fridgeDisplayer = fridgeDisplayer;
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
        _fridgeDisplayer.ShowDisplay(Items(), CurrentDate());
    }

    public void AddItem(string name, string expiry, string condition)
    {
        if (!_isDoorOpen)
            throw new Exception("Door is closed");

        var item = Item.CreateNew(name: "Peppers", expiry: "17/09/2022", condition: "sealed");

        _items.Add(item);
    }

    public IReadOnlyCollection<Item> Items()
    {
        return _items as IReadOnlyCollection<Item>;
    }

    public void RemoveItem(string name)
    {
        var item = _items.FirstOrDefault(x => x.Name().ToString().Equals(name, StringComparison.OrdinalIgnoreCase));

        if (item == null)
            throw new Exception("Item not found");

        _items.Remove(item);
    }
}