using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Interface
{
    public interface IInPatent
    {
        Task<InternationalPatent> CreateAsyncDTO(InternationalPatentDTO dto);
        Task<InternationalPatent> UpdateStatusAsync(string status, int id);

        Task<IEnumerable<InternationalPatent>> GetByCountryAsync(string country);


    }
}
