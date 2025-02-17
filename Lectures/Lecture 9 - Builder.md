# **Lecture 9: Design Patterns - Builder**

1. [Builder Pattern](#builder-pattern)
   - [Key Components of the Builder Pattern](#key-components-of-the-builder-pattern)
   - [When to Use the Builder Pattern](#when-to-use-the-builder-pattern)

## **Builder Pattern**

The **Builder** design pattern is a **creational pattern** that provides a way to construct complex objects step by step. It allows creating different representations of an object using the same building process.

### Key Components of the Builder Pattern
1. **Product**: The complex object that needs to be built.
2. **Builder Interface**: Defines the steps for building the product.
3. **Concrete Builders**: Implement the steps defined in the builder interface.
4. **Director**: Guides the construction process and ensures object consistency.

## When to Use the Builder Pattern
- When dealing with complex object creation with multiple configurations.
- When needing to create different variations of an object using the same construction process.
- When simplifying the instantiation of objects by separating construction logic.

## Example: Implementing the Builder Pattern in C#

### Step 1: Define the Product Class
```csharp
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
```

### Step 2: Create the Builder Interface
```csharp
// Builder Interface
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}
```

### Step 3: Implement Concrete Builders
```csharp
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
```

### Step 4: Create the Director Class
```csharp
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
```

### Step 5: Demonstrate the Builder Pattern in Action
```csharp
using System;

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
```

### Output
```
Product Parts: Part A built, Part B built, Part C built
```

### Conclusion
The **Builder Pattern** provides a flexible approach to constructing complex objects step by step. It ensures a clear separation between object representation and creation process.

#### Advantages
- Allows controlled step-by-step object construction.
- Supports different object variations without altering the construction logic.
- Improves code readability and maintainability.

#### Disadvantages
- Increases complexity by introducing additional classes.
- Requires a dedicated builder class for each object type.

By using the **Builder Pattern**, developers can create **scalable and flexible** applications that manage complex object creation effectively.

