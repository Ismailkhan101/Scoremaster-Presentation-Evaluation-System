using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class RubricCreate
    {
        [Key]
        public int RubricCreateId { get; set; }
        public string RubricName { get; set; }
        public DateTime Date { get; set; }
        public bool Isactive { get; set; }
        public bool IsDeleted { get; set; }
        public IList<ProgramlearingOutcome>programlearingOutcomes{ get; set; }
        public IList<Event> Events{ get; set; }
    }
}
