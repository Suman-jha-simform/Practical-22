using AutoMapper;
using Data_Access_Layer.Model;
using Data_Access_Layer.Interface;
using Microsoft.AspNetCore.Mvc;
using Practical_22___API.Dtos;

namespace Practical_22___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
 
        private readonly IMapper _mapper;
        private readonly IService _service;

        public EmployeeController(IMapper mapper, IService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
           var emp = _service.GetEmployee(id);
            if(emp == null)
            {
                return BadRequest("Employee not found");
            }
           var mappedEmp = _mapper.Map<EmployeeDto>(emp);
           return Ok(mappedEmp);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployee()
        {
            var emp = _service.Read();
            if(emp.Count == 0)
            {
                return NotFound("No Employee details found.");
            }
            var mappedEmp = _mapper.Map<List<EmployeeDto>>(emp);
            return Ok(mappedEmp);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmployeeDto employeeDto)
        {
            if(ModelState.IsValid)
            {
                var emp = _mapper.Map<Employee>(employeeDto);
                emp.JoiningDate = DateTime.Now;
                emp.Status = true;

                var dept = _service.GetDepartment(emp.DepartmentId);
                if (dept == null)
                {
                    return NotFound("Department not found : choose from 1:IT, 2:Admin, 3:HR, 4:Sales, 5:On-site");
                }
                emp.Departments = dept;
                _service.Create(emp);
                return Ok("Employee added successfully.");

            }
            else
            {
                return BadRequest("Invalid Employee details");
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployee(UpdateEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                var emp = _mapper.Map<Employee>(employeeDto);
                emp.Id = employeeDto.Id;
                var dept = _service.GetDepartment(emp.DepartmentId);
                if (dept == null)
                {
                    return NotFound("Department not found : choose from 1:IT, 2:Admin, 3:HR, 4:Sales, 5:On-site");
                }
                emp.Departments = dept;
                emp.JoiningDate = DateTime.Now;
                emp.Status = true;
                _service.Update(emp);
                return Ok("Employee updated successfully.");

            }
            else
            {
                return BadRequest("Employee could not be found");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var emp = _service.GetEmployee(id);
            if(emp == null)
            {
                return NotFound("Employee not found.");
            }
            else
            {
                _service.Delete(id);
                return Ok("Employee deleted successfully");
            }
        }

    }
}
