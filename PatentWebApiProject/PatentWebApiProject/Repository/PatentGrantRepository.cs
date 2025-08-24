using PatentWebApiProject.Models;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Data;
using PatentWebApiProject.DTO;
using Microsoft.EntityFrameworkCore;

namespace PatentWebApiProject.Repository
{
    public class PatentGrantRepository : ICrud<PatentGrants>
    {
        private readonly PatentContext _context;
        public PatentGrantRepository(PatentContext context)
        {
            _context = context;
        }
        public async Task<PatentGrants> CreateAsyncDTO(GrantDTO dto)
        {
            if(!dto.patentId.HasValue)
            {
                throw new Exception("Either patentId  provided.");
            }
            if(string.IsNullOrWhiteSpace(dto.domain))
            {
                throw new Exception("Domain cannot be empty.");
            }
            if(dto.score<=0)
            {
                throw new Exception("Score must be greater than zero.");
            }
            var newGrant = new PatentGrants
            {
                patentId = dto.patentId,
                
                domain = dto.domain,
                score = dto.score,
                
            };
           
                var Epatent = await _context.patents.FindAsync(dto.patentId.Value);
               if (Epatent == null)
               {
                 throw new Exception($"Patent with ID {dto.patentId.Value} does not exist you cant grant this patent.");
               }
            if (Epatent.status == "Pending")
            {

                Epatent.status = "Granted";
            }
            else
            {
                throw new Exception($"This patent is rejected");
            }

                return await CreateAsync(newGrant);
        }
        public async Task<PatentGrants> CreateAsync(PatentGrants entity)
        {
            await _context.grants.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var grant = await _context.grants.FindAsync(id);
            if(grant == null)
            {
                throw new Exception("PatentGrant with the Id does not exist");
            }
            _context.grants.Remove(grant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PatentGrants>> GetAllAsync()
        {
            var grants = await _context.grants.ToListAsync();
            if(grants == null || !grants.Any())
            {
                throw new Exception("No PatentGrants found.");
            }
            return grants;
        }
      

        public async Task<PatentGrants?> GetByIdAsync(int id)
        {
            var grant = await _context.grants.FindAsync(id);
            if (grant == null)
            {
                throw new Exception("PatentGrant with the Id does not exist");
            }
            return grant;
        }

        public async Task<PatentGrants> UpdateAsync(GrantUpdDTO entity,int id)
        {
            var existing = await _context.grants.FindAsync(id);

            if (existing == null)
                throw new Exception($"PatentGrant with ID {id} not found.");

            existing.domain = entity.domain;
            existing.score = entity.score;
                 
            _context.grants.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

     

        public Task<PatentGrants> UpdateAsync(PatentGrants entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
