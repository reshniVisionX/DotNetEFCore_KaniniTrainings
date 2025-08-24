using PatentWebApiProject.Models;

namespace PatentWebApiProject.DTO
{
    public class PatentDetailsDTO
    {
     

        public string title { get; set; } = default!;
        public string description { get; set; } = default!;
        public DateTime appliedDate { get; set; } = DateTime.Now;
        public string? status { get; set; } = "Pending";
        public List<InternationalPatent>? internationalPatent;
        public ICollection<Members>? members { get; set; } = new List<Members>();

    }
}
