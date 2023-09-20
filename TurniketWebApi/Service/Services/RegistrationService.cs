using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;
using TurniketWebApi.Data.IRepositories;
using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.EmployeeDTOs;
using TurniketWebApi.Service.DTOs.RegistrationDTOs;
using TurniketWebApi.Service.Exceptions;
using TurniketWebApi.Service.IServices;

namespace TurniketWebApi.Service.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepositoryAsync registrationRepository;
        private readonly IMapper mapper;
        public RegistrationService(IRegistrationRepositoryAsync registrationRepository,IMapper mapper)
        {
            this.registrationRepository = registrationRepository;
            this.mapper = mapper;
        }
        public async ValueTask<RegistrationForViewDTO> CreateAsync(RegistrationForCreationDTO registrationForCreationDTO)
        {
            var registration = await registrationRepository.CreateAsync(mapper.Map<Registration>(registrationForCreationDTO));
            await registrationRepository.SaveChangesAsync();

            return mapper.Map<RegistrationForViewDTO>(registration);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete=await registrationRepository.DeleteAsync(x=>x.Id==id);

            if (!isDelete)
                  throw new TurniketExceptions(400, "Registration Not delete");

            await registrationRepository.SaveChangesAsync();

            return isDelete;
        }
        
        public async ValueTask<IEnumerable<RegistrationForViewDTO>> GetAllAsync(Expression<Func<Registration, bool>> expression = null)
        {
           var registration= await registrationRepository.GetAllAsync(expression).ToListAsync();

            if (registration == null)
                throw new TurniketExceptions(400, "Registration Not found");

            return mapper.Map<IEnumerable<RegistrationForViewDTO>>(registration);
        }

        public async ValueTask<RegistrationForViewDTO> GetAsync(Expression<Func<Registration, bool>> expression)
        {
            var registration = await registrationRepository.GetAsync(expression);

            if (registration == null)
                throw new TurniketExceptions(400, "Registration Not found");

            return mapper.Map<RegistrationForViewDTO>(registration);
        }

        public async ValueTask<RegistrationForViewDTO> UpdateAsync(int id, RegistrationForCreationDTO registrationForCreationDTO)
        {
            var registration=await registrationRepository.GetAsync(x=>x.Id==id);

            if (registration == null)
                throw new TurniketExceptions(400, "Registration Not found");

            registration=registrationRepository.Update(mapper.Map<Registration>(registrationForCreationDTO));
            await registrationRepository.SaveChangesAsync();

            return mapper.Map<RegistrationForViewDTO>(registration);
        }
    }
}
