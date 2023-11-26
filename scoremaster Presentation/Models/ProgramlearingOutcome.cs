using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class ProgramlearingOutcome
    {
        [Key]
        public int ProgramlearingOutcomesId { get; set; }
        public string Name { get; set; }
        public int? RubricCreateId { get; set; }
        public virtual RubricCreate RubricCreate { get; set; }
        public IList<EvaluationCriteria> EvaluationCriterias{ get; set; }
    }
}
