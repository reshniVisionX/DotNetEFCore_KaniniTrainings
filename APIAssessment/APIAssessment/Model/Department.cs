using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAssessment.Model
{
    public class Department
    {
        [Key]
        public int depId { get; set; }
        [ForeignKey("Employee")]
        public int? managerId { get; set; }
        [Required,MaxLength(50)]
        public string? depName { get; set; }
        [Required,MaxLength(100)]
        public string location { get; set; }

        public ICollection<Employee>? employees { get; set; }

    }
}
