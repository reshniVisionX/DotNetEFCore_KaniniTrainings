using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;

namespace PatentWebApiProject.Services
{
    public class PatentGrantService
    {
        private readonly ICrud<PatentGrants> repo;
        private readonly IGrants grnts;
        public PatentGrantService(ICrud<PatentGrants> grants, IGrants ig)
        {
            repo = grants;
            grnts = ig;
        }

        public async Task<PatentGrants> CreateAsyncDTO(GrantDTO dto)
        {
            return await grnts.CreateAsyncDTO(dto);
        }

        public async Task<PatentGrants> CreateAsync(PatentGrants entity)
        {
            return await repo.CreateAsync(entity);
        }

        public async Task<PatentGrants> UpdateAsync(GrantUpdDTO entity, int id)
        {
            return await grnts.UpdateAsync(entity, id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PatentGrants>> GetAllAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task<PatentGrants?> GetByIdAsync(int id)
        {
            return await repo.GetByIdAsync(id);
        }

      
    }
}
