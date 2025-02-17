// Visitor Interface
public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}

// Concrete Visitor 1
public class ConcreteVisitor1 : IVisitor
{
    public void Visit(ElementA element)
    {
        Console.WriteLine("ConcreteVisitor1 processing ElementA");
    }

    public void Visit(ElementB element)
    {
        Console.WriteLine("ConcreteVisitor1 processing ElementB");
    }
}

// Concrete Visitor 2
public class ConcreteVisitor2 : IVisitor
{
    public void Visit(ElementA element)
    {
        Console.WriteLine("ConcreteVisitor2 processing ElementA");
    }

    public void Visit(ElementB element)
    {
        Console.WriteLine("ConcreteVisitor2 processing ElementB");
    }
}

// Element Interface
public abstract class Element
{
    public abstract void Accept(IVisitor visitor);
}

// Concrete Element A
public class ElementA : Element
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Concrete Element B
public class ElementB : Element
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Program
{
    static void Main()
    {
        List<Element> elements = new List<Element> { new ElementA(), new ElementB() };
        
        IVisitor visitor1 = new ConcreteVisitor1();
        IVisitor visitor2 = new ConcreteVisitor2();

        foreach (var element in elements)
        {
            element.Accept(visitor1);
            element.Accept(visitor2);
        }
    }
}