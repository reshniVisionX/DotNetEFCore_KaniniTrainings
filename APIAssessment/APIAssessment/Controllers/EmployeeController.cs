using APIAssessment.Services;
using APIAssessment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService emp;
        public EmployeeController(EmployeeService employee) {
            emp = employee;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            try
            {
                var empList = await emp.GetAll();
                return Ok(empList);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            try
            {
                var empId = await emp.GetById(id);
                return Ok(empId);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                var employees=await emp.Create(employee);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id,Employee employe)
        {
            try
            {
                var empl = await emp.UpdateEmp(id,employe);
                return Ok(empl);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var empl = await emp.DeleteById(id);
                return Ok(empl);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
