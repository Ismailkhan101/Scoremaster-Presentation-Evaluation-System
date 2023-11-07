using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]

        public string DeptName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public IList<UsersRegistration> UsersRegistrations { get; set; }
        public IList<Event> Events { get; set; }
        public IList<ExternalUserscs> ExternalUsers { get; set; } 

    }
}
