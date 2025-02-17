// Memento: Stores the state of an object
public class Memento
{
    public string State { get; private set; }
    public Memento(string state)
    {
        State = state;
    }
}

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