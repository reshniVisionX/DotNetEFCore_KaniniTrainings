using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore_ConsoleAppCodeFirst
{
    public class EmployeeController
    {
        private readonly EmpDBContext _context;

        public EmployeeController(EmpDBContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            Console.WriteLine("Employee added successfully.");
        }

        public void UpdateEmployee(int id, string newDept, int newSalary)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                employee.dept = newDept;
                employee.salary = newSalary;
                _context.SaveChanges();
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void ListEmployees()
        {
            var employees = _context.Employee.ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.FirstName}, Dept: {emp.dept}, Salary: {emp.salary}");
            }
        }
    }
}
