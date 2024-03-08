using System;
using System.Numerics;

public class Employee
{
    private int Id;
    private string Name;
    private string DepartmentName;

    // Event declaration
    public event EventHandler<EmployeeEventArgs> MethodCalled;

    // Constructor
    public Employee(int id, string name, string departmentName)
    {
        Id = id;
        Name = name;
        DepartmentName = departmentName;
    }

    // Custom EventArgs class
    public class EmployeeEventArgs : EventArgs
    {
        public string Message { get; }

        public EmployeeEventArgs(string message)
        {
            Message = message;
        }
    }


    // Methods to get properties
    public int GetId()
    {
        OnMethodCalled("GetId() method called");
        return Id;
    }

    public string GetName()
    {
        OnMethodCalled("GetName() method called");
        return Name;
    }

    public string GetDepartmentName()
    {
        OnMethodCalled("GetDepartmentName() method called");
        return DepartmentName;
    }

    // Overloaded methods to update properties
    public void UpdateEmployee(int newId)
    {
        Id = newId;
        OnMethodCalled("UpdateEmployee() method called for updating id ");
    }

    public void UpdateEmployee(string newName)
    {
        Name = newName;
        OnMethodCalled("UpdateEmployee() method called for updating employee's name");
    }

    public void UpdateEmployee(int newId, string newDepartmentName)
    {
        Id = newId;
        DepartmentName = newDepartmentName;
        OnMethodCalled("UpdateEmployee() method called for updating id and department's name");
    }

    // Event method
    protected virtual void OnMethodCalled(string message)
    {
        MethodCalled?.Invoke(this, new EmployeeEventArgs(message));
    }
}



public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Employee's Id : ");
        int EmpId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Employee's Name : ");
        string EmpName = Console.ReadLine();

        Console.WriteLine("Enter Employee's Department Name: ");
        string DeptName = Console.ReadLine();

        // Creating an object of the Employee class
        Employee employee = new Employee(EmpId,EmpName,DeptName);

        // Subscribing to the event
        employee.MethodCalled += (sender, e) =>  Console.WriteLine(e.Message);

        // Printing all three properties
        Console.WriteLine($"Employee Id: {employee.GetId()}");
        Console.WriteLine($"Employee Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");

        // Updating properties using overloaded methods

        Console.WriteLine("Enter New Employee's Id : ");
        int newId = Convert.ToInt32(Console.ReadLine());
        employee.UpdateEmployee(newId);

        Console.WriteLine("Enter New Employee's Name : ");
        employee.UpdateEmployee(Console.ReadLine());

        Console.WriteLine("Enter New Employee's Department Name: ");
        employee.UpdateEmployee(newId, Console.ReadLine());


        // Printing updated properties
        Console.WriteLine($"Employee Id: {employee.GetId()}");
        Console.WriteLine($"Employee Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
        //Console.ReadLine();
    }
}
