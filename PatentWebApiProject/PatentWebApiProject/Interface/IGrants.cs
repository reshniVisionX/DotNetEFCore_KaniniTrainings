using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Interface
{
    public interface IGrants
    {
        Task<PatentGrants> CreateAsyncDTO(GrantDTO dto);
        Task<PatentGrants> UpdateAsync(GrantUpdDTO entity, int id);
    }
}
