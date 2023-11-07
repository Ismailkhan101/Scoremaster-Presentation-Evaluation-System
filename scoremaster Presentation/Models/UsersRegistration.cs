using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace scoremaster_Presentation.Models
{
    public class UsersRegistration
    {
        [Key]
        public int UsersRegistrationId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }
        public string Contact { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? ROleId { get; set; }
        public virtual Roles Role { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<Marks> Marks { get; set; }
        
    }
}
