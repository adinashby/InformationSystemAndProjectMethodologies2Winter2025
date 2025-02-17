// Subject Interface
public interface ISubject
{
    void Request();
}

// Real Subject
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

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

class Program
{
    static void Main()
    {
        ISubject proxy = new Proxy();
        proxy.Request(); // Logs request and forwards to RealSubject
    }
}