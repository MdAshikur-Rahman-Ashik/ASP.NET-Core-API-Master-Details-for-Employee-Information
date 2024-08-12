namespace MasterDetailsCoreAPITest.Models.DTOs
{
    public class CommonDTO
    {
        public string EmployeeName { get; set; } 
        public bool IsActive { get; set; }
        public DateTime JoinDate { get; set; }
        public IFormFile ImgFile { get; set; }
        public string ImageName { get; set; }
        public string Experiences { get; set; }
    }
}
