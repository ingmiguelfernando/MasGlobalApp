using MasGlobalApp.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalApp.Api.Data
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<IEmployee> GetEmployee(int id);
    }
}
