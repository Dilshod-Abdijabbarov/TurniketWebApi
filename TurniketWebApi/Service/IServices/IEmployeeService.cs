using System.Linq.Expressions;
using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;

namespace TurniketWebApi.Service.IServices
{
    public interface IEmployeeService
    {
        ValueTask<EmployeeForViewDTO> CreateAsync(EmployeeForCreationDTO employeeForCreationDTO);

        ValueTask<EmployeeForViewDTO> UpdateAsync(ulong JSHSHIR, EmployeeForCreationDTO employeeForCreationDTO);

        ValueTask<bool> DeleteAsync(ulong JSHSHIR);

        ValueTask<EmployeeForViewDTO> GetAsync(Expression<Func<Employee, bool>> expression);

        ValueTask<IEnumerable<EmployeeForViewDTO>> GetAllAsync(
            Expression<Func<Employee, bool>> expression = null);
    }
}
