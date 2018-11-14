using AutoMapper;
using MasGlobalApp.Api.Dtos;
using MasGlobalApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalApp.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Employee, EmployeeWithAnnualSalaryDto>()
                .ForMember(dest => dest.AnnualSalary, opt =>
                {
                    opt.ResolveUsing(src =>
                    {
                        switch (src.ContractTypeName)
                        {
                            case ContractType.HourlySalaryEmployee: return (AppSettingsProvider.HoursByMonth * src.HourlySalary * AppSettingsProvider.MonthsByYear);
                            case ContractType.MonthlySalaryEmployee: return (src.MonthlySalary * AppSettingsProvider.MonthsByYear);
                            default: return 0;
                        }
                    });
                });
        }
    }
}
