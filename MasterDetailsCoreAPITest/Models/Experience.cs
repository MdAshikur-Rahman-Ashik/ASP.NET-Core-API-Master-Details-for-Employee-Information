namespace MasterDetailsCoreAPITest.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public virtual Employee Employee { get; set; } = null!;
    }
}
