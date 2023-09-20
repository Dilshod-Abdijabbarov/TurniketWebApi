using System.ComponentModel.DataAnnotations;

namespace TurniketWebApi.Models
{
    public class Employee
    {
        [Key] 
        public ulong JSHSHIR { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
