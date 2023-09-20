using TurniketWebApi.Models;

namespace TurniketWebApi.Service.DTOs.RegistrationDTOs
{
    public class RegistrationForViewDTO
    {
        public int Id { get; set; }
        public DateTime AccessTime { get; set; }
        public DateTime ExitTime { get; set; }
        public ulong EmployeeJSHSHIR { get; set; }
    }
}
