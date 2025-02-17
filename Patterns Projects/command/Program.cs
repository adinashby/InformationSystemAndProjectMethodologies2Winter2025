// Command Interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Concrete Command
public class LightOnCommand : ICommand
{
    private Light _light;
    
    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

// Receiver
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Invoker
public class RemoteControl
{
    private ICommand _command;
    
    public void SetCommand(ICommand command)
    {
        _command = command;
    }
    
    public void PressButton()
    {
        _command.Execute();
    }
    
    public void PressUndo()
    {
        _command.Undo();
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();
        ICommand lightOn = new LightOnCommand(light);
        
        RemoteControl remote = new RemoteControl();
        remote.SetCommand(lightOn);
        
        remote.PressButton(); // Turns on the light
        remote.PressUndo(); // Turns off the light
    }
}