# **Lecture 8: Design Patterns - Façade, Prototype and Factory Method**

1. [Façade Pattern](#façade-pattern)
   - [Key Components of the Façade Pattern](#key-components-of-the-façade-pattern)
   - [When to Use the Façade Pattern](#when-to-use-the-façade-pattern)
2. [Prototype Pattern](#prototype-pattern)
   - [Key Components of the Prototype Pattern](#key-components-of-the-prototype-pattern)
   - [When to Use the Prototype Pattern](#when-to-use-the-prototype-pattern)
3. [Factory Method Pattern](#factory-method-pattern)
   - [Key Components of the Factory Method Pattern](#key-components-of-the-factory-method-pattern)
   - [When to Use the Factory Method Pattern](#when-to-use-the-factory-method-pattern)

## **Façade Pattern**

The **Façade** design pattern is a **structural pattern** that provides a simplified interface to a complex subsystem. It helps clients interact with a system by offering a unified and easier-to-use API.

### Key Components of the Façade Pattern
1. **Façade**: A high-level class that provides a simple interface to interact with complex subsystems.
2. **Subsystems**: Multiple classes that handle detailed system operations.
3. **Client**: Uses the Façade to interact with subsystems without needing to know their complexity.

## When to Use the Façade Pattern
- When simplifying interactions with complex subsystems.
- When reducing dependencies between clients and subsystems.
- When providing a uniform interface for multiple related components.

## Example: Implementing the Façade Pattern in C#

### Step 1: Define Subsystems
```csharp
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
```

### Step 2: Create the Façade Class
```csharp
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
```

### Step 3: Demonstrate the Façade Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        Facade facade = new Facade();
        facade.PerformOperation();
    }
}
```

### Output
```
Facade orchestrating subsystem operations:
SubsystemA: Operation A
SubsystemB: Operation B
SubsystemC: Operation C
```

### Conclusion
The **Façade Pattern** simplifies complex systems by providing a single, easy-to-use interface. It promotes better code maintainability and reduces dependencies between clients and subsystems.

#### Advantages
- Simplifies client interactions with complex systems.
- Reduces dependencies by decoupling clients from subsystem details.
- Improves code maintainability and readability.

#### Disadvantages
- May introduce unnecessary complexity if the subsystem is already simple.
- Can become a maintenance challenge if too many responsibilities are placed on the Façade.

By using the **Façade Pattern**, developers can create **more manageable and scalable** applications while hiding the complexity of underlying systems.

## **Prototype Pattern**

The **Prototype** design pattern is a **creational pattern** that allows objects to be cloned, avoiding the overhead of creating new instances from scratch. It is particularly useful when object creation is expensive.

### Key Components of the Prototype Pattern
1. **Prototype Interface**: Defines a method for cloning objects.
2. **Concrete Prototype**: Implements the cloning method.
3. **Client**: Uses the prototype to create new objects.

## When to Use the Prototype Pattern
- When object creation is expensive and should be minimized.
- When new instances should be created dynamically at runtime.
- When avoiding subclassing for object creation.

## Example: Implementing the Prototype Pattern in C#

### Step 1: Define the Prototype Interface
```csharp
// Prototype Interface
public interface IPrototype
{
    IPrototype Clone();
}
```

### Step 2: Implement Concrete Prototype Classes
```csharp
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
```

### Step 3: Demonstrate the Prototype Pattern in Action
```csharp
using System;

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
```

### Output
```
Name: John, Age: 25
Name: Jane, Age: 30
```

### Conclusion
The **Prototype Pattern** simplifies object creation by cloning existing instances, reducing the cost of new object instantiation.

#### Advantages
- Reduces overhead by reusing existing objects.
- Enables dynamic object creation at runtime.
- Eliminates the need for subclassing in certain cases.

#### Disadvantages
- Cloning may introduce deep/shallow copy complexity.
- Not suitable for all object types, especially those with complex dependencies.

By using the **Prototype Pattern**, developers can **efficiently create new objects** while optimizing performance and memory usage.

## **Factory Method Pattern**

The **Factory Method** design pattern is a **creational pattern** that provides an interface for creating objects, allowing subclasses to alter the type of objects that will be created. It promotes loose coupling by delegating object creation to factory classes.

### Key Components of the Factory Method Pattern
1. **Product Interface**: Defines a common interface for all products.
2. **Concrete Products**: Implement the product interface.
3. **Factory Interface**: Declares the factory method for creating objects.
4. **Concrete Factories**: Implement the factory method to create specific product types.

## When to Use the Factory Method Pattern
- When the exact type of objects to be created is determined at runtime.
- When promoting loose coupling by delegating object creation.
- When simplifying object instantiation and maintaining scalability.

## Example: Implementing the Factory Method Pattern in C#

### Step 1: Define the Product Interface
```csharp
// Product Interface
public interface IProduct
{
    void Display();
}
```

### Step 2: Implement Concrete Products
```csharp
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
```

### Step 3: Create the Factory Interface
```csharp
// Factory Interface
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}
```

### Step 4: Implement Concrete Factories
```csharp
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
```

### Step 5: Demonstrate the Factory Method Pattern in Action
```csharp
using System;

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
```

### Output
```
ConcreteProductA created
ConcreteProductB created
```

### Conclusion
The **Factory Method Pattern** promotes loose coupling and ensures flexibility in object creation. It allows clients to instantiate objects without specifying their exact types.

#### Advantages
- Promotes scalability by encapsulating object creation.
- Enhances code maintainability by reducing dependencies.
- Follows the Open/Closed Principle by allowing extension without modification.

#### Disadvantages
- Introduces extra classes and complexity.
- May lead to code duplication if not designed efficiently.

By using the **Factory Method Pattern**, developers can build **flexible and scalable** applications while maintaining clean code architecture.
