using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class EvaluationCriteria
    {
        [Key]
        public int EvaluationCriteriaId { get; set; }
        public string Name { get; set; }
        public decimal TotalMarks { get; set; }
        public string Type { get; set; }
        public int? ProgramlearingOutcomesId { get; set; }
        public virtual ProgramlearingOutcome ProgramlearingOutcomes { get; set; }
        public IList<EvaluationLevels> EvaluationLevels { get; set; }
    }
}
