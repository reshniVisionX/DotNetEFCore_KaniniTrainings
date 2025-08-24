using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;

namespace PatentWebApiProject.Services
{
    public class PatentService
    {
        private readonly PatentRepository _patentRepo;

        public PatentService(PatentRepository patentRepo)
        {
            _patentRepo = patentRepo;
        }

        public async Task<Patent> CreatePatent(PatentDTO dto)
        {
            return await _patentRepo.CreatePatentAsync(dto);
        }

        public async Task<IEnumerable<Patent>> GetAllPatents()
        {
            return await _patentRepo.GetAllAsync();
        }

        public async Task<Patent> GetPatentById(int id)
        {
            return await _patentRepo.GetByIdAsync(id);
        }

        public async Task<bool> DeletePatent(int id)
        {
            return await _patentRepo.DeleteAsync(id);
        }

        public async Task<Patent> AddMemberToPatent(int patentId, int memberId)
        {
            return await _patentRepo.AddMemberToPatent(patentId, memberId);
        }
        public async Task<IEnumerable<Patent>> GetByTitleAsync(string title)
        {
            return await _patentRepo.GetByTitleAsync(title);
        }
        public async Task<Patent> UpdateDescription(PatentUpdDTO dto)
        {
            return await _patentRepo.UpdateDescription(dto);

        }

        public async Task<PatentDetailsDTO?> GetPatentDetails(int patentId)
        {
            return await _patentRepo.GetPatentDetailsDTO(patentId);
        }

        public async Task<Patent?> UpdateStatus(int id,string status)
        {
            return await _patentRepo.UpdatePatentStatus(id,status);
        }
    }
}
