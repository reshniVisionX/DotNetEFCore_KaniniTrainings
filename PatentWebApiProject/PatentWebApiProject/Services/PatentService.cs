using PatentWebApiProject.DTO;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Services
{
    public class PatentService
    {
        private readonly ICrud<Patent> _crudRepo;
        private readonly IPatent _patentRepo;
        private readonly ICrud<Members> _memRepo;

        public PatentService(ICrud<Patent> crudRepo, IPatent patentRepo, ICrud<Members> mem)
        {
            _crudRepo = crudRepo;
            _patentRepo = patentRepo;
            _memRepo = mem;
        }

        public async Task<Patent> CreatePatent(PatentDTO dto)
        {
            var existingPatent = await _patentRepo.GetByTitleAsync(dto.title);

            if (existingPatent.Any()) 
                throw new Exception($"Patent with title '{dto.title}' already exists.");
            var member = await _patentRepo.ExistingMemberByNameAsync(dto.name);
            if (member == null)
                throw new Exception($"Member with name '{dto.name}' not found.");

            return await _patentRepo.CreatePatentAsync(dto);
        }

        public async Task<IEnumerable<Patent>> GetAllPatents()
        {
            return await _crudRepo.GetAllAsync();
        }

        public async Task<Patent> GetPatentById(int id)
        {
            var patent = await _crudRepo.GetByIdAsync(id);
            if (patent == null)
                throw new Exception($"Patent with ID {id} does not exist.");

            return patent;
        }

        public async Task<IEnumerable<Patent>> GetByTitleAsync(string title)
        {
            var patents = await _patentRepo.GetByTitleAsync(title);
            if (patents.Count() == 0)
                throw new Exception($"No patent with title : {title} is available");

            return patents;
        }

        public async Task<bool> DeletePatent(int id)
        {
            var result = await _crudRepo.DeleteAsync(id);
            if (!result)
                throw new Exception($"Patent with ID {id} does not exist, so cannot delete.");

            return result;
        }

        public async Task<Patent> AddMemberToPatent(int patentId, int memberId)
        {
            var patent = await _crudRepo.GetByIdAsync(patentId);
            if (patent == null)
                throw new Exception($"Patent with ID {patentId} does not exist.");
            var member = await _memRepo.GetByIdAsync(memberId);
            if (member == null)
                throw new Exception($"Member with ID {memberId} does not exist.");
            if (patent.members.Count >= 8)
                throw new Exception($"Patent with ID {patentId} already has 8 members. Cannot add more.");
            if (patent.members.Any(m => m.memId == memberId))
                throw new Exception($"Member with ID {memberId} is already associated with Patent ID {patentId}.");

            return await _patentRepo.AddMemberToPatent(patentId, memberId);
        }

        public async Task<Patent> UpdateDescription(PatentUpdDTO dto)
        {
            var patent = await _patentRepo.UpdateDescription(dto);
            if (patent == null)
                throw new Exception($"Patent with id {dto.patentId} doesn't exist");

            return patent;
        }

        public async Task<PatentDetailsDTO> GetPatentDetails(int patentId)
        {
            var patentDetails = await _patentRepo.GetPatentDetailsDTO(patentId);
            if (patentDetails == null)
                throw new KeyNotFoundException($"Patent with Id {patentId} not found");

            return patentDetails;
        }

        public async Task<Patent> UpdateStatus(int id, string status)
        {
            var patent = await _crudRepo.GetByIdAsync(id);
            if (patent == null)
                throw new Exception($"Patent with id {id} doesn't exist");
            if (string.IsNullOrWhiteSpace(status) || (status != "Pending" && status != "Rejected"))
                throw new Exception("Status must be one of the following values: 'Pending' or 'Rejected'.");
            if (patent.status == "Granted")
                throw new Exception($"Patent with id {id} already granted the status can't be changed");

            return await _patentRepo.UpdatePatentStatus(id, status);
        }

        public async Task<object> GetAnalysis()
        {
            return await _patentRepo.GetAnalysis();
        }
    }
}