# **Lecture 6: Design Patterns - Mediator, Chain of Responsibility and Visitor**

## Table of Contents
1. [Mediator Pattern](#mediator-pattern)
   - [Key Components of the Mediator Pattern](#key-components-of-the-mediator-pattern)
   - [When to Use the Mediator Pattern](#when-to-use-the-mediator-pattern)
2. [Chain of Responsibility Pattern](#chain-of-responsibility-pattern)
   - [Key Components of the Chain of Responsibility Pattern](#key-components-of-the-chain-of-responsibility-pattern)
   - [When to Use the Chain of Responsibility Pattern](#when-to-use-the-chain-of-responsibility-pattern)
3. [Visitor Pattern](#visitor-pattern)
   - [Key Components of the Visitor Pattern](#key-components-of-the-visitor-pattern)
   - [When to Use the Visitor Pattern](#when-to-use-the-visitor-pattern)

## **Mediator Pattern**  

The **Mediator** design pattern is a **behavioral pattern** that facilitates communication between objects by centralizing interactions into a mediator object. This reduces dependencies and promotes loose coupling.

### Key Components of the Mediator Pattern
1. **Mediator Interface**: Defines the communication contract between colleagues.
2. **Concrete Mediator**: Implements communication between colleagues.
3. **Colleague Classes**: Represent the objects that communicate through the mediator.

## When to Use the Mediator Pattern
- When a system involves complex object interactions that should be simplified.
- When promoting loose coupling and centralizing control of interactions.
- When communication logic should be independent of colleague classes.

## Example: Implementing the Mediator Pattern in C#

### Step 1: Define the Mediator Interface
```csharp
// Mediator Interface
public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}
```

### Step 2: Implement Concrete Mediator
```csharp
// Concrete Mediator
public class ConcreteMediator : IMediator
{
    private ColleagueA _colleagueA;
    private ColleagueB _colleagueB;

    public void RegisterColleagueA(ColleagueA colleague)
    {
        _colleagueA = colleague;
    }

    public void RegisterColleagueB(ColleagueB colleague)
    {
        _colleagueB = colleague;
    }

    public void SendMessage(string message, Colleague colleague)
    {
        if (colleague == _colleagueA)
        {
            _colleagueB.ReceiveMessage(message);
        }
        else if (colleague == _colleagueB)
        {
            _colleagueA.ReceiveMessage(message);
        }
    }
}
```

### Step 3: Create the Colleague Classes
```csharp
// Base Colleague Class
public abstract class Colleague
{
    protected IMediator _mediator;

    public Colleague(IMediator mediator)
    {
        _mediator = mediator;
    }
}

// Concrete Colleague A
public class ColleagueA : Colleague
{
    public ColleagueA(IMediator mediator) : base(mediator) {}
    
    public void Send(string message)
    {
        Console.WriteLine("Colleague A sends message: " + message);
        _mediator.SendMessage(message, this);
    }
    
    public void ReceiveMessage(string message)
    {
        Console.WriteLine("Colleague A received message: " + message);
    }
}

// Concrete Colleague B
public class ColleagueB : Colleague
{
    public ColleagueB(IMediator mediator) : base(mediator) {}
    
    public void Send(string message)
    {
        Console.WriteLine("Colleague B sends message: " + message);
        _mediator.SendMessage(message, this);
    }
    
    public void ReceiveMessage(string message)
    {
        Console.WriteLine("Colleague B received message: " + message);
    }
}
```

### Step 4: Demonstrate the Mediator Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        ConcreteMediator mediator = new ConcreteMediator();

        ColleagueA colleagueA = new ColleagueA(mediator);
        ColleagueB colleagueB = new ColleagueB(mediator);

        mediator.RegisterColleagueA(colleagueA);
        mediator.RegisterColleagueB(colleagueB);

        colleagueA.Send("Hello from A!");
        colleagueB.Send("Hello from B!");
    }
}
```

### Output
```
Colleague A sends message: Hello from A!
Colleague B received message: Hello from A!
Colleague B sends message: Hello from B!
Colleague A received message: Hello from B!
```

### Conclusion
The **Mediator Pattern** centralizes object interactions, reducing dependencies and making communication management easier.

#### Advantages
- Reduces coupling between communicating objects.
- Simplifies object interaction by centralizing communication logic.
- Enhances code maintainability.

#### Disadvantages
- Can introduce a single point of failure if the mediator becomes too complex.
- Increases the complexity of the mediator when handling numerous interactions.

By using the **Mediator Pattern**, developers can design systems where objects interact efficiently while remaining loosely coupled.

## **Chain of Responsibility Pattern**  

The **Chain of Responsibility** design pattern is a **behavioral pattern** that allows multiple objects to handle a request without the sender needing to know which object will handle it. The request is passed along a chain of handlers until it is processed.

### Key Components of the Chain of Responsibility Pattern
1. **Handler Interface**: Defines the method for handling requests and setting the next handler.
2. **Concrete Handlers**: Implement request handling and decide whether to pass the request along the chain.
3. **Client**: Initiates requests without needing to know which handler will process them.

## When to Use the Chain of Responsibility Pattern
- When multiple objects can handle a request but only one should process it.
- When requests must be processed in a predefined sequence.
- When decoupling request senders and receivers is needed.

## Example: Implementing the Chain of Responsibility Pattern in C#

### Step 1: Define the Handler Interface
```csharp
// Handler Interface
public abstract class Handler
{
    protected Handler _nextHandler;
    
    public void SetNext(Handler handler)
    {
        _nextHandler = handler;
    }
    
    public abstract void HandleRequest(int request);
}
```

### Step 2: Implement Concrete Handlers
```csharp
// Concrete Handler A
public class ConcreteHandlerA : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
        {
            Console.WriteLine("Handler A handled request: " + request);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

// Concrete Handler B
public class ConcreteHandlerB : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine("Handler B handled request: " + request);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

// Concrete Handler C
public class ConcreteHandlerC : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20)
        {
            Console.WriteLine("Handler C handled request: " + request);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}
```

### Step 3: Create the Client
```csharp
// Client Code
public class Client
{
    public static void Main()
    {
        Handler handlerA = new ConcreteHandlerA();
        Handler handlerB = new ConcreteHandlerB();
        Handler handlerC = new ConcreteHandlerC();

        handlerA.SetNext(handlerB);
        handlerB.SetNext(handlerC);

        int[] requests = { 5, 15, 25, 8, 18 };
        
        foreach (int request in requests)
        {
            handlerA.HandleRequest(request);
        }
    }
}
```

### Output
```
Handler A handled request: 5
Handler B handled request: 15
Handler C handled request: 25
Handler A handled request: 8
Handler B handled request: 18
```

### Conclusion
The **Chain of Responsibility Pattern** helps create a flexible and decoupled system where multiple handlers process a request in sequence.

#### Advantages
- Reduces coupling between sender and receiver.
- Enhances flexibility in assigning responsibility.
- Allows adding new handlers without modifying existing code.

#### Disadvantages
- Can introduce complexity if the chain is long.
- May lead to debugging challenges if requests pass through many handlers.

By using the **Chain of Responsibility Pattern**, developers can build maintainable and scalable applications that distribute request handling efficiently.

## **Visitor Pattern**

The **Visitor** design pattern is a **behavioral pattern** that allows adding further operations to objects without modifying their structure. It is useful when performing distinct operations on elements of a structure while keeping element classes unchanged.

### Key Components of the Visitor Pattern
1. **Visitor Interface**: Defines the operations that can be performed on elements.
2. **Concrete Visitors**: Implement specific operations on elements.
3. **Element Interface**: Defines an `Accept` method that allows a visitor to operate on it.
4. **Concrete Elements**: Implement the `Accept` method to allow visitors to process them.

## When to Use the Visitor Pattern
- When operations need to be performed on objects without modifying their structure.
- When new behaviors need to be added dynamically.
- When a structure contains many different element types with unique operations.

## Example: Implementing the Visitor Pattern in C#

### Step 1: Define the Visitor Interface
```csharp
// Visitor Interface
public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}
```

### Step 2: Implement Concrete Visitors
```csharp
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
```

### Step 3: Define the Element Interface
```csharp
// Element Interface
public abstract class Element
{
    public abstract void Accept(IVisitor visitor);
}
```

### Step 4: Implement Concrete Elements
```csharp
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
```

### Step 5: Demonstrate the Visitor Pattern in Action
```csharp
using System;
using System.Collections.Generic;

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
```

### Output
```
ConcreteVisitor1 processing ElementA
ConcreteVisitor1 processing ElementB
ConcreteVisitor2 processing ElementA
ConcreteVisitor2 processing ElementB
```

### Conclusion
The **Visitor Pattern** enables adding operations to existing object structures without modifying them. It is particularly useful when a system needs to support new operations without altering element classes.

#### Advantages
- Promotes open/closed principle by allowing operations to be added without modifying elements.
- Groups related behaviors into a single visitor class.
- Makes extending functionality easier.

#### Disadvantages
- Can increase complexity due to additional visitor classes.
- Breaks encapsulation as visitor objects require access to element internals.

By using the **Visitor Pattern**, developers can achieve flexible and scalable object-oriented designs with well-structured operations on elements.