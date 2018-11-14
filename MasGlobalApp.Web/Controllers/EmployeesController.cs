using MasGlobalApp.Web.Data;
using MasGlobalApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalApp.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _repo;

        public EmployeesController(IEmployeesRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Find()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Find(int? employeeId)
        {
            if (employeeId == null)
            {
                var findedEmployees = await _repo.GetEmployees();
                return View(findedEmployees);
            }
            else
            {
                var findedEmployee = await _repo.GetEmployee((int)employeeId);
                if (findedEmployee != null)
                {
                    return View(new List<IEmployee>() { findedEmployee });
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
