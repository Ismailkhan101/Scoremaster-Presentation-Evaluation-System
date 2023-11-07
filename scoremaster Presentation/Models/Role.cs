using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Roles
    {
        [Key]
        public int ROleId { get; set; }
        public string RoleName { get; set; }
        public bool Isdeleted { get; set; }
        public bool IsActive { get; set; }
        public IList<UsersRegistration> UsersRegistrations { get; set; }
        public IList<ExternalUserscs> ExternalUserscs { get; set; }
        public IList<UserPermision> UserPermisions { get; set; }



    }
}
