using Microsoft.EntityFrameworkCore;
using PatentWebApiProject.Data;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Repository
{
    public class PatentRepository : ICrud<Patent>, IPatent
    {
        private readonly PatentContext context;

        public PatentRepository(PatentContext context)
        {
            this.context = context;
        }

        public async Task<Patent> CreateAsync(Patent entity)
        {
            await context.patents.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Patent> CreatePatentAsync(PatentDTO dto)
        {
            var member = await context.members
    .FirstOrDefaultAsync(m => m.name.ToLower() == dto.name.ToLower());


            var newPatent = new Patent
            {
                title = dto.title,
                description = dto.description,
                members = member != null ? new List<Members> { member } : new List<Members>()
            };
            await CreateAsync(newPatent);
            return newPatent;
        }

        public async Task<IEnumerable<Patent>> GetAllAsync()
        {
            return await context.patents.Include(p => p.members).ToListAsync();
        }

        public async Task<Patent> GetByIdAsync(int id)
        {
            return await context.patents.Include(p => p.members).FirstOrDefaultAsync(p => p.patentId == id);
        }

        public async Task<IEnumerable<Patent>> GetByTitleAsync(string title)
        {
            return await context.patents
                .Where(ip => ip.title.ToLower() == title.ToLower())
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await context.patents.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            context.patents.Remove(existing);
            await context.SaveChangesAsync();
            return true;
        }

  
        public async Task<Patent> AddMemberToPatent(int patentId, int memberId)
        {
            var patent = await context.patents
                .Include(p => p.members)
                .FirstOrDefaultAsync(p => p.patentId == patentId);

            if (patent == null)
                throw new Exception($"Patent with ID {patentId} does not exist.");

            if (patent.members == null)   
                patent.members = new List<Members>();

            var member = await context.members.FindAsync(memberId);
            if (member == null)
                throw new Exception($"Member with ID {memberId} does not exist.");

            patent.members.Add(member);
            await context.SaveChangesAsync();

            return patent;
        }


        public async Task<Patent> UpdateDescription(PatentUpdDTO pat)
        {
            var patent = await context.patents.FindAsync(pat.patentId);
            if (patent != null)
            {
                patent.description = pat.description;
                await context.SaveChangesAsync();
            }

            return patent;
        }

        public async Task<PatentDetailsDTO> GetPatentDetailsDTO(int patentId)
        {
            var patent = await context.patents
                .Include(p => p.members)
                .Include(p => p.patentGrants)
                .FirstOrDefaultAsync(p => p.patentId == patentId);

            var internationalPatents = await context.inPatents
                .Where(ip => ip.patentId == patentId)
                .ToListAsync();

            if (patent == null)
            {
                return null;
            }

            return new PatentDetailsDTO
            {
                title = patent.title,
                description = patent.description,
                appliedDate = patent.appliedDate,
                status = patent.status,
                internationalPatent = internationalPatents,
                members = patent.members
            };
        }

        public async Task<Patent> UpdatePatentStatus(int id, string status)
        {
            var patent = await context.patents.FindAsync(id);
            if (patent != null)
            {
                patent.status = status;
                await context.SaveChangesAsync();
            }

            return patent;
        }

        public async Task<object> GetAnalysis()
        {
            var patentStats = await context.patents
                .Select(p => new
                {
                    PatentTitle = p.title,
                    MemberCount = p.members.Count
                })
                .ToListAsync();

            var memberStats = await context.members
                .Select(m => new
                {
                    MemberName = m.name,
                    PatentCount = m.patents.Count
                })
                .ToListAsync();

            return new
            {
                Patents = patentStats,
                Members = memberStats
            };
        }

        public async Task<Members> ExistingMemberByNameAsync(String name)
        {

            var member = await context.members
                .FirstOrDefaultAsync(m => m.name.ToLower() == name.ToLower());
            return member;
        }
        public Task<Patent> UpdateAsync(Patent entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}