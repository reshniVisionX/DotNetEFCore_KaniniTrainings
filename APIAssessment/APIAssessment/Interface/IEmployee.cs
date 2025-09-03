using APIAssessment.Model;
namespace APIAssessment.Interface
{
    public interface IEmployee
    {
        public Task<ICollection<Employee>> GetAll();
        public Task<Employee> GetById(int id);
        public Task<Employee> Create(Employee employee);
        public Task<Employee> UpdateEmp(int id,Employee emp);
        public Task<bool> DeleteById(int id);


    }
}
