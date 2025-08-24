using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;

namespace PatentWebApiProject.Services
{
    public class InternationalPatentService
    {
        private readonly InternationalPatentRepository _repo;

        public InternationalPatentService(InternationalPatentRepository repo)
        {
            _repo = repo;
        }

        public async Task<InternationalPatent> CreateInternationalPatentAsync(InternationalPatentDTO dto)
        {
            return await _repo.CreateAsyncDTO(dto);
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
            return await _repo.GetByCountryAsync(country);
        }
    }
}
