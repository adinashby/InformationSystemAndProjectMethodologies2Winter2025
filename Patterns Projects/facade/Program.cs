// Subsystem 1
public class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("SubsystemA: Operation A");
    }
}

// Subsystem 2
public class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("SubsystemB: Operation B");
    }
}

// Subsystem 3
public class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("SubsystemC: Operation C");
    }
}

// Façade
public class Facade
{
    private SubsystemA _subsystemA;
    private SubsystemB _subsystemB;
    private SubsystemC _subsystemC;

    public Facade()
    {
        _subsystemA = new SubsystemA();
        _subsystemB = new SubsystemB();
        _subsystemC = new SubsystemC();
    }

    public void PerformOperation()
    {
        Console.WriteLine("Facade orchestrating subsystem operations:");
        _subsystemA.OperationA();
        _subsystemB.OperationB();
        _subsystemC.OperationC();
    }
}

class Program
{
    static void Main()
    {
        Facade facade = new Facade();
        facade.PerformOperation();
    }
}