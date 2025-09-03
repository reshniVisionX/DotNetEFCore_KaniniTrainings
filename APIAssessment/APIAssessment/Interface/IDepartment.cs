using APIAssessment.Model;
namespace APIAssessment.Interface
{
    public interface IDepartment
    {
        public Task<IEnumerable<Department>> GetAll();
        public Task<Department> Create(Department dep);

    }
}
