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
    public class InternationalPatentController : ControllerBase
    {
        private readonly InternationalPatentService _service;

        public InternationalPatentController(InternationalPatentService service)
        {
            _service = service;
        }
       
        [HttpGet]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<IEnumerable<InternationalPatent>>> GetAll()
        {
            var ips = await _service.GetAllInternationalPatentsAsync();
            return Ok(ips);
        }

      
        [HttpGet("byId/{id}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<InternationalPatent>> GetById(int id)
        {
            try
            {
                var ip = await _service.GetInternationalPatentByIdAsync(id);
                return Ok(ip);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

       
        [HttpPost]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<InternationalPatent>> Create([FromBody] InternationalPatentDTO dto)
        {
            try
            {
                var ip = await _service.CreateInternationalPatentAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = ip.ipId }, ip);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("byCountry/{country}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult<IEnumerable<InternationalPatent>>> SearchByCountryName(string country)
        {
            try {
                var ips = await _service.SearchByCountryAsync(country);
                return Ok(ips);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
          
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "user,controller")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteInternationalPatentAsync(id);
                return Ok(new { message = $"InternationalPatent with ID {id} deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
