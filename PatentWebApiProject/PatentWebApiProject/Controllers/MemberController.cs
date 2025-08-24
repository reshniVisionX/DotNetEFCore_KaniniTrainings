using Microsoft.AspNetCore.Mvc;
using PatentWebApiProject.Models;
using PatentWebApiProject.Services;
using PatentWebApiProject.DTO;

namespace PatentWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MembersService _membersService;

        public MemberController(MembersService membersService)
        {
            _membersService = membersService;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetAllMembers()
        {
            var members = await _membersService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMemberById(int id)
        {
            try
            {
                var member = await _membersService.GetMemberById(id);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Members>> CreateMember([FromBody] MembersDTO mem)
        {
            try
            {
                var member = new Members
                {
                    name = mem.name,
                    email = mem.email,
                    city = mem.city,
                    role = mem.role
                };

                var createdMember = await _membersService.CreateAMember(member);
                return CreatedAtAction(nameof(GetMemberById), new { id = createdMember.memId }, createdMember);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Members>> UpdateMember( MembersDTO mem,int id)
        {
            try
            {
                var member = new Members
                {
                    name = mem.name,
                    email = mem.email,
                    city = mem.city,
                    role = mem.role
                };
                var updatedMember = await _membersService.UpdateAMember(member,id);
                return Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

  
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            try
            {
                var deleted = await _membersService.DeleteAMember(id);
                if (!deleted)
                {
                    return NotFound(new { message = $"Member with ID {id} not found." });
                }

                return Ok(new { message = $"Member with ID {id} deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("byname/{name}")]
        public async Task<ActionResult<Members>> GetMemberByName(string name)
        {
            try
            {
                var member = await _membersService.GetMemberByName(name);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
