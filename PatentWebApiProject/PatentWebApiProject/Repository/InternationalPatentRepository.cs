using Microsoft.EntityFrameworkCore;
using PatentWebApiProject.Data;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using System.Globalization;

namespace PatentWebApiProject.Repository
{
    public class InternationalPatentRepository : ICrud<InternationalPatent>,IInPatent
    {
        private readonly PatentContext context;

        public InternationalPatentRepository(PatentContext context)
        {
            this.context = context;
        }

        public async Task<InternationalPatent> CreateAsyncDTO(InternationalPatentDTO dto)
        {
          
            var existing = await context.inPatents
                .FirstOrDefaultAsync(ip => ip.patentId == dto.patentId && ip.country == dto.country);
          
            if (existing != null)
                throw new Exception($"InternationalPatent for PatentID {dto.patentId} in the country {dto.country} already exists.");

            var granted = await context.grants
                .AnyAsync(pg => pg.patentId == dto.patentId);
            if (!granted)
                throw new Exception($"PatentID {dto.patentId} is not granted yet, cannot create InternationalPatent.");

            var newIP = new InternationalPatent
            {
                country = dto.country,
                patentId = dto.patentId,
                fieledDate = DateTime.Now
            };

          return await CreateAsync(newIP);
        }
        public async Task<InternationalPatent> CreateAsync(InternationalPatent entity)
        {
            await context.inPatents.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<InternationalPatent>> GetAllAsync()
        {
            return await context.inPatents.ToListAsync();
        }

        public async Task<InternationalPatent?> GetByIdAsync(int id)
        {
            var ip = await context.inPatents.FindAsync(id);
            if (ip == null)
                throw new Exception($"InternationalPatent with ID {id} does not exist.");
            return ip;
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await context.inPatents.FindAsync(id);
            if (existing == null)
                throw new Exception($"InternationalPatent with ID {id} does not exist, cannot delete.");

            context.inPatents.Remove(existing);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<InternationalPatent> UpdateAsync(InternationalPatent entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InternationalPatent> UpdateStatusAsync(string status,int id)
        {
            
            var patent = await context.inPatents
                                      .FirstOrDefaultAsync(p => p.ipId == id);

            if (patent == null)
                throw new Exception("Patent not found.");

            if (patent.status == "Pending" && status == "Granted")
            {
                patent.status = "Granted";
            }else if(status == "Rejected" && patent.status == "Pending")
            {
                patent.status = "Rejected";
            }
            else
            {
                throw new Exception("Invalid status transition.");
            }

            await context.SaveChangesAsync();
            return patent;
        }

        public async Task<IEnumerable<InternationalPatent>> GetByCountryAsync(string country)
        {
           var inPatents = await context.inPatents
                .Where(ip => ip.country.ToLower() == country.ToLower())
                .ToListAsync();
            if (inPatents.Count == 0)
                throw new Exception($"No InternationalPatents found for country: {country}");
            return inPatents;
        }
    }
}
