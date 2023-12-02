using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class ExternalUserscs
    {
        [Key]
        public int ExternalUserscsId { get; set; }
        [Required]
        public string Name { get; set; }
        public string?  Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string  Password { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? EventId { get; set; }
       
        public virtual Event Event { get; set; }
        public IList<Marks> Marks { get; set; }
        public int? ROleId { get; set; }
        public virtual Roles Role { get; set; }
        public int? RubricCreateId { get; set; }
        public virtual RubricCreate RubricCreate { get; set; }


    }
}
