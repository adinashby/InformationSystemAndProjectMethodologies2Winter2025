// Flyweight Interface
public interface IShape
{
    void Draw(string color);
}

// Concrete Flyweight
public class Circle : IShape
{
    private readonly string _shapeType = "Circle";
    
    public void Draw(string color)
    {
        Console.WriteLine($"Drawing a {_shapeType} with color {color}");
    }
}

// Flyweight Factory
public class ShapeFactory
{
    private static readonly Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();
    
    public static IShape GetShape(string shapeType)
    {
        if (!_shapes.ContainsKey(shapeType))
        {
            _shapes[shapeType] = new Circle();
            Console.WriteLine("Creating new Circle object");
        }
        return _shapes[shapeType];
    }
}

class Program
{
    static void Main()
    {
        IShape shape1 = ShapeFactory.GetShape("Circle");
        shape1.Draw("Red");
        
        IShape shape2 = ShapeFactory.GetShape("Circle");
        shape2.Draw("Blue");
        
        IShape shape3 = ShapeFactory.GetShape("Circle");
        shape3.Draw("Green");
    }
}