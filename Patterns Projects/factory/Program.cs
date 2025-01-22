public interface IPolygon
{
    string GetType();
}

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