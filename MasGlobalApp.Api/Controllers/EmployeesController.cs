using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MasGlobalApp.Api.Data;
using MasGlobalApp.Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasGlobalApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _repo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _repo.GetEmployees();
            var employeesWithAnnualSalary = _mapper.Map<IEnumerable<EmployeeWithAnnualSalaryDto>>(employees);
            return Ok(employeesWithAnnualSalary);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _repo.GetEmployee(id);
            var employeeWithAnnualSalary = _mapper.Map<EmployeeWithAnnualSalaryDto>(employee);
            return Ok(employeeWithAnnualSalary);
        }

    }
}