# **Lecture 5: Design Patterns - Iterator, Command and Template Method**

## Table of Contents
1. [Iterator Pattern](#iterator-pattern)
   - [Key Components of the Iterator Pattern](#key-components-of-the-iterator-pattern)
   - [When to Use the Iterator Pattern](#when-to-use-the-iterator-pattern)
2. [Command Pattern](#command-pattern)
   - [Key Components of the Command Pattern](#key-components-of-the-command-pattern)
   - [When to Use the Command Pattern](#when-to-use-the-command-pattern)
3. [Template Method Pattern](#template-method-pattern)
   - [Key Components of the Template Method Pattern](#key-components-of-the-template-method-pattern)
   - [When to Use the Template Method Pattern](#when-to-use-the-template-method-pattern)

## **Iterator Pattern**  

The **Iterator** design pattern is a **behavioral pattern** that allows sequential access to elements of a collection without exposing the underlying structure. It is particularly useful for traversing collections such as lists, trees, or graphs in a consistent manner.

### Key Components of the Iterator Pattern
1. **Iterator Interface**: Defines methods for traversing elements.
2. **Concrete Iterator**: Implements the traversal logic.
3. **Aggregate Interface**: Defines a collection that provides an iterator.
4. **Concrete Aggregate**: Implements the collection that returns an iterator.

## When to Use the Iterator Pattern
- When you need to traverse a collection without exposing its underlying representation.
- When multiple types of traversals are required for a collection.
- When you want to provide a uniform way to iterate over different data structures.

## Example: Implementing the Iterator Pattern in C#

### Step 1: Define the Iterator Interface
```csharp
// Iterator Interface
public interface IIterator
{
    bool HasNext();
    object Next();
}
```

### Step 2: Implement Concrete Iterator Class
```csharp
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
```

### Step 3: Create the Aggregate Interface
```csharp
// Aggregate Interface
public interface IAggregate
{
    IIterator CreateIterator();
}
```

### Step 4: Implement Concrete Aggregate Class
```csharp
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
```

### Step 5: Demonstrate the Iterator Pattern in Action
```csharp
using System;
using System.Collections.Generic;

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
```

### Output
```
Item 1
Item 2
Item 3
```

### Conclusion
The **Iterator Pattern** provides a uniform way to traverse collections without exposing their underlying details. It is widely used in frameworks and libraries to iterate over collections in a consistent manner.

#### Advantages
- Simplifies traversal of complex collections.
- Decouples iteration logic from the collection.
- Supports multiple traversals without modifying the collection.

#### Disadvantages
- Adds extra complexity with additional classes.
- May introduce performance overhead if not implemented efficiently.

By using the **Iterator Pattern**, developers can traverse collections in a flexible and structured way while keeping the internal representation hidden.

## **Command Pattern** 

The **Command** design pattern is a **behavioral pattern** that encapsulates a request as an object, allowing parameterization and queuing of requests. This pattern is useful for implementing undo/redo functionality and decoupling sender and receiver objects.

### Key Components of the Command Pattern
1. **Command Interface**: Defines the method to execute a command.
2. **Concrete Commands**: Implement specific actions by delegating to a receiver.
3. **Receiver**: The object that performs the actual operation.
4. **Invoker**: Stores and invokes commands.
5. **Client**: Creates and assigns commands to an invoker.

## When to Use the Command Pattern
- When you need to encapsulate requests as objects.
- When implementing undo/redo functionality.
- When logging operations or executing requests at a later time.

## Example: Implementing the Command Pattern in C#

### Step 1: Define the Command Interface
```csharp
// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}
```

### Step 2: Implement Concrete Command Classes
```csharp
// Concrete Command
public class LightOnCommand : ICommand
{
    private Light _light;
    
    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}
```

### Step 3: Create the Receiver Class
```csharp
// Receiver
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}
```

### Step 4: Implement the Invoker Class
```csharp
// Invoker
public class RemoteControl
{
    private ICommand _command;
    
    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    
    public void PressButton()
    {
        _command.Execute();
    }
    
    public void PressUndo()
    {
        _command.Undo();
    }
}
```

### Step 5: Demonstrate the Command Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        Light light = new Light();
        ICommand lightOn = new LightOnCommand(light);
        
        RemoteControl remote = new RemoteControl();
        remote.SetCommand(lightOn);
        
        remote.PressButton(); // Turns on the light
        remote.PressUndo(); // Turns off the light
    }
}
```

### Output
```
Light is ON
Light is OFF
```

### Conclusion
The **Command Pattern** provides a flexible way to encapsulate actions as objects, allowing for better decoupling, undo/redo functionality, and request queuing.

#### Advantages
- Decouples sender and receiver.
- Supports undo/redo functionality.
- Allows queuing and logging of commands.

#### Disadvantages
- Can introduce complexity with multiple command classes.
- Requires careful management of command objects.

By using the **Command Pattern**, developers can create flexible and extensible applications with decoupled command execution mechanisms.

## **Template Pattern**

The **Template Method** design pattern is a **behavioral pattern** that defines the skeleton of an algorithm in a base class but allows subclasses to override specific steps without changing the structure of the algorithm itself.

### Key Components of the Template Method Pattern
1. **Abstract Class**: Defines the template method that outlines the algorithm steps.
2. **Concrete Classes**: Implement the specific details of certain steps defined in the abstract class.

## When to Use the Template Method Pattern
- When you need to enforce a sequence of steps but allow customization in some steps.
- When multiple classes share a similar algorithm but have variations in specific steps.
- When reducing code duplication by placing common behavior in a base class.

## Example: Implementing the Template Method Pattern in C#

### Step 1: Define the Abstract Class
```csharp
// Abstract Class
public abstract class DataProcessor
{
    public void ProcessData()
    {
        ReadData();
        Process();
        SaveData();
    }

    protected abstract void ReadData();
    protected abstract void Process();
    protected abstract void SaveData();
}
```

### Step 2: Implement Concrete Classes
```csharp
// Concrete Class A
public class CSVDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from CSV file");
    }
    
    protected override void Process()
    {
        Console.WriteLine("Processing CSV data");
    }
    
    protected override void SaveData()
    {
        Console.WriteLine("Saving processed CSV data");
    }
}

// Concrete Class B
public class JSONDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from JSON file");
    }
    
    protected override void Process()
    {
        Console.WriteLine("Processing JSON data");
    }
    
    protected override void SaveData()
    {
        Console.WriteLine("Saving processed JSON data");
    }
}
```

### Step 3: Demonstrate the Template Method Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        DataProcessor csvProcessor = new CSVDataProcessor();
        csvProcessor.ProcessData();

        Console.WriteLine();

        DataProcessor jsonProcessor = new JSONDataProcessor();
        jsonProcessor.ProcessData();
    }
}
```

### Output
```
Reading data from CSV file
Processing CSV data
Saving processed CSV data

Reading data from JSON file
Processing JSON data
Saving processed JSON data
```

### Conclusion
The **Template Method Pattern** provides a structured approach to defining an algorithm with flexible implementation details, promoting code reuse and enforcing a consistent workflow.

#### Advantages
- Reduces code duplication by placing common behavior in a base class.
- Enforces a defined sequence of steps.
- Makes algorithms more maintainable and extensible.

#### Disadvantages
- Can be difficult to refactor if the base class grows too complex.
- Requires careful design to avoid violating the **Liskov Substitution Principle**.

By using the **Template Method Pattern**, developers can create reusable and maintainable algorithms that allow for controlled variations in specific steps.
