using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;

namespace PatentWebApiProject.Services
{
    public class InternationalPatentService
    {
        private readonly ICrud<InternationalPatent> _repo;
        private readonly IInPatent grant;

       public InternationalPatentService(ICrud<InternationalPatent> inPatent, IInPatent grant)
        {
            _repo = inPatent;
            this.grant = grant;
        }
        public async Task<InternationalPatent> CreateInternationalPatentAsync(InternationalPatentDTO dto)
        {
            return await grant.CreateAsyncDTO(dto);
        }

        public async Task<IEnumerable<InternationalPatent>> GetAllInternationalPatentsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<InternationalPatent?> GetInternationalPatentByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> DeleteInternationalPatentAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InternationalPatent>> SearchByCountryAsync(string country)
        {
            return await grant.GetByCountryAsync(country);
        }

        public async Task<InternationalPatent?> UpdateStatusAsync(string status ,int id)
        {
           return await grant.UpdateStatusAsync( status, id);
        }
    }
}
