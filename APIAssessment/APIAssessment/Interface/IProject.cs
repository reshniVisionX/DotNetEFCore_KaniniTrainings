using APIAssessment.Model;
namespace APIAssessment.Interface
{
    public interface IProject
    {
        public Task<IEnumerable<Project>> GetAll();

        public Task<Project> Create(Project pro,int empId);

        public Task<bool> AddProjectToEmployee(int proId, int EmpId);
    }
}
