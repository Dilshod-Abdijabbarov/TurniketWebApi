using AutoMapper;
using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;
using TurniketWebApi.Service.DTOs.RegistrationDTOs;

namespace TurniketWebApi.Service.Configuration
{
    public class MappingProFiles : Profile
    {
        public MappingProFiles()
        {
            CreateMap<Employee,EmployeeForCreationDTO>().ReverseMap();
            CreateMap<Employee,EmployeeForViewDTO>().ReverseMap();

            CreateMap<Registration,RegistrationForCreationDTO>().ReverseMap();
            CreateMap<Registration,RegistrationForViewDTO>().ReverseMap();
        }
    }
}
