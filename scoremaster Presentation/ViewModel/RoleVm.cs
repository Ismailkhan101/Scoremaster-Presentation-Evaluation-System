using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.ViewModel
{
    public class RolesVM
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
        public List<Permission> AddUpdatePermissions { get; set; }
       public List<RolesList> roles { get; set; }
    }
}
