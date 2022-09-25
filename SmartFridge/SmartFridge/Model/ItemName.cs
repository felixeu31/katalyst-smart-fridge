using Ardalis.GuardClauses;
using System.Xml.Linq;

namespace SmartFridge.Model;

public class ItemName : IEquatable<ItemName>
{

    public string Value { get; set; }

    private ItemName(string value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));

        Value = value;
    }

    public static ItemName FromString(string itemName)
    {
        return new ItemName(itemName);
    }

    public static bool operator ==(ItemName left, ItemName right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(ItemName left, ItemName right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return Value;
    }
    public static implicit operator string(ItemName value)
    {
        return value.Value;
    }

    public static explicit operator ItemName(string value)
    {
        return new ItemName(value);
    }

    public bool Equals(ItemName? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ItemName)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}