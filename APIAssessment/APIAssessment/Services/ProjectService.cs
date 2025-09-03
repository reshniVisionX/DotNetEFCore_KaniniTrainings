using APIAssessment.Data;
using APIAssessment.Interface;
using APIAssessment.Model;
using Microsoft.EntityFrameworkCore;

namespace APIAssessment.Services
{
    public class ProjectService : IProject
    {
        private readonly MainContext _context;
        public ProjectService(MainContext context)
        {
            _context = context; 
        }

        public async Task<bool> AddProjectToEmployee(int proId, int EmpId)
        {
            var employee = await _context.Employees.FindAsync(EmpId);
            var pro = await _context.Projects.FindAsync(proId);
            if (pro == null)
                throw new Exception("Project is not created");
            if (employee == null)
                throw new Exception("Employee with id is null");
            if (pro.employees == null)
                pro.employees = new List<Employee>();
            pro.employees!.Add(employee);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Project> Create(Project pro,int EmpId)
        {

            _context.Projects.Add(pro);
            await _context.SaveChangesAsync();
           // var created = await _context.Projects.FirstOrDefaultAsync(p => p.title == pro.title);
          //  int pro_id = created.proId;
         
            return pro;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
           return await _context.Projects.Include(e=>e.employees).ToListAsync();    
        }
    }
}
