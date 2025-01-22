public interface IMovable
{
    // Returns speed in MPH
    double GetSpeed();
}

public class BugattiVeyron : IMovable
{
    public double GetSpeed()
    {
        return 268;  // Speed in MPH
    }
}

public interface IMovableAdapter
{
    // Returns speed in KM/H
    double GetSpeed();
}

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