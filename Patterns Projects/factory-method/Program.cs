// Product Interface
public interface IProduct
{
    void Display();
}

// Concrete Product A
public class ConcreteProductA : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProductA created");
    }
}

// Concrete Product B
public class ConcreteProductB : IProduct
{
    public void Display()
    {
        Console.WriteLine("ConcreteProductB created");
    }
}

// Factory Interface
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

// Concrete Factory A
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// Concrete Factory B
public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

class Program
{
    static void Main()
    {
        Creator factoryA = new ConcreteCreatorA();
        IProduct productA = factoryA.FactoryMethod();
        productA.Display();
        
        Creator factoryB = new ConcreteCreatorB();
        IProduct productB = factoryB.FactoryMethod();
        productB.Display();
    }
}