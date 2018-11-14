using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MasGlobalApp.Api.Helpers;
using MasGlobalApp.Web.Models;
using Newtonsoft.Json;

namespace MasGlobalApp.Web.Data
{
    public class EmployeesRepository : IEmployeesRepository
    {

        private static HttpClient client = new HttpClient();

        public async Task<IEmployee> GetEmployee(int id)
        {
            HttpResponseMessage response = await client.GetAsync(AppSettingsProvider.ApiUrl + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return (IEmployee)JsonConvert.DeserializeObject<Employee>(data);
            }
            else
            {
                throw new HttpRequestException("The service is unavailable.");
            }
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
