using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeToReturnDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.LastName + " " + s.FirstName + " " + s.SecondName))
                .ForMember(d => d.Birthdate, o => o.MapFrom(s => s.Birthdate.ToString("d", CultureInfo.GetCultureInfo("ru-Ru"))))
                .ForMember(d => d.Hiredate, o => o.MapFrom(s => s.Hiredate.ToString("d", CultureInfo.GetCultureInfo("ru-Ru"))))
                .ForMember(d => d.Salary, o => o.MapFrom(s => s.Salary.Value))
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department.Name));

            CreateMap<Department, DepartmentToReturnDto>();
        }
    }
}