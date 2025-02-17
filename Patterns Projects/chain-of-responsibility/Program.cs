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