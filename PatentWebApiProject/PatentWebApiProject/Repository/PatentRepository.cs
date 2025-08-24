using Microsoft.EntityFrameworkCore;
using PatentWebApiProject.Data;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using System.IO;

namespace PatentWebApiProject.Repository
{
    public class PatentRepository : ICrud<Patent>
    {
        private readonly PatentContext context;

        public PatentRepository(PatentContext context)
        {
            this.context = context;
        }

        public async Task<Patent> CreatePatentAsync(PatentDTO dto)
        {
           
            var existingPatent = await context.patents
                .FirstOrDefaultAsync(p => p.title == dto.title);

            if (existingPatent != null)
                throw new Exception($"Patent with title '{dto.title}' already exists.");

            var member = await context.members
                .FirstOrDefaultAsync(m => m.name == dto.name);

            if (member == null)
                throw new Exception($"Member with name '{dto.name}' not found.");

            var newPatent = new Patent
            {
                title = dto.title,
                description = dto.description,
                members = new List<Members> { member }
            };
            return await CreateAsync(newPatent);
        }


        public async Task<Patent> CreateAsync(Patent entity)
        {
            await context.patents.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Patent>> GetAllAsync()
        {
            return await context.patents.Include(p=>p.members).ToListAsync();
        }

        public async Task<Patent> GetByIdAsync(int id)
        {
            var patent = await context.patents.Include(p => p.members).FirstOrDefaultAsync(p=>p.patentId==id);

            if (patent == null)
            {
                throw new Exception($"Patent with ID {id} does not exist.");
            }

            return patent;
        }

        public async Task<IEnumerable<Patent>> GetByTitleAsync(string title)
        {
            var Patents = await context.patents
                 .Where(ip => ip.title.ToLower() == title.ToLower())
                 .ToListAsync();
            if (Patents.Count == 0)
                throw new Exception($"No patent with title : {title} is available");
            return Patents;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await context.patents.FindAsync(id);

            if (existing == null)
            {
                throw new Exception($"Patent with ID {id} does not exist, so cannot delete.");
            }

            context.patents.Remove(existing);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Patent> AddMemberToPatent(int patentId,int memberId)
        {
            var patent = await context.patents
                     .Include(p => p.members)
                     .FirstOrDefaultAsync(p => p.patentId == patentId);

            if(patent == null)
            {
                throw new Exception($"Patent with ID {patentId} does not exist.");
            }
            var member = await context.members.FindAsync(memberId);
            if(member == null)
            {
                throw new Exception($"Member with ID {memberId} does not exist.");
            }
            if (patent.members.Count >= 8)
            {
                throw new Exception($"Patent with ID {patentId} already has 8 members. Cannot add more.");
            }
            if (patent.members.Any(m => m.memId == memberId))
                throw new Exception($"Member with ID {memberId} is already associated with Patent ID {patentId}.");

            patent.members.Add(member);
            await context.SaveChangesAsync();

            return patent; 
        }
        public async Task<Patent> UpdateDescription(PatentUpdDTO pat)
        {
            var patent = await context.patents.FindAsync(pat.patentId);
            if(patent == null)
            {
                throw new Exception($"Patent with id {pat.patentId} doesn't exist");
            }
            patent.description = pat.description;
            await context.SaveChangesAsync(); 

            return patent;
        }

        public async Task<PatentDetailsDTO> GetPatentDetailsDTO(int patentId)
        {
            var patent = await context.patents
                .Include(p=>p.members)
                .Include(p=>p.patentGrants)
                .FirstOrDefaultAsync(p => p.patentId == patentId);

            var internationalPatents = await context.inPatents
                .Where(ip => ip.patentId == patentId)
                .ToListAsync();
            if (patent == null)
            {
                throw new KeyNotFoundException($"Patent with Id {patentId} not found");
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
        public Task<Patent> UpdateAsync(Patent entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Patent> UpdatePatentStatus(int id, string status)
        {
            var patent = await context.patents.FindAsync(id);
            if (patent == null)
            {
                throw new Exception($"Patent with id {id} doesn't exist");
            }
            if (string.IsNullOrWhiteSpace(status) || (status != "Pending" && status != "Rejected"))
            {
                throw new Exception("Status must be one of the following values: 'Pending' or 'Rejected'.");
            }

            patent.status=status;
            await context.SaveChangesAsync();

            return patent;
        }
    }
}
