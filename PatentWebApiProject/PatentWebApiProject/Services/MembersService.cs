using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Data;
using Microsoft.EntityFrameworkCore;

namespace PatentWebApiProject.Services
{
    public class MembersService
    {
        private readonly ICrud<Members> membersRepo;
        public MembersService(ICrud<Members> membersRepo)
        {
            this.membersRepo = membersRepo;
        }
        public async Task<Members> CreateAMember(Members member)
        {
            return await membersRepo.CreateAsync(member);
        }
        public async Task<Members> UpdateAMember(Members member,int id)
        {
            
            return await membersRepo.UpdateAsync(member,id);
        }
        public async Task<Members?> GetMemberById(int id)
        {
            return await membersRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Members>> GetAllMembers()
        {
            return await membersRepo.GetAllAsync();
        }
        public async Task<bool> DeleteAMember(int id)
        {
            return await membersRepo.DeleteAsync(id);
        }

        public async Task<Members?> GetMemberByName(string name)
        {
            var member =( await membersRepo.GetAllAsync()).FirstOrDefault(m => m.name.ToLower()== name.ToLower());
            if (member == null)
            {
                throw new Exception("Member with the name doesn't exist");
            }
            return member;
        }
    }
}
