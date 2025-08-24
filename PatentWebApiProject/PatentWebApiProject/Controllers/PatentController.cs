using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatentWebApiProject.DTO;
using PatentWebApiProject.Models;
using PatentWebApiProject.Services;

namespace PatentWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatentController : ControllerBase
    {
        private readonly PatentService _patentService;

        public PatentController(PatentService patentService)
        {
            _patentService = patentService;
        }

     
        [HttpGet]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<IEnumerable<Patent>>> GetAllPatents()
        {
            var patents = await _patentService.GetAllPatents();
            return Ok(patents);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<Patent>> GetPatentById(int id)
        {
            try
            {
                var patent = await _patentService.GetPatentById(id);
                return Ok(patent);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("byTitle/{title}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<IEnumerable<Patent>>> GetPatentsByTitle(string title)
        {
            try
            {
                var patents = await _patentService.GetByTitleAsync(title);
                return Ok(patents);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

       
        [HttpPost]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<Patent>> CreatePatent([FromBody] PatentDTO dto)
        {
            try
            {
                var patent = await _patentService.CreatePatent(dto);
                return CreatedAtAction(nameof(GetPatentById), new { id = patent.patentId }, patent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPatch("update-description")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<Patent>> UpdateDescription([FromBody] PatentUpdDTO dto)
        {
            try
            {
                var patent = await _patentService.UpdateDescription(dto);
                return Ok(patent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPatch("update-status")]
        [Authorize(Roles = "controller")]
        public async Task<ActionResult<Patent>> UpdateStatus(int patent_id, string status)
        {
            try
            {
                var patent = await _patentService.UpdateStatus(patent_id, status);
                return Ok(patent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("byIdFullDetails/{patentId}")]
        [Authorize(Roles = "user,controller")]
        public async Task<IActionResult> GetPatentDetails(int patentId)
        {
            var result = await _patentService.GetPatentDetails(patentId);

            if (result == null)
                return NotFound(new { Message = $"Patent with ID {patentId} not found." });

            return Ok(result);
        }

      
        [HttpDelete("{id}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult> DeletePatent(int id)
        {
            try
            {
                await _patentService.DeletePatent(id);
                return Ok($"Patent with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        
        [HttpPost("{patentId}/AddMember/{memberId}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<Patent>> AddMemberToPatent(int patentId, int memberId)
        {
            try
            {
                var patent = await _patentService.AddMemberToPatent(patentId, memberId);
                return Ok(patent);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
