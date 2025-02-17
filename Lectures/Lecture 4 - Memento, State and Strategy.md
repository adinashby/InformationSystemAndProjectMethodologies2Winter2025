# **Lecture 4: Design Patterns - Memento, State, and Strategy**

## **Table of Contents**

1. [Memento Pattern](#memento-pattern)
   - [Key Components of the Memento Pattern](#key-components-of-the-memento-pattern)
   - [When to Use the Memento Pattern](#when-to-use-the-memento-pattern)
2. [State Pattern](#state-pattern)
   - [Key Components of the State Pattern](#key-components-of-the-state-pattern)
   - [When to Use the State Pattern](#when-to-use-the-state-pattern)
3. [Strategy Pattern](#strategy-pattern)
   - [Key Components of the Strategy Pattern](#key-components-of-the-strategy-pattern)
   - [When to Use the Strategy Pattern](#when-to-use-the-strategy-pattern)

---

## **Memento Pattern**  
The **Memento** design pattern is a **behavioral pattern** used to capture and restore an object's state without violating encapsulation. This pattern is useful when implementing features like undo/redo functionality in applications.

### Key Components of the Memento Pattern
1. **Originator**: The object that holds the state and can create and restore mementos.
2. **Memento**: A snapshot of the Originator’s state.
3. **Caretaker**: Manages the memento objects without modifying their contents.

## When to Use the Memento Pattern
- When you need to implement undo/redo functionality.
- When you want to capture an object's state periodically and restore it later.
- When direct access to an object's state violates encapsulation.

## Example: Implementing the Memento Pattern in C#

### Step 1: Define the Memento Class
```csharp
// Memento: Stores the state of an object
public class Memento
{
    public string State { get; private set; }
    public Memento(string state)
    {
        State = state;
    }
}
```

### Step 2: Create the Originator Class
```csharp
// Originator: Creates and restores memento objects
public class Originator
{
    public string State { get; set; }

    public Memento SaveState()
    {
        return new Memento(State);
    }

    public void RestoreState(Memento memento)
    {
        State = memento.State;
    }
}
```

### Step 3: Implement the Caretaker Class
```csharp
// Caretaker: Manages multiple mementos
public class Caretaker
{
    private List<Memento> _mementoList = new List<Memento>();

    public void AddMemento(Memento memento)
    {
        _mementoList.Add(memento);
    }

    public Memento GetMemento(int index)
    {
        return _mementoList[index];
    }
}
```

### Step 4: Demonstrate the Memento Pattern in Action
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        // Setting initial state
        originator.State = "State 1";
        Console.WriteLine("Initial State: " + originator.State);
        caretaker.AddMemento(originator.SaveState());

        // Changing state
        originator.State = "State 2";
        Console.WriteLine("Changed State: " + originator.State);
        caretaker.AddMemento(originator.SaveState());

        // Changing state again
        originator.State = "State 3";
        Console.WriteLine("Changed State Again: " + originator.State);
        caretaker.AddMemento(originator.SaveState());

        // Restoring to a previous state
        originator.RestoreState(caretaker.GetMemento(0));
        Console.WriteLine("Restored State: " + originator.State);
    }
}
```

### Output
```
Initial State: State 1
Changed State: State 2
Changed State Again: State 3
Restored State: State 1
```

### Conclusion
The **Memento Pattern** is a powerful design pattern that allows for saving and restoring object states without breaking encapsulation. This is particularly useful for implementing undo/redo functionalities in applications such as text editors, games, and database transactions.

#### Advantages
- Preserves encapsulation by storing an object’s state externally.
- Enables undo/redo functionality easily.
- Allows restoration of an object's state without exposing internal details.

#### Disadvantages
- Can consume a lot of memory if storing large states.
- Caretaker needs to manage mementos efficiently to prevent excessive memory usage.

By using the **Memento Pattern**, developers can create robust and scalable applications with state-saving capabilities.

## **State Pattern**  

The **State** design pattern is a **behavioral pattern** that allows an object to change its behavior when its internal state changes. This pattern is particularly useful when an object’s behavior depends on its state and it must change its behavior at runtime.

### Key Components of the State Pattern  
1. **State Interface**: Defines the common behavior for all concrete states.
2. **Concrete States**: Implement different behaviors depending on the state.
3. **Context**: Maintains a reference to the current state and delegates behavior changes.

## When to Use the State Pattern  
- When an object’s behavior depends on its state and must change dynamically.
- When using large conditional statements to switch between different behaviors.
- When different states share behaviors but vary in execution.

## Example: Implementing the State Pattern in C#

### Step 1: Define the State Interface
```csharp
// State Interface
public interface IState
{
    void Handle(Context context);
}
```

### Step 2: Implement Concrete State Classes
```csharp
// Concrete State A
public class StateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State A handling request. Changing to State B.");
        context.SetState(new StateB());
    }
}

// Concrete State B
public class StateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State B handling request. Changing to State A.");
        context.SetState(new StateA());
    }
}
```

### Step 3: Create the Context Class
```csharp
// Context Class
public class Context
{
    private IState _state;

    public Context(IState state)
    {
        _state = state;
    }

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}
```

### Step 4: Demonstrate the State Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        Context context = new Context(new StateA());
        
        context.Request(); // Switch to State B
        context.Request(); // Switch back to State A
    }
}
```

### Output
```
State A handling request. Changing to State B.
State B handling request. Changing to State A.
```

### Conclusion
The **State Pattern** is a powerful tool for managing an object’s changing behavior dynamically. It replaces complex conditional logic with polymorphic state transitions.

#### Advantages
- Eliminates large `if-else` or `switch` statements.
- Enhances maintainability by separating state-specific behavior.
- Allows adding new states without modifying existing code.

#### Disadvantages
- Can lead to increased complexity with many state classes.
- Requires careful management of state transitions.

By using the **State Pattern**, developers can write more maintainable and scalable applications that dynamically change behaviors based on state.


## **Strategy Pattern**

The **Strategy** design pattern is a **behavioral pattern** that allows an algorithm's behavior to be selected at runtime. This pattern is particularly useful when multiple algorithms can be used interchangeably, and it helps avoid conditional logic.

### Key Components of the Strategy Pattern
1. **Strategy Interface**: Defines a family of interchangeable algorithms.
2. **Concrete Strategies**: Implement different versions of the algorithm.
3. **Context**: Maintains a reference to a strategy and delegates execution.

## When to Use the Strategy Pattern
- When multiple algorithms exist for a task, and only one needs to be selected at runtime.
- When avoiding large conditional statements.
- When strategies need to be easily interchangeable.

## Example: Implementing the Strategy Pattern in C#

### Step 1: Define the Strategy Interface
```csharp
// Strategy Interface
public interface IStrategy
{
    void Execute();
}
```

### Step 2: Implement Concrete Strategy Classes
```csharp
// Concrete Strategy A
public class StrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy A");
    }
}

// Concrete Strategy B
public class StrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy B");
    }
}
```

### Step 3: Create the Context Class
```csharp
// Context Class
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
```

### Step 4: Demonstrate the Strategy Pattern in Action
```csharp
using System;

class Program
{
    static void Main()
    {
        Context context = new Context(new StrategyA());
        context.ExecuteStrategy(); // Executes Strategy A
        
        context.SetStrategy(new StrategyB());
        context.ExecuteStrategy(); // Executes Strategy B
    }
}
```

### Output
```
Executing Strategy A
Executing Strategy B
```

### Conclusion
The **Strategy Pattern** is a powerful tool for selecting algorithms dynamically at runtime. It eliminates complex conditional logic and makes code more maintainable.

#### Advantages
- Reduces the use of large `if-else` or `switch` statements.
- Improves code maintainability by encapsulating algorithms.
- Allows dynamic swapping of strategies at runtime.

#### Disadvantages
- Increases the number of classes due to multiple strategy implementations.
- Clients must understand different strategy implementations.

By using the **Strategy Pattern**, developers can create flexible and scalable applications where algorithms can be changed without modifying the existing code.