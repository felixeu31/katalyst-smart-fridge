namespace SmartFridge.Model;

public class Item
{
    private readonly string _name;
    private readonly DateTime _expiry;
    private readonly string _condition;

    private Item(string name, string expiry, string condition)
    {
        _name = name;
        _expiry = Convert.ToDateTime(expiry);
        _condition = condition;
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
}