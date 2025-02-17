// Strategy Interface
public interface IStrategy
{
    void Execute();
}

// Concrete Strategy A
public class StrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy A");
    }
}

// Concrete Strategy B
public class StrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy B");
    }
}

// Context Class
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}

class Program
{
    static void Main()
    {
        Context context = new Context(new StrategyA());
        context.ExecuteStrategy(); // Executes Strategy A
        
        context.SetStrategy(new StrategyB());
        context.ExecuteStrategy(); // Executes Strategy B
    }
}