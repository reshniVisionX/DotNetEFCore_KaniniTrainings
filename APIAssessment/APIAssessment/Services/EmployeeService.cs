using APIAssessment.Data;
using APIAssessment.Interface;
using APIAssessment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace APIAssessment.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly MainContext _context;
        public EmployeeService(MainContext context)
        {
            _context = context;
        }
        public async Task<Employee> Create(Employee employee)
        {
            if (employee == null)
                throw new Exception("Employee data needed");
            var existing = await _context.Employees.FirstOrDefaultAsync(p => p.empName.ToLower() == employee.empName.ToLower());
            if (existing != null)
            {
                throw new Exception("Employee with same name already exist");
            }
            var emailExisting = await _context.Employees.FirstOrDefaultAsync(p => p.email.ToLower() == employee.email.ToLower());
            if (emailExisting != null)
            {
                throw new Exception("Employee with the same email already exist");
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteById(int id)
        {
            if(id < 1)
            {
                throw new Exception("Id must be greater than 1");
            }

            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
                throw new Exception("Employee with id doesnt exist");
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            return await _context.Employees.Include(d => d.projects).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id must be greater than 1");
            }
            var empList = await _context.Employees.Include(p => p.projects).FirstAsync(d=>d.empId==id);
            if (empList == null)
                throw new Exception("Employee with id doesnt exist");
            return empList;
        }

        public async Task<Employee> UpdateEmp(int empId,Employee employe)
        {
            if (empId<0)
                throw new Exception("Employee id should be greater than 1 ");
            var emp = await _context.Employees.FindAsync(empId);
            if (emp == null)
                throw new Exception($"Employee with id {empId} doesnt exist");
            _context.Employees.Update(employe);
            await _context.SaveChangesAsync();
            return employe;
        }
    }
}
