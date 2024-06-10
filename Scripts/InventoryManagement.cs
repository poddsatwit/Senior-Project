using System.Collections.Generic;

public class Inventory<T>
{
    private List<T> items;

    public Inventory()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void RemoveItem(T item)
    {
        items.Remove(item);
    }

    public List<T> GetItems()
    {
        return new List<T>(items);
    }

    public override string ToString()
    {
        return $"Inventory: {string.Join(", ", items)}";
    }
}
