using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        public string PesmissionName { get; set; }
        public string PesmissionDbName { get; set; }
        public bool Isdeleted { get; set; }
        public bool IsActive { get; set; }
        public IList<UserPermision> UserPermisions{ get; set; }
    }
}
