namespace SmartFridge.Model;

/// <summary>
/// Inspired on https://github.com/lurumad/DotNet2022.git OrderStatus
/// Ideas from https://github.com/kgrzybek/modular-monolith-with-ddd.git
/// </summary>
public class ItemCondition
{
    private static readonly IDictionary<ItemConditionEnum, ItemCondition> _itemConditions =
        new Dictionary<ItemConditionEnum, ItemCondition>();

    public enum ItemConditionEnum
    {
        Sealed,
        Opened
    }

    public readonly ItemConditionEnum Id;
    public readonly string Name;
    public readonly double DegradationTime;

    private ItemCondition(ItemConditionEnum id, string name, double degradationTime)
    {
        Id = id;
        Name = name;
        DegradationTime = degradationTime;
        _itemConditions.Add(id, this);
    }

    public static readonly ItemCondition Sealed = new ItemCondition(ItemConditionEnum.Sealed, ItemConditionEnum.Sealed.ToString(), 1);
    public static readonly ItemCondition Opened = new ItemCondition(ItemConditionEnum.Opened, ItemConditionEnum.Opened.ToString(), 5);

    public static ItemCondition FromLiteral(string literal)
    {
        if (!Enum.TryParse(literal, true, out ItemConditionEnum itemConditionId))
            throw new Exception("Invalid condition input");

        return _itemConditions[itemConditionId];
    }

    public static bool operator ==(ItemCondition left, ItemCondition right)
    {
        return left.Id == right.Id;
    }

    public static bool operator !=(ItemCondition left, ItemCondition right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return Name;
    }


    public static IReadOnlyCollection<ItemCondition>? Values => _itemConditions.Values as IReadOnlyCollection<ItemCondition>;
}