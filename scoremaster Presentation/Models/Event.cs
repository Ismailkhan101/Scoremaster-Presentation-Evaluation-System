using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Year { get; set; } = string.Empty;
        [Required]
        public string Organizer { get; set; }
        [Required]
        public string GroupIndividual { get; set; }
        [Required]
        public int NoOfGroups { get; set; }
        public DateTime EventDate { get; set; }
         [Required]
        public int NoOfExaminers { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? RubricCreateId { get; set; }
        public virtual RubricCreate RubricCreate { get; set; }
        public IList<Group> Groups { get; set; }
        public IList<ExternalUserscs>ExternalUsers { get; set; }

    }
}
