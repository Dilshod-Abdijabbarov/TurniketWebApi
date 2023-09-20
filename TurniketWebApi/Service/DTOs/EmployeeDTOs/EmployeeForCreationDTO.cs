using System.ComponentModel.DataAnnotations;

namespace TurniketWebApi.Service.DTOs.EmployeeDTOs
{
    public class EmployeeForCreationDTO
    {
        [Required]
        
        public ulong JSHSHIR { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
