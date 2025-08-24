using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;

namespace PatentWebApiProject.Services
{
    public class PatentGrantService
    {
        private readonly PatentGrantRepository grant_repo;

        public PatentGrantService(PatentGrantRepository grant_repo)
        {
            this.grant_repo = grant_repo;
        }

        public async Task<PatentGrants> CreateAsyncDTO(GrantDTO dto)
        {
            return await grant_repo.CreateAsyncDTO(dto);
        }

        public async Task<PatentGrants> CreateAsync(PatentGrants entity)
        {
            return await grant_repo.CreateAsync(entity);
        }

        public async Task<PatentGrants> UpdateAsync(GrantUpdDTO entity, int id)
        {
            return await grant_repo.UpdateAsync(entity, id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await grant_repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PatentGrants>> GetAllAsync()
        {
            return await grant_repo.GetAllAsync();
        }

        public async Task<PatentGrants?> GetByIdAsync(int id)
        {
            return await grant_repo.GetByIdAsync(id);
        }

      
    }
}
