using System.Linq.Expressions;
using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;
using TurniketWebApi.Service.DTOs.RegistrationDTOs;

namespace TurniketWebApi.Service.IServices
{
    public interface IRegistrationService
    {
        ValueTask<RegistrationForViewDTO> CreateAsync(RegistrationForCreationDTO registrationForCreationDTO);

        ValueTask<RegistrationForViewDTO> UpdateAsync(int id, RegistrationForCreationDTO registrationForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<RegistrationForViewDTO> GetAsync(Expression<Func<Registration, bool>> expression);

        ValueTask<IEnumerable<RegistrationForViewDTO>> GetAllAsync(
            Expression<Func<Registration, bool>> expression = null);
    }
}
