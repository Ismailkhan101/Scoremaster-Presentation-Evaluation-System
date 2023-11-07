using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class UserPermision
    {
        [Key]
        public int UserPermisionId { get; set; }
        public int? PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public int? RoleId { get; set; }
        public virtual Roles Role{ get; set; }
       
        public bool Isdeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
