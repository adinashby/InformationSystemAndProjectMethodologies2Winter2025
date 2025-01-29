public interface IChristmasTree
{
    string Decorate();
}

public class ChristmasTreeImpl : IChristmasTree
{
    public string Decorate()
    {
        return "Christmas tree";
    }
}

public abstract class TreeDecorator : IChristmasTree
{
    private readonly IChristmasTree _tree;

    // Constructor to initialize the tree
    protected TreeDecorator(IChristmasTree tree)
    {
        _tree = tree;
    }

    public virtual string Decorate()
    {
        return _tree.Decorate(); // Delegate to the wrapped tree
    }
}

public class BubbleLights : TreeDecorator
{
    public BubbleLights(IChristmasTree tree) : base(tree) { }

    public override string Decorate()
    {
        return base.Decorate() + " with Bubble Lights";  // Add Bubble Lights
    }
}

public class Garland : TreeDecorator
{
    public Garland(IChristmasTree tree) : base(tree) { }

    public override string Decorate()
    {
        return base.Decorate() + " with Garland";  // Add Garland
    }
}

public class Program
{
    public static void Main()
    {
        IChristmasTree tree1 = new Garland(new ChristmasTreeImpl());
        Console.WriteLine(tree1.Decorate()); // Output: Christmas tree with Garland

        IChristmasTree tree2 = new BubbleLights(new Garland(new Garland(new ChristmasTreeImpl())));
        Console.WriteLine(tree2.Decorate()); // Output: Christmas tree with Garland with Garland with Bubble Lights
    }
}