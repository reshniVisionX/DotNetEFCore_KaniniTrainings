using APIAssessment.Data;
using APIAssessment.Interface;
using APIAssessment.Model;
using Microsoft.EntityFrameworkCore;

namespace APIAssessment.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly MainContext _context;
        public DepartmentService(MainContext con)
        {
            _context = con;
        }
        public async Task<Department> Create(Department dep)
        {
            if (dep == null)
                throw new Exception("Department data needed");
            var existing = await _context.Departments.FirstOrDefaultAsync(p => p.depName.ToLower() == dep.depName.ToLower());
            if (existing != null)
            {
                throw new Exception("department with same name already exist");
            }
          
            _context.Departments.Add(dep);
            await _context.SaveChangesAsync();
            return dep;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
           return await _context.Departments.Include(p=>p.employees).ToListAsync();
        }
    }
}
