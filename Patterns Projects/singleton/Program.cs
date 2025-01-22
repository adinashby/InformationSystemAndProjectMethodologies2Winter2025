using System;

public class Database
{
    private static Database dbObject;

    // Private constructor to restrict object creation
    private Database() { }

    // Public static method to provide access to the singleton object
    public static Database GetInstance()
    {
        // Create the object if it's not already created
        if (dbObject == null)
        {
            dbObject = new Database();
        }

        // Returns the singleton object
        return dbObject;
    }

    public void GetConnection()
    {
        Console.WriteLine("You are now connected to the database.");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Database db1;

        // Refers to the only object of Database
        db1 = Database.GetInstance();

        db1.GetConnection();
    }
}