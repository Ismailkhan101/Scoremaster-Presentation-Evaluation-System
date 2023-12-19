using System.ComponentModel.DataAnnotations;

namespace scoremaster_Presentation.Models
{
    public class EvaluationLevels
    {
        [Key]
        public int EvaluationLevelId { get; set; }
        public string Poor { get; set; }
        public string BelowAverae { get; set; }
        public string AboveAverae { get; set; }
        public string Excellent { get; set; }
        public bool Isactive { get; set; }
        public bool IsDeleted { get; set; }
        public int? EvaluationCriteriaId { get; set; }
        public virtual EvaluationCriteria EvaluationCriterias{ get; set; }
        public IList<Marks> Marks { get; set; }

    }
}
