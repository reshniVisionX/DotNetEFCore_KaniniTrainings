// See https://aka.ms/new-console-template for more information
using EFCore_ConsoleAppCodeFirst;

Console.WriteLine("Hello, World!");

var context = new EmpDBContext();
var service = new EmployeeController(context);

var newEmployee = new Employee
{
    FirstName = "Resh",
    dept = "Engineering",
    salary = 75000
};

service.AddEmployee(newEmployee);


service.UpdateEmployee(id: 1, newDept: "Product", newSalary: 80000);
using (context = new EmpDBContext())
{
    service.ListEmployees();
}