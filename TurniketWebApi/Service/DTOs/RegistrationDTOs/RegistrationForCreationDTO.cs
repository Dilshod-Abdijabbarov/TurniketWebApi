using TurniketWebApi.Models;

namespace TurniketWebApi.Service.DTOs.RegistrationDTOs
{
    public class RegistrationForCreationDTO
    {
        public DateTime AccessTime { get; set; }= DateTime.Now;
        public DateTime ExitTime { get; set; }= DateTime.Now;
        public ulong EmployeeJSHSHIR { get; set; }
    }
}
