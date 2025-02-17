// Mediator Interface
public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

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