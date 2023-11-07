using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Marks
    {
        [Key]
        public int MarksId { get; set; }
        public string TotalMarks { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public int? UsersRegistrationId { get; set; }
        public virtual UsersRegistration UsersRegistration { get; set; }
        public int? ExternalUserscsId { get; set; }
        public virtual ExternalUserscs ExternalUserscs { get; set; }
        public int? MemberDataId { get; set; }
        public virtual MemberData MemberData { get; set; }
    }
}
