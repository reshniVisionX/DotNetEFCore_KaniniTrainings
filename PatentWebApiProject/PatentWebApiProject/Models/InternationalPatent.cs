using System.ComponentModel.DataAnnotations;

namespace PatentWebApiProject.Models
{
    public class InternationalPatent
    {
        [Key]
        public int ipId { get; set; }
        public string? country { get; set; } = "USA";
        public int patentId { get; set; }
        public string? status { get; set; } = "Pending";
        public DateTime? fieledDate { get; set; } = DateTime.Now;

        public Patent patent { get; set; } = default!;

    }
}
