// Iterator Interface
public interface IIterator
{
    bool HasNext();
    object Next();
}

// Concrete Iterator
public class ConcreteIterator : IIterator
{
    private List<string> _collection;
    private int _position = 0;

    public ConcreteIterator(List<string> collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _position < _collection.Count;
    }

    public object Next()
    {
        return HasNext() ? _collection[_position++] : null;
    }
}

// Aggregate Interface
public interface IAggregate
{
    IIterator CreateIterator();
}

// Concrete Aggregate
public class ConcreteAggregate : IAggregate
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(_items);
    }
}

class Program
{
    static void Main()
    {
        ConcreteAggregate collection = new ConcreteAggregate();
        collection.AddItem("Item 1");
        collection.AddItem("Item 2");
        collection.AddItem("Item 3");

        IIterator iterator = collection.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}