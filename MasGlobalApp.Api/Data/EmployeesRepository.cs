using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MasGlobalApp.Api.Helpers;
using MasGlobalApp.Api.Models;
using Newtonsoft.Json;

namespace MasGlobalApp.Api.Data
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private static HttpClient client = new HttpClient();

        public async Task<IEmployee> GetEmployee(int id)
        {
            IEnumerable<IEmployee> employees = await this.GetEmployees();
            if (employees.Count<IEmployee>() > 0)
            {
                return employees.FirstOrDefault(e => e.Id.Equals(id));
            }
            return null;
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            HttpResponseMessage response = await client.GetAsync(AppSettingsProvider.ApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return (IEnumerable<IEmployee>)JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            else
            {
                throw new HttpRequestException("The service is unavailable.");
            }
        }
    }
}
