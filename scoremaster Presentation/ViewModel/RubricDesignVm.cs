

using scoremaster_Presentation.Models;

namespace scoremaster_Presentation.ViewModel
{
    public class RubricDesignVm
    {
        public string PlO { get; set; }
        public string PloDescription { get; set; }
        public int PloMarks { get; set; }
        public string PLOType { get; set; }
        public string poor { get; set; }
        public string BelowAverage { get; set; }
        public string AboveAverage { get; set; }
        public string Excellent { get; set; }
        public int EvaluationLevelId { get; set; }

        public Group Group { get; set; }
        public List<MemberData> Members { get; set; }
        public List<Marks> Marks { get; set; }
    }
}
