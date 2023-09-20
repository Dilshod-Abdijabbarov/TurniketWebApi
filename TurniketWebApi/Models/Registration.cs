using System.ComponentModel.DataAnnotations;

namespace TurniketWebApi.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public DateTime AccessTime { get; set; }
        public DateTime ExitTime { get; set; }
        public ulong EmployeeJSHSHIR { get; set; }
        public Employee Employee { get; set; }
    }
}
