# **Lecture 7: Design Patterns - Bridge, Proxy and Flyweight**

## Table of Contents
1. [Bridge Pattern](#bridge-pattern)
   - [Key Components of the Bridge Pattern](#key-components-of-the-bridge-pattern)
   - [When to Use the Bridge Pattern](#when-to-use-the-bridge-pattern)
2. [Proxy Pattern](#proxy-pattern)
   - [Key Components of the Proxy Pattern](#key-components-of-the-proxy-pattern)
   - [When to Use the Proxy Pattern](#when-to-use-the-proxy-pattern)
3. [Flyweight Pattern](#flyweight-pattern)
   - [Key Components of the Flyweight Pattern](#key-components-of-the-flyweight-pattern)
   - [When to Use the Flyweight Pattern](#when-to-use-the-flyweight-pattern)

## **Bridge Pattern**  

The **Bridge** design pattern is a **structural pattern** that decouples an abstraction from its implementation, allowing both to be developed independently. It is useful for situations where an abstraction needs to work with multiple implementations dynamically.

### Key Components of the Bridge Pattern
1. **Implementation Interface**: Defines a common interface for all implementation classes.
2. **Concrete Implementations**: Implement the details defined in the interface.
3. **Abstraction**: Maintains a reference to an implementation object and delegates operations to it.
4. **Refined Abstraction**: Extends the abstraction with additional functionality.

## When to Use the Bridge Pattern
- When an abstraction needs to be decoupled from its implementation.
- When different implementations need to be interchangeable.
- When extending both abstraction and implementation independently is required.

## Example: Implementing the Bridge Pattern in C#

### Step 1: Define the Implementation Interface
```csharp
// Implementation Interface
public interface IRenderer
{
    void RenderShape(string shape);
}
```

### Step 2: Implement Concrete Implementations
```csharp
// Concrete Implementation A
public class VectorRenderer : IRenderer
{
    public void RenderShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " as vectors.");
    }
}

// Concrete Implementation B
public class RasterRenderer : IRenderer
{
    public void RenderShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " as pixels.");
    }
}
```

### Step 3: Create the Abstraction Class
```csharp
// Abstraction
public abstract class Shape
{
    protected IRenderer _renderer;

    public Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }
    
    public abstract void Draw();
}
```

### Step 4: Implement Refined Abstraction
```csharp
// Refined Abstraction
public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) {}
    
    public override void Draw()
    {
        _renderer.RenderShape("Circle");
    }
}
```

### Step 5: Demonstrate the Bridge Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle1 = new Circle(vectorRenderer);
        Shape circle2 = new Circle(rasterRenderer);
        
        circle1.Draw(); // Draws using vector rendering
        circle2.Draw(); // Draws using raster rendering
    }
}
```

### Output
```
Drawing Circle as vectors.
Drawing Circle as pixels.
```

### Conclusion
The **Bridge Pattern** provides a flexible way to separate an abstraction from its implementation, promoting maintainability and scalability.

#### Advantages
- Decouples abstraction from implementation.
- Enhances flexibility by allowing independent extension of both components.
- Promotes cleaner and more organized code.

#### Disadvantages
- Increases complexity due to additional abstraction layers.
- Requires careful design to ensure proper separation.

By using the **Bridge Pattern**, developers can create scalable applications where abstractions and implementations can evolve independently.

## **Proxy Pattern** 

The **Proxy** design pattern is a **structural pattern** that provides a surrogate or placeholder for another object to control access to it. It is commonly used for **lazy initialization, access control, logging, or security mechanisms**.

### Key Components of the Proxy Pattern
1. **Subject Interface**: Defines the common interface for the real object and the proxy.
2. **Real Subject**: Implements the actual functionality.
3. **Proxy**: Acts as an intermediary and controls access to the real subject.

## When to Use the Proxy Pattern
- When adding additional control over object access is needed (e.g., security, logging, caching).
- When dealing with expensive object creation (lazy loading).
- When working with remote objects (remote proxies).

## Example: Implementing the Proxy Pattern in C#

### Step 1: Define the Subject Interface
```csharp
// Subject Interface
public interface ISubject
{
    void Request();
}
```

### Step 2: Implement the Real Subject
```csharp
// Real Subject
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}
```

### Step 3: Implement the Proxy Class
```csharp
// Proxy
public class Proxy : ISubject
{
    private RealSubject _realSubject;
    
    public void Request()
    {
        if (_realSubject == null)
        {
            _realSubject = new RealSubject();
        }
        Console.WriteLine("Proxy: Logging Request before forwarding to RealSubject.");
        _realSubject.Request();
    }
}
```

### Step 4: Demonstrate the Proxy Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        ISubject proxy = new Proxy();
        proxy.Request(); // Logs request and forwards to RealSubject
    }
}
```

### Output
```
Proxy: Logging Request before forwarding to RealSubject.
RealSubject: Handling Request.
```

### Conclusion
The **Proxy Pattern** provides a way to control access to objects, improving security, logging, and performance optimizations such as lazy initialization.

#### Advantages
- Enhances security by controlling object access.
- Supports lazy initialization and optimizes resource usage.
- Allows logging, caching, and access control without modifying the real subject.

#### Disadvantages
- Increases complexity due to additional classes.
- Can introduce performance overhead if overused.

By using the **Proxy Pattern**, developers can implement **efficient and controlled access** to objects while **maintaining flexibility and extensibility** in their applications.

## **Flyweight Pattern**  

The **Flyweight** design pattern is a **structural pattern** that reduces memory usage by sharing large numbers of similar objects. It is particularly useful when an application uses a large number of objects that share common data.

### Key Components of the Flyweight Pattern
1. **Flyweight Interface**: Defines operations that can be shared across objects.
2. **Concrete Flyweight**: Implements the shared state.
3. **Flyweight Factory**: Manages flyweight objects to ensure reusability.
4. **Client**: Uses the flyweight objects.

## When to Use the Flyweight Pattern
- When an application requires a large number of similar objects.
- When object creation consumes significant memory.
- When objects share common data that can be extracted and stored separately.

## Example: Implementing the Flyweight Pattern in C#

### Step 1: Define the Flyweight Interface
```csharp
// Flyweight Interface
public interface IShape
{
    void Draw(string color);
}
```

### Step 2: Implement Concrete Flyweight
```csharp
// Concrete Flyweight
public class Circle : IShape
{
    private readonly string _shapeType = "Circle";
    
    public void Draw(string color)
    {
        Console.WriteLine($"Drawing a {_shapeType} with color {color}");
    }
}
```

### Step 3: Create the Flyweight Factory
```csharp
// Flyweight Factory
public class ShapeFactory
{
    private static readonly Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();
    
    public static IShape GetShape(string shapeType)
    {
        if (!_shapes.ContainsKey(shapeType))
        {
            _shapes[shapeType] = new Circle();
            Console.WriteLine("Creating new Circle object");
        }
        return _shapes[shapeType];
    }
}
```

### Step 4: Demonstrate the Flyweight Pattern in Action
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        IShape shape1 = ShapeFactory.GetShape("Circle");
        shape1.Draw("Red");
        
        IShape shape2 = ShapeFactory.GetShape("Circle");
        shape2.Draw("Blue");
        
        IShape shape3 = ShapeFactory.GetShape("Circle");
        shape3.Draw("Green");
    }
}
```

### Output
```
Creating new Circle object
Drawing a Circle with color Red
Drawing a Circle with color Blue
Drawing a Circle with color Green
```

### Conclusion
The **Flyweight Pattern** optimizes memory usage by sharing instances of similar objects instead of creating new ones. It is ideal for applications dealing with large numbers of similar objects.

#### Advantages
- Reduces memory consumption by reusing objects.
- Improves application performance by minimizing object creation overhead.
- Encourages better separation of intrinsic and extrinsic state.

#### Disadvantages
- Increased complexity due to the need for a factory and shared objects.
- Not useful when object state varies significantly.

By using the **Flyweight Pattern**, developers can build **efficient and memory-optimized applications** while reducing unnecessary object creation.

