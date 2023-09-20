using TurniketWebApi.Models;
using TurniketWebApi.Service.DTOs.RegistrationDTOs;

namespace TurniketWebApi.Service.DTOs.EmployeeDTOs
{
    public class EmployeeForViewDTO
    {
        public ulong JSHSHIR { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<RegistrationForViewDTO> Registrations { get; set; }
    }
}
