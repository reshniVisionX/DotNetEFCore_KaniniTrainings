using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Interface
{
    public interface IPatent
    {
        Task<Patent> AddMemberToPatent(int patentId, int memberId);

        Task<Patent> CreatePatentAsync(PatentDTO dto);

        Task<Patent> UpdateDescription(PatentUpdDTO pat);

        Task<PatentDetailsDTO> GetPatentDetailsDTO(int patentId);

        Task<Patent> UpdatePatentStatus(int id, string status);

        Task<object> GetAnalysis();

        Task<IEnumerable<Patent>> GetByTitleAsync(String title);
        Task<Members> ExistingMemberByNameAsync(String name);
    }
}
