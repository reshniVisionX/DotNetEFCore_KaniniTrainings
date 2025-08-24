using System.ComponentModel.DataAnnotations;

namespace PatentWebApiProject.Models
{
    public class Patent
    {
        [Key]
        public int patentId { get; set; }
        public string? title { get; set; } = default!;
        public string? description { get; set; } = default!;
        public DateTime appliedDate { get; set; } =DateTime.Now;
        public string? status { get; set; } = "Pending";
        public ICollection<Members>? members { get; set; } = new List<Members>();

        public ICollection<PatentGrants>? patentGrants { get; set; } = new List<PatentGrants>();

    }
}
