// Prototype Interface
public interface IPrototype
{
    IPrototype Clone();
}

// Concrete Prototype
public class ConcretePrototype : IPrototype
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public ConcretePrototype(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public IPrototype Clone()
    {
        return new ConcretePrototype(Name, Age);
    }
    
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        ConcretePrototype prototype1 = new ConcretePrototype("John", 25);
        ConcretePrototype clonedPrototype = (ConcretePrototype)prototype1.Clone();
        
        clonedPrototype.Name = "Jane";
        clonedPrototype.Age = 30;
        
        prototype1.Display();
        clonedPrototype.Display();
    }
}