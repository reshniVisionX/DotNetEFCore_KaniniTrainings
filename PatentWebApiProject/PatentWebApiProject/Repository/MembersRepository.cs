using Microsoft.EntityFrameworkCore;
using PatentWebApiProject.Data;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Repository
{
    public class MembersRepository : ICrud<Members>
    {
        public readonly PatentContext context;
        public MembersRepository(PatentContext context) { 
             this.context = context;
        }
      
        public async Task<Members?> CreateAsync(Members entity)
        {
            if (string.IsNullOrWhiteSpace(entity.name))
            {
                throw new Exception("Member name cannot be null or empty.");
            }

            var existingMember = await context.members
                .FirstOrDefaultAsync(m => m.name == entity.name);

            if (existingMember != null)
            {
                throw new Exception("Member with the same name already exists.");
            }

            context.members.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeleteAsync(int id)
        {
           var old = await context.members.FindAsync(id);
            if(old == null)
            {
                return false;
            }
            context.members.Remove(old);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Members>> GetAllAsync()
        {
          return await context.members.Include(m=>m.patents).ToListAsync();
        }

        public async Task<Members?> GetByIdAsync(int id)
        {
            var found = await context.members
                   .Include(m => m.patents) 
                  .FirstOrDefaultAsync(m => m.memId == id); 
            if (found==null)
            {
                throw new Exception("Member with the Id does not exist");
            }
            return await context.members.FindAsync(id);
        }

        public async Task<Members?> UpdateAsync(Members entity,int id)
        {
            var existing = await context.members.FindAsync(id);

            if (existing == null)
            {
                throw new Exception("Member with the given ID does not exist.");
            }
          
            entity.memId = id;
            context.Entry(existing).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
            return existing; 
        }

        
    }
}
