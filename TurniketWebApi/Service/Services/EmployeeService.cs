using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TurniketWebApi.Data.IRepositories;
using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;
using TurniketWebApi.Service.Exceptions;
using TurniketWebApi.Service.IServices;

namespace TurniketWebApi.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositoryAsync employeeRepository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepositoryAsync employeeRepository,IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public async ValueTask<EmployeeForViewDTO> CreateAsync(EmployeeForCreationDTO employeeForCreationDTO)
        {
           var user=await employeeRepository.GetAsync(x=>x.JSHSHIR==employeeForCreationDTO.JSHSHIR);

            if(user!=null)
            {
                throw new TurniketExceptions(400, "This Employee already exists");               
            }

            var employee = await employeeRepository.CreateAsync(mapper.Map<Employee>(employeeForCreationDTO));
            await employeeRepository.SaveChangesAsync();

            return mapper.Map<EmployeeForViewDTO>(employee);
        }

        public async ValueTask<bool> DeleteAsync(ulong JSHSHIR)
        {
           var isDelete= await employeeRepository.DeleteAsync(x=>x.JSHSHIR== JSHSHIR);

            if (!isDelete)
                throw new TurniketExceptions(400, "Employee not delete");

            await employeeRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<EmployeeForViewDTO>> GetAllAsync(Expression<Func<Employee, bool>> expression = null)
        {
           var employees = await employeeRepository.GetAllAsync(expression: expression, includes:new string[]{"Registrations"}, isTracking: false).ToListAsync();

            if (employees == null)
                throw new TurniketExceptions(400, "Not Found");

            return mapper.Map<IEnumerable<EmployeeForViewDTO>>(employees);
        }

        public async ValueTask<EmployeeForViewDTO> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var employee=await employeeRepository.GetAsync(expression, include: new string[] { "Registrations" });

            if (employee == null)
                throw new TurniketExceptions(400, "Not Found");

            return mapper.Map<EmployeeForViewDTO>(employee);
        }
        
        public async ValueTask<EmployeeForViewDTO> UpdateAsync(ulong JSHSHIR, EmployeeForCreationDTO employeeForCreationDTO)
        {
            var employee=await employeeRepository.GetAsync(x=>x.JSHSHIR==JSHSHIR);

            if (employee == null)
                throw new TurniketExceptions(400, "Employee not found");

            employee = employeeRepository.Update(mapper.Map<Employee>(employeeForCreationDTO));
            await employeeRepository.SaveChangesAsync();

            return mapper.Map<EmployeeForViewDTO>(employee);
        }
    }
}
