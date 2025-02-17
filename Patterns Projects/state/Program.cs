// State Interface
public interface IState
{
    void Handle(Context context);
}

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

class Program
{
    static void Main()
    {
        Context context = new Context(new StateA());
        
        context.Request(); // Switch to State B
        context.Request(); // Switch back to State A
    }
}