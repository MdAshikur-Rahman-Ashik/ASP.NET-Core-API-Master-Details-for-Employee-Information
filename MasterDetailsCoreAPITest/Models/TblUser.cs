namespace MasterDetailsCoreAPITest.Models
{
    public class TblUser
    {
        public int TblUserId { get; set; }

        public string? FullName { get; set; }

        public string EmailId { get; set; } = null!;

        public string? Password { get; set; }

       // public DateTime? CreatedDate { get; set; }
    }
}
