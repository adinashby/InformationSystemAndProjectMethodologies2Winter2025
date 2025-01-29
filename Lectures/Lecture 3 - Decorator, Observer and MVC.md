# **Lecture 3: Design Patterns - Decorator, Observer, and MVC**

## **Table of Contents**

1. [Decorator](#decorator)
   - [Decorator Example](#decorator-example)
   - [When to Use Decorator Pattern](#when-to-use-decorator-pattern)
2. [Observer Pattern](#observer-pattern)
   - [Observer Example in C#](#observer-example-in-c)
3. [Model-View-Controller (MVC) Pattern](#model-view-controller-mvc-pattern)
   - [MVC Example in C#](#mvc-example-in-c#)
   - [Advantages of MVC Architecture](#advantages-of-mvc-architecture)

---

## **Decorator**

The **Decorator** pattern allows you to add new responsibilities to an object dynamically without altering its structure. It is a structural pattern that uses composition over inheritance, which provides flexibility in adding functionalities to objects at runtime. This pattern is ideal for adding additional features or behaviors without the overhead of subclassing repeatedly.

### **Decorator Example**

In this example, we will model a **ChristmasTree** that can be decorated with various items like garlands, bubble lights, and a tree topper. Instead of subclassing the **ChristmasTree** each time a new decoration is added, we’ll use decorators to enhance the tree dynamically.

### **C# Implementation**

1. **ChristmasTree Interface**

   The **ChristmasTree** interface will define a method `decorate()` which will return a description of the tree's decoration.

```csharp
public interface IChristmasTree
{
    string Decorate();
}
```

2. **ChristmasTree Implementation**

   The concrete implementation of the **ChristmasTree** interface will represent the basic tree without any decorations.

```csharp
public class ChristmasTreeImpl : IChristmasTree
{
    public string Decorate()
    {
        return "Christmas tree";
    }
}
```

3. **TreeDecorator Abstract Class**

   The **TreeDecorator** class is an abstract class that implements the **IChristmasTree** interface. It holds a reference to another **IChristmasTree** object and delegates the `decorate()` method to it.

```csharp
public abstract class TreeDecorator : IChristmasTree
{
    private readonly IChristmasTree _tree;

    // Constructor to initialize the tree
    protected TreeDecorator(IChristmasTree tree)
    {
        _tree = tree;
    }

    public virtual string Decorate()
    {
        return _tree.Decorate(); // Delegate to the wrapped tree
    }
}
```

4. **Decorating Elements**

   Now, we’ll create concrete decorators like **BubbleLights** and **Garland** that extend **TreeDecorator** and modify the behavior of the `decorate()` method.

- **BubbleLights Decorator**: Adds bubble lights to the tree.

```csharp
public class BubbleLights : TreeDecorator
{
    public BubbleLights(IChristmasTree tree) : base(tree) { }

    public override string Decorate()
    {
        return base.Decorate() + " with Bubble Lights";  // Add Bubble Lights
    }
}
```

- **Garland Decorator**: Adds garland to the tree.

```csharp
public class Garland : TreeDecorator
{
    public Garland(IChristmasTree tree) : base(tree) { }

    public override string Decorate()
    {
        return base.Decorate() + " with Garland";  // Add Garland
    }
}
```

5. **Using the Decorators**

   Finally, we can create instances of **ChristmasTreeImpl** and apply decorators at runtime. This allows us to dynamically add decorations to the tree.

```csharp
public class Program
{
    public static void Main()
    {
        IChristmasTree tree1 = new Garland(new ChristmasTreeImpl());
        Console.WriteLine(tree1.Decorate()); // Output: Christmas tree with Garland

        IChristmasTree tree2 = new BubbleLights(new Garland(new Garland(new ChristmasTreeImpl())));
        Console.WriteLine(tree2.Decorate()); // Output: Christmas tree with Garland with Garland with Bubble Lights
    }
}
```

### **Expected Output:**

```plaintext
Christmas tree with Garland
Christmas tree with Garland with Garland with Bubble Lights
```

### **When to Use Decorator Pattern**

The **Decorator** pattern is useful in the following scenarios:

- **Enhancing or modifying the behavior** of a specific object without altering other objects of the same class.
- **Dynamically adding responsibilities** to an object at runtime, such as adding different kinds of decorations to a Christmas tree.
- **Avoiding subclassing**: Rather than creating a new subclass for each combination of behaviors, decorators provide a flexible way to add behavior.

#### **Advantages**:
- **Extensibility**: You can add new decorations to the tree or other objects without modifying their existing code.
- **Composability**: Multiple decorators can be applied in various combinations, making it easy to change or extend behavior.
- **Flexible**: You can apply decorations to individual objects without affecting the entire class.

## **Observer Pattern**

The **Observer Pattern** is a behavioral design pattern where one object (the observable) notifies multiple observers when its state changes. This is useful when you have a one-to-many dependency between objects. For example, a **NewsAgency** might notify different **NewsChannels** when there’s breaking news.

### **Observer Example in C#**

#### **Step 1: Define the Observable (NewsAgency)**

In this example, the **NewsAgency** is the observable, and it notifies its observers (channels) whenever the news updates.

```csharp
using System;
using System.Collections.Generic;

public class NewsAgency
{
    private string news;
    private List<IChannel> channels = new List<IChannel>();

    // Add observer
    public void AddObserver(IChannel channel)
    {
        channels.Add(channel);
    }

    // Remove observer
    public void RemoveObserver(IChannel channel)
    {
        channels.Remove(channel);
    }

    // Notify all observers when news updates
    public void SetNews(string news)
    {
        this.news = news;
        foreach (var channel in channels)
        {
            channel.Update(news);
        }
    }
}
```

#### **Step 2: Define the Observer Interface (Channel)**

Each **Channel** implements the **IChannel** interface and reacts to the news updates.

```csharp
public interface IChannel
{
    void Update(string news);
}

public class NewsChannel : IChannel
{
    private string news;

    public void Update(string news)
    {
        this.news = news;
        Console.WriteLine("NewsChannel received: " + this.news);
    }
}
```

#### **Step 3: Testing the Observer Pattern**

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        NewsAgency newsAgency = new NewsAgency();

        // Create observer channels
        NewsChannel channel1 = new NewsChannel();
        NewsChannel channel2 = new NewsChannel();

        // Register observers
        newsAgency.AddObserver(channel1);
        newsAgency.AddObserver(channel2);

        // Update news
        newsAgency.SetNews("Breaking news: Design Patterns in C#!");
    }
}
```

### **Output:**

```plaintext
NewsChannel received: Breaking news: Design Patterns in C#!
NewsChannel received: Breaking news: Design Patterns in C#!
```

The **NewsAgency** updates all registered **NewsChannel** observers when the news changes.

## **Model-View-Controller (MVC) Pattern**

The **MVC Pattern** is widely used for separating concerns in application development. It divides the application into three parts:
- **Model**: Holds the application data and logic.
- **View**: Displays the data (UI elements).
- **Controller**: Manages the flow of data between the model and view.

### **MVC Example in C#**

#### **Model (Employee)**

```csharp
public class Employee
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Department { get; set; }
}
```

#### **View (EmployeeView)**

```csharp
public class EmployeeView
{
    public void PrintEmployeeDetails(string name, string id, string department)
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Employee ID: {id}");
        Console.WriteLine($"Employee Department: {department}");
    }
}
```

#### **Controller (EmployeeController)**

```csharp
public class EmployeeController
{
    private Employee _model;
    private EmployeeView _view;

    public EmployeeController(Employee model, EmployeeView view)
    {
        _model = model;
        _view = view;
    }

    // Getters and Setters
    public string GetEmployeeName() => _model.Name;
    public void SetEmployeeName(string name) => _model.Name = name;

    public string GetEmployeeId() => _model.Id;
    public void SetEmployeeId(string id) => _model.Id = id;

    public string GetEmployeeDepartment() => _model.Department;
    public void SetEmployeeDepartment(string department) => _model.Department = department;

    // Update the view with the model data
    public void UpdateView()
    {
        _view.PrintEmployeeDetails(_model.Name, _model.Id, _model.Department);
    }
}
```

#### **Main Program to Test MVC Pattern**

```csharp
public class Program
{
    public static void Main()
    {
        // Creating the model (data)
        Employee employee = new Employee
        {
            Name = "John Doe",
            Id = "12345",
            Department = "Software Engineering"
        };

        // Creating the view (UI)
        EmployeeView view = new EmployeeView();

        // Creating the controller (bridge between model and view)
        EmployeeController controller = new EmployeeController(employee, view);

        // Display the initial details
        controller.UpdateView();

        // Updating the employee's data through the controller
        controller.SetEmployeeName("Jane Doe");
        controller.SetEmployeeId("67890");
        controller.SetEmployeeDepartment("Marketing");

        // Display updated details
        Console.WriteLine("\nAfter update:");
        controller.UpdateView();
    }
}
```

### **Output:**

```plaintext
Employee Details:
Name: John Doe
Employee ID: 12345
Employee Department: Software Engineering

After update:
Employee Details:
Name: Jane Doe
Employee ID: 67890
Employee Department: Marketing
```

### **Advantages of MVC Architecture**
- **Separation of Concerns**: Each layer has a distinct responsibility, making the code easier to maintain and test.
- **Flexibility**: You can modify the user interface without changing the underlying business logic (Model), and vice versa.
- **Parallel Development**: Developers can work on the Model, View, and Controller simultaneously.
- **Reusability**: The Model can be reused with different Views, enabling multiple UI options for the same data.