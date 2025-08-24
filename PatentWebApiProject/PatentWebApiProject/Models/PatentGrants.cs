using System.ComponentModel.DataAnnotations;

namespace PatentWebApiProject.Models
{
    public class PatentGrants
    {
        [Key]
        public int grantId { get; set; } 
        public int? patentId { get; set; } 
        public string? domain { get; set; } = "Biomedical";
        public int? score { get; set; } = 5;
        public DateTime grantDate { get; set; } = DateTime.Now;
        public Patent? patent { get; set; }

    }
}
