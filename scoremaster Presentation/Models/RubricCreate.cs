namespace scoremaster_Presentation.Models
{
    public class RubricCreate
    {
        public int RubricCreateId { get; set; }
        public string RubricName { get; set; }
        public DateTime Date { get; set; }
        public bool Isactive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
