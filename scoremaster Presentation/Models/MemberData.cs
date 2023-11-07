using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class MemberData
    {
        [Key]
        public int MemberDataId { get; set; }
        public string MemberName { get; set; }
        public string MemberCMSID { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public int GroupId { get; set; }
        public virtual Group Groups { get; set; }
        public IList<Marks> Marks { get; set; }
        /*  public int? EventId { get; set; }
          public virtual Event Events { get; set; }*/
    }
}
