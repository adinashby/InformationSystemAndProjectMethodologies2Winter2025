public class Employee
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Department { get; set; }
}

public class EmployeeView
{
    public void PrintEmployeeDetails(string name, string id, string department)
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Employee ID: {id}");
        Console.WriteLine($"Employee Department: {department}");
    }
}

public class EmployeeController
{
    private Employee _model;
    private EmployeeView _view;

    public EmployeeController(Employee model, EmployeeView view)
    {
        _model = model;
        _view = view;
    }

    // Getters and Setters
    public string GetEmployeeName() => _model.Name;
    public void SetEmployeeName(string name) => _model.Name = name;

    public string GetEmployeeId() => _model.Id;
    public void SetEmployeeId(string id) => _model.Id = id;

    public string GetEmployeeDepartment() => _model.Department;
    public void SetEmployeeDepartment(string department) => _model.Department = department;

    // Update the view with the model data
    public void UpdateView()
    {
        _view.PrintEmployeeDetails(_model.Name, _model.Id, _model.Department);
    }
}

public class Program
{
    public static void Main()
    {
        // Creating the model (data)
        Employee employee = new Employee
        {
            Name = "John Doe",
            Id = "12345",
            Department = "Software Engineering"
        };

        // Creating the view (UI)
        EmployeeView view = new EmployeeView();

        // Creating the controller (bridge between model and view)
        EmployeeController controller = new EmployeeController(employee, view);

        // Display the initial details
        controller.UpdateView();

        // Updating the employee's data through the controller
        controller.SetEmployeeName("Jane Doe");
        controller.SetEmployeeId("67890");
        controller.SetEmployeeDepartment("Marketing");

        // Display updated details
        Console.WriteLine("\nAfter update:");
        controller.UpdateView();
    }
}

