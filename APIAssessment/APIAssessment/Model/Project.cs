using System.ComponentModel.DataAnnotations;

namespace APIAssessment.Model
{
    public class Project
    {
        [Key]
        public int proId { get; set; }
        [Required,MaxLength(50)]
        public string title { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }   

        public ICollection<Employee>? employees { get; set; }
    }
}
