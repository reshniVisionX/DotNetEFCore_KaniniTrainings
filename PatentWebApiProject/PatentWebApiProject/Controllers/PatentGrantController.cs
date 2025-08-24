using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;
using PatentWebApiProject.Services;

namespace PatentWebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatentGrantController : ControllerBase
    {
        private readonly PatentGrantService _grantService;

        public PatentGrantController(PatentGrantService grantService)
        {
            _grantService = grantService;
        }

        
        [HttpGet]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<IEnumerable<PatentGrants>>> GetAll()
        {
            try
            {
                var grants = await _grantService.GetAllAsync();
                return Ok(grants);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       
        [HttpGet("{id}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<PatentGrants>> GetById(int id)
        {
            try
            {
                var grant = await _grantService.GetByIdAsync(id);
                return Ok(grant);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
      
       
        [HttpPost("create")]
        [Authorize(Roles = "controller")]
        public async Task<ActionResult<PatentGrants>> CreateGrant([FromBody] GrantDTO dto)
        {
            try
            {
                var grant = await _grantService.CreateAsyncDTO(dto);
                return Ok(grant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        
        [HttpPut("{id}")]
        [Authorize(Roles = "controller")]
        public async Task<ActionResult<PatentGrants>> Update(int id, [FromBody] GrantUpdDTO upd)
        {
            try
            {
                var updated = await _grantService.UpdateAsync(upd, id);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "controller")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _grantService.DeleteAsync(id);
                return Ok($"PatentGrant with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       
    }
}
