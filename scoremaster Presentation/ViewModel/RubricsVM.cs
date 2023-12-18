using scoremaster_Presentation.Migrations;
using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.ViewModel
{
    public class RubricsVM
    {
        
        public ProgramlearingOutcome ProgramlearingOutcomes { get; set; }
        public List<EvaluationCriteria> EvaluationCriteria { get; set; }
        public List<EvaluationLevels> EvaluationLevels { get; set; }
    }
}
