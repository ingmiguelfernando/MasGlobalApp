using MasGlobalApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalApp.Web.Data
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<IEmployee> GetEmployee(int id);
    }
}
