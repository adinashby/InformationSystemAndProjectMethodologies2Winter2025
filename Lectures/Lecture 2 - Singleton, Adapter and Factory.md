# Lecture 2: Design Patterns - Singleton, Adapter and Factory

## **Table of Contents**
1. [What is a Design Pattern?](#what-is-a-design-pattern)
2. [SOLID Principles](#solid-principles)
3. [Design Patterns for the Week](#design-patterns-for-the-week)
    - [Singleton](#singleton)
    - [Adapter](#adapter)
    - [Factory](#factory)

### **What is a Design Pattern?**
A **Design Pattern** is a general reusable solution to a commonly occurring problem in software design. It’s a proven solution that is applicable to many different scenarios in software development. Design patterns are not specific to a particular programming language and serve as templates to follow for common issues.

Design patterns provide:
- **Reusability**: The same solutions can be used across various situations.
- **Maintainability**: The codebase is easier to maintain when design patterns are used because the pattern defines a consistent structure.
- **Scalability**: It’s easier to scale software when following a pattern because changes can be made systematically.

### **SOLID Principles**
**SOLID** is a set of five design principles that guide object-oriented software design. These principles are widely accepted as best practices in the industry and aim to improve code readability, scalability, and maintainability.

1. **Single Responsibility Principle (SRP)**: A class should have only one reason to change, meaning it should only have one job or responsibility.
   
2. **Open/Closed Principle (OCP)**: Software entities should be open for extension but closed for modification. New functionality can be added by creating new classes, not modifying existing ones.

3. **Liskov Substitution Principle (LSP)**: Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.

4. **Interface Segregation Principle (ISP)**: Clients should not be forced to depend on interfaces they do not use.

5. **Dependency Inversion Principle (DIP)**: High-level modules should not depend on low-level modules. Both should depend on abstractions.

### **Design Patterns for the Week**

#### **Singleton Design Pattern**

In C#, Singleton is a design pattern that ensures that a class can only have one object.

To create a singleton class, a class must implement the following properties:

- Create a `private` constructor of the class to restrict object creation outside of the class.
- Create a `private` attribute of the class type that refers to the single object.
- Create a `public static` method that allows us to create and access the object we created. Inside the method, we will create a condition that restricts us from creating more than one object.

Singletons can be used while working with databases. They can be used to create a connection pool to access the database while reusing the same connection for all the clients. For example,

```cs
using System;

public class Database
{
    private static Database dbObject;

    // Private constructor to restrict object creation
    private Database() { }

    // Public static method to provide access to the singleton object
    public static Database GetInstance()
    {
        // Create the object if it's not already created
        if (dbObject == null)
        {
            dbObject = new Database();
        }

        // Returns the singleton object
        return dbObject;
    }

    public void GetConnection()
    {
        Console.WriteLine("You are now connected to the database.");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Database db1;

        // Refers to the only object of Database
        db1 = Database.GetInstance();

        db1.GetConnection();
    }
}
```

### **Adapter Design Pattern**

An Adapter pattern acts as a connector between two incompatible interfaces that otherwise cannot be connected directly. An Adapter wraps an existing class with a new interface so that it becomes compatible with the client’s interface.

The main motive behind using this pattern is to convert an existing interface into another interface that the client expects. It's usually implemented once the application is designed.

#### 1.3.1. Adapter Example

Consider a scenario in which there is an app that's developed in the US which returns the top speed of luxury cars in miles per hour (MPH). Now we need to use the same app for our client in the UK that wants the same results but in kilometers per hour (km/h).

To deal with this problem, we'll create an adapter which will convert the values and give us the desired results:

![](../Imgs/week_8_adapter_uml.png)

First, we'll create the original interface Movable which is supposed to return the speed of some luxury cars in miles per hour:

```cs
public interface IMovable
{
    // Returns speed in MPH
    double GetSpeed();
}
```

We'll now create one concrete implementation of this interface:

```cs
public class BugattiVeyron : IMovable
{
    public double GetSpeed()
    {
        return 268;  // Speed in MPH
    }
}
```

Now we'll create an adapter interface MovableAdapter that will be based on the same Movable class. It may be slightly modified to yield different results in different scenarios:

```cs
public interface IMovableAdapter
{
    // Returns speed in KM/H
    double GetSpeed();
}
```

The implementation of this interface will consist of private method convertMPHtoKMPH() that will be used for the conversion:

```cs
public class MovableAdapterImpl : IMovableAdapter
{
    private readonly IMovable luxuryCars;

    public MovableAdapterImpl(IMovable movable)
    {
        luxuryCars = movable;
    }

    public double GetSpeed()
    {
        return ConvertMPHtoKMPH(luxuryCars.GetSpeed());
    }

    private double ConvertMPHtoKMPH(double mph)
    {
        return mph * 1.60934;  // Convert MPH to KM/H
    }
}
```

Now we'll only use the methods defined in our Adapter, and we'll get the converted speeds. In this case, the following assertion will be true:

```cs
class MainClass
{
    public static void Main(string[] args)
    {
        IMovable bugattiVeyron = new BugattiVeyron();
        IMovableAdapter bugattiVeyronAdapter = new MovableAdapterImpl(bugattiVeyron);

        // Get the converted speed (from MPH to KM/H)
        Console.WriteLine("Speed in KM/H: " + bugattiVeyronAdapter.GetSpeed());
    }
}
```

As we can notice here, our adapter converts 268 mph to 431 km/h for this particular case.

#### 1.3.2. When to Use Adapter Pattern

- When an outside component provides captivating functionality that we'd like to reuse, but it's incompatible with our current application. A suitable Adapter can be developed to make them compatible with each other
- When our application is not compatible with the interface that our client is expecting
- When we want to reuse legacy code in our application without making any modification in the original code

### **Factory Design Pattern**

The Factory Design Pattern or Factory Method Design Pattern is one of the most used design patterns in C#.

According to GoF, this pattern “defines an interface for creating an object, but let subclasses decide which class to instantiate. The Factory method lets a class defer instantiation to subclasses”.

This pattern delegates the responsibility of initializing a class from the client to a particular factory class by creating a type of virtual constructor.

To achieve this, we rely on a factory which provides us with the objects, hiding the actual implementation details. The created objects are accessed using a common interface.

#### 1.4.1. Factory Example

In this example, we'll create a Polygon interface which will be implemented by several concrete classes. A PolygonFactory will be used to fetch objects from this family:

![](../Imgs/week_8_factory_uml.png)

Let's first create the Polygon interface:

```cs
public interface IPolygon
{
    string GetType();
}
```

Next, we'll create a few implementations like Square, Triangle, etc. that implement this interface and return an object of Polygon type.

Now we can create a factory that takes the number of sides as an argument and returns the appropriate implementation of this interface:

```cs
public class Triangle : IPolygon
{
    public string GetType()
    {
        return "Triangle";
    }
}

public class Square : IPolygon
{
    public string GetType()
    {
        return "Square";
    }
}

public class Pentagon : IPolygon
{
    public string GetType()
    {
        return "Pentagon";
    }
}

public class Heptagon : IPolygon
{
    public string GetType()
    {
        return "Heptagon";
    }
}

public class Octagon : IPolygon
{
    public string GetType()
    {
        return "Octagon";
    }
}
```

```cs
public class PolygonFactory
{
    public IPolygon GetPolygon(int numberOfSides)
    {
        if (numberOfSides == 3)
        {
            return new Triangle();
        }
        if (numberOfSides == 4)
        {
            return new Square();
        }
        if (numberOfSides == 5)
        {
            return new Pentagon();
        }
        if (numberOfSides == 7)
        {
            return new Heptagon();
        }
        else if (numberOfSides == 8)
        {
            return new Octagon();
        }
        return null;
    }
}
```

```cs
class MainClass
{
    public static void Main(string[] args)
    {
        PolygonFactory factory = new PolygonFactory();

        IPolygon polygon1 = factory.GetPolygon(3);
        Console.WriteLine("Polygon type: " + polygon1.GetType());

        IPolygon polygon2 = factory.GetPolygon(4);
        Console.WriteLine("Polygon type: " + polygon2.GetType());
    }
}
```

Notice how the client can rely on this factory to give us an appropriate Polygon, without having to initialize the object directly.

#### 1.4.2. When to Use Factory Pattern

- When the implementation of an interface or an abstract class is expected to change frequently
- When the current implementation cannot comfortably accommodate new change
- When the initialization process is relatively simple, and the constructor only requires a handful of parameters
