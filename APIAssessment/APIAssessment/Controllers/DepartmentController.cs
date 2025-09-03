using APIAssessment.Model;
using APIAssessment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace APIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService dep;
        public DepartmentController(DepartmentService dept)
        {
            dep = dept;
        }
        [HttpPost]
        public async Task<ActionResult<Department>> Create(Department dept)
        {
            try
            {
                var deptm = await dep.Create(dept);
                return Ok(deptm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            try
            {
                var all = await dep.GetAll();
                return Ok(all);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
