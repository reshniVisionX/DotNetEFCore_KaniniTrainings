using APIAssessment.Services;
using APIAssessment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService ser;
        public ProjectController(ProjectService service)
        {
            ser = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAll()
        {
            try
            {
                var all = await ser.GetAll();
                return Ok(all);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project pro,int Empid)
        {
            try
            {
                var project = await ser.Create(pro,Empid);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ByMerge")]
        public async Task<ActionResult> Merge(int pId, int eId)
        {
            try
            {
                var res = await ser.AddProjectToEmployee(pId, eId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
