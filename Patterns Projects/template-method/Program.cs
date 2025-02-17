// Abstract Class
public abstract class DataProcessor
{
    public void ProcessData()
    {
        ReadData();
        Process();
        SaveData();
    }

    protected abstract void ReadData();
    protected abstract void Process();
    protected abstract void SaveData();
}

// Concrete Class A
public class CSVDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from CSV file");
    }
    
    protected override void Process()
    {
        Console.WriteLine("Processing CSV data");
    }
    
    protected override void SaveData()
    {
        Console.WriteLine("Saving processed CSV data");
    }
}

// Concrete Class B
public class JSONDataProcessor : DataProcessor
{
    protected override void ReadData()
    {
        Console.WriteLine("Reading data from JSON file");
    }
    
    protected override void Process()
    {
        Console.WriteLine("Processing JSON data");
    }
    
    protected override void SaveData()
    {
        Console.WriteLine("Saving processed JSON data");
    }
}

class Program
{
    static void Main()
    {
        DataProcessor csvProcessor = new CSVDataProcessor();
        csvProcessor.ProcessData();

        Console.WriteLine();

        DataProcessor jsonProcessor = new JSONDataProcessor();
        jsonProcessor.ProcessData();
    }
}