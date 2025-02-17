// Implementation Interface
public interface IRenderer
{
    void RenderShape(string shape);
}

// Concrete Implementation A
public class VectorRenderer : IRenderer
{
    public void RenderShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " as vectors.");
    }
}

// Concrete Implementation B
public class RasterRenderer : IRenderer
{
    public void RenderShape(string shape)
    {
        Console.WriteLine("Drawing " + shape + " as pixels.");
    }
}

// Abstraction
public abstract class Shape
{
    protected IRenderer _renderer;

    public Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }
    
    public abstract void Draw();
}

// Refined Abstraction
public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) {}
    
    public override void Draw()
    {
        _renderer.RenderShape("Circle");
    }
}

class Program
{
    static void Main()
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle1 = new Circle(vectorRenderer);
        Shape circle2 = new Circle(rasterRenderer);
        
        circle1.Draw(); // Draws using vector rendering
        circle2.Draw(); // Draws using raster rendering
    }
}