namespace SmartFridge.Model;

public class Item
{
    private string _name;
    private DateTime _expiry;
    private ItemCondition _itemCondition;

    private Item(string name, string expiry, string condition)
    {
        _name = name;
        _expiry = Convert.ToDateTime(expiry);
        _itemCondition = ItemCondition.FromLiteral(condition);
    }

    public static Item CreateNew(string name, string expiry, string condition)
    {
        return new Item(name, expiry, condition);
    }

    public string Name()
    {
        return _name;
    }

    public double CalculateRemainingDays(DateTime? currentDate)
    {
        return (_expiry.Date - currentDate.Value.Date).TotalDays;
    }

    public DateTime Expiry()
    {
        return _expiry;
    }

    public void Degrade()
    {
        _expiry = _expiry.AddHours(- _itemCondition.DegradationTime);
    }
}