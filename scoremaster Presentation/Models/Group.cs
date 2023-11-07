using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Group
    {
             [Key]
            public int GroupId { get; set; }
            public string Title { get; set; }
            public string Supervisor { get; set; }
            public string CoSupervisor { get; set; }
          /*  public string Name { get; set; }
            public int CMSID { get; set; }*/
            public bool IsDelete { get; set; }
            public bool IsActive { get; set; }
            public int UsersRegistrationId { get; set; }
            public virtual UsersRegistration UsersRegistration{ get; set; }
            public int? EventId { get; set; }
            public virtual Event Events { get; set; }
            public IList<MemberData> MemberDatas { get; set; }
    }
}
