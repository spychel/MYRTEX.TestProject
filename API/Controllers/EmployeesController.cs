using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Employee> _empRepo;
        private readonly IGenericRepository<Department> _deptRepo;

        public EmployeesController(IGenericRepository<Employee> empRepo, IMapper mapper, IGenericRepository<Department> deptRepo)
        {
            _mapper = mapper;
            _empRepo = empRepo;
            _deptRepo = deptRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeToReturnDto>>> GetEmployeesAsync(
            [FromQuery] EmployeeFilteringSpecParams empParams)
        {
            var spec = new EmployeesWithSalaryAndDepartment(empParams);
            var employees = await _empRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeToReturnDto>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeToReturnDto>> GetEmployeeByIdAsync(int id)
        {
            var spec = new EmployeesWithSalaryAndDepartment(x => x.Id == id);
            var employee = await _empRepo.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Employee, EmployeeToReturnDto>(employee));
        }

        [HttpGet("departments")]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetDepartments()
        {
            var departments = await _deptRepo.ListAsync();
            return Ok(_mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentToReturnDto>>(departments));
        }
    }
}