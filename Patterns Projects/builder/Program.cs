// Product Class
public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
    public string PartC { get; set; }

    public void Show()
    {
        Console.WriteLine($"Product Parts: {PartA}, {PartB}, {PartC}");
    }
}

// Builder Interface
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}

// Concrete Builder
public class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();

    public void BuildPartA()
    {
        _product.PartA = "Part A built";
    }

    public void BuildPartB()
    {
        _product.PartB = "Part B built";
    }

    public void BuildPartC()
    {
        _product.PartC = "Part C built";
    }

    public Product GetResult()
    {
        return _product;
    }
}

// Director
public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}

class Program
{
    static void Main()
    {
        Director director = new Director();
        IBuilder builder = new ConcreteBuilder();
        
        director.Construct(builder);
        Product product = builder.GetResult();
        product.Show();
    }
}